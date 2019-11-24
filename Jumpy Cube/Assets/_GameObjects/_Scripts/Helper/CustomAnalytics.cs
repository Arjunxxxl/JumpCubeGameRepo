using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class CustomAnalytics : MonoBehaviour
{
    #region MAIN MENU STRS
    string GAME_PLAYED_STR = "Game played";
    string STORE_VISITED = "STORE VISITED";
    string STATS_VISITED = "STATS VISITED";
    string SETTINGS_VISITED = "SETTINGS VISITED";
    string GOOGLE_PLAY_VISITED_HOME = "GOOGLE PLAY VISITED HOME";
    string GAME_SHARED_HOME = "GAME SHARE HOME";
    string NOADS_CLICK_HOME = "NO ADS CLICKED HOME";
    #endregion

    #region STATS STRS
    string STATS_SHARED = "STATS SHARED";
    string LEADERBOARD_OPEND = "LEADER BOARD OPENED";
    #endregion

    #region REVIVAL STRS
    string REVIVE_REQUESTED = "REVIVE REQUESTED";
    string REVIVE_DONE = "REVIVE DONE";
    string REVIVE_OPEN = "REVIVE OPEN";

    string DIAMOND_PLAYER_REVIVE = "DIAMOND PLAYER REVIVE";
    #endregion

    #region GAME OVER STR
    string REWARD_DOUBLED_REQUESTED = "REWARD DOUBLED REQUESTED";
    string REWARD_DOUBLED_DONE = "REWARD DOUBLED DONE";
    string REWARD_DOUBLE_OPEN = "REWARD DOUBLE OPEN";

    string GAMEOVER_SHARE = "GAME OVER SHARE";

    string PLAYER_DEATH_STR = "PLAYER DEATH";
    #endregion

    #region LEVEL OVER STR
    public string LEVEL_OVER_SHARE = "LEVEL OVER SHARE";
    #endregion
    
    #region INTERSTITIAL ADS DATA
    string INTERSTITIAL_REQUESTED = "INTERSTITIAL REQUESTED";
    string INTERSTITIAL_SHOW = "INTERSTITIAL SHOW";
    string INTERSTITIAL_OPEN = "INTERSTITIAL OPEN";
    #endregion

    #region BANNER ADS DATA
    string BANNER_ADS_SHOWN = "BANNER ADS SHOWN";
    string BANNER_ADS_OPENED = "BANNER ADS OPENED";
    #endregion

    #region STORE MENU STRS
    string FREE_DIAMONDS_REQUESTED = "FREE DIAMONDS REQUESTED";
    string FREE_DIAMONDS_DONE = "FREE DIAMONDS DONE";
    string FREE_DIAMONDS_OPEN = "FREE DIAMONDS OPEN";

    string FACEBOOK_VISISTED = "FACEBOOK VISITED";
    string INSTAGRAM_VISITED = "INSTAGRAM VISITED";
    string YOUTUBE_VISISTED = "YOUTUBE VISITED";
    string GOOGLE_PLAY_VISITED_STORE = "GOOGLE PLAY VISISTED STORE";
    string GAME_SHARED_STORE = "GAME SHARE STORE";

    string NO_ADS_STORE = "NO ADS STORE";
    string NO_ADS_EXTRA = "NO ADS EXTRA";
    string PACK1 = "PACK 1";
    string PACK2 = "PACK 2";
    string PACK3 = "PACK3";

    string WORLD_UNLOCKED = "WORLD UNLOCKED";
    string COMMON_CUBE_UNLOCKED = "COMMON CUBE UNLOCKED";
    string RARE_CUBE_UNLOCKED = "RARE CUBE UNLOCKED";
    string LEGENDARY_CUBE_UNLOCKED = "LEGENDARY CUBE UNLOCKED";
    string MISSION_CUBE_UNLOCKED = "MISSION CUBE UNLOCKED";
    #endregion

    #region LEVEL MENU STRS
    string LEVEL = "LEVEL ";
    string correctLevel;
    #endregion

    #region SingleTon
    public static CustomAnalytics Instance;
    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    /*\---------------------------------------------------------------------------------------------------\*/

    #region MAIN MENU
    public void UpdatePlayCount()
    {
        Analytics.CustomEvent(GAME_PLAYED_STR);
    }
    
    public void StoreVisited()
    {
        Analytics.CustomEvent(STORE_VISITED);
    }

    public void Stats_Visited()
    {
        Analytics.CustomEvent(STATS_VISITED);
    }

    public void Settings_Visited()
    {
        Analytics.CustomEvent(SETTINGS_VISITED);
    }

    public void GooglePlayerVisited_Home()
    {
        Analytics.CustomEvent(GOOGLE_PLAY_VISITED_HOME);
    }

    public void GameShared_Home()
    {
        Analytics.CustomEvent(GAME_SHARED_HOME);
    }

    public void NoAdsClicked_Home()
    {
        Analytics.CustomEvent(NOADS_CLICK_HOME);
    }
    #endregion

    #region STATS MENU
    public void StatsShared()
    {
        Analytics.CustomEvent(STATS_SHARED);
    }

    public void Leaderboard_Opened()
    {
        Analytics.CustomEvent(LEADERBOARD_OPEND);
    }
    #endregion

    #region REVIVAL MENU
    public void DiamondRevive()
    {
        Analytics.CustomEvent(DIAMOND_PLAYER_REVIVE);
    }

    public void Revive_Requested()
    {
        Analytics.CustomEvent(REVIVE_REQUESTED);
    }

    public void Revive_Done()
    {
        Analytics.CustomEvent(REVIVE_DONE);
    }

    public void Revive_Open()
    {
        Analytics.CustomEvent(REVIVE_OPEN);
    }
    #endregion

    #region GAME OVER MENU
    public void UpdatePlayerDeath()
    {
        Analytics.CustomEvent(PLAYER_DEATH_STR);
    }

    public void ScoreShared_Gameover()
    {
        Analytics.CustomEvent(GAMEOVER_SHARE);
    }

    public void RewardDoubled_Requested()
    {
        Analytics.CustomEvent(REWARD_DOUBLED_REQUESTED);
    }

    public void RewardDoubled_Done()
    {
        Analytics.CustomEvent(REWARD_DOUBLED_DONE);
    }

    public void RewardDoubled_Open()
    {
        Analytics.CustomEvent(REWARD_DOUBLE_OPEN);
    }
    #endregion

    #region LEVEL OVER MENU
    public void ScoreShared_Levelover()
    {
        Analytics.CustomEvent(LEVEL_OVER_SHARE);
    }
    #endregion

    #region INTERSTITAL FUNCTIONS
    public void IntestitialRequested()
    {
        Analytics.CustomEvent(INTERSTITIAL_REQUESTED);
    }

    public void InterstitialAdsShown()
    {
        Analytics.CustomEvent(INTERSTITIAL_SHOW);
    }

    public void InterstitialAdsOpen()
    {
        Analytics.CustomEvent(INTERSTITIAL_OPEN);
    }
    #endregion

    #region BANNER ADS FUNCTIONS
    public void BannerAdsShown()
    {
        Analytics.CustomEvent(BANNER_ADS_SHOWN);
    }

    public void BannerAdsOpened()
    {
        Analytics.CustomEvent(BANNER_ADS_OPENED);
    }
    #endregion

    #region STORE MENU
    public void FreeDiamonds_Requested()
    {
        Analytics.CustomEvent(FREE_DIAMONDS_REQUESTED);
    }

    public void FreeDiamonds_Open()
    {
        Analytics.CustomEvent(FREE_DIAMONDS_OPEN);
    }

    public void FreeDiamonds_Done()
    {
        Analytics.CustomEvent(FREE_DIAMONDS_DONE);
    }

    public void Facebook_Visited()
    {
        Analytics.CustomEvent(FACEBOOK_VISISTED);
    }

    public void Instagram_Visited()
    {
        Analytics.CustomEvent(INSTAGRAM_VISITED);
    }

    public void Youtube_Visited()
    {
        Analytics.CustomEvent(YOUTUBE_VISISTED);
    }

    public void Google_Play_Visited_Store()
    {
        Analytics.CustomEvent(GOOGLE_PLAY_VISITED_STORE);
    }

    public void GameShare_Store()
    {
        Analytics.CustomEvent(GAME_SHARED_STORE);
    }

    public void NoAds_Store()
    {
        Analytics.CustomEvent(NO_ADS_STORE);
    }

    public void NoAds_Extra()
    {
        Analytics.CustomEvent(NO_ADS_EXTRA);
    }

    public void Pack1()
    {
        Analytics.CustomEvent(PACK1);
    }

    public void Pack2()
    {
        Analytics.CustomEvent(PACK2);
    }

    public void Pack3()
    {
        Analytics.CustomEvent(PACK3);
    }

    public void WorldUnlocked()
    {
        Analytics.CustomEvent(WORLD_UNLOCKED);
    }

    public void CommonCubeUnlocked()
    {
        Analytics.CustomEvent(COMMON_CUBE_UNLOCKED);
    }

    public void RareCubeUnlocked()
    {
        Analytics.CustomEvent(RARE_CUBE_UNLOCKED);
    }

    public void LegendaryCubeUnlocked()
    {
        Analytics.CustomEvent(LEGENDARY_CUBE_UNLOCKED);
    }

    public void MissionCubeUnlocked()
    {
        Analytics.CustomEvent(MISSION_CUBE_UNLOCKED);
    }
    #endregion

    #region LEVEL COMPLETE DATA
    public void UpdateLevelComplete(int levelNo)
    {
        correctLevel = LEVEL + levelNo;
        Analytics.CustomEvent(correctLevel);
    }
    #endregion
}
