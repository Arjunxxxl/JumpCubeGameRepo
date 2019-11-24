using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public float commandExecuationDelay;

    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject homeMenu;
    public GameObject playMenu;
    public GameObject store;
    public GameObject levels;
    public GameObject stats;
    public GameObject settings;
    public GameObject quitGame;

    [Header("Data for continious level loading")]
    public float gameStartDelay = 1.5f;

    [Header("Buttons")]
    public Button[] allbuttons;

    [Header("Data for optimization")]
    public GameObject player;
    public GameObject tileSystem;
    public GameObject playerChild;

    public float mainMenuDisableDealy = 2.1f;

    [Header("Play Button Data")]
    public bool isGameStart;

    [Header("Level number UI")]
    public GameObject levelNumberUI;
    public float levelNumberShowingDuration = 5f;

    [Header("Starting dark canvas")]
    public GameObject startingDarkCanvas;
    public float disableAfterTime = 1.5f;
    public int showingStartingCanvas;

    TimelinePlayer timelinePlayer;
    ButtonClickCommandExecutionDelay buttonClickCommandExecutionDelay;
    GameModeManager gameModeManager;
    MissionManager missionManager;
    SavedData savedData;
    LevelMenu levelMenu;
    CustomAdManager customAdManager;
    BackgroundAudioManager backgroundAudioManager;

    CustomAnalytics customAnalytics;

    #region SingleTon
    public static MainMenu Instance;
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


        startingDarkCanvas.SetActive(false);
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        timelinePlayer = TimelinePlayer.Instance;
        buttonClickCommandExecutionDelay = ButtonClickCommandExecutionDelay.Instance;
        gameModeManager = GameModeManager.Instance;
        missionManager = MissionManager.Instance;
        savedData = SavedData.Instance;
        levelMenu = LevelMenu.Instance;
        customAdManager = CustomAdManager.Instance;

        customAnalytics = CustomAnalytics.Instance;
        backgroundAudioManager = BackgroundAudioManager.Instance;

        commandExecuationDelay = buttonClickCommandExecutionDelay.mainmenuCommandExecutionDelay;

        backgroundAudioManager.gameState = GameState.gameStart;
        
        levelNumberUI.SetActive(false);

        if (gameModeManager.gameMode == GameModeManager.GameMode.endless)
        {
            if (gameModeManager.isGameRestarted)
            {
                Play_GameResetted();
                gameModeManager.isGameRestarted = false;
            }
            else
            {
                gameModeManager.isGameRestarted = false;

                isGameStart = false;
                mainMenu.SetActive(true);
                homeMenu.SetActive(true);
                playMenu.SetActive(false);
                store.SetActive(false);
                levels.SetActive(false);
                stats.SetActive(false);
                settings.SetActive(false);
                quitGame.SetActive(false);

                foreach (Button b in allbuttons)
                {
                    b.interactable = true;
                }
            }
        }
        else if (gameModeManager.gameMode == GameModeManager.GameMode.level)
        {
            gameModeManager.isGameRestarted = false;

            Play_Level();
        }

        tileSystem.SetActive(true);
        playerChild = player.transform.GetChild(1).gameObject;
        playerChild.SetActive(true);

        showingStartingCanvas = gameModeManager.showStartingCanvas;
        if(showingStartingCanvas != 0)
        {
            if (!startingDarkCanvas.activeSelf)
            {
                startingDarkCanvas.SetActive(true);
            }
            timelinePlayer.PlayStartingDarkCanvas();
            Invoke("DisableStartingDarkCanvas", disableAfterTime);
            Debug.Log("1");
        }
        else
        {
            if (startingDarkCanvas.activeSelf)
            {
                startingDarkCanvas.SetActive(false);
                Debug.Log("2");
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(mainMenu.activeSelf)
            {
                if (quitGame.activeSelf)
                {
                    quitGame.SetActive(false);
                }
                else if (homeMenu.activeSelf)
                {
                    quitGame.SetActive(true);
                }
                else
                {
                    HomeButtonFunction();
                }
            }
        }
    }

    public void Play()
    {
        if(startingDarkCanvas.activeSelf || quitGame.activeSelf)
        {
            return;
        }

        isGameStart = true;

        timelinePlayer.MainmenuDiaable();
        StartCoroutine(DisableMainMenuWithDelay());

        playMenu.SetActive(true);
        store.SetActive(false);
        levels.SetActive(false);
        stats.SetActive(false);
        settings.SetActive(false);

        foreach (Button b in allbuttons)
        {
            b.interactable = false;
        }
        
        missionManager.CheckingForTimesGamePlayedMission();
        savedData.UpdateTimesGamePlayed();

        if (customAdManager != null)
        {
            customAdManager.UpdatePlayCount();
        }
        else
        {
            if (!customAdManager)
            {
                customAdManager = CustomAdManager.Instance;
            }
            customAdManager.UpdatePlayCount();
        }

        gameModeManager.showStartingCanvas++;

        customAnalytics.UpdatePlayCount();
        backgroundAudioManager.gameState = GameState.gamePlaying;
    }

    IEnumerator DisableMainMenuWithDelay()
    {
        yield return new WaitForSeconds(mainMenuDisableDealy);
        homeMenu.SetActive(false);
        mainMenu.SetActive(false);
    }
    
    public void HomeButton()
    {
        backgroundAudioManager.gameState = GameState.gameStart;
        Invoke("HomeButtonFunction", commandExecuationDelay);
    }

    void HomeButtonFunction()
    {
        playerChild = player.transform.GetChild(1).gameObject;

        tileSystem.SetActive(true);
        playerChild.SetActive(true);

        homeMenu.SetActive(true);
        store.SetActive(false);
        levels.SetActive(false);
        stats.SetActive(false);
        settings.SetActive(false);

    }

    public void StoreButton()
    {
        customAnalytics.StoreVisited();
        backgroundAudioManager.gameState = GameState.inTheMenues;

        Invoke("StoreButtonFunction", commandExecuationDelay);
    }

    void StoreButtonFunction()
    {
        playerChild = player.transform.GetChild(1).gameObject;

        homeMenu.SetActive(false);
        store.SetActive(true);
        levels.SetActive(false);
        stats.SetActive(false);
        settings.SetActive(false);

        tileSystem.SetActive(false);
        playerChild.SetActive(false);
    }

    public void LevelButton()
    {
        levelMenu.SetLevelCompleteUI();
        backgroundAudioManager.gameState = GameState.inTheMenues;
        Invoke("LevelButtonFunction", commandExecuationDelay);
    }

    void LevelButtonFunction()
    {
        homeMenu.SetActive(false);
        store.SetActive(false);
        levels.SetActive(true);
        stats.SetActive(false);
        settings.SetActive(false);
    }

    public void StatsButton()
    {
        customAnalytics.Stats_Visited();
        backgroundAudioManager.gameState = GameState.inTheMenues;

        Invoke("StatsButtonFunction", commandExecuationDelay);
    }

    void StatsButtonFunction()
    {
        homeMenu.SetActive(false);
        store.SetActive(false);
        levels.SetActive(false);
        stats.SetActive(true);
        settings.SetActive(false);
    }

    public void SettingButton()
    {
        customAnalytics.Settings_Visited();
        backgroundAudioManager.gameState = GameState.inTheMenues;

        Invoke("SettingsButtonFunction", commandExecuationDelay);
    }

    void SettingsButtonFunction()
    {
        homeMenu.SetActive(false);
        store.SetActive(false);
        levels.SetActive(false);
        stats.SetActive(false);
        settings.SetActive(true);
    }

    public void QuitGame()
    {
        Invoke("QuitGame_Function", commandExecuationDelay);
    }

    void QuitGame_Function()
    {
        Application.Quit();
    }

    public void NotQuitGame()
    {
        Invoke("NotQuitGame_Function", commandExecuationDelay);
    }

    public void NotQuitGame_Function()
    {
        quitGame.SetActive(false);
    }

    void DisableStartingDarkCanvas()
    {
        startingDarkCanvas.SetActive(false);
        Debug.Log("3");
    }

    ///FUNCTIONS FOR CONTINIOUS LEVEL CHANGE
    ///

    public void Play_GameResetted()
    {
        
        homeMenu.SetActive(false);
        mainMenu.SetActive(false);

        playMenu.SetActive(true);
        store.SetActive(false);
        levels.SetActive(false);
        stats.SetActive(false);
        settings.SetActive(false);

        StartCoroutine(StartGameWithDelay());

        foreach (Button b in allbuttons)
        {
            b.interactable = false;
        }
        
        missionManager.CheckingForTimesGamePlayedMission();
        savedData.UpdateTimesGamePlayed();

        if (!customAdManager)
        {
            customAdManager = CustomAdManager.Instance;
        }
        customAdManager.UpdatePlayCount();

        gameModeManager.showStartingCanvas++;
        
        customAnalytics.UpdatePlayCount();
        backgroundAudioManager.gameState = GameState.gamePlaying;
    }

    public void Play_Level()
    {
        homeMenu.SetActive(false);
        mainMenu.SetActive(false);

        playMenu.SetActive(true);
        store.SetActive(false);
        levels.SetActive(false);
        stats.SetActive(false);
        settings.SetActive(false);

        StartCoroutine(StartGameWithDelay());
        
        levelNumberUI.SetActive(true);
        levelMenu.SetCorrectLevelNumber();

        StartCoroutine(DisableLevelNumberUI());

        foreach (Button b in allbuttons)
        {
            b.interactable = false;
        }
        
        missionManager.CheckingForTimesGamePlayedMission();
        savedData.UpdateTimesGamePlayed();

        if (!customAdManager)
        {
            customAdManager = CustomAdManager.Instance;
        }
        customAdManager.UpdatePlayCount();

        gameModeManager.showStartingCanvas++;

        customAnalytics.UpdatePlayCount();
        backgroundAudioManager.gameState = GameState.gamePlaying;
    }

    IEnumerator StartGameWithDelay()
    {
        yield return new WaitForSeconds(gameStartDelay);

        isGameStart = true;

        if (gameModeManager.gameMode == GameModeManager.GameMode.level)
        {
            timelinePlayer.PlayShowLevelNumber();
        }
    }

    IEnumerator DisableLevelNumberUI()
    {
        yield return new WaitForSeconds(levelNumberShowingDuration);
        
        levelNumberUI.SetActive(false);
    }
}
