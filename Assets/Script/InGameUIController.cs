using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUIController : MonoBehaviour {

    private Button[] blockButtons = new Button[23];
    public Transform blockButtonContainer;
    public Button SettingButton,Ad;
    public Text ScoreText;
    public Text HighScoreText;
    public GameObject RoundUp;
    public GameObject Start_, Arrow, Panel;
    public GameObject SoundContainer;
    SoundManager soundManager;
    public Tutorial Tutorial_;


    private void Start()
    {
        SoundContainer = GameObject.Find("SoundManager").gameObject;
        soundManager = SoundContainer.GetComponent<SoundManager>();
        ScoreToText();
        HighScoreText.text = PlayerPrefs.GetInt("highscore", 0).ToString();
        for (int i = 0; i < 23; i++)
            blockButtons[i] = blockButtonContainer.GetChild(i).GetComponent<Button>();
        //PlayerPrefs.SetInt("tuto", 0);
        if (PlayerPrefs.GetInt("tuto",0) == 1)
            StartEffect();
        else
            Tutorial_.Start_Tutorial();
    }

    public void CallBack_Start()
    {
        Time.timeScale = 1;
        for (int i = 0; i < 23; i++)
            blockButtons[i].enabled = true;
        SettingButton.enabled = true;
        Ad.enabled = true;
        GameController.isRunning = true;
    }

    public void CallBack_Finish()
    {
        for (int i = 0; i < 23; i++)
            blockButtons[i].enabled = false;
        SettingButton.enabled = false;
        Ad.enabled = false;
    }

    public void CallBack_Stop()
    {
        Time.timeScale = 0;
        for (int i = 0; i < 23; i++)
            blockButtons[i].enabled = false;
        SettingButton.enabled = false;
        Ad.enabled = false;
    }

    public void RestartGame()
    {
        soundManager.Click_Sound();
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        soundManager.Click_Sound();
        SceneManager.LoadScene(0);
    }

    public void StopInstantiate()
    {
        for (int i = 0; i < 23; i++)
            blockButtons[i].enabled = false;
    }

    public IEnumerator StartInstantiate()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 23; i++)
            blockButtons[i].enabled = true;
    }

    public void ScoreToText()
    {
        ScoreText.text = "Score: "+GameController.score.ToString();
    }

    public void RoundUpEffect()
    {
        StartCoroutine(roundup());
    }

    public void StartEffect()
    {
        StartCoroutine(start());
    }

    public void Reward()
    {
        GameObject.Find("AdmobManager").GetComponent<RewardManager>().ShowRewardAd();
    }

    IEnumerator roundup()
    {
        RoundUp.SetActive(false);
        RoundUp.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RoundUp.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        RoundUp.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        RoundUp.SetActive(false);
    }

    IEnumerator start()
    {
        Panel.SetActive(true);
        Start_.SetActive(true);
        Arrow.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Start_.SetActive(false);
        Arrow.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Start_.SetActive(true);
        Arrow.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Start_.SetActive(false);
        Arrow.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Panel.SetActive(false);

        CallBack_Start();
    }
}
