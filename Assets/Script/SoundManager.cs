using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public Transform clickContainer;
    public Transform EndContainer;
    public Transform DropContainer;
    public Transform ThunderContainer;
    //  public Transform bgmContainer;

    AudioSource audioSource_click;
    AudioSource audioSource_End;
    AudioSource audioSource_Drop;
    AudioSource audioSource_Thunder;
    public Transform OutGameContainer;
    OutGameUIController uIController;
//    AudioSource audioSource_bgm;
    // Use this for initialization
    void Start() {
        audioSource_click = clickContainer.GetComponent<AudioSource>();
        //      audioSource_bgm = bgmContainer.GetComponent<AudioSource>();
        if (OutGameContainer == null)
        {
            audioSource_End = EndContainer.GetComponent<AudioSource>();
            audioSource_Drop = DropContainer.GetComponent<AudioSource>();
            audioSource_Thunder = ThunderContainer.GetComponent<AudioSource>();

            if (MyPlayerPrefs.Volume_Click == 0)
            {
                audioSource_click.enabled = false;
                audioSource_Drop.enabled = false;
                audioSource_End.enabled = false;
                audioSource_Thunder.enabled = false;
            }
        }
        else
        {
            uIController = OutGameContainer.GetComponent<OutGameUIController>();
            if (MyPlayerPrefs.Volume_Click == 0)
            {
                audioSource_click.enabled = false;
            }
        }



    }

    public void Click_On()
    {
        MyPlayerPrefs.SetVolume_Click(1);
        audioSource_click.enabled = true;
        if (OutGameContainer != null)
        {
            uIController.Setting();
        }
    }

    public void Click_Off()
    {
        MyPlayerPrefs.SetVolume_Click(0);
        audioSource_click.enabled = false;
        if (OutGameContainer != null)
        {
            uIController.Setting();
        }
    }

    public void Click_Sound()
    {
        if(MyPlayerPrefs.Volume_Click == 1)
        {
            audioSource_click.Play();
        }
    }

    public void Drop_Sound()
    {
        if (MyPlayerPrefs.Volume_Click == 1)
        {
            audioSource_Drop.Play();
        }
    }

    public void End_Sound()
    {
        if (MyPlayerPrefs.Volume_Click == 1)
        {
            audioSource_End.Play();
        }
    }

    public void Thunder_Sound()
    {
        if (MyPlayerPrefs.Volume_Click == 1)
        {
            audioSource_Thunder.Play();
        }
    }
}
