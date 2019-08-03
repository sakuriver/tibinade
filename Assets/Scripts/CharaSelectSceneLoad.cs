using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CharaSelectSceneLoad : MonoBehaviour
{

    public SePlayer sePlayer;


    public void OnClick()
    {
        sePlayer.onClickSe();
        DataBank bank = DataBank.Open();
        bank.Load<UserGameSaveData>("userGamePlay");

        UserGameSaveData playerData = new UserGameSaveData();
        playerData = bank.Get<UserGameSaveData>("userGamePlay");
        if (playerData != null)
        {
            UserPlayData.Instance.userGamePlayData.pleaseCharacterId =  playerData.pleaseCharacterId;
            UserPlayData.Instance.userGamePlayData.pleaseCommandFlg = playerData.pleaseCommandFlg;
            UserPlayData.Instance.userGamePlayData.pleaseItemId = playerData.pleaseItemId;
            if (playerData.pleaseCompleteYear > 2000) {
                playerData.pleaseCompleteTime = new System.DateTime(playerData.pleaseCompleteYear, playerData.pleaseCompleteMonth, playerData.pleaseCompleteDay, playerData.pleaseCompleteHour, playerData.pleaseCompleteMinute, playerData.pleaseCompleteSecond, playerData.pleaseCompleteMilliSecond);
            }
            UserPlayData.Instance.userGamePlayData.pleaseCompleteTime = playerData.pleaseCompleteTime;
            UserPlayData.Instance.userGamePlayData.userCharacterData = new System.Collections.Generic.Dictionary<int, UserCharacterData>();
            foreach (UserCharacterSaveData characterSaveData in playerData.userCharacterDatas) {
                var characterId = characterSaveData.characterId;
                if (!UserPlayData.Instance.userGamePlayData.userCharacterData.ContainsKey(characterId)) {
                    UserPlayData.Instance.userGamePlayData.userCharacterData.Add(characterId, new UserCharacterData());
                    UserPlayData.Instance.userGamePlayData.userCharacterData[characterId].itemCountTable = new System.Collections.Generic.Dictionary<int, int>();
                }
                var itemId = characterSaveData.itemId;
                var itemCount = characterSaveData.itemCount;
                UserPlayData.Instance.userGamePlayData.userCharacterData[characterId].itemCountTable.Add(itemId, itemCount);

            }
        }
        StartCoroutine("CharaSelectStart");
    }

    IEnumerator CharaSelectStart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("charaselect");
    }
}
