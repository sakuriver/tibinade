using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PleaseBoadEvent : MonoBehaviour
{

    private GameObject pleaseWindow;

	void Start() {
		pleaseWindow = GameObject.Find("PleaseWindow");
        var characterId = UserPlayData.Instance.selectCharacterId;

        var itemCount = PleaseItem.ItemNameList[characterId].Count;
        var setPostionCount = 1;
        var userGamePlayData = UserPlayData.Instance.userGamePlayData;
        for (int i = 1; i <= 4; i++) {
           GameObject itemObjectRoot = GameObject.Find("ItemObj" + i).gameObject;
           if (i == 1)
           {
                itemObjectRoot.SetActive(false);

                continue;
           }
           if (i <= itemCount) {
               itemObjectRoot.SetActive(true);
           } else {
               itemObjectRoot.SetActive(false);
               continue;
           }
           Image img = itemObjectRoot.transform.FindChild("Icon").GetComponent<Image>();
           img.sprite = Resources.Load<Sprite>("OnegaiIcon/" + PleaseItem.ItemNameList[characterId][i].IconName);
           var localPosition = itemObjectRoot.transform.localPosition;
           itemObjectRoot.transform.localPosition = new Vector3(localPosition.x, 390 + (setPostionCount * -170), localPosition.z);

           if (userGamePlayData.userCharacterData == null){
                setPostionCount++;
                continue;
           }
           var characterDataCountFlg = userGamePlayData.userCharacterData.ContainsKey(characterId);
           if (!characterDataCountFlg) {
                setPostionCount++;
                continue;
           }
           var itemCountFlg = userGamePlayData.userCharacterData[characterId].itemCountTable.ContainsKey(i);
           if (!itemCountFlg || userGamePlayData.userCharacterData[characterId].itemCountTable[i] < 0) {
                setPostionCount++;
                continue;
           } 
           itemObjectRoot.transform.gameObject.SetActive(false);           

        }
        pleaseWindow.SetActive (false);
    }


    public void OpenWindowButtonClick(int itemId) {
        
        Image img = pleaseWindow.transform.FindChild("SelectItem").GetComponent<Image>();
        img.sprite = Resources.Load<Sprite>("OnegaiIcon/" + PleaseItem.ItemNameList[UserPlayData.Instance.selectCharacterId][itemId].IconName);
        UserPlayData.Instance.userGamePlayData.pleaseCharacterId = UserPlayData.Instance.selectCharacterId;
        UserPlayData.Instance.userGamePlayData.pleaseItemId = itemId;
        if (UserPlayData.Instance.userGamePlayData.userCharacterData == null) {
            UserPlayData.Instance.userGamePlayData.userCharacterData = new Dictionary<int, UserCharacterData>();
        }
        if (!UserPlayData.Instance.userGamePlayData.userCharacterData.ContainsKey(UserPlayData.Instance.userGamePlayData.pleaseCharacterId)) {
            UserPlayData.Instance.userGamePlayData.userCharacterData.Add(UserPlayData.Instance.userGamePlayData.pleaseCharacterId, new UserCharacterData());
            UserPlayData.Instance.userGamePlayData.userCharacterData[UserPlayData.Instance.userGamePlayData.pleaseCharacterId].itemCountTable = new Dictionary<int, int>();
        }
        pleaseWindow.SetActive(true);
	}


	public void NoButtonClick() {
        UserPlayData.Instance.userGamePlayData.pleaseCommandFlg = false;
		pleaseWindow.SetActive (false);
	}

	public void YesButtonClick() {
        UserPlayData.Instance.userGamePlayData.pleaseCommandFlg = true;
        UserPlayData.Instance.userGamePlayData.pleaseCompleteTime = System.DateTime.Now;
        UserPlayData.Instance.userGamePlayData.pleaseCompleteTime = UserPlayData.Instance.userGamePlayData.pleaseCompleteTime.Add(new System.TimeSpan(0, 0, 20));
        pleaseWindow.SetActive (false);
	}

	public void OnClick()
	{
        StartCoroutine("MainStart");
	}

	IEnumerator MainStart()
	{
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("main");
	}


}