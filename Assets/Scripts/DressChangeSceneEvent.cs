using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DressChangeSceneEvent : MonoBehaviour {

	public GameObject CharaPanel;

	// Use this for initialization
	void Start () {

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

	public void OnClickDressChangeButton()
	{
	}



}
