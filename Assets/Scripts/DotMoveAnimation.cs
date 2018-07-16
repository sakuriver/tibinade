using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections.Generic;

public class DotMoveAnimation : MonoBehaviour
{

    public Transform charaPanel;
    public Transform titleTouch;
    public bool titleFlg;
	public Dictionary<int, int> characterFaces;
	public Dictionary<int, int> characterTexts;
    public Sprite bagOpenSprite;
    public Sprite bagCloseSprite;
    public bool rightScrollStartFlg;
    public bool leftScrollStartFlg;
    public bool characterPoseFlg;
	private Dictionary<int, Dictionary<int, Vector2>> charaPoseFacePositions;
	private Dictionary<int, string> characterNames;
	private Dictionary<int, string> characterBgNames;
	private GameObject leftScrollAllow;
    private GameObject rightScrollAllow;
    private GameObject charaPanelObj;
    public GameObject talkPanelObj;
    private GameObject bagObj;
    private GameObject pleaseBoadPanelObj;
    private bool bagOpenFlg;
    private AudioSource touch;
    private AudioSource talk;


    // Use this for initialization
    void Start()
    {

        DOTween.Init(true, false, LogBehaviour.Default);
        titleFlg = false;
        rightScrollStartFlg = false;
        leftScrollStartFlg = false;
        charaPanelObj = GameObject.Find("CharaPanel");
        talkPanelObj = GameObject.Find("TalkPanel");
        bagObj = GameObject.Find("Bag");
        if (GameObject.Find("pleaseBoadPanel") != null) {
            pleaseBoadPanelObj = GameObject.Find("pleaseBoadPanel");
            pleaseBoadPanelObj.SetActive(false);
        }
		if (GameObject.Find ("LeftScrollAllow") != null) {
			leftScrollAllow = GameObject.Find("LeftScrollAllow");
			rightScrollAllow = GameObject.Find("RightScrollAllow");
			rightScrollAllow.SetActive(true);
			leftScrollAllow.SetActive(false);
			talkPanelObj.SetActive(false);
		}
		charaPoseFacePositions = new Dictionary<int, Dictionary<int, Vector2>> ();
		charaPoseFacePositions.Add(1, new Dictionary<int, Vector2>());
		charaPoseFacePositions [1].Add (1, new Vector2 (7, 196));
		charaPoseFacePositions [1].Add (2, new Vector2 (7, 196));
		charaPoseFacePositions [1].Add (3, new Vector2 (7, 126));
		charaPoseFacePositions [1].Add (4, new Vector2 (0, 143));
		charaPoseFacePositions.Add(2, new Dictionary<int, Vector2>());
		charaPoseFacePositions [2].Add (1, new Vector2 (10, 135));
		charaPoseFacePositions [2].Add (2, new Vector2 (0, 135));
		charaPoseFacePositions [2].Add (3, new Vector2 (10, 70));
		charaPoseFacePositions [2].Add (4, new Vector2 (0, 80));
		charaPoseFacePositions.Add(3, new Dictionary<int, Vector2>());
		charaPoseFacePositions [3].Add (1, new Vector2 (12, 250));
		charaPoseFacePositions [3].Add (2, new Vector2 (-10, 255));
		charaPoseFacePositions [3].Add (3, new Vector2 (-13, 155));
		charaPoseFacePositions [3].Add (4, new Vector2 (30, 190));
		charaPoseFacePositions.Add(4, new Dictionary<int, Vector2>());
		charaPoseFacePositions [4].Add (1, new Vector2 (0, 240));
		charaPoseFacePositions [4].Add (2, new Vector2 (-27, 238));
		charaPoseFacePositions [4].Add (3, new Vector2 (10, 170));
		charaPoseFacePositions [4].Add (4, new Vector2 (30, 150));
		charaPoseFacePositions.Add(5, new Dictionary<int, Vector2>());
		charaPoseFacePositions [5].Add (1, new Vector2 (-15, 232));
		charaPoseFacePositions [5].Add (2, new Vector2 (25, 230));
		charaPoseFacePositions [5].Add (3, new Vector2 (0, 140));
		charaPoseFacePositions [5].Add (4, new Vector2 (-25, 128));
		charaPoseFacePositions.Add(6, new Dictionary<int, Vector2>());
		charaPoseFacePositions [6].Add (1, new Vector2 (18, 287));
		charaPoseFacePositions [6].Add (2, new Vector2 (-45, 290));
		charaPoseFacePositions [6].Add (3, new Vector2 (-68, 185));
		charaPoseFacePositions [6].Add (4, new Vector2 (25, 198));
        charaPoseFacePositions.Add(7, new Dictionary<int, Vector2>());
        charaPoseFacePositions[7].Add(1, new Vector2(3, 338));
        charaPoseFacePositions[7].Add(2, new Vector2(-42, 335));
        charaPoseFacePositions[7].Add(3, new Vector2(63, 228));
        charaPoseFacePositions[7].Add(4, new Vector2(0, 235));

        characterNames = new Dictionary<int, string>();
		characterNames.Add (1, "lukluk");
		characterNames.Add (2, "dieule");
		characterNames.Add (3, "gelpic");
		characterNames.Add (4, "sron");
		characterNames.Add (5, "pamel");
		characterNames.Add (6, "ghiglia");
        characterNames.Add(7, "decerick");
        characterBgNames = new Dictionary<int, string> ();
		characterBgNames.Add (1, "lukluk_BG");
		characterBgNames.Add (2, "dieule_BG");
		characterBgNames.Add (3, "picsron_BG");
		characterBgNames.Add (4, "picsron_BG");
		characterBgNames.Add (5, "pamel_BG");
		characterBgNames.Add (6, "ghiglia_BG");
        characterBgNames.Add(7, "decerick_BG");
        characterFaces = new Dictionary<int, int> ();
		characterFaces.Add (1, 11);
		characterFaces.Add (2, 11);
		characterFaces.Add (3, 11);
		characterFaces.Add (4, 11);
		characterFaces.Add (5, 11);
		characterFaces.Add (6, 11);
        characterFaces.Add(7, 11);
        characterTexts = new Dictionary<int, int> ();

		characterTexts.Add (1, 43);
		characterTexts.Add (2, 7);
		characterTexts.Add (3, 11);
		characterTexts.Add (4, 12);
		characterTexts.Add (5, 12);
		characterTexts.Add (6, 12);
        characterTexts.Add(7, 12);
        CharaMove();
		CharaPoseChange ();
		int characterId = UserPlayData.Instance.selectCharacterId;
        GameObject gameBg = GameObject.Find("BackGround");
        AudioSource[] audioSources = GameObject.Find("EventSystem").GetComponents<AudioSource>();
        touch = audioSources[0];

        if (talkPanelObj != null)
        {
            gameBg.GetComponent<RawImage>().texture = Resources.Load<Texture>("Avator/" + characterBgNames[characterId]);
            gameBg.GetComponent<RawImage>().uvRect = new Rect(0.0f, 0.0f, 0.5f, 1.0f);
            talk = audioSources[1];
        }
    }

    // Update is called once per frame
    void Update() {
        RightScrollAnimation();
        LeftScrollAnimation();

    }

    void RightScrollAnimation()
    {
        if (rightScrollStartFlg) {
            GameObject.Find("BackGround").GetComponent<RawImage>().uvRect = new Rect(GameObject.Find("BackGround").GetComponent<RawImage>().uvRect.x + 0.0075f, 0.0f, 0.5f, 1.0f);
            RectTransform charapos = charaPanelObj.GetComponent<RectTransform>();
            RectTransform talkpos = talkPanelObj.GetComponent<RectTransform>();
            RectTransform leftpos = GameObject.Find("LeftMenuPanel").GetComponent<RectTransform>();
            talkPanelObj.GetComponent<RectTransform>().localPosition = new Vector3(talkpos.localPosition.x - 7.5f, talkpos.localPosition.y, talkpos.localPosition.z);
            charaPanelObj.GetComponent<RectTransform>().localPosition = new Vector3(charapos.localPosition.x - 7.5f, charapos.localPosition.y, charapos.localPosition.z);
            GameObject.Find("LeftMenuPanel").GetComponent<RectTransform>().localPosition = new Vector3(leftpos.localPosition.x - 8.5f, leftpos.localPosition.y, leftpos.localPosition.z);
            if (GameObject.Find("BackGround").GetComponent<RawImage>().uvRect.x > 0.5f) {
                talkPanelObj.GetComponent<RectTransform>().localPosition = new Vector3(-486.0f, talkpos.localPosition.y, talkpos.localPosition.z);
                charaPanelObj.GetComponent<RectTransform>().localPosition = new Vector3(-375.0f, charapos.localPosition.y, charapos.localPosition.z);
                GameObject.Find("LeftMenuPanel").GetComponent<RectTransform>().localPosition = new Vector3(-240.0f, leftpos.localPosition.y, leftpos.localPosition.z);
                GameObject.Find("BackGround").GetComponent<RawImage>().uvRect = new Rect(0.5f, 0.0f, 0.5f, 1.0f);
                rightScrollStartFlg = false;
                rightScrollAllow.SetActive(false);
                leftScrollAllow.SetActive(true);
                pleaseBoadPanelObj.SetActive(false);
            }
        }

    }

    public void BagClick()
    {
        if (!bagOpenFlg) {
            openBag();
        } else {
            closeBag();
        }
    }
    

    void LeftScrollAnimation()
    {
        if (leftScrollStartFlg) {
            GameObject.Find("BackGround").GetComponent<RawImage>().uvRect = new Rect(GameObject.Find("BackGround").GetComponent<RawImage>().uvRect.x - 0.0075f, 0.0f, 0.5f, 1.0f);
            RectTransform charapos = charaPanelObj.GetComponent<RectTransform>();
            RectTransform talkpos = talkPanelObj.GetComponent<RectTransform>();
            RectTransform leftpos = GameObject.Find("LeftMenuPanel").GetComponent<RectTransform>();
            talkPanelObj.GetComponent<RectTransform>().localPosition = new Vector3(talkpos.localPosition.x + 7.5f, talkpos.localPosition.y, talkpos.localPosition.z);
            charaPanelObj.GetComponent<RectTransform>().localPosition = new Vector3(charapos.localPosition.x + 7.5f, charapos.localPosition.y, charapos.localPosition.z);
            GameObject.Find("LeftMenuPanel").GetComponent<RectTransform>().localPosition = new Vector3(leftpos.localPosition.x + 8.5f, leftpos.localPosition.y, leftpos.localPosition.z);
            if (GameObject.Find("BackGround").GetComponent<RawImage>().uvRect.x <= 0.0f) {
                talkPanelObj.GetComponent<RectTransform>().localPosition = new Vector3(13.0f, talkpos.localPosition.y, talkpos.localPosition.z);
                charaPanelObj.GetComponent<RectTransform>().localPosition = new Vector3(125.0f, charapos.localPosition.y, charapos.localPosition.z);
                GameObject.Find("LeftMenuPanel").GetComponent<RectTransform>().localPosition = new Vector3(320.0f, leftpos.localPosition.y, leftpos.localPosition.z);
                GameObject.Find("BackGround").GetComponent<RawImage>().uvRect = new Rect(0.0f, 0.0f, 0.5f, 1.0f);
                leftScrollStartFlg = false;
                rightScrollAllow.SetActive(true);
                leftScrollAllow.SetActive(false);
           }
        }

    }

    public void CharaMove() {
        float rndValue = Random.value;
        if (characterPoseFlg && rndValue >= 0.8f ){
            CharaPoseChange();
        }

        int characterId = UserPlayData.Instance.selectCharacterId;
		string faceNumber = string.Format("{0:D2}", Random.Range (1, characterFaces[characterId]));
		string characterName = characterNames [characterId];
		Sprite ps = Resources.Load<Sprite> ("Avator/" + characterName  +"_face_" + faceNumber); 
		GameObject charaface = GameObject.Find ("CharaFace");
		charaface.GetComponent<Image>().sprite = ps;
		charaface.GetComponent<RectTransform> ().sizeDelta = new Vector2 (ps.bounds.size.x * 100, ps.bounds.size.y * 100);
        if (touch != null) {
            touch.PlayOneShot(touch.clip);
        }
        if (talkPanelObj != null){
            talkPanelObj.SetActive(false);
        }
        if (rndValue >= 0.3f) {
            if (talk != null) {
                talk.PlayOneShot(talk.clip);
            }
            Invoke("OpenTalkBox", 0.1f);
        }


        // 顔を変更させた後に、震えさせる
        charaPanel.transform.DOShakeScale(0.15f, 0.15f);
    }

    private void OpenTalkBox() {
        if (talkPanelObj == null) {
            return;
        }
        talkPanelObj.SetActive(true);
		int characterId = UserPlayData.Instance.selectCharacterId;
        string textNumber = string.Format("{0:D2}", Random.Range(1, characterTexts[characterId]));
        while (UserPlayData.Instance.pleasePrevCharacterTextNumber == textNumber) {
            textNumber = string.Format("{0:D2}", Random.Range(1, characterTexts[characterId]));
        }
		string characterName = characterNames [characterId];
		Sprite ps = Resources.Load<Sprite> ("Avator/" + characterName  +"_text_" + textNumber); 
		GameObject.Find("TalkLine").GetComponent<Image>().sprite = ps;
        talkPanelObj.transform.DOShakeScale(0.15f, 0.15f);
        UserPlayData.Instance.pleasePrevCharacterTextNumber = textNumber;
    }

    public void RightScroll() {
        rightScrollStartFlg = true;
        talkPanelObj.SetActive(false);
    }

    public void LeftScroll() {
        leftScrollStartFlg = true;
        closeBag();
		CharaPoseChange ();
    }

    private void closeBag() {
        bagObj.GetComponent<Image>().sprite = bagCloseSprite;
        pleaseBoadPanelObj.SetActive(false);
        bagOpenFlg = false;
    }

    private void openBag() {
        bagObj.GetComponent<Image>().sprite = bagOpenSprite;
        bagOpenFlg = true;
        pleaseBoadPanelObj.SetActive(true);
    }

    public void TitleButtonMove() {
        if (!titleFlg) {
            titleTouch.transform.DOShakeScale(0.5f, 0.5f, 3, 0);
            titleFlg = true;
        }
    }

	private void CharaPoseChange() {
		int poseValue = Random.Range (1, 5);
		int characterId = UserPlayData.Instance.selectCharacterId;
        int itemId = UserPlayData.Instance.selectItemId;
		string poseName = string.Format ("{0:D2}", poseValue);
		GameObject charaBody = GameObject.Find ("CharaBody");
		GameObject charaFace = GameObject.Find ("CharaFace");
		string characterName = characterNames [characterId];
        string itemTypeName = PleaseItem.ItemNameList[characterId][itemId].DressTypeName;
        Debug.Log("Avator/" + characterName + "_body_" + itemTypeName + poseName);
		Sprite ps = Resources.Load<Sprite> ("Avator/" + characterName  +"_body_" + itemTypeName + poseName);
		Vector2 selectFacePosition = charaPoseFacePositions [characterId][poseValue];
		charaBody.GetComponent<Image>().sprite = ps;
		charaBody.GetComponent<RectTransform> ().sizeDelta = new Vector2 (ps.bounds.size.x * 100, ps.bounds.size.y * 100);
		charaFace.GetComponent<RectTransform> ().localPosition = new Vector3 (selectFacePosition.x, selectFacePosition.y, charaFace.GetComponent<RectTransform> ().position.z);
	}



}
