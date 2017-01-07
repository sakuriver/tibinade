using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class MainSceneUserAnimation : MonoBehaviour
{

    public void PointerDown()
    {
        this.GetComponent<DotMoveAnimation>().CharaMove();
    }

    public void TalkPointerDown()
    {
        this.GetComponent<DotMoveAnimation>().talkPanelObj.SetActive(false);
    }


}