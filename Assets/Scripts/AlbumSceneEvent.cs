using UnityEngine;
using System.Collections;

public class AlbumSceneEvent : MonoBehaviour {

    public GameObject CharaPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PointerDown()
    {
        
        CharaPanel.GetComponent<DotMoveAnimation>().CharaMove();
    }


}
