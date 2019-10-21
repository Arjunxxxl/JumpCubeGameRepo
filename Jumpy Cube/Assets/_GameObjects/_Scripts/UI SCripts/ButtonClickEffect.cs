using UnityEngine;

public class ButtonClickEffect : MonoBehaviour
{
    public Vector3 originalSize = new Vector3(1, 1, 1);
    public Vector3 pressedSize = new Vector3(0.85f, 0.85f, 1);

    #region IN GAME MENU BUTTONS
    [Header("In Game Menu Buttons")]
    public Transform pauseButton;
    #endregion

    #region PAUSE GAME MENU
    [Header("Pause Menu")]
    public Transform playButton;
    public Transform homeButton;
    public Transform restartButton;
    #endregion

    #region REVIVAL MENU BUTTONS
    [Header("Revial Menu Buttons")]
    public Transform revival_WatchAdsButtons;
    public Transform useDiamondsButton;
    public Transform skipButton;
    #endregion

    #region LEVEL MENU
    [System.Serializable]
    public class LevelButtons
    {
        public Transform l1;
        public Transform l2;
        public Transform l3;
        public Transform l4;
        public Transform l5;
        public Transform l6;
        public Transform l7;
        public Transform l8;
        public Transform l9;
        [Space]
        public Transform l10;
        public Transform l11;
        public Transform l12;
        public Transform l13;
        public Transform l14;
        public Transform l15;
        public Transform l16;
        public Transform l17;
        public Transform l18;
        [Space]
        public Transform l19;
        public Transform l20;
        public Transform l21;
        public Transform l22;
        public Transform l23;
        public Transform l24;
        public Transform l25;
        public Transform l26;
        public Transform l27;
        [Space]
        public Transform l28;
        public Transform l29;
        public Transform l30;
        public Transform l31;
        public Transform l32;
        public Transform l33;
        public Transform l34;
        public Transform l35;
        public Transform l36;
        [Space]
        public Transform l37;
        public Transform l38;
        public Transform l39;
        public Transform l40;
        public Transform l41;
        public Transform l42;
        public Transform l43;
        public Transform l44;
        public Transform l45;
        [Space]
        public Transform l46;
        public Transform l47;
        public Transform l48;
        public Transform l49;
        public Transform l50;
        public Transform l51;
        public Transform l52;
        public Transform l53;
        public Transform l54;
    }

    [Header("LEVELS BUTTONS")]
    [SerializeField]
    public LevelButtons levelButtons;
    #endregion

    #region GAMEOVER MENU BUTTONS
    [Header("Gameover Menu Buttons")]
    public Transform gameover_HomeButton;
    public Transform gameover_ShareButton;
    public Transform gameover_WatchAdsButton;
    public Transform gameover_levelModeHomeButton;
    public Transform gameover_levelModeReplayButton;
    #endregion

    #region LEVEL COMPLETE BUTTONS
    [Header("Level complete buttons")]
    public Transform levelCompleteShareButton;
    public Transform levelCompleteWatchAdsButon;
    public Transform levelCompleteReplayButton;
    public Transform levelCompleteHomeButton;
    public Transform levelCompleteNextLevelButton;
    public Transform levelCompleteReplayLastLevelButton;
    public Transform levelCompleteHomeLastLevelButton;
    #endregion

    #region HOME MENUS BUTTONS
    [Header("Menus button")]
    public Transform storeButton;
    public Transform statsButton;
    public Transform settingsButton;
    public Transform levelButton;
    public Transform rateButton;
    public Transform shareButton;
    public Transform noAdsButton;
    #endregion

    #region BACK BUTTONS
    [Header("Back Button")]
    public Transform storeBack;
    public Transform statsBack;
    public Transform settingsBack1;
    public Transform levelBack;
    #endregion

    #region SETTINGS MENU BUTTONS
    [Header("Settings Buttons")]
    public Transform soundButton;
    public Transform vibrationButton;
    public Transform highQualityButton;
    public Transform privatePolicyButton;
    public Transform restorePurchaseButton;
    public Transform studioButton;
    #endregion

    #region STATS MENU BUTTONS
    [Header("Stats Buttons")]
    public Transform leaderBoardButton;
    public Transform statsShareButton;
    #endregion

    #region STORE LEFT RIGHT ARROW
    [Header("Store Left Right Arrow")]
    public Transform store_left_arrow;
    public Transform store_right_arrow;
    #endregion

    #region STORE PANNEL 1
    [Header("Store Pannel 1")]
    public Transform watchAdsButton;
    public Transform rateStoreButton;
    public Transform facebookButton;
    public Transform instagramButton;
    public Transform youtubeButton;
    public Transform shareStoreButton;
    public Transform buyNoAdsButton;
    public Transform buyNoAdsExtraButton;
    public Transform packButton_1;
    public Transform packButton_2;
    public Transform packButton_3;
    #endregion

    #region STORE PANNEL 2
    [Header("Store Pannel 2")]
    public Transform pannel2_button1;
    public Transform pannel2_button2;
    public Transform pannel2_button3;
    public Transform pannel2_button4;
    public Transform pannel2_button5;
    public Transform pannel2_button6;
    public Transform pannel2_button7;
    public Transform pannel2_button8;
    public Transform pannel2_button9;
    #endregion

    #region STORE PANNEL 3
    [Header("Store Pannel 3")]
    public Transform pannel3_button1;
    public Transform pannel3_button2;
    public Transform pannel3_button3;
    public Transform pannel3_button4;
    public Transform pannel3_button5;
    public Transform pannel3_button6;
    public Transform pannel3_button7;
    public Transform pannel3_button8;
    public Transform pannel3_button9;
    #endregion

    #region STORE PANNEL 4
    [Header("Store Pannel 4")]
    public Transform pannel4_button1;
    public Transform pannel4_button2;
    public Transform pannel4_button3;
    public Transform pannel4_button4;
    public Transform pannel4_button5;
    public Transform pannel4_button6;
    public Transform pannel4_button7;
    public Transform pannel4_button8;
    public Transform pannel4_button9;
    #endregion

    #region STORE PANNEL 5
    [Header("Store Pannel 5")]
    public Transform pannel5_button1;
    public Transform pannel5_button2;
    public Transform pannel5_button3;
    public Transform pannel5_button4;
    public Transform pannel5_button5;
    public Transform pannel5_button6;
    public Transform pannel5_button7;
    public Transform pannel5_button8;
    public Transform pannel5_button9;
    #endregion

    #region STORE PANNEL 6
    [Header("Store Pannel 6")]
    public Transform pannel6_button1;
    public Transform pannel6_button2;
    public Transform pannel6_button3;
    public Transform pannel6_button4;
    public Transform pannel6_button5;
    public Transform pannel6_button6;
    #endregion

    /// <summary>
    /// ***        AFTER THIS THERE ARE FUNCTIONS FOR BUTTONS        *** ///
    /// </summary>

    #region IN GAME BUTTONS
    public void InGameMenu_PauseButtonPressed()
    {
        pauseButton.localScale = pressedSize;
    }

    public void InGameMenu_PauseButtonReleased()
    {
        pauseButton.localScale = originalSize;
    }
    #endregion

    #region PAUSE BUTTONS
    public void PauseMenu_PlayButtonPressed()
    {
        playButton.localScale = pressedSize;
    }

    public void PauseMenu_PlayButtonreleased()
    {
        playButton.localScale = originalSize;
    }

    public void PauseMenu_HomeButtonPressed()
    {
        homeButton.localScale = pressedSize;
    }

    public void PauseMenu_HomeButtonreleased()
    {
        homeButton.localScale = originalSize;
    }

    public void PauseMenu_RestartButtonPressed()
    {
        restartButton.localScale = pressedSize;
    }

    public void PauseMenu_RestartButtonreleased()
    {
        restartButton.localScale = originalSize;
    }
    #endregion

    #region REVIVAL BUTTONS
    public void RevivalMenu_WatchAdsButtonPressed()
    {
        revival_WatchAdsButtons.localScale = pressedSize;
    }

    public void RevivalMenu_WatchAdsButtonReleased()
    {
        revival_WatchAdsButtons.localScale = originalSize;
    }

    public void RevivalMenu_UseDiamondsButtonPressed()
    {
        useDiamondsButton.localScale = pressedSize;
    }

    public void RevivalMenu_UseDiamondsButtonReleased()
    {
        useDiamondsButton.localScale = originalSize;
    }

    public void RevivalMenu_SkipButtonPressed()
    {
        skipButton.localScale = pressedSize;
    }

    public void RevivalMenu_SkipButtonReleased()
    {
        skipButton.localScale = originalSize;
    }
    #endregion

    #region LEVEL MENU BUTTONS
    public void LevelButton_1_1_Pressed()
    {
        levelButtons.l1.localScale = pressedSize;
    }

    public void LevelButton_1_1_Released()
    {
        levelButtons.l1.localScale = originalSize;
    }

    public void LevelButton_1_2_Pressed()
    {
        levelButtons.l2.localScale = pressedSize;
    }

    public void LevelButton_1_2_Released()
    {
        levelButtons.l2.localScale = originalSize;
    }

    public void LevelButton_1_3_Pressed()
    {
        levelButtons.l3.localScale = pressedSize;
    }

    public void LevelButton_1_3_Released()
    {
        levelButtons.l3.localScale = originalSize;
    }

    public void LevelButton_1_4_Pressed()
    {
        levelButtons.l4.localScale = pressedSize;
    }

    public void LevelButton_1_4_Released()
    {
        levelButtons.l4.localScale = originalSize;
    }

    public void LevelButton_1_5_Pressed()
    {
        levelButtons.l5.localScale = pressedSize;
    }

    public void LevelButton_1_5_Released()
    {
        levelButtons.l5.localScale = originalSize;
    }

    public void LevelButton_1_6_Pressed()
    {
        levelButtons.l6.localScale = pressedSize;
    }

    public void LevelButton_1_6_Released()
    {
        levelButtons.l6.localScale = originalSize;
    }

    public void LevelButton_1_7_Pressed()
    {
        levelButtons.l7.localScale = pressedSize;
    }

    public void LevelButton_1_7_Released()
    {
        levelButtons.l7.localScale = originalSize;
    }

    public void LevelButton_1_8_Pressed()
    {
        levelButtons.l8.localScale = pressedSize;
    }

    public void LevelButton_1_8_Released()
    {
        levelButtons.l8.localScale = originalSize;
    }

    public void LevelButton_1_9_Pressed()
    {
        levelButtons.l9.localScale = pressedSize;
    }

    public void LevelButton_1_9_Released()
    {
        levelButtons.l9.localScale = originalSize;
    }



    public void LevelButton_2_1_Pressed()
    {
        levelButtons.l10.localScale = pressedSize;
    }

    public void LevelButton_2_1_Released()
    {
        levelButtons.l10.localScale = originalSize;
    }

    public void LevelButton_2_2_Pressed()
    {
        levelButtons.l11.localScale = pressedSize;
    }

    public void LevelButton_2_2_Released()
    {
        levelButtons.l11.localScale = originalSize;
    }

    public void LevelButton_2_3_Pressed()
    {
        levelButtons.l12.localScale = pressedSize;
    }

    public void LevelButton_2_3_Released()
    {
        levelButtons.l12.localScale = originalSize;
    }

    public void LevelButton_2_4_Pressed()
    {
        levelButtons.l13.localScale = pressedSize;
    }

    public void LevelButton_2_4_Released()
    {
        levelButtons.l13.localScale = originalSize;
    }

    public void LevelButton_2_5_Pressed()
    {
        levelButtons.l14.localScale = pressedSize;
    }

    public void LevelButton_2_5_Released()
    {
        levelButtons.l14.localScale = originalSize;
    }

    public void LevelButton_2_6_Pressed()
    {
        levelButtons.l15.localScale = pressedSize;
    }

    public void LevelButton_2_6_Released()
    {
        levelButtons.l15.localScale = originalSize;
    }

    public void LevelButton_2_7_Pressed()
    {
        levelButtons.l16.localScale = pressedSize;
    }

    public void LevelButton_2_7_Released()
    {
        levelButtons.l16.localScale = originalSize;
    }

    public void LevelButton_2_8_Pressed()
    {
        levelButtons.l17.localScale = pressedSize;
    }

    public void LevelButton_2_8_Released()
    {
        levelButtons.l17.localScale = originalSize;
    }

    public void LevelButton_2_9_Pressed()
    {
        levelButtons.l18.localScale = pressedSize;
    }

    public void LevelButton_2_9_Released()
    {
        levelButtons.l18.localScale = originalSize;
    }



    public void LevelButton_3_1_Pressed()
    {
        levelButtons.l19.localScale = pressedSize;
    }

    public void LevelButton_3_1_Released()
    {
        levelButtons.l19.localScale = originalSize;
    }

    public void LevelButton_3_2_Pressed()
    {
        levelButtons.l20.localScale = pressedSize;
    }

    public void LevelButton_3_2_Released()
    {
        levelButtons.l20.localScale = originalSize;
    }

    public void LevelButton_3_3_Pressed()
    {
        levelButtons.l21.localScale = pressedSize;
    }

    public void LevelButton_3_3_Released()
    {
        levelButtons.l21.localScale = originalSize;
    }

    public void LevelButton_3_4_Pressed()
    {
        levelButtons.l22.localScale = pressedSize;
    }

    public void LevelButton_3_4_Released()
    {
        levelButtons.l22.localScale = originalSize;
    }

    public void LevelButton_3_5_Pressed()
    {
        levelButtons.l23.localScale = pressedSize;
    }

    public void LevelButton_3_5_Released()
    {
        levelButtons.l23.localScale = originalSize;
    }

    public void LevelButton_3_6_Pressed()
    {
        levelButtons.l24.localScale = pressedSize;
    }

    public void LevelButton_3_6_Released()
    {
        levelButtons.l24.localScale = originalSize;
    }

    public void LevelButton_3_7_Pressed()
    {
        levelButtons.l25.localScale = pressedSize;
    }

    public void LevelButton_3_7_Released()
    {
        levelButtons.l25.localScale = originalSize;
    }

    public void LevelButton_3_8_Pressed()
    {
        levelButtons.l26.localScale = pressedSize;
    }

    public void LevelButton_3_8_Released()
    {
        levelButtons.l26.localScale = originalSize;
    }

    public void LevelButton_3_9_Pressed()
    {
        levelButtons.l27.localScale = pressedSize;
    }

    public void LevelButton_3_9_Released()
    {
        levelButtons.l27.localScale = originalSize;
    }



    public void LevelButton_4_1_Pressed()
    {
        levelButtons.l28.localScale = pressedSize;
    }

    public void LevelButton_4_1_Released()
    {
        levelButtons.l28.localScale = originalSize;
    }

    public void LevelButton_4_2_Pressed()
    {
        levelButtons.l29.localScale = pressedSize;
    }

    public void LevelButton_4_2_Released()
    {
        levelButtons.l29.localScale = originalSize;
    }

    public void LevelButton_4_3_Pressed()
    {
        levelButtons.l30.localScale = pressedSize;
    }

    public void LevelButton_4_3_Released()
    {
        levelButtons.l30.localScale = originalSize;
    }

    public void LevelButton_4_4_Pressed()
    {
        levelButtons.l31.localScale = pressedSize;
    }

    public void LevelButton_4_4_Released()
    {
        levelButtons.l31.localScale = originalSize;
    }

    public void LevelButton_4_5_Pressed()
    {
        levelButtons.l32.localScale = pressedSize;
    }

    public void LevelButton_4_5_Released()
    {
        levelButtons.l32.localScale = originalSize;
    }

    public void LevelButton_4_6_Pressed()
    {
        levelButtons.l33.localScale = pressedSize;
    }

    public void LevelButton_4_6_Released()
    {
        levelButtons.l33.localScale = originalSize;
    }

    public void LevelButton_4_7_Pressed()
    {
        levelButtons.l34.localScale = pressedSize;
    }

    public void LevelButton_4_7_Released()
    {
        levelButtons.l34.localScale = originalSize;
    }

    public void LevelButton_4_8_Pressed()
    {
        levelButtons.l35.localScale = pressedSize;
    }

    public void LevelButton_4_8_Released()
    {
        levelButtons.l35.localScale = originalSize;
    }

    public void LevelButton_4_9_Pressed()
    {
        levelButtons.l36.localScale = pressedSize;
    }

    public void LevelButton_4_9_Released()
    {
        levelButtons.l36.localScale = originalSize;
    }



    public void LevelButton_5_1_Pressed()
    {
        levelButtons.l37.localScale = pressedSize;
    }

    public void LevelButton_5_1_Released()
    {
        levelButtons.l37.localScale = originalSize;
    }

    public void LevelButton_5_2_Pressed()
    {
        levelButtons.l38.localScale = pressedSize;
    }

    public void LevelButton_5_2_Released()
    {
        levelButtons.l38.localScale = originalSize;
    }

    public void LevelButton_5_3_Pressed()
    {
        levelButtons.l39.localScale = pressedSize;
    }

    public void LevelButton_5_3_Released()
    {
        levelButtons.l39.localScale = originalSize;
    }

    public void LevelButton_5_4_Pressed()
    {
        levelButtons.l40.localScale = pressedSize;
    }

    public void LevelButton_5_4_Released()
    {
        levelButtons.l40.localScale = originalSize;
    }

    public void LevelButton_5_5_Pressed()
    {
        levelButtons.l41.localScale = pressedSize;
    }

    public void LevelButton_5_5_Released()
    {
        levelButtons.l41.localScale = originalSize;
    }

    public void LevelButton_5_6_Pressed()
    {
        levelButtons.l42.localScale = pressedSize;
    }

    public void LevelButton_5_6_Released()
    {
        levelButtons.l42.localScale = originalSize;
    }

    public void LevelButton_5_7_Pressed()
    {
        levelButtons.l43.localScale = pressedSize;
    }

    public void LevelButton_5_7_Released()
    {
        levelButtons.l43.localScale = originalSize;
    }

    public void LevelButton_5_8_Pressed()
    {
        levelButtons.l44.localScale = pressedSize;
    }

    public void LevelButton_5_8_Released()
    {
        levelButtons.l44.localScale = originalSize;
    }

    public void LevelButton_5_9_Pressed()
    {
        levelButtons.l45.localScale = pressedSize;
    }

    public void LevelButton_5_9_Released()
    {
        levelButtons.l45.localScale = originalSize;
    }



    public void LevelButton_6_1_Pressed()
    {
        levelButtons.l46.localScale = pressedSize;
    }

    public void LevelButton_6_1_Released()
    {
        levelButtons.l46.localScale = originalSize;
    }

    public void LevelButton_6_2_Pressed()
    {
        levelButtons.l47.localScale = pressedSize;
    }

    public void LevelButton_6_2_Released()
    {
        levelButtons.l47.localScale = originalSize;
    }

    public void LevelButton_6_3_Pressed()
    {
        levelButtons.l48.localScale = pressedSize;
    }

    public void LevelButton_6_3_Released()
    {
        levelButtons.l48.localScale = originalSize;
    }

    public void LevelButton_6_4_Pressed()
    {
        levelButtons.l49.localScale = pressedSize;
    }

    public void LevelButton_6_4_Released()
    {
        levelButtons.l49.localScale = originalSize;
    }

    public void LevelButton_6_5_Pressed()
    {
        levelButtons.l50.localScale = pressedSize;
    }

    public void LevelButton_6_5_Released()
    {
        levelButtons.l50.localScale = originalSize;
    }

    public void LevelButton_6_6_Pressed()
    {
        levelButtons.l51.localScale = pressedSize;
    }

    public void LevelButton_6_6Released()
    {
        levelButtons.l51.localScale = originalSize;
    }

    public void LevelButton_6_7_Pressed()
    {
        levelButtons.l52.localScale = pressedSize;
    }

    public void LevelButton_6_7_Released()
    {
        levelButtons.l52.localScale = originalSize;
    }

    public void LevelButton_6_8_Pressed()
    {
        levelButtons.l53.localScale = pressedSize;
    }

    public void LevelButton_6_8_Released()
    {
        levelButtons.l53.localScale = originalSize;
    }

    public void LevelButton_6_9_Pressed()
    {
        levelButtons.l54.localScale = pressedSize;
    }

    public void LevelButton_6_9_Released()
    {
        levelButtons.l54.localScale = originalSize;
    }
    #endregion

    #region GAMEOVER BUTTONS
    public void GameoverMenu_WatchAdsButtonPressed()
    {
        gameover_WatchAdsButton.localScale = pressedSize;
    }

    public void GameoverMenu_WatchAdsButtonReleased()
    {
        gameover_WatchAdsButton.localScale = originalSize;
    }

    public void GameoverMenu_ShareButtonPressed()
    {
        gameover_ShareButton.localScale = pressedSize;
    }

    public void GameoverMenu_ShareButtonReleased()
    {
        gameover_ShareButton.localScale = originalSize;
    }

    public void GameoverMenu_HomeButtonPressed()
    {
        gameover_HomeButton.localScale = pressedSize;
    }

    public void GameoverMenu_HomeButtonReleased()
    {
        gameover_HomeButton.localScale = originalSize;
    }

    public void GameoverMenu_LevelModeHomeButtonPressed()
    {
        gameover_levelModeHomeButton.localScale = pressedSize;
    }

    public void GameoverMenu_LevelModeHomeButtonReleased()
    {
        gameover_levelModeHomeButton.localScale = originalSize;
    }

    public void GameoverMenu_LevelModeReplayButtonPressed()
    {
        gameover_levelModeReplayButton.localScale = pressedSize;
    }

    public void GameoverMenu_LevelModeReplayButtonReleased()
    {
        gameover_levelModeReplayButton.localScale = originalSize;
    }
    #endregion

    #region LEVEL COMPLETE bUTTONS
    public void LevelComplete_WatchAdsButtonPressed()
    {
        levelCompleteWatchAdsButon.localScale = pressedSize;
    }

    public void LevelComplete_WatchAdsButtonReleased()
    {
        levelCompleteWatchAdsButon.localScale = originalSize;
    }

    public void LevelComplete_ShareButtonPressed()
    {
        levelCompleteShareButton.localScale = pressedSize;
    }

    public void LevelComplete_ShareButtonReleased()
    {
        levelCompleteShareButton.localScale = originalSize;
    }

    public void LevelComplete_ReplayButtonPressed()
    {
        levelCompleteReplayButton.localScale = pressedSize;
    }

    public void LevelComplete_ReplayButtonReleased()
    {
        levelCompleteReplayButton.localScale = originalSize;
    }

    public void LevelComplete_HomeButtonPressed()
    {
        levelCompleteHomeButton.localScale = pressedSize;
    }

    public void LevelComplete_HomeButtonReleased()
    {
        levelCompleteHomeButton.localScale = originalSize;
    }

    public void LevelComplete_NextLevelButtonPressed()
    {
        levelCompleteNextLevelButton.localScale = pressedSize;
    }

    public void LevelComplete_NextLevelButtonReleased()
    {
        levelCompleteNextLevelButton.localScale = originalSize;
    }

    public void LevelComplete_ReplayLastButtonPressed()
    {
        levelCompleteReplayLastLevelButton.localScale = pressedSize;
    }

    public void LevelComplete_ReplayLastButtonReleased()
    {
        levelCompleteReplayLastLevelButton.localScale = originalSize;
    }

    public void LevelComplete_HomeLastButtonPressed()
    {
        levelCompleteHomeLastLevelButton.localScale = pressedSize;
    }

    public void LevelComplete_HomeLastButtonReleased()
    {
        levelCompleteHomeLastLevelButton.localScale = originalSize;
    }
    #endregion

    #region HOME BUTTONS
    public void StoreButtonPressed()
    {
        storeButton.localScale = pressedSize;
    }

    public void StoreButtonRelesed()
    {
        storeButton.localScale = originalSize;
    }

    public void StatsButtonPressed()
    {
        statsButton.localScale = pressedSize;
    }

    public void StatsButtonReleased()
    {
        statsButton.localScale = originalSize;
    }

    public void SettingsButtonPressed()
    {
        settingsButton.localScale = pressedSize;
    }

    public void SettingsButtonReleased()
    {
        settingsButton.localScale = originalSize;

    }

    public void LevelButtonPressed()
    {
        levelButton.localScale = pressedSize;
    }

    public void LevelButtonReleased()
    {
        levelButton.localScale = originalSize;

    }

    public void RateButtonPressed()
    {
        rateButton.localScale = pressedSize;
    }

    public void RateButtonReleased()
    {
        rateButton.localScale = originalSize;

    }

    public void ShareButtonPressed()
    {
        shareButton.localScale = pressedSize;
    }

    public void ShareButtonReleased()
    {
        shareButton.localScale = originalSize;

    }

    public void NoAdsButtonPressed()
    {
        noAdsButton.localScale = pressedSize;
    }

    public void NoAdsButtonReleased()
    {
        noAdsButton.localScale = originalSize;

    }
    #endregion

    #region BACK BUTTONS
    public void Back_Store_Pressed()
    {
        storeBack.localScale = pressedSize;
    }

    public void Back_Store_Released()
    {
        storeBack.localScale = originalSize;
    }

    public void Back_Stats_Pressed()
    {
        statsBack.localScale = pressedSize;
    }

    public void Back_Stats_Released()
    {
        statsBack.localScale = originalSize;
    }

    public void Back_Settings_Pressed1()
    {
        settingsBack1.localScale = pressedSize;
    }

    public void Back_Settings_Released1()
    {
        settingsBack1.localScale = originalSize;
    }

    public void Back_Level_Pressed()
    {
        levelBack.localScale = pressedSize;
    }

    public void Back_Level_Released()
    {
        levelBack.localScale = originalSize;
    }
    #endregion

    #region STATS BUTTONS
    public void Stats_ShareButtonPressed()
    {
        statsShareButton.localScale = pressedSize;
    }

    public void Stats_ShareButtonReleased()
    {
        statsShareButton.localScale = originalSize;
    }

    public void Stats_LeaderboardButtonPressed()
    {
        leaderBoardButton.localScale = pressedSize;
    }

    public void Stats_LeaderboardButtonReleased()
    {
        leaderBoardButton.localScale = originalSize;
    }
    #endregion

    #region SETTINGS BUTTONS
    public void Settings_SoundButtonPressed()
    {
        soundButton.localScale = pressedSize;
    }

    public void Settings_SoundButtonReleased()
    {
        soundButton.localScale = originalSize;
    }

    public void Settings_VibrationButtonPressed()
    {
        vibrationButton.localScale = pressedSize;
    }

    public void Settings_VibrationButtonReleased()
    {
        vibrationButton.localScale = originalSize;
    }

    public void Settings_HQButtonPressed()
    {
        highQualityButton.localScale = pressedSize;
    }

    public void Settings_HQButtonReleased()
    {
        highQualityButton.localScale = originalSize;
    }

    public void Settings_RestoreButtonPressed()
    {
        restorePurchaseButton.localScale = pressedSize;
    }

    public void Settings_RestoreButtonReleased()
    {
        restorePurchaseButton.localScale = originalSize;
    }

    public void Settings_PrivateButtonPressed()
    {
        privatePolicyButton.localScale = pressedSize;
    }

    public void Settings_PrivateButtonReleased()
    {
        privatePolicyButton.localScale = originalSize;
    }

    public void Settings_StudioButtonPressed()
    {
        studioButton.localScale = pressedSize;
    }

    public void Settings_StudioButtonReleased()
    {
        studioButton.localScale = originalSize;
    }
    #endregion

    #region STORE LEFT RIGHT ARROW
    public void Store_LeftArrowButtonPress()
    {
        store_left_arrow.localScale = pressedSize;
    }

    public void Store_LeftArrowButtonreleased()
    {
        store_left_arrow.localScale = originalSize;
    }

    public void Store_RightArrowButtonPress()
    {
        store_right_arrow.localScale = pressedSize;
    }

    public void Store_RightArrowButtonreleased()
    {
        store_right_arrow.localScale = originalSize;
    }
    #endregion

    #region STORE PANNEL 1
    public void Panne1_WatchAdsPressed()
    {
        watchAdsButton.localScale = pressedSize;
    }

    public void Pannel1_WatchAdsReleaded()
    {
        watchAdsButton.localScale = originalSize;
    }

    public void Panne1_RatePressed()
    {
        rateStoreButton.localScale = pressedSize;
    }

    public void Pannel1_RateReleaded()
    {
        rateStoreButton.localScale = originalSize;
    }

    public void Panne1_FacebookPressed()
    {
        facebookButton.localScale = pressedSize;
    }

    public void Pannel1_FacebookReleaded()
    {
        facebookButton.localScale = originalSize;
    }

    public void Panne1_InstagramPressed()
    {
        instagramButton.localScale = pressedSize;
    }

    public void Pannel1_InstagramReleaded()
    {
        instagramButton.localScale = originalSize;
    }

    public void Panne1_YoutubePressed()
    {
        youtubeButton.localScale = pressedSize;
    }

    public void Pannel1_YoutubeReleaded()
    {
        youtubeButton.localScale = originalSize;
    }

    public void Panne1_SharePressed()
    {
        shareStoreButton.localScale = pressedSize;
    }

    public void Pannel1_ShareReleaded()
    {
        shareStoreButton.localScale = originalSize;
    }

    public void Panne1_BuyNoAdsPressed()
    {
        buyNoAdsButton.localScale = pressedSize;
    }

    public void Pannel1_BuyNoAdsReleaded()
    {
        buyNoAdsButton.localScale = originalSize;
    }

    public void Panne1_BuyNoAdsExtraPressed()
    {
        buyNoAdsExtraButton.localScale = pressedSize;
    }

    public void Pannel1_BuyNoAdsExtraReleaded()
    {
        buyNoAdsExtraButton.localScale = originalSize;
    }

    public void Panne1_Pack1Pressed()
    {
        packButton_1.localScale = pressedSize;
    }

    public void Pannel1_Pack1Releaded()
    {
        packButton_1.localScale = originalSize;
    }

    public void Panne1_Pack2Pressed()
    {
        packButton_2.localScale = pressedSize;
    }

    public void Pannel1_Pack2Releaded()
    {
        packButton_2.localScale = originalSize;
    }

    public void Panne1_Pack3Pressed()
    {
        packButton_3.localScale = pressedSize;
    }

    public void Pannel1_Pack3Releaded()
    {
        packButton_3.localScale = originalSize;
    }
    #endregion

    #region STORE PANNEL 2
    public void Pannel2_Button1Pressed()
    {
        pannel2_button1.localScale = pressedSize;
    }

    public void Pannel2_Button1Released()
    {
        pannel2_button1.localScale = originalSize;
    }

    public void Pannel2_Button2Pressed()
    {
        pannel2_button2.localScale = pressedSize;
    }

    public void Pannel2_Button2Released()
    {
        pannel2_button2.localScale = originalSize;
    }

    public void Pannel2_Button3Pressed()
    {
        pannel2_button3.localScale = pressedSize;
    }

    public void Pannel2_Button3Released()
    {
        pannel2_button3.localScale = originalSize;
    }

    public void Pannel2_Button4Pressed()
    {
        pannel2_button4.localScale = pressedSize;
    }

    public void Pannel2_Button4Released()
    {
        pannel2_button4.localScale = originalSize;
    }

    public void Pannel2_Button5Pressed()
    {
        pannel2_button5.localScale = pressedSize;
    }

    public void Pannel2_Button5Released()
    {
        pannel2_button5.localScale = originalSize;
    }

    public void Pannel2_Button6Pressed()
    {
        pannel2_button6.localScale = pressedSize;
    }

    public void Pannel2_Button6Released()
    {
        pannel2_button6.localScale = originalSize;
    }

    public void Pannel2_Button7Pressed()
    {
        pannel2_button7.localScale = pressedSize;
    }

    public void Pannel2_Button7Released()
    {
        pannel2_button7.localScale = originalSize;
    }

    public void Pannel2_Button8Pressed()
    {
        pannel2_button8.localScale = pressedSize;
    }

    public void Pannel2_Button8Released()
    {
        pannel2_button8.localScale = originalSize;
    }

    public void Pannel2_Button9Pressed()
    {
        pannel2_button9.localScale = pressedSize;
    }

    public void Pannel2_Button9Released()
    {
        pannel2_button9.localScale = originalSize;
    }
    #endregion

    #region STORE PANNEL 3
    public void Pannel3_Button1Pressed()
    {
        pannel3_button1.localScale = pressedSize;
    }

    public void Pannel3_Button1Released()
    {
        pannel3_button1.localScale = originalSize;
    }

    public void Pannel3_Button2Pressed()
    {
        pannel3_button2.localScale = pressedSize;
    }

    public void Pannel3_Button2Released()
    {
        pannel3_button2.localScale = originalSize;
    }

    public void Pannel3_Button3Pressed()
    {
        pannel3_button3.localScale = pressedSize;
    }

    public void Pannel3_Button3Released()
    {
        pannel3_button3.localScale = originalSize;
    }

    public void Pannel3_Button4Pressed()
    {
        pannel3_button4.localScale = pressedSize;
    }

    public void Pannel3_Button4Released()
    {
        pannel3_button4.localScale = originalSize;
    }

    public void Pannel3_Button5Pressed()
    {
        pannel3_button5.localScale = pressedSize;
    }

    public void Pannel3_Button5Released()
    {
        pannel3_button5.localScale = originalSize;
    }

    public void Pannel3_Button6Pressed()
    {
        pannel3_button6.localScale = pressedSize;
    }

    public void Pannel3_Button6Released()
    {
        pannel3_button6.localScale = originalSize;
    }

    public void Pannel3_Button7Pressed()
    {
        pannel3_button7.localScale = pressedSize;
    }

    public void Pannel3_Button7Released()
    {
        pannel3_button7.localScale = originalSize;
    }

    public void Pannel3_Button8Pressed()
    {
        pannel3_button8.localScale = pressedSize;
    }

    public void Pannel3_Button8Released()
    {
        pannel3_button8.localScale = originalSize;
    }

    public void Pannel3_Button9Pressed()
    {
        pannel3_button9.localScale = pressedSize;
    }

    public void Pannel3_Button9Released()
    {
        pannel3_button9.localScale = originalSize;
    }
    #endregion

    #region STORE PANNEL 4
    public void Pannel4_Button1Pressed()
    {
        pannel4_button1.localScale = pressedSize;
    }

    public void Pannel4_Button1Released()
    {
        pannel4_button1.localScale = originalSize;
    }

    public void Pannel4_Button2Pressed()
    {
        pannel4_button2.localScale = pressedSize;
    }

    public void Pannel4_Button2Released()
    {
        pannel4_button2.localScale = originalSize;
    }

    public void Pannel4_Button3Pressed()
    {
        pannel4_button3.localScale = pressedSize;
    }

    public void Pannel4_Button3Released()
    {
        pannel4_button3.localScale = originalSize;
    }

    public void Pannel4_Button4Pressed()
    {
        pannel4_button4.localScale = pressedSize;
    }

    public void Pannel4_Button4Released()
    {
        pannel4_button4.localScale = originalSize;
    }

    public void Pannel4_Button5Pressed()
    {
        pannel4_button5.localScale = pressedSize;
    }

    public void Pannel4_Button5Released()
    {
        pannel4_button5.localScale = originalSize;
    }

    public void Pannel4_Button6Pressed()
    {
        pannel4_button6.localScale = pressedSize;
    }

    public void Pannel4_Button6Released()
    {
        pannel4_button6.localScale = originalSize;
    }

    public void Pannel4_Button7Pressed()
    {
        pannel4_button7.localScale = pressedSize;
    }

    public void Pannel4_Button7Released()
    {
        pannel4_button7.localScale = originalSize;
    }

    public void Pannel4_Button8Pressed()
    {
        pannel4_button8.localScale = pressedSize;
    }

    public void Pannel4_Button8Released()
    {
        pannel4_button8.localScale = originalSize;
    }

    public void Pannel4_Button9Pressed()
    {
        pannel4_button9.localScale = pressedSize;
    }

    public void Pannel4_Button9Released()
    {
        pannel4_button9.localScale = originalSize;
    }
    #endregion

    #region STORE PANNEL 5
    public void Pannel5_Button1Pressed()
    {
        pannel5_button1.localScale = pressedSize;
    }

    public void Pannel5_Button1Released()
    {
        pannel5_button1.localScale = originalSize;
    }

    public void Pannel5_Button2Pressed()
    {
        pannel5_button2.localScale = pressedSize;
    }

    public void Pannel5_Button2Released()
    {
        pannel5_button2.localScale = originalSize;
    }

    public void Pannel5_Button3Pressed()
    {
        pannel5_button3.localScale = pressedSize;
    }

    public void Pannel5_Button3Released()
    {
        pannel5_button3.localScale = originalSize;
    }

    public void Pannel5_Button4Pressed()
    {
        pannel5_button4.localScale = pressedSize;
    }

    public void Pannel5_Button4Released()
    {
        pannel5_button4.localScale = originalSize;
    }

    public void Pannel5_Button5Pressed()
    {
        pannel5_button5.localScale = pressedSize;
    }

    public void Pannel5_Button5Released()
    {
        pannel5_button5.localScale = originalSize;
    }

    public void Pannel5_Button6Pressed()
    {
        pannel5_button6.localScale = pressedSize;
    }

    public void Pannel5_Button6Released()
    {
        pannel5_button6.localScale = originalSize;
    }

    public void Pannel5_Button7Pressed()
    {
        pannel5_button7.localScale = pressedSize;
    }

    public void Pannel5_Button7Released()
    {
        pannel5_button7.localScale = originalSize;
    }

    public void Pannel5_Button8Pressed()
    {
        pannel5_button8.localScale = pressedSize;
    }

    public void Pannel5_Button8Released()
    {
        pannel5_button8.localScale = originalSize;
    }

    public void Pannel5_Button9Pressed()
    {
        pannel5_button9.localScale = pressedSize;
    }

    public void Pannel5_Button9Released()
    {
        pannel5_button9.localScale = originalSize;
    }
    #endregion

    #region STORE PANNEL 6
    public void Pannel6_Button1Pressed()
    {
        pannel6_button1.localScale = pressedSize;
    }

    public void Pannel6_Button1Released()
    {
        pannel6_button1.localScale = originalSize;
    }

    public void Pannel6_Button2Pressed()
    {
        pannel6_button2.localScale = pressedSize;
    }

    public void Pannel6_Button2Released()
    {
        pannel6_button2.localScale = originalSize;
    }

    public void Pannel6_Button3Pressed()
    {
        pannel6_button3.localScale = pressedSize;
    }

    public void Pannel6_Button3Released()
    {
        pannel6_button3.localScale = originalSize;
    }

    public void Pannel6_Button4Pressed()
    {
        pannel6_button4.localScale = pressedSize;
    }

    public void Pannel6_Button4Released()
    {
        pannel6_button4.localScale = originalSize;
    }

    public void Pannel6_Button5Pressed()
    {
        pannel6_button5.localScale = pressedSize;
    }

    public void Pannel6_Button5Released()
    {
        pannel6_button5.localScale = originalSize;
    }

    public void Pannel6_Button6Pressed()
    {
        pannel6_button6.localScale = pressedSize;
    }

    public void Pannel6_Button6Released()
    {
        pannel6_button6.localScale = originalSize;
    }
    #endregion
}
