using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelMenu : MonoBehaviour
{
    public TMP_Text levelText;

    [Header("Screen Shot Data")]
    public RawImage screenShotImg;
    public string path;
    public float screenShotDelay = 1f;
    public float screenshotDiaplayDelay = 2.5f;

    [Header("Level Mode Button parents")]
    public GameObject normalButtons;
    public GameObject lastLevelButtons;

    LevelManager levelManager;
    TileSequence tileSequence;
    GameModeManager gameModeManager;
    MainMenu mainMenu;
    LoadLevel loadLevel;
    ButtonClickCommandExecutionDelay buttonClickCommandExecutionDelay;
    MissionManager missionManager;

    float levelMenuCommandExecutionDelay;
    float levelOverMenuCommandExecutionDelay;

    int levelNo = 0;
    string levelname = "Level ";
    string finnalName;

    #region SingleTon
    public static LevelMenu Instance;
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
        levelManager = LevelManager.Instance;
        tileSequence = TileSequence.Instance;
        gameModeManager = GameModeManager.Instance;
        mainMenu = MainMenu.Instance;
        loadLevel = LoadLevel.Instance;
        buttonClickCommandExecutionDelay = ButtonClickCommandExecutionDelay.Instance;
        missionManager = MissionManager.Instance;

        levelNo = 0;
        finnalName = levelname + levelNo;

        levelMenuCommandExecutionDelay = buttonClickCommandExecutionDelay.levelMenuCommandExecutionDelay;
        levelOverMenuCommandExecutionDelay = buttonClickCommandExecutionDelay.levelOverMenuCommandExecutionDelay;

        if (gameModeManager.currentLevel == LevelNumbers._54)
        {
            normalButtons.SetActive(false);
            lastLevelButtons.SetActive(true);
        }
        else
        {
            normalButtons.SetActive(true);
            lastLevelButtons.SetActive(false);
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
        StartCoroutine(HomeButtonFunction());
    }

    public void ReplayButton()
    {
        StartCoroutine(RestartButtonFunction());
    }

    public void NextLevelButton()
    {
        StartCoroutine(NextLevelButtonFunction());
    }

    IEnumerator RestartButtonFunction()
    {
        yield return new WaitForSecondsRealtime(levelOverMenuCommandExecutionDelay);
        gameModeManager.gameMode = GameModeManager.GameMode.level;
        gameModeManager.isGameRestarted = true;
        loadLevel.Load(loadLevel.SAMPLE_SCENE_NAME);
    }

    IEnumerator NextLevelButtonFunction()
    {
        yield return new WaitForSecondsRealtime(levelOverMenuCommandExecutionDelay);
        gameModeManager.gameMode = GameModeManager.GameMode.level;
        gameModeManager.isGameRestarted = true;

        gameModeManager.currentLevel = gameModeManager.nextLevel;
        gameModeManager.nextLevel = levelManager.NextLevel(gameModeManager.currentLevel);

        loadLevel.Load(loadLevel.SAMPLE_SCENE_NAME);
    }

    IEnumerator HomeButtonFunction()
    {
        yield return new WaitForSecondsRealtime(levelOverMenuCommandExecutionDelay);
        gameModeManager.gameMode = GameModeManager.GameMode.endless;
        gameModeManager.isGameRestarted = false;
        loadLevel.Load(loadLevel.SAMPLE_SCENE_NAME);
    }

    public void ShareScreenshotButtonPressed()
    {
        missionManager.CheckingForShareScoreMission();

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
        
    }

    public void SetCorrectLevelNumber()
    {
        if(!gameModeManager)
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
                levelNo = 55;
                break;
        }
        
        finnalName = levelname + levelNo;

        levelText.text = finnalName;
    }

    ///* FUNCTION FOR LEVEL BUTTONS *///
    public void LoadLevel1()
    {
        Invoke("LoadLevel1_function", levelMenuCommandExecutionDelay);
    }
    
    void LoadLevel1_function()
    {
        levelManager.selectedLevelNumber = LevelNumbers._1;

        gameModeManager.currentLevel = levelManager.selectedLevelNumber;
        gameModeManager.nextLevel = levelManager.NextLevel(levelManager.selectedLevelNumber);

        gameModeManager.gameMode = GameModeManager.GameMode.level;
        tileSequence.LoadCurrentLevel();
        mainMenu.Play_Level();
    }
}
