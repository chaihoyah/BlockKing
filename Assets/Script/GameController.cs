using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static bool isRunning;
    public static bool inGame;
    public static int score;
    public static int adcount = 2;
    public GameObject uiController;
    public GameObject EffectController;
    public Transform roundControllerContainer;
    private InGameUIController UIController;
    private RoundController roundController;
    public GameObject FinishObject;
    public GameObject AdmobContainer;

    public GameObject SoundContainer;
    SoundManager soundManager;
    AdmobManager admobManager;
    //public GameObject AdmobContainer;
    //AdmobManager admobManager;


	// Use this for initialization
	void Start () {
        //Start Setting
        score = 0;
        inGame = true;
        isRunning = false;
        SoundContainer = GameObject.Find("SoundManager").gameObject;
        AdmobContainer = GameObject.Find("AdmobManager").gameObject;
        //Get All Controllers
        UIController = uiController.GetComponent<InGameUIController>();
        roundController = roundControllerContainer.GetComponent<RoundController>();
        soundManager = SoundContainer.GetComponent<SoundManager>();
        admobManager = AdmobContainer.GetComponent<AdmobManager>();
        //Start UI
        UIController.ScoreToText();
        EffectController.SetActive(true);
        StartCoroutine(WaitFewSecond(0.5f));
   	}
    //Drop Start Effect
    IEnumerator WaitFewSecond(float time)
    {
        yield return new WaitForSeconds(time);
    }
    //Game Start
    public void StartGame()
    {
        isRunning = true;
        //Callback UI Code
        //UIController.CallBack_Start();
        //
    }

    public IEnumerator GoToNext()
    {
        yield return new WaitForSeconds(0.7f);
        RoundController.count += 1;
        score += 10 * RoundController.round;
        int num = RoundController.count;

        if (num.Equals(10) || num.Equals(25)|| num.Equals(45))
        {
            yield return new WaitForSeconds(1);
            roundController.RoundUpCallback();
        }
        else
            isRunning = true;

        UIController.ScoreToText();

        if(num.Equals(37))
        {
            StartCoroutine(GameObject.Find("RewardEffectController").GetComponent<EffectForReward>().Twinkle());
        }
    }
    public GameObject obj;
    public Text scoretext_Fini;
    public GameObject GetHigh;

    public void Finish_Game()
    {
        isRunning = false;
        //UI Callback -> finish
        FinishObject.SetActive(true);

        if (score > MyPlayerPrefs.HighScore)
        {
            MyPlayerPrefs.SetHighScore(score);
            GetHigh.SetActive(true);
        }

        StartCoroutine(FinishEffect(obj, scoretext_Fini));
    }

    IEnumerator FinishEffect(GameObject Object, Text scoreText)
    {
        float velo = 1f;

        scoreText.text += score.ToString();

        yield return new WaitForSeconds(0.1f);
        soundManager.End_Sound();

        while (Object.transform.position.y > 1500)
        {
            Object.transform.position -= new Vector3(0, velo, 0);
            velo += (1.98f);
            yield return new WaitForSeconds(0.01f);
        }

        int a = Random.Range(1, 4);

        if (a == 1)
            admobManager.ShowInterstitialAd();
    }

    public GameObject[] PopObject = new GameObject[5];

    public void Effect_Reward_Block(Vector3 vec, int kind)
    {
        Instantiate(PopObject[kind], vec, Quaternion.identity);
    }
}
