using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelectSceneAction : MonoBehaviour
{

	public string selectCharacterPanelName = ""; 
    public SePlayer sePlayer;
    public int selectPageType = 0;
    public GameObject leftArrowButton;
    public GameObject rightArrowButton;
    public GameObject[] firstPageObject;
    public GameObject[] secondPageObject;

    public void Start()
    {
        OnAllowPointerUp(selectPageType);
    }

    public void OnCharacterPointerUp(string selectPanelLabel)
	{
		unSelectColor();
		char[] delimiterChars = {'#'};
		string[] updateInfo = selectPanelLabel.Split (delimiterChars, System.StringSplitOptions.None);
		if (this.GetComponent<MainSceneLoad> ().selectColorList.ContainsKey(int.Parse(updateInfo[1]))) {
            sePlayer.onClickSe();
            selectColor(updateInfo);
		}
	}

    public void OnAllowPointerUp(int pageType)
    {
        if (pageType == 0)
        {
            leftArrowButton.SetActive(false);
            rightArrowButton.SetActive(true);
            for (var i = 0; i < firstPageObject.Length; i++) {
                firstPageObject[i].SetActive(true);
            }
            for (var i = 0; i < secondPageObject.Length; i++)
            {
                secondPageObject[i].SetActive(false);
            }
        }
        else
        {
            leftArrowButton.SetActive(true);
            rightArrowButton.SetActive(false);
            for (var i = 0; i < firstPageObject.Length; i++)
            {
                firstPageObject[i].SetActive(false);
            }
            for (var i = 0; i < secondPageObject.Length; i++)
            {
                secondPageObject[i].SetActive(true);
            }
        }

        if (selectPageType != pageType) {
            sePlayer.onClickSe();
        }

        selectPageType = pageType;
    }

	void unSelectColor() {
		var unselectObj = GameObject.Find(selectCharacterPanelName);
		if (unselectObj != null) {
			Image img = unselectObj.transform.Find("BackGround").GetComponent<Image>();
			int selectCharacterId = UserPlayData.Instance.selectCharacterId;
			img.color =  this.GetComponent<MainSceneLoad>().defaultColorList[selectCharacterId];
		}
	}

	void selectColor(string[] updateInfo) {
		selectCharacterPanelName = updateInfo[0];
		UserPlayData.Instance.selectCharacterId = int.Parse(updateInfo[1]);
        UserPlayData.Instance.selectItemId = 1;
		int selectCharacterId = UserPlayData.Instance.selectCharacterId;
		Image img = GameObject.Find(selectCharacterPanelName).transform.Find("BackGround").GetComponent<Image>();
		img.color = this.GetComponent<MainSceneLoad>().selectColorList[selectCharacterId];
	}

}