using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MainSceneLoad : MonoBehaviour
{
	// Todo 通信が完成したら、色の切り替え処理はサーバーから取得するように変更する
	public Dictionary<int, Color> defaultColorList;
	public Dictionary<int, Color> selectColorList;
    public SePlayer sePlayer;


    void Start() {
		Debug.Log (UserPlayData.Instance.selectCharacterId);
		defaultColorList = new Dictionary<int, Color> ();
		selectColorList = new Dictionary<int, Color> ();
		defaultColorList.Add (1, new Color(120.0f/255.0f, 72.0f/255.0f, 117.0f/255.0f));
		defaultColorList.Add (2, new Color (45.0f/255.0f, 124.0f/255.0f, 101.0f/255.0f));
		defaultColorList.Add (3, new Color (35.0f/255.0f, 35.0f/255.0f, 96.0f/255.0f));
		defaultColorList.Add (4, new Color (122.0f/255.0f, 115.0f/255.0f, 44.0f/255.0f));
		defaultColorList.Add (5, new Color (113.0f/255.0f, 42.0f/255.0f, 118.0f/255.0f));
		defaultColorList.Add (6, new Color (109.0f/255.0f, 34.0f/255.0f, 36.0f/255.0f));
        defaultColorList.Add(7, new Color(49.0f / 255.0f, 145.0f / 255.0f, 57.0f / 255.0f));
        selectColorList.Add (1, new Color(255.0f/255.0f, 168.0f/255.0f, 248.0f/255.0f));
		selectColorList.Add (2, new Color(93.0f/255.0f, 255.0f/255.0f, 209.0f/255.0f));
		selectColorList.Add (3, new Color(55.0f/255.0f, 157.0f/255.0f, 255.0f/255.0f));
		selectColorList.Add (4, new Color(255.0f/255.0f, 243.0f/255.0f, 93.0f/255.0f));
		selectColorList.Add (5, new Color(245.0f/255.0f, 93.0f/255.0f, 255.0f/255.0f));
		selectColorList.Add (6, new Color (255.0f/255.0f, 93.0f/255.0f, 99.0f/255.0f));
        selectColorList.Add(7, new Color(75.0f / 255.0f, 239.0f / 255.0f, 88.0f / 255.0f));
    }

    public void OnClick()
    {
        sePlayer.onClickSe();
        StartCoroutine("MainStart");
    }

    IEnumerator MainStart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("main");
    }
}