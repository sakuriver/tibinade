using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AlbumSceneLoad : MonoBehaviour
{

    public SePlayer sePlayer;


    public void OnClick()
    {
        sePlayer.onClickSe();
        StartCoroutine("AlbumScene");
    }

    IEnumerator AlbumScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("album");
    }
}