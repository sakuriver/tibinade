using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class AlbumSceneEvent : MonoBehaviour {

    public SePlayer sePlayer;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    public void OnClickBackButton()
    {
        StartCoroutine("MainStart");
    }

    IEnumerator MainStart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("main");
    }

	public void OnClickDressChangeButton()
	{
        sePlayer.onClickSe();
		StartCoroutine("DressChangeStart");
	}

	IEnumerator DressChangeStart()
	{
		yield return new WaitForSeconds(1);
		SceneManager.LoadScene("dresschange");
	}


}
