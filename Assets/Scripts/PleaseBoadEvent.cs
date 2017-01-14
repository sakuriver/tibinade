using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PleaseBoadEvent : MonoBehaviour
{

    Dictionary<int, Dictionary<int, string>> itemNameList = new Dictionary<int, Dictionary<int, string>>()
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
        pleaseWindow.SetActive(true);
	}

	public void NoButtonClick() {
		pleaseWindow.SetActive (false);
	}

	public void YesButtonClick() {
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