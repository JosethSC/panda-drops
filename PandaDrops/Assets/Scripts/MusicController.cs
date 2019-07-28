using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public Sprite musicOn, musicOff;
    public GameObject musicOb;
    public Button musicbtn;
    public void MuteUnMute()
    {
        
        if(musicOb.activeSelf)
        {
            musicOb.SetActive(false);
            musicbtn.GetComponent<Image>().sprite = musicOff;
        } else if(!musicOb.activeSelf)
        {
            musicOb.SetActive(true);
            musicbtn.GetComponent<Image>().sprite = musicOn;
        }
        
    }
}
