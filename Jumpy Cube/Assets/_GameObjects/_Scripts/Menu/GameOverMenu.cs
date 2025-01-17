﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public float gameoverMenuCommandExecutionDelay;

    [Header("Menues")]
    public GameObject inGameMenu;
    public GameObject gameOverMenu;
    public GameObject revivalMenu;
    public GameObject countDownMenu;

    [Header("Game Over Buttons")]
    public GameObject endless_Buttons;
    public GameObject levelButtons;

    [Header("watch ads and share button")]
    public GameObject disableWatchAdsPannel_button;
    public GameObject disableSharePannel_button;
    public GameObject disableWatchAdsPannel;
    public GameObject disableSharePannel;
    [Space]
    public GameObject revivalAdsPannel_disable;
    public GameObject revivalAdsButton_disable;
    public GameObject revivalPannel_disable;
    public GameObject revivalButton_disable;
    int shareDiamondReward = 50;
    int reviveDiamonds = 100;

    [Header("Revival Screen Total Diamonds")]
    public TMP_Text rivivalTotalDiamonds;

    [Header("Screen Shot Data")]
    public RawImage screenShotImg;
    public string path;

    [Header("Data")]
    public float currentTime;
    public float gameOverMenuShowDelay = 4f;
    public float screenShotDelay = 2.5f;
    public float screenshotDiaplayDelay = 1f;

    [Header("Game over buttons")]
    public Button watchAdsButton;
    public Button shareButton;
    public Button homeButton1;
    public Button homeButton2;
    public Button replayButton1;

    public bool isNetworlAvailable;
    bool isDiamondsAvailable;

    public bool checker;
    bool isProcessing;
    
    bool sharing;
    bool sharingChecker;

    string screenshotfilename = "ScreenShot.png";
    byte[] bytes;
    Texture2D texture;

    PlayerDeath playerDeath;
    PlayerMovement playerMovement;
    LoadLevel loadLevel;
    TimelinePlayer timelinePlayer;
    MissionManager missionManager;
    ButtonClickCommandExecutionDelay buttonClickCommandExecutionDelay;
    DiamondScore diamondScore;
    GameModeManager gameModeManager;
    RevivePlayer revivePlayer;
    CustomAdManager customAdManager;
    NetworkManager networkManager;
    CustomAnalytics customAnalytics;
    CustomStrings customStrings;

    #region SingleTon
    public static GameOverMenu Instance;
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

    // Start is called before the first frame update
    void Start()
    {
        playerDeath = PlayerDeath.Instance;
        loadLevel = LoadLevel.Instance;
        timelinePlayer = TimelinePlayer.Instance;
        playerMovement = PlayerMovement.Instance;
        missionManager = MissionManager.Instance;
        diamondScore = DiamondScore.Instance;
        buttonClickCommandExecutionDelay = ButtonClickCommandExecutionDelay.Instance;
        gameModeManager = GameModeManager.Instance;
        customAdManager = CustomAdManager.Instance;
        networkManager = NetworkManager.Instance;
        customAnalytics = CustomAnalytics.Instance;
        customStrings = CustomStrings.Instance;

        if(!revivePlayer)
        {
            revivePlayer = GetComponent<RevivePlayer>();
        }

        gameoverMenuCommandExecutionDelay = buttonClickCommandExecutionDelay.gameoverMenuCommandExecutionDelay;

        gameOverMenu.SetActive(false);
        currentTime = 0;
        checker = false;

        sharing = false;
        sharingChecker = false;

        if (disableWatchAdsPannel_button.activeSelf){ disableWatchAdsPannel_button.SetActive(false); }
        if (disableSharePannel_button.activeSelf) { disableSharePannel_button.SetActive(false); }
        if (disableWatchAdsPannel.activeSelf) { disableWatchAdsPannel.SetActive(false); }
        if (disableSharePannel.activeSelf) { disableSharePannel.SetActive(false); }

        if (revivalAdsPannel_disable.activeSelf) { revivalAdsPannel_disable.SetActive(false); }
        if (revivalAdsButton_disable.activeSelf) { revivalAdsButton_disable.SetActive(false); }
        if (revivalPannel_disable.activeSelf) { revivalPannel_disable.SetActive(false); }
        if (revivalButton_disable.activeSelf) { revivalButton_disable.SetActive(false); }

        isNetworlAvailable = true;
        isDiamondsAvailable = true;

        ActivateAllButtons();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDeath.isDead && !checker)
        {
            if (inGameMenu.activeSelf)
            {
                inGameMenu.SetActive(false);
            }

            Activate_Deactivate_RevivalButton();
            DisableWatchAdsButtonIfNoInternet();

            currentTime += Time.deltaTime;

            if (currentTime > gameOverMenuShowDelay)
            {
                if (!gameModeManager.isTutorialActive)
                {
                    if (isNetworlAvailable || isDiamondsAvailable)
                    {
                        revivalMenu.SetActive(true);
                        rivivalTotalDiamonds.text = diamondScore.GetDiamonds() + "";
                    }
                    else
                    {
                        revivePlayer.SkipRevivalMenuButton();
                        customAdManager.RequestTopBanners_Gameover();
                    }
                }
                else if (gameModeManager.isTutorialActive && gameModeManager.gameMode == GameModeManager.GameMode.endless)
                {
                    revivePlayer.RevivePlayer_Tutorial();
                }
                else if(gameModeManager.isTutorialActive && gameModeManager.gameMode == GameModeManager.GameMode.level)
                {
                    if (isNetworlAvailable || isDiamondsAvailable)
                    {
                        revivalMenu.SetActive(true);
                        rivivalTotalDiamonds.text = diamondScore.GetDiamonds() + "";
                    }
                    else
                    {
                        revivePlayer.SkipRevivalMenuButton();
                        customAdManager.RequestTopBanners_Gameover();
                    }
                }
                checker = true;
            }

            if (gameModeManager.gameMode == GameModeManager.GameMode.endless)
            {
                if (!endless_Buttons.activeSelf)
                {
                    endless_Buttons.SetActive(true);
                }
                if (levelButtons.activeSelf)
                {
                    levelButtons.SetActive(false);
                }
            }
            else if(gameModeManager.gameMode == GameModeManager.GameMode.level)
            {
                if (!levelButtons.activeSelf)
                {
                    levelButtons.SetActive(true);
                }
                if (endless_Buttons.activeSelf)
                {
                    endless_Buttons.SetActive(false);
                }
            }
        }
        
    }

    private void OnApplicationPause(bool pause)
    {
        if (sharing)
        {
            if (!pause)
            {
                if (sharingChecker)
                {
                    //missionManager.CheckingForShareScoreMission();
                    StartCoroutine("CheckForShareReward");
                }
                sharing = false;
                sharingChecker = false;
            }
            else
            {
                sharingChecker = true;
            }
        }
    }

    void DisableWatchAdsButtonIfNoInternet()
    {
        if(!networkManager.CheckForInternet())
        {
            disableWatchAdsPannel_button.SetActive(true);
            disableWatchAdsPannel.SetActive(true);
            
            revivalAdsPannel_disable.SetActive(true);
            revivalAdsButton_disable.SetActive(true);

            isNetworlAvailable = false;
        }
        else
        {
            isNetworlAvailable = true;
        }
    }

    void Activate_Deactivate_RevivalButton()
    {
        if (diamondScore.GetDiamonds() >= reviveDiamonds)
        {
            if (revivalPannel_disable.activeSelf) { revivalPannel_disable.SetActive(false); }
            if (revivalButton_disable.activeSelf) { revivalButton_disable.SetActive(false); }

            isDiamondsAvailable = true;
        }
        else
        {
            if (!revivalPannel_disable.activeSelf) { revivalPannel_disable.SetActive(true); }
            if (!revivalButton_disable.activeSelf) { revivalButton_disable.SetActive(true); }

            isDiamondsAvailable = false;
        }
    }

    public void CaptureScreenShot()
    {
        StartCoroutine(takeScreenShot());
    }

    IEnumerator takeScreenShot()
    {
        yield return new WaitForSeconds(screenShotDelay);
        
        ScreenCapture.CaptureScreenshot(screenshotfilename);

        StartCoroutine(DisplayScreenShotCoroutine());
    }

    IEnumerator DisplayScreenShotCoroutine()
    {
        yield return new WaitForSeconds(screenshotDiaplayDelay);
        DisplayScreenShot();
    }

    void DisplayScreenShot()
    {
#if UNITY_ANDROID
        path = Path.Combine(Application.persistentDataPath, screenshotfilename);
#endif
#if UNITY_EDITOR
        path = screenshotfilename;
#endif


        bytes = File.ReadAllBytes(path);
        texture = new Texture2D(73, 73);
        texture.LoadImage(bytes);
        screenShotImg.texture = texture;
    }

    public void ShareScreenshotButtonPressed()
    {
        //missionManager.CheckingForShareScoreMission();

        DisableAllButtons();

        customAnalytics.ScoreShared_Gameover();

        Invoke("ShareScreenShotFunction", gameoverMenuCommandExecutionDelay);
    }

    void ShareScreenShotFunction()
    {
        #if UNITY_ANDROID
            path = Path.Combine(Application.persistentDataPath, screenshotfilename);
        #endif
        #if UNITY_EDITOR
            path = screenshotfilename;
        #endif

        //new method
        new NativeShare().AddFile(path).SetSubject(customStrings.MSG_SUBJECT)
            .SetText(customStrings.MSG_TEXT_GAMEOVER_1 + revivePlayer.currentScore + customStrings.MSG_TEXT_GAMEOVER_2)
            .SetTitle(customStrings.MSG_TITLE).Share();
        
        sharing = true;

        ActivateAllButtons();
    }
    
    public void HomeButton()
    {
        DisableAllButtons();
        if (!customAdManager.Check_To_ShowAds())
        {
            Invoke("HomeButtonFunction", gameoverMenuCommandExecutionDelay);
        }
    }

    public void HomeButton_InterstitialAdsClosed()
    {
        Invoke("HomeButtonFunction", gameoverMenuCommandExecutionDelay);
        ActivateAllButtons();
    }

    void HomeButtonFunction()
    {
        gameModeManager.gameMode = GameModeManager.GameMode.endless;
        gameModeManager.isGameRestarted = false;

        ActivateAllButtons();

        loadLevel.Load(loadLevel.SAMPLE_SCENE_NAME);
        
    }
    
    public void WatchAdsForDoubleReward()
    {
        DisableAllButtons();

        customAnalytics.RewardDoubled_Requested();

        Invoke("WatchAdsForDoubleRewardFunction", gameoverMenuCommandExecutionDelay);
    }

    void WatchAdsForDoubleRewardFunction()
    {
        customAdManager.ShowRewardingAds_DoubleReward();
        ActivateAllButtons();
    }

    public void ReplayButton()
    {
        DisableAllButtons();
        Invoke("ReplayButtonFunction", gameoverMenuCommandExecutionDelay);
    }

    void ReplayButtonFunction()
    {
        ActivateAllButtons();
    }

    void DisableAllButtons()
    {
        if (shareButton.interactable)
        {
            shareButton.interactable = false;
        }
        if (watchAdsButton.interactable)
        {
            watchAdsButton.interactable = false;
        }
        if (homeButton1.interactable)
        {
            homeButton1.interactable = false;
        }
        if (homeButton2.interactable)
        {
            homeButton2.interactable = false;
        }
        if (replayButton1.interactable)
        {
            replayButton1.interactable = false;
        }
    }

    void ActivateAllButtons()
    {
        if (!endless_Buttons.activeSelf && gameModeManager.gameMode == GameModeManager.GameMode.endless)
        {
            endless_Buttons.SetActive(true);
            levelButtons.SetActive(false);
        }
        if (!levelButtons.activeSelf && gameModeManager.gameMode == GameModeManager.GameMode.level)
        {
            levelButtons.SetActive(true);
            endless_Buttons.SetActive(false);
        }

        if (!shareButton.interactable)
        {
            shareButton.interactable = true;
        }
        if (!watchAdsButton.interactable)
        {
            watchAdsButton.interactable = true;
        }
        if (!homeButton1.interactable)
        {
            homeButton1.interactable = true;
        }
        if (!homeButton2.interactable)
        {
            homeButton2.interactable = true;
        }
        if (!replayButton1.interactable)
        {
            replayButton1.interactable = true;
        }
    }

    IEnumerator CheckForShareReward()
    {
        yield return new WaitForEndOfFrame();
        missionManager.CheckingForShareScoreMission();

        diamondScore.SaveDiamondsCollected(shareDiamondReward, true);

        revivePlayer.currentDiamondsTxt.text = revivePlayer.currentDiamonds + shareDiamondReward + " ";

        disableSharePannel_button.SetActive(true);
        disableSharePannel.SetActive(true);

        timelinePlayer.PlayDiamondReward();
    }
}
