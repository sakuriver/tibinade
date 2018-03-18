using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelectSceneAction : MonoBehaviour
{

	public string selectCharacterPanelName = ""; 
    public SePlayer sePlayer;


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
        UserPlayData.Instance.selectItemId = 0;
		int selectCharacterId = UserPlayData.Instance.selectCharacterId;
		Image img = GameObject.Find(selectCharacterPanelName).transform.Find("BackGround").GetComponent<Image>();
		img.color = this.GetComponent<MainSceneLoad>().selectColorList[selectCharacterId];
	}

}