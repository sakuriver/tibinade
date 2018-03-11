using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DressChangeSceneLoad : MonoBehaviour
{

	public SePlayer sePlayer;


	public void OnClick()
	{
		sePlayer.onClickSe();
		StartCoroutine("DressChangeScene");
	}

	IEnumerator DressChangeScene()
	{
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("dresschange");
	}
}