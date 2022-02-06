using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;

public class AdmobManager : MonoBehaviour {

    public string android_interstitial_id;
    public string ios_interstitialAdUnitId;
    private InterstitialAd interstitialAd;

    private void Start()
    {
        RequestInterstitialAd();

    }


    private void RequestInterstitialAd()
    {
        string adUnitId = string.Empty;

#if UNITY_ANDROID
        adUnitId = android_interstitial_id;
#elif UNITY_IOS
        adUnitId = ios_interstitialAdUnitId;
#endif

        interstitialAd = new InterstitialAd(adUnitId);
        //For Release Version
        //AdRequest request = new AdRequest.Builder().Build();
        //For Test Version
        AdRequest request = new AdRequest.Builder().Build();

        interstitialAd.LoadAd(request);

        interstitialAd.OnAdClosed += HandleOnInterstitialAdClosed;
    }

    public void HandleOnInterstitialAdClosed(object sender, EventArgs args)
    {
        print("HandleOnInterstitialAdClosed event received.");

        interstitialAd.Destroy();

        RequestInterstitialAd();
    }

    public void ShowInterstitialAd()
    {
        if (!interstitialAd.IsLoaded())
        {
            RequestInterstitialAd();
            return;
        }

        interstitialAd.Show();
    }
}
