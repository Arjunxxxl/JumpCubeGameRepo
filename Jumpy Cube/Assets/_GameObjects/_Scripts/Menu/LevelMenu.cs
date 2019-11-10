using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelMenu : MonoBehaviour
{
    public TMP_Text levelText;

    [Header("Complete Status UI")]
    public List<GameObject> completeStatusUI;
    public int levelRequiredToUnlockNextTier = 5;

    [Header("Screen Shot Data")]
    public RawImage screenShotImg;
    public string path;
    public float screenShotDelay = 1f;
    public float screenshotDiaplayDelay = 2.5f;
    int shareDiamondReward = 50;

    [Header("Level Mode Button parents")]
    public GameObject normalButtons;
    public GameObject lastLevelButtons;

    [Header("Level Complete Buttons")]
    public Button watchAdsButton;
    public Button shareButton;
    public Button homeButton1;
    public Button homeButton2;
    public Button replayButton1;
    public Button replayButton2;
    public Button nextButton;

    LevelManager levelManager;
    TileSequence tileSequence;
    GameModeManager gameModeManager;
    MainMenu mainMenu;
    LoadLevel loadLevel;
    ButtonClickCommandExecutionDelay buttonClickCommandExecutionDelay;
    MissionManager missionManager;
    CustomStrings customStrings;
    DiamondScore diamondScore;
    InGameMenu inGameMenu;
    CustomAdManager customAdManager;

    float levelMenuCommandExecutionDelay;
    float levelOverMenuCommandExecutionDelay;

    bool setLevelCompleteUIChecker;
    int diff_1, diff_2, diff_3, diff_4, diff_5, diff_6;
    public int[] diff;

    int levelNo = 0;
    string levelname = "Level ";
    string finnalName;
    
    bool sharing;
    bool sharingChecker;

    #region SingleTon
    public static LevelMenu Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }


        diff_1 = 0; diff_2 = 0; diff_3 = 0;
        diff_4 = 0; diff_5 = 0; diff_6 = 0;

        diff = new int[6];
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        levelManager = LevelManager.Instance;
        tileSequence = TileSequence.Instance;
        gameModeManager = GameModeManager.Instance;
        mainMenu = MainMenu.Instance;
        loadLevel = LoadLevel.Instance;
        buttonClickCommandExecutionDelay = ButtonClickCommandExecutionDelay.Instance;
        missionManager = MissionManager.Instance;
        customStrings = CustomStrings.Instance;
        diamondScore = DiamondScore.Instance;
        inGameMenu = InGameMenu.Instance;
        customAdManager = CustomAdManager.Instance;

        levelNo = 0;
        finnalName = levelname + levelNo;

        levelMenuCommandExecutionDelay = buttonClickCommandExecutionDelay.levelMenuCommandExecutionDelay;
        levelOverMenuCommandExecutionDelay = buttonClickCommandExecutionDelay.levelOverMenuCommandExecutionDelay;

        setLevelCompleteUIChecker = false;

        GetLevelCompleteStatus();

        diff[0] = diff_1;
        diff[1] = diff_2;
        diff[2] = diff_3;
        diff[3] = diff_4;
        diff[4] = diff_5;
        diff[5] = diff_6;

        SetCorrectLevelEndUIButtons();

        sharing = false;
        sharingChecker = false;

        EnableAllButtons();
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

    public void CaptureScreenShot()
    {
        StartCoroutine(takeScreenShot());
    }

    IEnumerator takeScreenShot()
    {
        yield return new WaitForSeconds(screenShotDelay);

        ScreenCapture.CaptureScreenshot("ScreenShot.png");

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
        path = Path.Combine(Application.persistentDataPath, "ScreenShot.png");
#endif
#if UNITY_EDITOR
        path = "ScreenShot.png";
#endif


        var bytes = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(73, 73);
        texture.LoadImage(bytes);
        screenShotImg.texture = texture;
    }

    ///* FUNCTIONS FOR LEVEN COMPLETE MENU *///
    public void HomeButtonPressed()
    {
        DisableAllButtons();
        StartCoroutine(HomeButtonFunction());
    }

    public void ReplayButton()
    {
        DisableAllButtons();
        StartCoroutine(RestartButtonFunction());
    }

    public void NextLevelButton()
    {
        DisableAllButtons();
        StartCoroutine(NextLevelButtonFunction());
    }

    IEnumerator RestartButtonFunction()
    {
        yield return new WaitForSecondsRealtime(levelOverMenuCommandExecutionDelay);
        gameModeManager.gameMode = GameModeManager.GameMode.level;
        gameModeManager.isGameRestarted = true;

        EnableAllButtons();

        loadLevel.Load(loadLevel.SAMPLE_SCENE_NAME);
    }

    IEnumerator NextLevelButtonFunction()
    {
        yield return new WaitForSecondsRealtime(levelOverMenuCommandExecutionDelay);
        gameModeManager.gameMode = GameModeManager.GameMode.level;
        gameModeManager.isGameRestarted = true;

        gameModeManager.currentLevel = gameModeManager.nextLevel;
        gameModeManager.nextLevel = levelManager.NextLevel(gameModeManager.currentLevel);
        
        EnableAllButtons();

        loadLevel.Load(loadLevel.SAMPLE_SCENE_NAME);
    }

    IEnumerator HomeButtonFunction()
    {
        yield return new WaitForSecondsRealtime(levelOverMenuCommandExecutionDelay);
        gameModeManager.gameMode = GameModeManager.GameMode.endless;
        gameModeManager.isGameRestarted = false;

        EnableAllButtons();

        loadLevel.Load(loadLevel.SAMPLE_SCENE_NAME);
    }

    public void ShareScreenshotButtonPressed()
    {
        //missionManager.CheckingForShareScoreMission();

        DisableAllButtons();

        Invoke("ShareScreenShotFunction", levelOverMenuCommandExecutionDelay);
    }

    void ShareScreenShotFunction()
    {
#if UNITY_ANDROID
        path = Path.Combine(Application.persistentDataPath, "ScreenShot.png");
#endif
#if UNITY_EDITOR
        path = "ScreenShot.png";
#endif

        //new method
        new NativeShare().AddFile(path).SetSubject("Subject").SetText("Text").SetTitle("Title").Share();
        
        sharing = true;

        EnableAllButtons();
    }

    public void SetCorrectLevelNumber()
    {
        if (!gameModeManager)
        {
            gameModeManager = GameModeManager.Instance;
        }

        switch (gameModeManager.currentLevel)
        {
            case LevelNumbers._1:
                levelNo = 1;
                break;

            case LevelNumbers._2:
                levelNo = 2;
                break;

            case LevelNumbers._3:
                levelNo = 3;
                break;

            case LevelNumbers._4:
                levelNo = 4;
                break;

            case LevelNumbers._5:
                levelNo = 5;
                break;

            case LevelNumbers._6:
                levelNo = 6;
                break;

            case LevelNumbers._7:
                levelNo = 7;
                break;

            case LevelNumbers._8:
                levelNo = 8;
                break;

            case LevelNumbers._9:
                levelNo = 9;
                break;

            case LevelNumbers._10:
                levelNo = 10;
                break;

            case LevelNumbers._11:
                levelNo = 11;
                break;

            case LevelNumbers._12:
                levelNo = 12;
                break;

            case LevelNumbers._13:
                levelNo = 13;
                break;

            case LevelNumbers._14:
                levelNo = 14;
                break;

            case LevelNumbers._15:
                levelNo = 15;
                break;

            case LevelNumbers._16:
                levelNo = 16;
                break;

            case LevelNumbers._17:
                levelNo = 17;
                break;

            case LevelNumbers._18:
                levelNo = 18;
                break;

            case LevelNumbers._19:
                levelNo = 19;
                break;

            case LevelNumbers._20:
                levelNo = 20;
                break;

            case LevelNumbers._21:
                levelNo = 21;
                break;

            case LevelNumbers._22:
                levelNo = 22;
                break;

            case LevelNumbers._23:
                levelNo = 23;
                break;

            case LevelNumbers._24:
                levelNo = 24;
                break;

            case LevelNumbers._25:
                levelNo = 25;
                break;

            case LevelNumbers._26:
                levelNo = 26;
                break;

            case LevelNumbers._27:
                levelNo = 27;
                break;

            case LevelNumbers._28:
                levelNo = 28;
                break;

            case LevelNumbers._29:
                levelNo = 29;
                break;

            case LevelNumbers._30:
                levelNo = 30;
                break;

            case LevelNumbers._31:
                levelNo = 31;
                break;

            case LevelNumbers._32:
                levelNo = 32;
                break;

            case LevelNumbers._33:
                levelNo = 33;
                break;

            case LevelNumbers._34:
                levelNo = 34;
                break;

            case LevelNumbers._35:
                levelNo = 35;
                break;

            case LevelNumbers._36:
                levelNo = 36;
                break;

            case LevelNumbers._37:
                levelNo = 37;
                break;

            case LevelNumbers._38:
                levelNo = 38;
                break;

            case LevelNumbers._39:
                levelNo = 39;
                break;

            case LevelNumbers._40:
                levelNo = 40;
                break;

            case LevelNumbers._41:
                levelNo = 41;
                break;

            case LevelNumbers._42:
                levelNo = 42;
                break;

            case LevelNumbers._43:
                levelNo = 43;
                break;

            case LevelNumbers._44:
                levelNo = 44;
                break;

            case LevelNumbers._45:
                levelNo = 45;
                break;

            case LevelNumbers._46:
                levelNo = 46;
                break;

            case LevelNumbers._47:
                levelNo = 47;
                break;

            case LevelNumbers._48:
                levelNo = 48;
                break;

            case LevelNumbers._49:
                levelNo = 49;
                break;

            case LevelNumbers._50:
                levelNo = 50;
                break;

            case LevelNumbers._51:
                levelNo = 51;
                break;

            case LevelNumbers._52:
                levelNo = 52;
                break;

            case LevelNumbers._53:
                levelNo = 53;
                break;

            case LevelNumbers._54:
                levelNo = 54;
                break;
        }

        finnalName = levelname + levelNo;

        levelText.text = finnalName;
    }

    public void WatchAdsForDoubleReward()
    {
        DisableAllButtons();
        Invoke("WatchAdsForDoubleRewardFunction", levelOverMenuCommandExecutionDelay);
    }

    void WatchAdsForDoubleRewardFunction()
    {
        customAdManager.ShowRewardingAds_DoubleReward_LevelEndMenu();
        EnableAllButtons();
    }

    void DisableAllButtons()
    {
        if(shareButton.interactable)
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
        if (replayButton2.interactable)
        {
            replayButton2.interactable = false;
        }
        if (nextButton.interactable)
        {
            nextButton.interactable = false;
        }
    }

    void EnableAllButtons()
    {
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
        if (!replayButton2.interactable)
        {
            replayButton2.interactable = true;
        }
        if (!nextButton.interactable)
        {
            nextButton.interactable = true;
        }
    }

    IEnumerator CheckForShareReward()
    {
        yield return new WaitForEndOfFrame();
        missionManager.CheckingForShareScoreMission();

        diamondScore.SaveDiamondsCollected(shareDiamondReward, true);

        inGameMenu.diamondsTxt.text = inGameMenu.currentDiamonds + shareDiamondReward + " ";

        inGameMenu.levelEnd_disableSharePannel_button.SetActive(true);
        inGameMenu.levelEnd_disableSharePannel.SetActive(true);
    }

    ///
    /// FUNCTION TO UPDATE LEVEL COMPLETE STATUS
    ///
    public void UpdateLevelCompleteStatus(LevelNumbers levelNumbers)
    {
        switch (levelNumbers)
        {
            case LevelNumbers._1:
                PlayerPrefs.SetInt(customStrings.LevelComplete1, 1);
                break;

            case LevelNumbers._2:
                PlayerPrefs.SetInt(customStrings.LevelComplete2, 1);
                break;

            case LevelNumbers._3:
                PlayerPrefs.SetInt(customStrings.LevelComplete3, 1);
                break;

            case LevelNumbers._4:
                PlayerPrefs.SetInt(customStrings.LevelComplete4, 1);
                break;

            case LevelNumbers._5:
                PlayerPrefs.SetInt(customStrings.LevelComplete5, 1);
                break;

            case LevelNumbers._6:
                PlayerPrefs.SetInt(customStrings.LevelComplete6, 1);
                break;

            case LevelNumbers._7:
                PlayerPrefs.SetInt(customStrings.LevelComplete7, 1);
                break;

            case LevelNumbers._8:
                PlayerPrefs.SetInt(customStrings.LevelComplete8, 1);
                break;

            case LevelNumbers._9:
                PlayerPrefs.SetInt(customStrings.LevelComplete9, 1);
                break;

            case LevelNumbers._10:
                PlayerPrefs.SetInt(customStrings.LevelComplete10, 1);
                break;

            case LevelNumbers._11:
                PlayerPrefs.SetInt(customStrings.LevelComplete11, 1);
                break;

            case LevelNumbers._12:
                PlayerPrefs.SetInt(customStrings.LevelComplete12, 1);
                break;

            case LevelNumbers._13:
                PlayerPrefs.SetInt(customStrings.LevelComplete13, 1);
                break;

            case LevelNumbers._14:
                PlayerPrefs.SetInt(customStrings.LevelComplete14, 1);
                break;

            case LevelNumbers._15:
                PlayerPrefs.SetInt(customStrings.LevelComplete15, 1);
                break;

            case LevelNumbers._16:
                PlayerPrefs.SetInt(customStrings.LevelComplete16, 1);
                break;

            case LevelNumbers._17:
                PlayerPrefs.SetInt(customStrings.LevelComplete17, 1);
                break;

            case LevelNumbers._18:
                PlayerPrefs.SetInt(customStrings.LevelComplete18, 1);
                break;

            case LevelNumbers._19:
                PlayerPrefs.SetInt(customStrings.LevelComplete19, 1);
                break;

            case LevelNumbers._20:
                PlayerPrefs.SetInt(customStrings.LevelComplete20, 1);
                break;

            case LevelNumbers._21:
                PlayerPrefs.SetInt(customStrings.LevelComplete21, 1);
                break;

            case LevelNumbers._22:
                PlayerPrefs.SetInt(customStrings.LevelComplete22, 1);
                break;

            case LevelNumbers._23:
                PlayerPrefs.SetInt(customStrings.LevelComplete23, 1);
                break;

            case LevelNumbers._24:
                PlayerPrefs.SetInt(customStrings.LevelComplete24, 1);
                break;

            case LevelNumbers._25:
                PlayerPrefs.SetInt(customStrings.LevelComplete25, 1);
                break;

            case LevelNumbers._26:
                PlayerPrefs.SetInt(customStrings.LevelComplete26, 1);
                break;

            case LevelNumbers._27:
                PlayerPrefs.SetInt(customStrings.LevelComplete27, 1);
                break;

            case LevelNumbers._28:
                PlayerPrefs.SetInt(customStrings.LevelComplete28, 1);
                break;

            case LevelNumbers._29:
                PlayerPrefs.SetInt(customStrings.LevelComplete29, 1);
                break;

            case LevelNumbers._30:
                PlayerPrefs.SetInt(customStrings.LevelComplete30, 1);
                break;

            case LevelNumbers._31:
                PlayerPrefs.SetInt(customStrings.LevelComplete31, 1);
                break;

            case LevelNumbers._32:
                PlayerPrefs.SetInt(customStrings.LevelComplete32, 1);
                break;

            case LevelNumbers._33:
                PlayerPrefs.SetInt(customStrings.LevelComplete33, 1);
                break;

            case LevelNumbers._34:
                PlayerPrefs.SetInt(customStrings.LevelComplete34, 1);
                break;

            case LevelNumbers._35:
                PlayerPrefs.SetInt(customStrings.LevelComplete35, 1);
                break;

            case LevelNumbers._36:
                PlayerPrefs.SetInt(customStrings.LevelComplete36, 1);
                break;

            case LevelNumbers._37:
                PlayerPrefs.SetInt(customStrings.LevelComplete37, 1);
                break;

            case LevelNumbers._38:
                PlayerPrefs.SetInt(customStrings.LevelComplete38, 1);
                break;

            case LevelNumbers._39:
                PlayerPrefs.SetInt(customStrings.LevelComplete39, 1);
                break;

            case LevelNumbers._40:
                PlayerPrefs.SetInt(customStrings.LevelComplete40, 1);
                break;

            case LevelNumbers._41:
                PlayerPrefs.SetInt(customStrings.LevelComplete41, 1);
                break;

            case LevelNumbers._42:
                PlayerPrefs.SetInt(customStrings.LevelComplete42, 1);
                break;

            case LevelNumbers._43:
                PlayerPrefs.SetInt(customStrings.LevelComplete43, 1);
                break;

            case LevelNumbers._44:
                PlayerPrefs.SetInt(customStrings.LevelComplete44, 1);
                break;

            case LevelNumbers._45:
                PlayerPrefs.SetInt(customStrings.LevelComplete45, 1);
                break;

            case LevelNumbers._46:
                PlayerPrefs.SetInt(customStrings.LevelComplete46, 1);
                break;

            case LevelNumbers._47:
                PlayerPrefs.SetInt(customStrings.LevelComplete47, 1);
                break;

            case LevelNumbers._48:
                PlayerPrefs.SetInt(customStrings.LevelComplete48, 1);
                break;

            case LevelNumbers._49:
                PlayerPrefs.SetInt(customStrings.LevelComplete49, 1);
                break;

            case LevelNumbers._50:
                PlayerPrefs.SetInt(customStrings.LevelComplete50, 1);
                break;

            case LevelNumbers._51:
                PlayerPrefs.SetInt(customStrings.LevelComplete51, 1);
                break;

            case LevelNumbers._52:
                PlayerPrefs.SetInt(customStrings.LevelComplete52, 1);
                break;

            case LevelNumbers._53:
                PlayerPrefs.SetInt(customStrings.LevelComplete53, 1);
                break;

            case LevelNumbers._54:
                PlayerPrefs.SetInt(customStrings.LevelComplete54, 1);
                break;
        }
    }

    public int[] GetLevelCompleteStatus()
    {
        if (!customStrings)
        {
            customStrings = CustomStrings.Instance;
        }

        diff_1 += PlayerPrefs.GetInt(customStrings.LevelComplete1, 0) == 0 ? 0 : 1;
        diff_1 += PlayerPrefs.GetInt(customStrings.LevelComplete2, 0) == 0 ? 0 : 1;
        diff_1 += PlayerPrefs.GetInt(customStrings.LevelComplete3, 0) == 0 ? 0 : 1;
        diff_1 += PlayerPrefs.GetInt(customStrings.LevelComplete4, 0) == 0 ? 0 : 1;
        diff_1 += PlayerPrefs.GetInt(customStrings.LevelComplete5, 0) == 0 ? 0 : 1;
        diff_1 += PlayerPrefs.GetInt(customStrings.LevelComplete6, 0) == 0 ? 0 : 1;
        diff_1 += PlayerPrefs.GetInt(customStrings.LevelComplete7, 0) == 0 ? 0 : 1;
        diff_1 += PlayerPrefs.GetInt(customStrings.LevelComplete8, 0) == 0 ? 0 : 1;
        diff_1 += PlayerPrefs.GetInt(customStrings.LevelComplete9, 0) == 0 ? 0 : 1;

        diff_2 += PlayerPrefs.GetInt(customStrings.LevelComplete10, 0) == 0 ? 0 : 1;
        diff_2 += PlayerPrefs.GetInt(customStrings.LevelComplete11, 0) == 0 ? 0 : 1;
        diff_2 += PlayerPrefs.GetInt(customStrings.LevelComplete12, 0) == 0 ? 0 : 1;
        diff_2 += PlayerPrefs.GetInt(customStrings.LevelComplete13, 0) == 0 ? 0 : 1;
        diff_2 += PlayerPrefs.GetInt(customStrings.LevelComplete14, 0) == 0 ? 0 : 1;
        diff_2 += PlayerPrefs.GetInt(customStrings.LevelComplete15, 0) == 0 ? 0 : 1;
        diff_2 += PlayerPrefs.GetInt(customStrings.LevelComplete16, 0) == 0 ? 0 : 1;
        diff_2 += PlayerPrefs.GetInt(customStrings.LevelComplete17, 0) == 0 ? 0 : 1;
        diff_2 += PlayerPrefs.GetInt(customStrings.LevelComplete18, 0) == 0 ? 0 : 1;

        diff_3 += PlayerPrefs.GetInt(customStrings.LevelComplete19, 0) == 0 ? 0 : 1;
        diff_3 += PlayerPrefs.GetInt(customStrings.LevelComplete20, 0) == 0 ? 0 : 1;
        diff_3 += PlayerPrefs.GetInt(customStrings.LevelComplete21, 0) == 0 ? 0 : 1;
        diff_3 += PlayerPrefs.GetInt(customStrings.LevelComplete22, 0) == 0 ? 0 : 1;
        diff_3 += PlayerPrefs.GetInt(customStrings.LevelComplete23, 0) == 0 ? 0 : 1;
        diff_3 += PlayerPrefs.GetInt(customStrings.LevelComplete24, 0) == 0 ? 0 : 1;
        diff_3 += PlayerPrefs.GetInt(customStrings.LevelComplete25, 0) == 0 ? 0 : 1;
        diff_3 += PlayerPrefs.GetInt(customStrings.LevelComplete26, 0) == 0 ? 0 : 1;
        diff_3 += PlayerPrefs.GetInt(customStrings.LevelComplete27, 0) == 0 ? 0 : 1;

        diff_4 += PlayerPrefs.GetInt(customStrings.LevelComplete28, 0) == 0 ? 0 : 1;
        diff_4 += PlayerPrefs.GetInt(customStrings.LevelComplete29, 0) == 0 ? 0 : 1;
        diff_4 += PlayerPrefs.GetInt(customStrings.LevelComplete30, 0) == 0 ? 0 : 1;
        diff_4 += PlayerPrefs.GetInt(customStrings.LevelComplete31, 0) == 0 ? 0 : 1;
        diff_4 += PlayerPrefs.GetInt(customStrings.LevelComplete32, 0) == 0 ? 0 : 1;
        diff_4 += PlayerPrefs.GetInt(customStrings.LevelComplete33, 0) == 0 ? 0 : 1;
        diff_4 += PlayerPrefs.GetInt(customStrings.LevelComplete34, 0) == 0 ? 0 : 1;
        diff_4 += PlayerPrefs.GetInt(customStrings.LevelComplete35, 0) == 0 ? 0 : 1;
        diff_4 += PlayerPrefs.GetInt(customStrings.LevelComplete36, 0) == 0 ? 0 : 1;

        diff_5 += PlayerPrefs.GetInt(customStrings.LevelComplete37, 0) == 0 ? 0 : 1;
        diff_5 += PlayerPrefs.GetInt(customStrings.LevelComplete38, 0) == 0 ? 0 : 1;
        diff_5 += PlayerPrefs.GetInt(customStrings.LevelComplete39, 0) == 0 ? 0 : 1;
        diff_5 += PlayerPrefs.GetInt(customStrings.LevelComplete40, 0) == 0 ? 0 : 1;
        diff_5 += PlayerPrefs.GetInt(customStrings.LevelComplete41, 0) == 0 ? 0 : 1;
        diff_5 += PlayerPrefs.GetInt(customStrings.LevelComplete42, 0) == 0 ? 0 : 1;
        diff_5 += PlayerPrefs.GetInt(customStrings.LevelComplete43, 0) == 0 ? 0 : 1;
        diff_5 += PlayerPrefs.GetInt(customStrings.LevelComplete44, 0) == 0 ? 0 : 1;
        diff_5 += PlayerPrefs.GetInt(customStrings.LevelComplete45, 0) == 0 ? 0 : 1;

        diff_6 += PlayerPrefs.GetInt(customStrings.LevelComplete46, 0) == 0 ? 0 : 1;
        diff_6 += PlayerPrefs.GetInt(customStrings.LevelComplete47, 0) == 0 ? 0 : 1;
        diff_6 += PlayerPrefs.GetInt(customStrings.LevelComplete48, 0) == 0 ? 0 : 1;
        diff_6 += PlayerPrefs.GetInt(customStrings.LevelComplete49, 0) == 0 ? 0 : 1;
        diff_6 += PlayerPrefs.GetInt(customStrings.LevelComplete50, 0) == 0 ? 0 : 1;
        diff_6 += PlayerPrefs.GetInt(customStrings.LevelComplete51, 0) == 0 ? 0 : 1;
        diff_6 += PlayerPrefs.GetInt(customStrings.LevelComplete52, 0) == 0 ? 0 : 1;
        diff_6 += PlayerPrefs.GetInt(customStrings.LevelComplete53, 0) == 0 ? 0 : 1;
        diff_6 += PlayerPrefs.GetInt(customStrings.LevelComplete54, 0) == 0 ? 0 : 1;

        diff[0] = diff_1;
        diff[1] = diff_2;
        diff[2] = diff_3;
        diff[3] = diff_4;
        diff[4] = diff_5;
        diff[5] = diff_6;

        return diff;
    }

    public void SetLevelCompleteUI()
    {
        if (setLevelCompleteUIChecker)
        {
            return;
        }

        setLevelCompleteUIChecker = true;

        completeStatusUI[0].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete1, 0) == 0 ? false : true);
        completeStatusUI[1].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete2, 0) == 0 ? false : true);
        completeStatusUI[2].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete3, 0) == 0 ? false : true);
        completeStatusUI[3].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete4, 0) == 0 ? false : true);
        completeStatusUI[4].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete5, 0) == 0 ? false : true);
        completeStatusUI[5].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete6, 0) == 0 ? false : true);
        completeStatusUI[6].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete7, 0) == 0 ? false : true);
        completeStatusUI[7].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete8, 0) == 0 ? false : true);
        completeStatusUI[8].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete9, 0) == 0 ? false : true);

        completeStatusUI[9].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete10, 0) == 0 ? false : true);
        completeStatusUI[10].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete11, 0) == 0 ? false : true);
        completeStatusUI[11].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete12, 0) == 0 ? false : true);
        completeStatusUI[12].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete13, 0) == 0 ? false : true);
        completeStatusUI[13].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete14, 0) == 0 ? false : true);
        completeStatusUI[14].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete15, 0) == 0 ? false : true);
        completeStatusUI[15].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete16, 0) == 0 ? false : true);
        completeStatusUI[16].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete17, 0) == 0 ? false : true);
        completeStatusUI[17].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete18, 0) == 0 ? false : true);

        completeStatusUI[18].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete19, 0) == 0 ? false : true);
        completeStatusUI[19].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete20, 0) == 0 ? false : true);
        completeStatusUI[20].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete21, 0) == 0 ? false : true);
        completeStatusUI[21].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete22, 0) == 0 ? false : true);
        completeStatusUI[22].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete23, 0) == 0 ? false : true);
        completeStatusUI[23].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete24, 0) == 0 ? false : true);
        completeStatusUI[24].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete25, 0) == 0 ? false : true);
        completeStatusUI[25].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete26, 0) == 0 ? false : true);
        completeStatusUI[26].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete27, 0) == 0 ? false : true);

        completeStatusUI[27].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete28, 0) == 0 ? false : true);
        completeStatusUI[28].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete29, 0) == 0 ? false : true);
        completeStatusUI[29].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete30, 0) == 0 ? false : true);
        completeStatusUI[30].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete31, 0) == 0 ? false : true);
        completeStatusUI[31].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete32, 0) == 0 ? false : true);
        completeStatusUI[32].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete33, 0) == 0 ? false : true);
        completeStatusUI[33].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete34, 0) == 0 ? false : true);
        completeStatusUI[34].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete35, 0) == 0 ? false : true);
        completeStatusUI[35].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete36, 0) == 0 ? false : true);

        completeStatusUI[36].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete37, 0) == 0 ? false : true);
        completeStatusUI[37].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete38, 0) == 0 ? false : true);
        completeStatusUI[38].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete39, 0) == 0 ? false : true);
        completeStatusUI[39].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete40, 0) == 0 ? false : true);
        completeStatusUI[40].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete41, 0) == 0 ? false : true);
        completeStatusUI[41].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete42, 0) == 0 ? false : true);
        completeStatusUI[42].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete43, 0) == 0 ? false : true);
        completeStatusUI[43].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete44, 0) == 0 ? false : true);
        completeStatusUI[44].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete45, 0) == 0 ? false : true);

        completeStatusUI[45].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete46, 0) == 0 ? false : true);
        completeStatusUI[46].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete47, 0) == 0 ? false : true);
        completeStatusUI[47].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete48, 0) == 0 ? false : true);
        completeStatusUI[48].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete49, 0) == 0 ? false : true);
        completeStatusUI[49].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete50, 0) == 0 ? false : true);
        completeStatusUI[50].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete51, 0) == 0 ? false : true);
        completeStatusUI[51].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete52, 0) == 0 ? false : true);
        completeStatusUI[52].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete53, 0) == 0 ? false : true);
        completeStatusUI[53].SetActive(PlayerPrefs.GetInt(customStrings.LevelComplete54, 0) == 0 ? false : true);
    }

    void SetCorrectLevelEndUIButtons()
    {
        if (gameModeManager.currentLevel == LevelNumbers._9)
        {
            if (diff_1 < levelRequiredToUnlockNextTier)
            {
                if (normalButtons.activeSelf)
                {
                    normalButtons.SetActive(false);
                }
                if (!lastLevelButtons.activeSelf)
                {
                    lastLevelButtons.SetActive(true);
                }
            }
            else
            {
                if (!normalButtons.activeSelf)
                {
                    normalButtons.SetActive(true);
                }
                if (lastLevelButtons.activeSelf)
                {
                    lastLevelButtons.SetActive(false);
                }
            }
        }
        else if (gameModeManager.currentLevel == LevelNumbers._18)
        {
            if (diff_2 < levelRequiredToUnlockNextTier)
            {
                if (normalButtons.activeSelf)
                {
                    normalButtons.SetActive(false);
                }
                if (!lastLevelButtons.activeSelf)
                {
                    lastLevelButtons.SetActive(true);
                }
            }
            else
            {
                if (!normalButtons.activeSelf)
                {
                    normalButtons.SetActive(true);
                }
                if (lastLevelButtons.activeSelf)
                {
                    lastLevelButtons.SetActive(false);
                }
            }
        }
        else if (gameModeManager.currentLevel == LevelNumbers._27)
        {
            if (diff_3 < levelRequiredToUnlockNextTier)
            {
                if (normalButtons.activeSelf)
                {
                    normalButtons.SetActive(false);
                }
                if (!lastLevelButtons.activeSelf)
                {
                    lastLevelButtons.SetActive(true);
                }
            }
            else
            {
                if (!normalButtons.activeSelf)
                {
                    normalButtons.SetActive(true);
                }
                if (lastLevelButtons.activeSelf)
                {
                    lastLevelButtons.SetActive(false);
                }
            }
        }
        else if (gameModeManager.currentLevel == LevelNumbers._36)
        {
            if (diff_4 < levelRequiredToUnlockNextTier)
            {
                if (normalButtons.activeSelf)
                {
                    normalButtons.SetActive(false);
                }
                if (!lastLevelButtons.activeSelf)
                {
                    lastLevelButtons.SetActive(true);
                }
            }
            else
            {
                if (!normalButtons.activeSelf)
                {
                    normalButtons.SetActive(true);
                }
                if (lastLevelButtons.activeSelf)
                {
                    lastLevelButtons.SetActive(false);
                }
            }
        }
        else if (gameModeManager.currentLevel == LevelNumbers._45)
        {
            if (diff_5 < levelRequiredToUnlockNextTier)
            {
                if (normalButtons.activeSelf)
                {
                    normalButtons.SetActive(false);
                }
                if (!lastLevelButtons.activeSelf)
                {
                    lastLevelButtons.SetActive(true);
                }
            }
            else
            {
                if (!normalButtons.activeSelf)
                {
                    normalButtons.SetActive(true);
                }
                if (lastLevelButtons.activeSelf)
                {
                    lastLevelButtons.SetActive(false);
                }
            }
        }
        else if (gameModeManager.currentLevel == LevelNumbers._54)
        {
            if (normalButtons.activeSelf)
            {
                normalButtons.SetActive(false);
            }
            if (!lastLevelButtons.activeSelf)
            {
                lastLevelButtons.SetActive(true);
            }
        }
        else
        {
            if (!normalButtons.activeSelf)
            {
                normalButtons.SetActive(true);
            }
            if (lastLevelButtons.activeSelf)
            {
                lastLevelButtons.SetActive(false);
            }
        }
    }

    ///* FUNCTION FOR LEVEL BUTTONS TO LOAD LEVEL*///
    public void LoadLevel1_1()
    {
        Invoke("LoadLevel1_1_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel1_1_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._1;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel1_2()
    {
        Invoke("LoadLevel1_2_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel1_2_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._2;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel1_3()
    {
        Invoke("LoadLevel1_3_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel1_3_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._3;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel1_4()
    {
        Invoke("LoadLevel1_4_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel1_4_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._4;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel1_5()
    {
        Invoke("LoadLevel1_5_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel1_5_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._5;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel1_6()
    {
        Invoke("LoadLevel1_6_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel1_6_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._6;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel1_7()
    {
        Invoke("LoadLevel1_7_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel1_7_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._7;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel1_8()
    {
        Invoke("LoadLevel1_8_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel1_8_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._8;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel1_9()
    {
        Invoke("LoadLevel1_9_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel1_9_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._9;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }



    public void LoadLevel2_1()
    {
        Invoke("LoadLevel2_1_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel2_1_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._10;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel2_2()
    {
        Invoke("LoadLevel2_2_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel2_2_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._11;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel2_3()
    {
        Invoke("LoadLevel2_3_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel2_3_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._12;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel2_4()
    {
        Invoke("LoadLevel2_4_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel2_4_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._13;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel2_5()
    {
        Invoke("LoadLevel2_5_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel2_5_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._14;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel2_6()
    {
        Invoke("LoadLevel2_6_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel2_6_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._15;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel2_7()
    {
        Invoke("LoadLevel2_7_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel2_7_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._16;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel2_8()
    {
        Invoke("LoadLevel2_8_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel2_8_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._17;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel2_9()
    {
        Invoke("LoadLevel2_9_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel2_9_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._18;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }



    public void LoadLevel3_1()
    {
        Invoke("LoadLevel3_1_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel3_1_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._19;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel3_2()
    {
        Invoke("LoadLevel3_2_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel3_2_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._20;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel3_3()
    {
        Invoke("LoadLevel3_3_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel3_3_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._21;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel3_4()
    {
        Invoke("LoadLevel3_4_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel3_4_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._22;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel3_5()
    {
        Invoke("LoadLevel3_5_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel3_5_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._23;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel3_6()
    {
        Invoke("LoadLevel3_6_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel3_6_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._24;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel3_7()
    {
        Invoke("LoadLevel3_7_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel3_7_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._25;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel3_8()
    {
        Invoke("LoadLevel3_8_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel3_8_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._26;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel3_9()
    {
        Invoke("LoadLevel3_9_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel3_9_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._27;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }



    public void LoadLevel4_1()
    {
        Invoke("LoadLevel4_1_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel4_1_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._28;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel4_2()
    {
        Invoke("LoadLevel4_2_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel4_2_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._29;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel4_3()
    {
        Invoke("LoadLevel4_3_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel4_3_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._30;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel4_4()
    {
        Invoke("LoadLevel4_4_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel4_4_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._31;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel4_5()
    {
        Invoke("LoadLevel4_5_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel4_5_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._32;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel4_6()
    {
        Invoke("LoadLevel4_6_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel4_6_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._33;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel4_7()
    {
        Invoke("LoadLevel4_7_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel4_7_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._34;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel4_8()
    {
        Invoke("LoadLevel4_8_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel4_8_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._35;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel4_9()
    {
        Invoke("LoadLevel4_9_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel4_9_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._36;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }



    public void LoadLevel5_1()
    {
        Invoke("LoadLevel5_1_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel5_1_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._37;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel5_2()
    {
        Invoke("LoadLevel5_2_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel5_2_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._38;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel5_3()
    {
        Invoke("LoadLevel5_3_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel5_3_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._39;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel5_4()
    {
        Invoke("LoadLevel5_4_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel5_4_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._40;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel5_5()
    {
        Invoke("LoadLevel5_5_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel5_5_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._41;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel5_6()
    {
        Invoke("LoadLevel5_6_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel5_6_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._42;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel5_7()
    {
        Invoke("LoadLevel5_7_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel5_7_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._43;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel5_8()
    {
        Invoke("LoadLevel5_8_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel5_8_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._44;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel5_9()
    {
        Invoke("LoadLevel5_9_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel5_9_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._45;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }



    public void LoadLevel6_1()
    {
        Invoke("LoadLevel6_1_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel6_1_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._46;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel6_2()
    {
        Invoke("LoadLevel6_2_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel6_2_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._47;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel6_3()
    {
        Invoke("LoadLevel6_3_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel6_3_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._48;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel6_4()
    {
        Invoke("LoadLevel6_4_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel6_4_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._49;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel6_5()
    {
        Invoke("LoadLevel6_5_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel6_5_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._50;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel6_6()
    {
        Invoke("LoadLevel6_6_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel6_6_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._51;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel6_7()
    {
        Invoke("LoadLevel6_7_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel6_7_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._52;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel6_8()
    {
        Invoke("LoadLevel6_8_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel6_8_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._53;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }

    public void LoadLevel6_9()
    {
        Invoke("LoadLevel6_9_function", levelMenuCommandExecutionDelay);
    }

    void LoadLevel6_9_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._54;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();

        SetCorrectLevelEndUIButtons();
    }
}
