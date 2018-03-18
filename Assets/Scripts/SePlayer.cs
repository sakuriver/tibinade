using UnityEngine;
using System.Collections;

public class SePlayer : MonoBehaviour
{

    public AudioClip click;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickSe()
    {
      AudioSource audioSource = GetComponent<AudioSource>();
      audioSource.PlayOneShot(click);
    }


}
