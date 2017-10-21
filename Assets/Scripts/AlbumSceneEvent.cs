using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class AlbumSceneEvent : MonoBehaviour {

    public GameObject CharaPanel;

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


}
