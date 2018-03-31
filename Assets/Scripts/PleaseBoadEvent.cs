using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PleaseBoadEvent : MonoBehaviour
{
    public UserGamePlayData userGamePlayData;
    public Dictionary<int, Dictionary<int, string>> itemNameList = new Dictionary<int, Dictionary<int, string>>()
        {
            {1, new Dictionary<int, string> {
                {1, "ONluklukEicon"},
                {2, "ONluklukBicon"},
                {3, "ONluklukCicon"},
                {4, "ONluklukDicon"},
                }
            },
            { 2, new Dictionary<int, string> {
                {1, "ONdieuleiconA"},
                {2, "ONdieuleiconB"},
                {3, "ONdieuleiconC"},
                }
            },
            { 3, new Dictionary<int, string> {
                {1, "OngelpiciconB"},
                {2, "OngelpiciconC"},
                {3, "OngelpiciconD"},
                {4, "OngelpiciconE"},
            }
            },
            { 4, new Dictionary<int, string> {
                {1, "ONsroniconA"},
                {2, "ONsroniconB"},
                {3, "ONsroniconC"},
                {4, "ONsroniconD"},
                {5, "ONsroniconE"},
            } },
            { 5, new Dictionary<int, string> {
                {1, "ONpameliconA"},
                {2, "ONpameliconB"},
                {3, "ONpameliconC"},
                {4, "ONpameliconE"},
                {5, "ONpameliconF"},
            } },
            { 6, new Dictionary<int, string> {
                {1, "ONghigliaiconB" },
                {2, "ONghigliaiconC" },
                {3, "ONghigliaiconD" },
                {4, "ONghigliaiconE" },
            } }

        };
    private GameObject pleaseWindow;

	void Start() {
		pleaseWindow = GameObject.Find("PleaseWindow");
        var characterId = UserPlayData.Instance.selectCharacterId;
        Debug.Log(characterId.ToString());
        Debug.Log(itemNameList.Keys.ToString());

        var itemCount = itemNameList[characterId].Count;
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
           img.sprite = Resources.Load<Sprite>("OnegaiIcon/" + itemNameList[characterId][i]);
           var localPosition = itemObjectRoot.transform.localPosition;
           itemObjectRoot.transform.localPosition = new Vector3(localPosition.x, 390 + (setPostionCount * -170), localPosition.z);
           Debug.Log(65 + (setPostionCount * -170));           

           if (userGamePlayData.userCharacterData == null){
                itemObjectRoot.transform.Find("OnegaiButton").gameObject.SetActive(true);
                itemObjectRoot.transform.Find("DressChangeButton").gameObject.SetActive(false);
                setPostionCount++;
                continue;
           }
           var characterDataCountFlg = userGamePlayData.userCharacterData.ContainsKey(characterId);
           if (!characterDataCountFlg) {
                itemObjectRoot.transform.Find("OnegaiButton").gameObject.SetActive(true);
                itemObjectRoot.transform.Find("DressChangeButton").gameObject.SetActive(false);
                setPostionCount++;
                continue;
           }
           var itemCountFlg = userGamePlayData.userCharacterData[characterId].itemCountTable.ContainsKey(i);
           if (!itemCountFlg || userGamePlayData.userCharacterData[characterId].itemCountTable[i] < 0) {
                itemObjectRoot.transform.Find("OnegaiButton").gameObject.SetActive(true);
                itemObjectRoot.transform.Find("DressChangeButton").gameObject.SetActive(false);
                setPostionCount++;
                continue;
           } 
           itemObjectRoot.transform.gameObject.SetActive(false);           

        }
        pleaseWindow.SetActive (false);
    }


    public void OpenWindowButtonClick(int itemId) {
        
        Image img = pleaseWindow.transform.FindChild("SelectItem").GetComponent<Image>();
        img.sprite = Resources.Load<Sprite>("OnegaiIcon/" + itemNameList[UserPlayData.Instance.selectCharacterId][itemId]);
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

    public void DressChangeButtonClick(int itemId) {
        UserPlayData.Instance.selectItemId = itemId;
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