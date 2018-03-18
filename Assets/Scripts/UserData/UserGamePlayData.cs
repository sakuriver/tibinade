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
    public Dictionary<int, UserCharacterData> userCharacterData;
}

public class UserCharacterData {

    public Dictionary<int, int> itemCountTable;
}

