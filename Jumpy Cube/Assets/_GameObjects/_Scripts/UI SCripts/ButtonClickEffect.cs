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

    #region GAMEOVER MENU BUTTONS
    [Header("Gameover Menu Buttons")]
    public Transform gameover_HomeButton;
    public Transform gameover_ShareButton;
    public Transform gameover_WatchAdsButton;
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
