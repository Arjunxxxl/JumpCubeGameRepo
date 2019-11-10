using System.Collections;
using UnityEngine;
using GoogleMobileAds.Api;

public class CustomAdManager : MonoBehaviour
{
    float menuButtondelay;
    float inGameMenuDelay;
    float revivalMenuDelay;
    float gameoverMenuDelay;
    

    ButtonClickCommandExecutionDelay buttonClickCommandExecutionDelay;
    CustomBannerAdsManager customBannerAds;
    CustomInterstialAdsManager customInterstialAdsManager;
    CustomRewardingAdsManager customRewardingAdsManager;

    #region SingleTon
    public static CustomAdManager Instance;
    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        customBannerAds = GetComponent<CustomBannerAdsManager>();
        customInterstialAdsManager = GetComponent<CustomInterstialAdsManager>();
        customRewardingAdsManager = GetComponent<CustomRewardingAdsManager>();

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    void Start()
    {
        buttonClickCommandExecutionDelay = ButtonClickCommandExecutionDelay.Instance;

        menuButtondelay = buttonClickCommandExecutionDelay.mainmenuCommandExecutionDelay;
        inGameMenuDelay = buttonClickCommandExecutionDelay.ingameMenuCommandExecutionDelay;
        revivalMenuDelay = buttonClickCommandExecutionDelay.revivalMenuCommandExecutionDelay;
        gameoverMenuDelay = buttonClickCommandExecutionDelay.gameoverMenuCommandExecutionDelay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region BANNER ADS
    public void RequestBannerAds()
    {
        Invoke("RequestBannerAds_Function", menuButtondelay);
    }

    public void RequestBannerAds_PauseMenu()
    {
        Invoke("RequestBannerAds_Function", inGameMenuDelay);
    }

    public void RequestBannerAds_Instantly()
    {
        RequestBannerAds_Function();
    }

    void RequestBannerAds_Function()
    {
        customBannerAds.ShowBannerAds();
    }

    public void DestoyBannerAds()
    {
        Invoke("DestoyBannerAds_Function", menuButtondelay);
    }

    public void DestoryBannerAds_PauseMenu()
    {
        StartCoroutine(DestoryBannerAds_PauseMenu_Coroutine());
    }

    IEnumerator DestoryBannerAds_PauseMenu_Coroutine()
    {
        yield return new WaitForSecondsRealtime(menuButtondelay);
        DestoyBannerAds_Function();
    }

    void DestoyBannerAds_Function()
    {
        customBannerAds.DestroyBanner();
    }

    public void RequestTopBanners_Gameover()
    {
        Invoke("RequestTopBanners_Gameover_Function", revivalMenuDelay);
    }

    void RequestTopBanners_Gameover_Function()
    {
        customBannerAds.ShowTopBannerAds();
    }

    public void DestoyTopBannerAds()
    {
        DestoyTopBannerAds_Function();
    }

    void DestoyTopBannerAds_Function()
    {
        customBannerAds.DestroyTopBanner();
    }
    #endregion

    #region INTERSTIAL ADS
    public void UpdatePlayCount()
    {
        customInterstialAdsManager.UpdateCurrentPlayCount();
    }

    public void ShowInterstitialAds()
    {
        if (Check_To_ShowAds()) 
        {
            customInterstialAdsManager.ShowInterstitialAds();
        }
    }

    public bool Check_To_ShowAds()
    {
        if(customInterstialAdsManager.CurrentPlayCount >= customInterstialAdsManager.PlayCountForInterstialAds)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsInterstitialAdAshoting
    {
        get
        {
            return customInterstialAdsManager._isInterstitialAdShowing;
        }
    }
    #endregion

    #region REWARDING ADS
    public void ShowRewardingAds_Store()
    {
        customRewardingAdsManager.ShowRewardingAds_Store();
    }

    public void ShowRewardingAds_ExtraLife()
    {
        customRewardingAdsManager.ShowRewardingAds_ExtraLife();
    }

    public void ShowRewardingAds_DoubleReward()
    {
        customRewardingAdsManager.ShowRewardingAds_DoubleReward();
    }
    #endregion
}
