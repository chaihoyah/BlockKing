using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    public GameObject Panel;
    public GameObject Text_Button, Text_Wall, Text_Lets_Go, Text_Ad;
    public GameObject Arrow_Button, Arrow_Wall, Arrow_Wall2, Arrow_ad;
    public Text Text_Tutorial;
    public GameObject next, previous;
    string tuto = "Tutorial";
    int stage = 0;

    public void Start_Tutorial()
    {
        stage = 1;
        StartCoroutine(Tutorial_Coroutine());
    }

    IEnumerator Tutorial_Coroutine()
    {
        switch (stage)
        {
            case 1:
                Panel.SetActive(true);
                Reset_Obj();
                Text_Tutorial.gameObject.SetActive(true);
                yield return new WaitForSeconds(1);
                for (int i = 0; i < 8; i++)
                {
                    Text_Tutorial.text += tuto[i];
                    yield return new WaitForSeconds(0.2f);
                }

                Text_Tutorial.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                Text_Tutorial.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                Text_Tutorial.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                Text_Tutorial.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                Text_Tutorial.gameObject.SetActive(false);
                yield return new WaitForSeconds(1);
                Text_Button.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                Arrow_Button.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                Arrow_Button.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                Arrow_Button.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                Arrow_Button.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                Arrow_Button.SetActive(true);

                yield return new WaitForSeconds(0.5f);
                stage++;
                next.SetActive(true);
                break;
            case 2:
                Reset_Obj();
                yield return new WaitForSeconds(1);
                Text_Button.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                Arrow_Button.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                Arrow_Button.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                Arrow_Button.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                Arrow_Button.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                Arrow_Button.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                next.SetActive(true);
                break;
            case 3:
                Reset_Obj();
                yield return new WaitForSeconds(1);
                Text_Wall.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                Arrow_Wall.SetActive(true);
                Arrow_Wall2.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                Arrow_Wall.SetActive(false);
                Arrow_Wall2.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                Arrow_Wall.SetActive(true);
                Arrow_Wall2.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                Arrow_Wall.SetActive(false);
                Arrow_Wall2.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                Arrow_Wall.SetActive(true);
                Arrow_Wall2.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                next.SetActive(true);
                previous.SetActive(true);
                break;
            case 4:
                Reset_Obj();
                yield return new WaitForSeconds(1);
                Text_Ad.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                Arrow_ad.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                Arrow_ad.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                Arrow_ad.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                Arrow_ad.SetActive(false);
                yield return new WaitForSeconds(0.5f);
                Arrow_ad.SetActive(true);
                yield return new WaitForSeconds(0.5f);
                
                next.SetActive(true);
                previous.SetActive(true);
                break;
            case 5:
                Reset_Obj();
                yield return new WaitForSeconds(1);
                Text_Lets_Go.SetActive(true);

                yield return new WaitForSeconds(2);
                PlayerPrefs.SetInt("tuto", 1);
                SceneManager.LoadScene(1);
                break;
        }        
    }

    public void Next()
    {
        stage++;
        next.SetActive(false);
        previous.SetActive(false);
        StartCoroutine(Tutorial_Coroutine());
    }

    public void Previous()
    {
        stage--;
        next.SetActive(false);
        previous.SetActive(false);
        StartCoroutine(Tutorial_Coroutine());
    }

    void Reset_Obj()
    {
        Text_Button.SetActive(false);
        Text_Ad.SetActive(false);
        Text_Lets_Go.SetActive(false);
        Text_Tutorial.gameObject.SetActive(false);
        Text_Wall.SetActive(false);

        Text_Button.SetActive(false);
        Arrow_Button.SetActive(false);
        Arrow_Wall.SetActive(false);
        Arrow_Wall2.SetActive(false);
        Arrow_ad.SetActive(false);
    }
}
