using UnityEngine;
using System.Collections;

public class UserPlayData
{
	public static UserPlayData Instance = new UserPlayData();
	public int selectCharacterId = 0;
    public int selectItemId = 0;
    public string pleasePrevCharacterTextNumber = "";
    public UserGamePlayData userGamePlayData = new UserGamePlayData();

}