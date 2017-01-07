using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PleaseBoadSceneLoad : MonoBehaviour
{

    public void OnClick()
    {
        StartCoroutine("PleaseBoadScene");
    }

    IEnumerator PleaseBoadScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("pleaseboad");
    }
}