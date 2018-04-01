using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DressChangeSceneEvent : MonoBehaviour {

    public GameObject CharaPanel;

	// Use this for initialization
	void Start () {
        var characterId = UserPlayData.Instance.selectCharacterId;

        var itemCount = PleaseItem.ItemNameList[characterId].Count;
        var setPostionCount = 1;
        var userGamePlayData = UserPlayData.Instance.userGamePlayData;
        for (int i = 1; i <= 4; i++)
        {

            GameObject itemObjectRoot = GameObject.Find("ItemObj" + i).gameObject;
            if (i <= itemCount)
            {
                itemObjectRoot.SetActive(true);
            }
            else
            {
                itemObjectRoot.SetActive(false);
                continue;
            }
            Image img = itemObjectRoot.transform.FindChild("Icon").GetComponent<Image>();
            img.sprite = Resources.Load<Sprite>("OnegaiIcon/" + PleaseItem.ItemNameList[characterId][i]);
            var localPosition = itemObjectRoot.transform.localPosition;
            itemObjectRoot.transform.localPosition = new Vector3(localPosition.x, 390 + (setPostionCount * -170), localPosition.z);

            if (userGamePlayData.userCharacterData == null)
            {
                itemObjectRoot.transform.gameObject.SetActive(false);
                continue;
            }
            var characterDataCountFlg = userGamePlayData.userCharacterData.ContainsKey(characterId);
            if (!characterDataCountFlg)
            {
                itemObjectRoot.transform.gameObject.SetActive(false);
                continue;
            }
            var itemCountFlg = userGamePlayData.userCharacterData[characterId].itemCountTable.ContainsKey(i);
            if (!itemCountFlg || userGamePlayData.userCharacterData[characterId].itemCountTable[i] < 0)
            {
                itemObjectRoot.transform.gameObject.SetActive(false);
                continue;
            }
            setPostionCount++;

        }
    }

	// Update is called once per frame
	void Update () {

	}


	public void OnClickBackButton()
	{
		StartCoroutine("AlbumStart");
	}

	IEnumerator AlbumStart()
	{
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("album");
	}

    public void OnClickDressChangeButton(int itemId)
    {
        UserPlayData.Instance.selectItemId = itemId;
    }



}
