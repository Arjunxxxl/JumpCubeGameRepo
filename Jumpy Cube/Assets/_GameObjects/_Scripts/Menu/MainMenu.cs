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
    public GameObject optimizationMenu;

    [Header("Optimization menues")]
    public GameObject optimizationRunning;
    public GameObject optimizationDone;

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

        commandExecuationDelay = buttonClickCommandExecutionDelay.mainmenuCommandExecutionDelay;

        isGameStart = false;
        mainMenu.SetActive(true);
        homeMenu.SetActive(true);
        playMenu.SetActive(false);
        store.SetActive(false);
        levels.SetActive(false);
        stats.SetActive(false);
        settings.SetActive(false);
        optimizationMenu.SetActive(false);

        foreach (Button b in allbuttons)
        {
            b.interactable = true;
        }

        tileSystem.SetActive(true);
        playerChild = player.transform.GetChild(1).gameObject;
        playerChild.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        optimizationMenu.SetActive(false);

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
        optimizationMenu.SetActive(false);

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
        optimizationMenu.SetActive(false);

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
        optimizationMenu.SetActive(false);
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
        optimizationMenu.SetActive(false);
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
        optimizationMenu.SetActive(false);
    }

    public void OptimizeTheGame()
    {
        homeMenu.SetActive(false);
        store.SetActive(false);
        levels.SetActive(false);
        stats.SetActive(false);
        settings.SetActive(false);
        optimizationMenu.SetActive(true);
    }

    public void OptimizeTheGame_done_stop()
    {
        homeMenu.SetActive(true);
        store.SetActive(false);
        levels.SetActive(false);
        stats.SetActive(false);
        settings.SetActive(false);
        optimizationMenu.SetActive(false);
    }
}
