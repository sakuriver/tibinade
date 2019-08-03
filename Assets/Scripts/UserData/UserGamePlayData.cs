using UnityEngine;
using System.Collections;
using System.Timers;
using System.Collections.Generic;
using System;

[CreateAssetMenu]
public class UserGamePlayData : ScriptableObject {

    public int pleaseCharacterId;
    public int pleaseItemId;
    public bool pleaseCommandFlg;
    public DateTime pleaseCompleteTime;
    public int pleaseCompleteYear;
    public int pleaseCompleteMonth;
    public int pleaseCompleteDay;
    public int pleaseCompleteHour;
    public int pleaseCompleteMinute;
    public int pleaseCompleteSecond;
    public int pleaseCompleteMilliSecond;
    public Dictionary<int, UserCharacterData> userCharacterData;
}

[Serializable]
public class UserGameSaveData {

    public int pleaseCharacterId;
    public int pleaseItemId;
    public bool pleaseCommandFlg;
    public DateTime pleaseCompleteTime;
    public int pleaseCompleteYear;
    public int pleaseCompleteMonth;
    public int pleaseCompleteDay;
    public int pleaseCompleteHour;
    public int pleaseCompleteMinute;
    public int pleaseCompleteSecond;
    public int pleaseCompleteMilliSecond;
    public List<UserCharacterSaveData> userCharacterDatas;
   
}

[Serializable]
public class UserCharacterSaveData {
    public int characterId;
    public int itemId;
    public int itemCount;
}

[Serializable]
public class UserCharacterData {

    public Dictionary<int, int> itemCountTable;
}

