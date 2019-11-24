using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class CustomBannerAdsManager : MonoBehaviour
{
    BannerView bannerView, bannerView_top;
    string appId;
    string adUnitId;

    bool showBannerAds, showTopBannerAds;

    CustomAnalytics customAnalytics;
    
    // Start is called before the first frame update
    void Start()
    {
        customAnalytics = CustomAnalytics.Instance;

        appId = "ca-app-pub-3940256099942544~3347511713";
        adUnitId = "ca-app-pub-3940256099942544/6300978111";

        MobileAds.Initialize(appId);

        showBannerAds = false;
        showTopBannerAds = false;

        this.RequestBanner();
        this.RequestTopBanners();
    }

    void RequestBanner()
    {
        adUnitId = "ca-app-pub-3940256099942544/6300978111";

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        BannerAdsEvents();

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);

        bannerView.Hide();
    }

    public void ShowBannerAds()
    {
        showBannerAds = true;

        if (bannerView == null)
        {
            this.RequestBanner();
        }
        else
        {
            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();

            // Load the banner with the request.
            this.bannerView.LoadAd(request);
        }

        customAnalytics.BannerAdsShown();

        bannerView.Show();
    }

    public void DestroyBanner()
    {
        showBannerAds = false;

        if (bannerView != null)
        {
            bannerView.Hide();
            //bannerView.Destroy();
        }
    }

    void RequestTopBanners()
    {
        adUnitId = "ca-app-pub-3940256099942544/6300978111";

        // Create a 320x50 banner at the top of the screen.
        this.bannerView_top = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);

        BannerAdsEvents_Top();

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView_top.LoadAd(request);

        bannerView_top.Hide();
    }

    public void ShowTopBannerAds()
    {
        showTopBannerAds = true;

        if (bannerView_top == null)
        {
            this.RequestTopBanners();
        }
        else
        {
            // Create an empty ad request.
            //AdRequest request = new AdRequest.Builder().Build();

            // Load the banner with the request.
            //this.bannerView_top.LoadAd(request);
        }

        bannerView_top.Show();
    }

    public void DestroyTopBanner()
    {
        showTopBannerAds = false;

        if (bannerView_top != null)
        {
            bannerView_top.Hide();
            bannerView_top.Destroy();
        }

        if (bannerView != null)
        {
            bannerView.Hide();
            bannerView.Destroy();
        }
    }

    #region BANNER ADS EVENTS
    void BannerAdsEvents()
    {
        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
    }

    void BannerAdsEvents_Top()
    {
        // Called when an ad request has successfully loaded.
        this.bannerView_top.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView_top.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView_top.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView_top.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerView_top.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
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

        customAnalytics.BannerAdsOpened();
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
