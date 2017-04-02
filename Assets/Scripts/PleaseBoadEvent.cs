﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PleaseBoadEvent : MonoBehaviour
{
    public UserGamePlayData userGamePlayData;
    public Dictionary<int, Dictionary<int, string>> itemNameList = new Dictionary<int, Dictionary<int, string>>()
        {
            {1, new Dictionary<int,string> {
                {1, "ONluklukEicon"},
                {2, "ONluklukBicon"},
                {3, "ONluklukCicon"},
                {4, "ONluklukDicon"},
            }
            },
            { 2, new Dictionary<int,string> {
                {1, "ONluklukEicon"},
                {2, "ONluklukBicon"},
                {3, "ONluklukCicon"},
                {4, "ONluklukDicon"},
            }
            },
            { 3, new Dictionary<int,string> {
                {1, "OngelpiciconB"},
                {2, "OngelpiciconC"},
                {3, "OngelpiciconD"},
                {4, "OngelpiciconE"},
            } },
            { 4, new Dictionary<int,string> {
                {1, "ONsroniconB"},
                {2, "ONsroniconC"},
                {3, "ONsroniconD"},
                {4, "ONsroniconE"},
            } },
            { 5, new Dictionary<int,string> {
                {1, "ONpameliconB"},
                {2, "ONpameliconC"},
                {3, "ONpameliconE"},
                {4, "ONpameliconF"},
            } },
            { 6, new Dictionary<int,string> {
                {1, "ONghigliaiconB" },
                {2, "ONghigliaiconC" },
                {3, "ONghigliaiconD" },
                {4, "ONghigliaiconE" },
            } }

        };
    private GameObject pleaseWindow;

	void Start() {
		pleaseWindow = GameObject.Find("PleaseWindow");
        for (int i = 1; i < 5; i++) {
           Image img = GameObject.Find("ItemObj" + i).gameObject.transform.FindChild("Icon").GetComponent<Image>();
           img.sprite = Resources.Load<Sprite>("OnegaiIcon/" + itemNameList[UserPlayData.Instance.selectCharacterId][i]);
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