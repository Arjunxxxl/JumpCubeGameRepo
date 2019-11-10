using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class CustomRewardingAdsManager : MonoBehaviour
{
    private RewardedAd rewardedAd_store;
    private RewardedAd rewardedAd_extraLife;
    private RewardedAd rewardedAd_doubleReward;

    bool isStoreAdShowing;
    bool isExtraLifeAdShowing;
    bool isDoubleRewardAdShowing;
    bool isDoubleRewardAdShowing_levelEnd;

    string adUnitId;

    DiamondScore diamondScore;
    Store store;
    RevivePlayer revivePlayer;
    GameOverMenu gameOverMenu;
    InGameMenu inGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        diamondScore = DiamondScore.Instance;
        store = Store.Instance;
        revivePlayer = RevivePlayer.Instance;
        gameOverMenu = GameOverMenu.Instance;
        inGameMenu = InGameMenu.Instance;

        adUnitId = "ca-app-pub-3940256099942544/5224354917";

        rewardedAd_store = RequestRewardingAds(adUnitId);
        rewardedAd_extraLife = RequestRewardingAds(adUnitId);
        rewardedAd_doubleReward = RequestRewardingAds(adUnitId);

        isStoreAdShowing = false;
        isExtraLifeAdShowing = false;
        isDoubleRewardAdShowing = false;
        isDoubleRewardAdShowing_levelEnd = false;
    }

    private RewardedAd RequestRewardingAds(string adUnitId)
    {
        RewardedAd rewardedAd = new RewardedAd(adUnitId);

        // Called when an ad request has successfully loaded.
        rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        LoadRewardingAds(rewardedAd);

        return rewardedAd;
    }

    void LoadRewardingAds(RewardedAd rewardedAd)
    {
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        rewardedAd.LoadAd(request);
    }

    public void ShowRewardingAds_Store()
    {
        if (this.rewardedAd_store.IsLoaded())
        {
            isStoreAdShowing = true;
            this.rewardedAd_store.Show();
        }
    }

    public void ShowRewardingAds_ExtraLife()
    {
        if (this.rewardedAd_extraLife.IsLoaded())
        {
            isExtraLifeAdShowing = true;
            this.rewardedAd_extraLife.Show();
        }
    }

    public void ShowRewardingAds_DoubleReward()
    {
        if (this.rewardedAd_doubleReward.IsLoaded())
        {
            isDoubleRewardAdShowing = true;
            this.rewardedAd_doubleReward.Show();
        }
    }

    public void ShowRewardingAds_DoubleReward_LevelEnd()
    {
        if (this.rewardedAd_doubleReward.IsLoaded())
        {
            isDoubleRewardAdShowing_levelEnd = true;
            this.rewardedAd_doubleReward.Show();
        }
    }

    #region RewardingAds Events

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        
        if(isStoreAdShowing)
        {
            rewardedAd_store = RequestRewardingAds(adUnitId);

            isStoreAdShowing = false;
        }

        if (isExtraLifeAdShowing)
        {
            rewardedAd_extraLife = RequestRewardingAds(adUnitId);
            
            isExtraLifeAdShowing = false;
        }

        if(isDoubleRewardAdShowing)
        {
            rewardedAd_doubleReward = RequestRewardingAds(adUnitId);
            
            isDoubleRewardAdShowing = false;
        }

        if (isDoubleRewardAdShowing_levelEnd)
        {
            rewardedAd_doubleReward = RequestRewardingAds(adUnitId);

            isDoubleRewardAdShowing_levelEnd = false;
        }
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);

        if (!diamondScore)
        {
            diamondScore = DiamondScore.Instance;
        }

        if (isStoreAdShowing)
        {
            if (!store)
            {
                store = Store.Instance;
            }

            diamondScore.SaveDiamondsCollected(100, true);

            store.ownedDiamonds = diamondScore.GetDiamonds();
            store.ownedDiamondTxt.text = store.ownedDiamonds + ""; 
        }

        if (isExtraLifeAdShowing)
        {
            if (!revivePlayer)
            {
                revivePlayer = RevivePlayer.Instance;
            }

            revivePlayer.ReviePlayerFunction();
        }

        if(isDoubleRewardAdShowing)
        {
            if (!revivePlayer) { revivePlayer = RevivePlayer.Instance; }
            if (!gameOverMenu) { gameOverMenu = GameOverMenu.Instance; }

            gameOverMenu.disableWatchAdsPannel_button.SetActive(true);
            gameOverMenu.disableWatchAdsPannel.SetActive(true);

            diamondScore.SaveDiamondsCollected(revivePlayer.currentDiamonds, true);
            
            revivePlayer.currentDiamondsTxt.text = revivePlayer.currentDiamonds * 2 + " ";
            
        }

        if (isDoubleRewardAdShowing_levelEnd)
        {
            if (!inGameMenu)
            {
                inGameMenu = InGameMenu.Instance;
            }

            inGameMenu.levelEnd_disableWatchAdsPannel_button.SetActive(true);
            inGameMenu.levelEnd_disableWatchAdsPannel.SetActive(true);

            diamondScore.SaveDiamondsCollected(inGameMenu.currentDiamonds, true);

            inGameMenu.diamondsTxt.text = inGameMenu.currentDiamonds * 2 + " ";

        }
    }
    #endregion
}
