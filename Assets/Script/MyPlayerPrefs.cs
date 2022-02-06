using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerPrefs : MonoBehaviour {

    public static int HighScore;
    public static int Volume_Click;
    public static int Volume_BGM;

    // Use this for initialization
    void Awake () {
        HighScore = PlayerPrefs.GetInt("highscore", 0);
        Volume_Click = PlayerPrefs.GetInt("click", 1);
        Volume_BGM = PlayerPrefs.GetInt("bgm", 1);
    }

    public static void SetHighScore(int score)
    {
        HighScore = score;
        PlayerPrefs.SetInt("highscore", HighScore);
    }
    //1 -> on, 0 -> off
    public static void SetVolume_Click(int volume)
    {
        Volume_Click = volume;
        PlayerPrefs.SetInt("click", volume);
    }

    public static void SetVolume_BGM(int volume)
    {
        Volume_BGM = volume;
        PlayerPrefs.SetInt("bgm", volume);
    }
}
