using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PleaseBoadEvent : MonoBehaviour
{
    public UserGamePlayData userGamePlayData;

    private GameObject pleaseWindow;

	void Start() {
		pleaseWindow = GameObject.Find("PleaseWindow");
        var characterId = UserPlayData.Instance.selectCharacterId;

        var itemCount = PleaseItem.ItemNameList[characterId].Count;
        var setPostionCount = 1;
        for (int i = 1; i <= 4; i++) {

           GameObject itemObjectRoot = GameObject.Find("ItemObj" + i).gameObject;
           if (i <= itemCount) {
               itemObjectRoot.SetActive(true);
           } else {
               itemObjectRoot.SetActive(false);
               continue;
           }
           Image img = itemObjectRoot.transform.FindChild("Icon").GetComponent<Image>();
           img.sprite = Resources.Load<Sprite>("OnegaiIcon/" + PleaseItem.ItemNameList[characterId][i]);
           var localPosition = itemObjectRoot.transform.localPosition;
           itemObjectRoot.transform.localPosition = new Vector3(localPosition.x, 390 + (setPostionCount * -170), localPosition.z);
           Debug.Log(65 + (setPostionCount * -170));           

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
        img.sprite = Resources.Load<Sprite>("OnegaiIcon/" + PleaseItem.ItemNameList[UserPlayData.Instance.selectCharacterId][itemId]);
        userGamePlayData.pleaseCharacterId = UserPlayData.Instance.selectCharacterId;
        userGamePlayData.pleaseItemId = itemId;
        if (userGamePlayData.userCharacterData == null) {
            userGamePlayData.userCharacterData = new Dictionary<int, UserCharacterData>();
        }
        if (!userGamePlayData.userCharacterData.ContainsKey(userGamePlayData.pleaseCharacterId)) {
            userGamePlayData.userCharacterData.Add(userGamePlayData.pleaseCharacterId, new UserCharacterData());
            userGamePlayData.userCharacterData[userGamePlayData.pleaseCharacterId].itemCountTable = new Dictionary<int, int>();
        }
        pleaseWindow.SetActive(true);
	}


	public void NoButtonClick() {
        userGamePlayData.pleaseCommandFlg = false;
		pleaseWindow.SetActive (false);
	}

	public void YesButtonClick() {
        userGamePlayData.pleaseCommandFlg = true;
        userGamePlayData.pleaseCompleteTime = System.DateTime.Now;
        userGamePlayData.pleaseCompleteTime = userGamePlayData.pleaseCompleteTime.Add(new System.TimeSpan(0, 0, 20));
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