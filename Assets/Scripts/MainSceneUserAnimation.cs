using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainSceneUserAnimation : MonoBehaviour
{

    public GameObject pleaseBoardRoot;
    public GameObject pleaseBoardCompleteRoot;
    public Text pleaseTimeText;
    public Image pleaseItemIcon;
    public UserGamePlayData userGamePlayData;

    public void Start(){
        var pleaseBoardFlg = userGamePlayData != null && userGamePlayData.pleaseCommandFlg;
        pleaseBoardRoot.SetActive(pleaseBoardFlg);
        if (userGamePlayData.pleaseCommandFlg) {
            PleaseBoadEvent pEvent = new PleaseBoadEvent();
            pleaseItemIcon.sprite = Resources.Load<Sprite>("OnegaiIcon/" + pEvent.itemNameList[userGamePlayData.pleaseCharacterId][userGamePlayData.pleaseItemId]);
            pleaseItemIcon.SetNativeSize();
            pleaseTimeText.enabled = true;
        }
    }

    public void PointerDown()
    {
        this.GetComponent<DotMoveAnimation>().CharaMove();
    }

    public void TalkPointerDown()
    {
        this.GetComponent<DotMoveAnimation>().talkPanelObj.SetActive(false);
    }

    public void Update()
    {
        if (userGamePlayData != null && userGamePlayData.pleaseCommandFlg) {

            // 時間を経過しているのでデータをゲットする
            var pleaseTimeTextEnabled = userGamePlayData.pleaseCompleteTime.CompareTo(System.DateTime.Now) != -1;
            if (pleaseTimeTextEnabled){
                var now = userGamePlayData.pleaseCompleteTime.Subtract(System.DateTime.Now);
                if (now != null) {
                    pleaseTimeText.text = now.Hours.ToString() + ":" + now.Minutes.ToString() + ":" + now.Seconds.ToString();
                }
            } else if (userGamePlayData != null) {
                // 初めてお願いしたキャラクターの場合
                var pleaseCharacterId = userGamePlayData.pleaseCharacterId;
                var pleaseItemId = userGamePlayData.pleaseItemId;
                if (!userGamePlayData.userCharacterData.ContainsKey(pleaseCharacterId)) {
                    var charaData = new UserCharacterData();
                    charaData.itemCountTable = new Dictionary<int, int>();
                    userGamePlayData.userCharacterData.Add(pleaseCharacterId, charaData);
                }

                if (!userGamePlayData.userCharacterData[pleaseCharacterId].itemCountTable.ContainsKey(pleaseItemId)) {
                    userGamePlayData.userCharacterData[pleaseCharacterId].itemCountTable.Add(pleaseItemId, 1);
                } else {
                    userGamePlayData.userCharacterData[pleaseCharacterId].itemCountTable[pleaseItemId] += 1;
                }
                Debug.Log("count:" + userGamePlayData.userCharacterData[pleaseCharacterId].itemCountTable[pleaseItemId]);
                userGamePlayData.pleaseCommandFlg = false;
                pleaseBoardCompleteRoot.SetActive(true);
            }
            pleaseBoardRoot.SetActive(pleaseTimeTextEnabled);
        }
    }

    public void OnPleaseBoardCompleteCloseClick() {
        pleaseBoardCompleteRoot.SetActive(false);
    }

}