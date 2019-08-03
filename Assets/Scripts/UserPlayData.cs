using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserPlayData
{
	public static UserPlayData Instance = new UserPlayData();
	public int selectCharacterId = 0;
    public int selectItemId = 1;
    public string pleasePrevCharacterTextNumber = "";
    public UserGamePlayData userGamePlayData = new UserGamePlayData();



    public static void UpdateSaveData() {
        DataBank bank = DataBank.Open();
        UserGameSaveData saveData = new UserGameSaveData();
        saveData.pleaseCharacterId = UserPlayData.Instance.userGamePlayData.pleaseCharacterId;
        saveData.pleaseCommandFlg = UserPlayData.Instance.userGamePlayData.pleaseCommandFlg;
        saveData.pleaseCompleteTime = UserPlayData.Instance.userGamePlayData.pleaseCompleteTime;
        saveData.pleaseCompleteYear = UserPlayData.Instance.userGamePlayData.pleaseCompleteTime.Year;
        saveData.pleaseCompleteMonth = UserPlayData.Instance.userGamePlayData.pleaseCompleteTime.Month;
        saveData.pleaseCompleteDay = UserPlayData.Instance.userGamePlayData.pleaseCompleteTime.Day;
        saveData.pleaseCompleteHour = UserPlayData.Instance.userGamePlayData.pleaseCompleteTime.Hour;
        saveData.pleaseCompleteMinute = UserPlayData.Instance.userGamePlayData.pleaseCompleteTime.Minute;
        saveData.pleaseCompleteSecond = UserPlayData.Instance.userGamePlayData.pleaseCompleteTime.Second;
        saveData.pleaseCompleteMilliSecond = UserPlayData.Instance.userGamePlayData.pleaseCompleteTime.Second;
        saveData.pleaseItemId = UserPlayData.Instance.userGamePlayData.pleaseItemId;
        saveData.userCharacterDatas = new List<UserCharacterSaveData>();
        foreach (KeyValuePair<int, UserCharacterData> userSaveData in UserPlayData.Instance.userGamePlayData.userCharacterData)
        {
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


    }

}