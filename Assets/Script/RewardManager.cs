using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class RewardManager : MonoBehaviour {

    public static bool isSet = false;
    RewardBasedVideoAd rewardBasedVideo;
    [SerializeField] string appId;
    // Use this for initialization
    void Start () {
        if (!isSet)
        {
            MobileAds.Initialize(appId);
            this.rewardBasedVideo = RewardBasedVideoAd.Instance;

            // Called when an ad request has successfully loaded.
            rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
            // Called when an ad request failed to load.
            rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
            // Called when an ad is shown.
            rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
            // Called when the ad starts to play.
            rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
            // Called when the user should be rewarded for watching a video.
            rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
            // Called when the ad is closed.
            rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
            // Called when the ad click caused the user to leave the application.
            rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;

            this.RequestRewardBasedVideo();

        }
	}

    private void RequestRewardBasedVideo()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-7566633670552557/4772220159";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-1853978140041482/8580069815";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create an empty ad request.
        //For Release Version
        //AdRequest request = new AdRequest.Builder().Build();
        //For Test Version
        AdRequest request = new AdRequest.Builder().Build();

        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);
    }

    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardBasedVideoFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)//보상 추가
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardBasedVideoRewarded event received for "
                        + amount.ToString() + " " + type);
        GameController.adcount -= 1;

        GameObject.Find("EventSystem_MakeBlock").GetComponent<makeBlock>().RewardBlock();
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }

    public void ShowRewardAd()
    {
        if (rewardBasedVideo.IsLoaded())
        {
            rewardBasedVideo.Show();
        }
        else
        {
            this.RequestRewardBasedVideo();
        }
    }

}
