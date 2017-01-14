using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CharaSelectSceneLoad : MonoBehaviour
{

    public SePlayer sePlayer;


    public void OnClick()
    {
        sePlayer.onClickSe();
        StartCoroutine("CharaSelectStart");
    }

    IEnumerator CharaSelectStart()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("charaselect");
    }
}
