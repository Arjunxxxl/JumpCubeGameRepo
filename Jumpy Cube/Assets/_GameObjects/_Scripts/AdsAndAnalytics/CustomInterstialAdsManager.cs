using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class CustomInterstialAdsManager : MonoBehaviour
{
    int playCountForInterstialAds = 2;
    
    public int currentPlayCount;

    [SerializeField]
    bool restartBool;
    [SerializeField]
    bool homeBool;
    [SerializeField]
    bool gamOver_home_Bool;
    [SerializeField]
    bool gamOver_replay_Bool;
    [SerializeField]
    bool levelComplete_home_Bool;
    [SerializeField]
    bool levelComplete_replay_Bool;
    [SerializeField]
    bool levelComplete_next_Bool;

    private InterstitialAd interstitial;

    CustomStrings customStrings;
    GameOverMenu gameOverMenu;
    LevelMenu levelMenu;
    PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        customStrings = CustomStrings.Instance;
        gameOverMenu = GameOverMenu.Instance;
        levelMenu = LevelMenu.Instance;
        pauseMenu = PauseMenu.Instance;
        
        this.RequestInterstitial();

        _isInterstitialAdShowing = false;

        _restartBool = false;
        _homeBool = false;
        _gamOver_home_Bool = false;
        _gamOver_replay_Bool = false;
        _levelComplete_home_Bool = false;
        _levelComplete_replay_Bool = false;
        _levelComplete_next_Bool = false;
    }

    public void UpdateCurrentPlayCount()
    {
        if (!customStrings)
        {
            customStrings = CustomStrings.Instance;
        }

        currentPlayCount = PlayerPrefs.GetInt(customStrings.play_count_for_interstialAds, 0);

        ///
        currentPlayCount++;
        

        Debug.Log("here 4 - " + currentPlayCount);

        if (currentPlayCount < PlayCountForInterstialAds)
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
            //LoadNewInterstitialAd();
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

            if (currentPlayCount >= playCountForInterstialAds)
            {
                currentPlayCount = 0;
            }

            if (!customStrings)
            {
                customStrings = CustomStrings.Instance;
            }

            PlayerPrefs.SetInt(customStrings.play_count_for_interstialAds, currentPlayCount);
        }
        else
        {
            SetCorrectBehaviour();
        }
    }

    public bool _isInterstitialAdShowing { get; set; }
    
    public int PlayCountForInterstialAds
    {
        get
        {
            return playCountForInterstialAds;
        }
    }

    public bool _restartBool { get; set; }
    public bool _homeBool { get; set; }
    public bool _gamOver_home_Bool { get; set; }
    public bool _gamOver_replay_Bool { get; set; }
    public bool _levelComplete_home_Bool { get; set; }
    public bool _levelComplete_replay_Bool { get; set; }
    public bool _levelComplete_next_Bool { get; set; }

    void SetCorrectBehaviour()
    {
        if(_gamOver_home_Bool)
        {
            if (!gameOverMenu)
            {
                gameOverMenu = GameOverMenu.Instance;
            }
            gameOverMenu.HomeButton_InterstitialAdsClosed();
        }
        else if (_gamOver_replay_Bool)
        {
            if (!levelMenu)
            {
                levelMenu = LevelMenu.Instance;
            }
            levelMenu.ReplayButton_InterstitialAdClosed();
        }
        else if (_levelComplete_home_Bool)
        {
            if (!levelMenu)
            {
                levelMenu = LevelMenu.Instance;
            }
            levelMenu.HomeButton_InterstitialAdsClosed();
        }
        else if (_levelComplete_replay_Bool)
        {
            if (!levelMenu)
            {
                levelMenu = LevelMenu.Instance;
            }
            levelMenu.ReplayButton_InterstitialAdClosed();
        }
        else if (_levelComplete_next_Bool)
        {
            if (!levelMenu)
            {
                levelMenu = LevelMenu.Instance;
            }
            levelMenu.NextLevel_InterstitialAdClosed();
        }
        else if (_restartBool)
        {
            if (!pauseMenu)
            {
                pauseMenu = PauseMenu.Instance;
            }
            pauseMenu.RestartGame_InterstitialAdClosed();
        }
        else if (_homeBool)
        {
            if (!pauseMenu)
            {
                pauseMenu = PauseMenu.Instance;
            }
            pauseMenu.HomeButton_InterstitialAdClosed();
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

        interstitial.Destroy();

        SetCorrectBehaviour();
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
    #endregion
}
