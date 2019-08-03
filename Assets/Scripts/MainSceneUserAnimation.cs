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
    public Text pleaseBoardText;
    public Image pleaseBoardItemIcon;
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
            pleaseItemIcon.sprite = Resources.Load<Sprite>("OnegaiIcon/" + PleaseItem.ItemNameList[userPlayData.userGamePlayData.pleaseCharacterId][userPlayData.userGamePlayData.pleaseItemId].IconName);
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
                DataBank bank = DataBank.Open();
                
                UserGameSaveData saveData = new UserGameSaveData();
                saveData.pleaseCharacterId = UserPlayData.Instance.userGamePlayData.pleaseCharacterId;
                saveData.pleaseCommandFlg = UserPlayData.Instance.userGamePlayData.pleaseCommandFlg;
                saveData.pleaseCompleteTime = UserPlayData.Instance.userGamePlayData.pleaseCompleteTime;
                saveData.pleaseItemId = UserPlayData.Instance.userGamePlayData.pleaseItemId;
                saveData.pleaseCompleteYear = UserPlayData.Instance.userGamePlayData.pleaseCompleteTime.Year;
                saveData.pleaseCompleteMonth = UserPlayData.Instance.userGamePlayData.pleaseCompleteTime.Month;
                saveData.pleaseCompleteDay = UserPlayData.Instance.userGamePlayData.pleaseCompleteTime.Day;
                saveData.pleaseCompleteHour = UserPlayData.Instance.userGamePlayData.pleaseCompleteTime.Hour;
                saveData.pleaseCompleteMinute = UserPlayData.Instance.userGamePlayData.pleaseCompleteTime.Minute;
                saveData.pleaseCompleteSecond = UserPlayData.Instance.userGamePlayData.pleaseCompleteTime.Second;
                saveData.pleaseCompleteMilliSecond = UserPlayData.Instance.userGamePlayData.pleaseCompleteTime.Second;
                saveData.userCharacterDatas = new List<UserCharacterSaveData>();
                foreach (KeyValuePair<int, UserCharacterData> userSaveData in UserPlayData.Instance.userGamePlayData.userCharacterData) {
                    foreach (KeyValuePair<int, int> itemCountTable in userSaveData.Value.itemCountTable)
                    {
                        var userCharacterSaveData = new UserCharacterSaveData();
                        userCharacterSaveData.characterId = userSaveData.Key;
                        userCharacterSaveData.itemId = itemCountTable.Key;
                        userCharacterSaveData.itemCount = itemCountTable.Value;
                        saveData.userCharacterDatas.Add(userCharacterSaveData);
                    }
                }
                bank.Store("userGamePlay", saveData);
                bank.SaveAll();
                pleaseBoardItemIcon.sprite = pleaseItemIcon.sprite;
                pleaseBoardCompleteRoot.SetActive(true);
            }
            pleaseBoardRoot.SetActive(pleaseTimeTextEnabled);
        }
    }

    public void OnPleaseBoardCompleteCloseClick() {
        pleaseBoardCompleteRoot.SetActive(false);
    }

}