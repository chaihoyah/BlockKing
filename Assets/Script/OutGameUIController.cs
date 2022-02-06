using GooglePlayGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutGameUIController : MonoBehaviour {

    public Canvas SettingMenu;
    public GameObject SoundContainer;
    SoundManager soundManager;

    private void Start()
    {
        SoundContainer = GameObject.Find("SoundManager").gameObject;
        soundManager = SoundContainer.GetComponent<SoundManager>();
        Setting();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Setting()
    {
        switch (MyPlayerPrefs.Volume_Click)
        {
            case 1: SettingMenu.transform.Find("SoundOn").gameObject.SetActive(true); SettingMenu.transform.Find("SoundOff").gameObject.SetActive(false); break;
            case 0: SettingMenu.transform.Find("SoundOn").gameObject.SetActive(false); SettingMenu.transform.Find("SoundOff").gameObject.SetActive(true); break;
        }

       /* switch (MyPlayerPrefs.Volume_Bgm)
        {
            case 0: SettingMenu.transform.Find("BgmOn").gameObject.SetActive(true); SettingMenu.transform.Find("BgmOff").gameObject.SetActive(false); break;
            case 1: SettingMenu.transform.Find("BgmOn").gameObject.SetActive(false); SettingMenu.transform.Find("BgmOff").gameObject.SetActive(true); break;
        }*/
    }
#if UNITY_ANDROID
    string leaderboardId = "CggI1cbM_gwQAhAB";
#elif UNITY_IOS
    string leaderboardId = "CggI1cbM_gwQAhAB";
#endif

    public void RankButtonClick()
    {
#if UNITY_ANDROID
        PlayGamesPlatform.Activate();
#endif
        Social.localUser.Authenticate(AuthenticateHandler);

    }

    void AuthenticateHandler(bool isSuccess)
    {
      /**  if (isSuccess)
        {
            int highScore = PlayerPrefs.GetInt("highscore");
           Social.ReportScore((long)highScore, leaderboardId, (bool success) =>
            {
                if (success)
                {
#if UNITY_ANDROID
                    PlayGamesPlatform.Instance.ShowLeaderboardUI(leaderboardId);
#elif UNITY_IOS
                    Social.ShowLeaderboardUI();
#endif
                }
                else
                { //gg
                }

            });
        }
        else
        {
            Debug.Log("Login Failed");
            //login failed
        }**/
    }
}
