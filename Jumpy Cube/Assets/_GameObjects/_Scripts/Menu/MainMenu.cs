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

    TimelinePlayer timelinePlayer;
    ButtonClickCommandExecutionDelay buttonClickCommandExecutionDelay;
    GameModeManager gameModeManager;

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
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        timelinePlayer = TimelinePlayer.Instance;
        buttonClickCommandExecutionDelay = ButtonClickCommandExecutionDelay.Instance;
        gameModeManager = GameModeManager.Instance;

        commandExecuationDelay = buttonClickCommandExecutionDelay.mainmenuCommandExecutionDelay;

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

                foreach (Button b in allbuttons)
                {
                    b.interactable = true;
                }
            }
        }
        else if (gameModeManager.gameMode == GameModeManager.GameMode.level)
        {
            gameModeManager.isGameRestarted = false;

            Play_CONTINIOUS();
        }

        tileSystem.SetActive(true);
        playerChild = player.transform.GetChild(1).gameObject;
        playerChild.SetActive(true);
    }
    

    public void Play()
    {
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
    }

    IEnumerator DisableMainMenuWithDelay()
    {
        yield return new WaitForSeconds(mainMenuDisableDealy);
        homeMenu.SetActive(false);
        mainMenu.SetActive(false);
    }
    
    public void HomeButton()
    {
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

    ///FUNCTIONS FOR CONTINIOUS LEVEL CHANGE
    ///

    public void Play_GameResetted()
    {
        isGameStart = true;
        
        homeMenu.SetActive(false);
        mainMenu.SetActive(false);

        playMenu.SetActive(true);
        store.SetActive(false);
        levels.SetActive(false);
        stats.SetActive(false);
        settings.SetActive(false);

        foreach (Button b in allbuttons)
        {
            b.interactable = false;
        }
    }

    public void Play_CONTINIOUS()
    {
        homeMenu.SetActive(false);
        mainMenu.SetActive(false);

        playMenu.SetActive(true);
        store.SetActive(false);
        levels.SetActive(false);
        stats.SetActive(false);
        settings.SetActive(false);

        StartCoroutine(StartGameWithDelay());

        timelinePlayer.PlayShowLevelNumber();

        foreach (Button b in allbuttons)
        {
            b.interactable = false;
        }
    }

    IEnumerator StartGameWithDelay()
    {
        yield return new WaitForSeconds(gameStartDelay);

        isGameStart = true;
    }

}
