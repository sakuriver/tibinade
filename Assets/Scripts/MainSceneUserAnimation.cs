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

    public void Start(){
        var userPlayData = UserPlayData.Instance;
        var pleaseBoardFlg = userPlayData.userGamePlayData != null && userPlayData.userGamePlayData.pleaseCommandFlg;
        if (pleaseBoardRoot != null) {
            pleaseBoardRoot.SetActive(pleaseBoardFlg);
        }
        if (userPlayData.userGamePlayData == null) {
            return;
        }
        if (userPlayData.userGamePlayData.pleaseCommandFlg) {
            pleaseItemIcon.sprite = Resources.Load<Sprite>("OnegaiIcon/" + PleaseItem.ItemNameList[userPlayData.userGamePlayData.pleaseCharacterId][userPlayData.userGamePlayData.pleaseItemId]);
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
        var userPlayData = UserPlayData.Instance;

        if (userPlayData.userGamePlayData != null && userPlayData.userGamePlayData.pleaseCommandFlg) {

            // 時間を経過しているのでデータをゲットする
            var pleaseTimeTextEnabled = userPlayData.userGamePlayData.pleaseCompleteTime.CompareTo(System.DateTime.Now) != -1;
            if (pleaseTimeTextEnabled){
                var now = userPlayData.userGamePlayData.pleaseCompleteTime.Subtract(System.DateTime.Now);
                if (now != null) {
                    pleaseTimeText.text = now.Hours.ToString() + ":" + now.Minutes.ToString() + ":" + now.Seconds.ToString();
                }
            } else if (userPlayData.userGamePlayData != null) {
                // 初めてお願いしたキャラクターの場合
                var pleaseCharacterId = userPlayData.userGamePlayData.pleaseCharacterId;
                var pleaseItemId = userPlayData.userGamePlayData.pleaseItemId;
                if (!userPlayData.userGamePlayData.userCharacterData.ContainsKey(pleaseCharacterId)) {
                    var charaData = new UserCharacterData();
                    charaData.itemCountTable = new Dictionary<int, int>();
                    UserPlayData.Instance.userGamePlayData.userCharacterData.Add(pleaseCharacterId, charaData);
                }

                if (!userPlayData.userGamePlayData.userCharacterData[pleaseCharacterId].itemCountTable.ContainsKey(pleaseItemId)) {
                    UserPlayData.Instance.userGamePlayData.userCharacterData[pleaseCharacterId].itemCountTable.Add(pleaseItemId, 1);
                } else {
                    UserPlayData.Instance.userGamePlayData.userCharacterData[pleaseCharacterId].itemCountTable[pleaseItemId] += 1;
                }
                UserPlayData.Instance.userGamePlayData.pleaseCommandFlg = false;
                pleaseBoardCompleteRoot.SetActive(true);
            }
            pleaseBoardRoot.SetActive(pleaseTimeTextEnabled);
        }
    }

    public void OnPleaseBoardCompleteCloseClick() {
        pleaseBoardCompleteRoot.SetActive(false);
    }

}