using UnityEngine;
using System.Collections;
using System.Timers;
using System;

[CreateAssetMenu]
public class UserGamePlayData : ScriptableObject {

    public int pleaseCharacterId;
    public int pleaseItemId;
    public bool pleaseCommandFlg;
    public DateTime pleaseCompleteTime;
}
