using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainSceneUserAnimation : MonoBehaviour
{

    public GameObject pleaseBoardRoot;
    public Text pleaseTimeText;
    public Image pleaseItemIcon;
    public UserGamePlayData userGamePlayData;

    public void Start(){
        pleaseBoardRoot.SetActive(userGamePlayData.pleaseCommandFlg);
        if (userGamePlayData.pleaseCommandFlg) {
            PleaseBoadEvent pEvent = new PleaseBoadEvent();
            pleaseItemIcon.sprite = Resources.Load<Sprite>("OnegaiIcon/" + pEvent.itemNameList[userGamePlayData.pleaseCharacterId][userGamePlayData.pleaseItemId]);
            pleaseItemIcon.SetNativeSize();
        }
    }

    public void PointerDown()
    {
        this.GetComponent<DotMoveAnimation>().CharaMove();
    }

    public void TalkPointerDown()
    {
        this.GetComponent<DotMoveAnimation>().talkPanelObj.SetActive(false);
    }

    public void Update()
    {
        if (userGamePlayData.pleaseCommandFlg) {
            var now = userGamePlayData.pleaseCompleteTime.Subtract(System.DateTime.Now);
            Debug.Log(userGamePlayData.pleaseCompleteTime.Hour.ToString() + ":" + userGamePlayData.pleaseCompleteTime.Minute.ToString() + ":" + userGamePlayData.pleaseCompleteTime.ToString());
            pleaseTimeText.text = now.Hours.ToString() + ":" + now.Minutes.ToString() + ":" + now.Seconds.ToString();
        }
    }

}