using System.Collections;
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

    public bool checker;
    bool isProcessing;

    Texture2D screenCapture;

    PlayerDeath playerDeath;
    PlayerMovement playerMovement;
    LoadLevel loadLevel;
    TimelinePlayer timelinePlayer;
    MissionManager missionManager;
    ButtonClickCommandExecutionDelay buttonClickCommandExecutionDelay;
    DiamondScore diamondScore;
    GameModeManager gameModeManager;
    RevivePlayer revivePlayer;
    

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

        if(!revivePlayer)
        {
            revivePlayer = GetComponent<RevivePlayer>();
        }

        gameoverMenuCommandExecutionDelay = buttonClickCommandExecutionDelay.gameoverMenuCommandExecutionDelay;

        gameOverMenu.SetActive(false);
        currentTime = 0;
        checker = false;

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

            currentTime += Time.deltaTime;

            if (currentTime > gameOverMenuShowDelay)
            {
                if (!gameModeManager.isTutorialActive)
                { 
                    revivalMenu.SetActive(true);
                    rivivalTotalDiamonds.text = diamondScore.GetDiamonds() + "";
                }
                else if (gameModeManager.isTutorialActive && gameModeManager.gameMode == GameModeManager.GameMode.endless)
                {
                    revivePlayer.ReviePlayerFunction();
                }
                else if(gameModeManager.isTutorialActive && gameModeManager.gameMode == GameModeManager.GameMode.level)
                {
                    revivalMenu.SetActive(true);
                    rivivalTotalDiamonds.text = diamondScore.GetDiamonds() + "";
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

    public void ShareScreenshotButtonPressed()
    {
        missionManager.CheckingForShareScoreMission();

        DisableAllButtons();

        Invoke("ShareScreenShotFunction", gameoverMenuCommandExecutionDelay);
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


        ActivateAllButtons();
        //old meathod
        //StartCoroutine(ShareScreenshot());
    }

    IEnumerator ShareScreenshot()
    {
        isProcessing = true;

        if(path == "")
        {
#if UNITY_ANDROID
            path = Path.Combine(Application.persistentDataPath, "ScreenShot.png");
#endif
#if UNITY_EDITOR
            path = "ScreenShot.png";
#endif
        }

        //yield return null;
        yield return new WaitForSecondsRealtime(0.3f);

        if (!Application.isEditor)
        {
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + path);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"),
                uriObject);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"),
                "Can you beat my score?");
            intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser",
                intentObject, "Share your new score");
            currentActivity.Call("startActivity", chooser);

            yield return new WaitForSecondsRealtime(1);
        }

        isProcessing = false;
    }

    public void HomeButton()
    {
        DisableAllButtons();
        Invoke("HomeButtonFunction", gameoverMenuCommandExecutionDelay);
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
        Invoke("WatchAdsForDoubleRewardFunction", gameoverMenuCommandExecutionDelay);
    }

    void WatchAdsForDoubleRewardFunction()
    {
        ActivateAllButtons();
    }

    public void ReplayButton()
    {
        Invoke("ReplayButtonFunction", gameoverMenuCommandExecutionDelay);
    }

    void ReplayButtonFunction()
    {
        DisableAllButtons();
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
        if (!endless_Buttons.activeSelf)
        {
            endless_Buttons.SetActive(true);
        }
        if (levelButtons.activeSelf)
        {
            levelButtons.SetActive(false);
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
}
