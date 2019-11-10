using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class CustomInterstialAdsManager : MonoBehaviour
{
    int playCountForInterstialAds = 2;

    [SerializeField]
    int currentPlayCount;

    private InterstitialAd interstitial;

    CustomStrings customStrings;

    // Start is called before the first frame update
    void Start()
    {
        customStrings = CustomStrings.Instance;

        CurrentPlayCount = PlayerPrefs.GetInt(customStrings.play_count_for_interstialAds, 0);

        this.RequestInterstitial();

        _isInterstitialAdShowing = false;
    }

    public void UpdateCurrentPlayCount()
    {
        if (!customStrings)
        {
            customStrings = CustomStrings.Instance;

            CurrentPlayCount = PlayerPrefs.GetInt(customStrings.play_count_for_interstialAds, 0);
        }

        ///
        CurrentPlayCount++;

        if(currentPlayCount < PlayCountForInterstialAds)
        {
            PlayerPrefs.SetInt(customStrings.play_count_for_interstialAds, currentPlayCount);
        }
        ///

        if (interstitial == null)
        {
            this.RequestInterstitial();
        }
        else
        {
            LoadNewInterstitialAd();
        }
    }

    private void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        InterstitialAdsEvents();

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    private void LoadNewInterstitialAd()
    {// Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void ShowInterstitialAds()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();

            _isInterstitialAdShowing = true;

            if (CurrentPlayCount >= playCountForInterstialAds)
            {
                CurrentPlayCount = 0;
            }

            if (!customStrings)
            {
                customStrings = CustomStrings.Instance;
            }

            PlayerPrefs.SetInt(customStrings.play_count_for_interstialAds, CurrentPlayCount);
        }
    }

    public bool _isInterstitialAdShowing { get; set; }

    public int CurrentPlayCount { get { return currentPlayCount; } set { currentPlayCount = value; } }

    public int PlayCountForInterstialAds
    {
        get
        {
            return playCountForInterstialAds;
        }
    }

    #region InterstitialAds Events
    void InterstitialAdsEvents()
    {
        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
    #endregion
}
