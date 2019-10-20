using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public float commandExecutionDelay_inGame;
    public float commandExecutionDelay_pauseMenu;

    [Header("Menues")]
    public GameObject inGameMenu;
    public GameObject pauseMenu;
    public GameObject resumeDelayCounter;

    [Header("Data")]
    public TMP_Text afterResumeTxt;
    public float afterResumeTime;
    public float afterResumeDelay = 2.95f;

    public bool isPaused;

    TimelinePlayer timelinePlayer;
    LoadLevel loadLevel;
    ButtonClickCommandExecutionDelay buttonClickCommandExecutionDelay;
    MainMenu mainMenu;
    PlayerSpawner playerSpawner;
    PlayerDeath playerDeath;
    GameModeManager gameModeManager;
    PlayerMovement playerMovement;

    #region SingleTon
    public static PauseMenu Instance;
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

        isPaused = false;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        timelinePlayer = TimelinePlayer.Instance;
        loadLevel = LoadLevel.Instance;
        buttonClickCommandExecutionDelay = ButtonClickCommandExecutionDelay.Instance;
        mainMenu = MainMenu.Instance;
        playerSpawner = PlayerSpawner.Instance;
        playerDeath = PlayerDeath.Instance;
        gameModeManager = GameModeManager.Instance;
        playerMovement = PlayerMovement.Instance;

        pauseMenu.SetActive(false);
        resumeDelayCounter.SetActive(false);
        Time.timeScale = 1f;

        isPaused = false;
        afterResumeTxt.text = "3";
        afterResumeTime = 0;

        commandExecutionDelay_inGame = buttonClickCommandExecutionDelay.ingameMenuCommandExecutionDelay;
        commandExecutionDelay_pauseMenu = buttonClickCommandExecutionDelay.pauseMenuCommndExecutionDelay;

    }

    private void Update()
    {
        if(resumeDelayCounter.activeSelf)
        {
            afterResumeTime += Time.unscaledDeltaTime;
            afterResumeTxt.text = "" + (3 - (int)afterResumeTime);
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if(pause && mainMenu.isGameStart && !playerDeath.isDead && !gameModeManager.isTutorialActive && !playerMovement.isLevelCompleted && !resumeDelayCounter.activeSelf)
        {
            PauseGameFunction();
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if(!focus && mainMenu.isGameStart && !playerDeath.isDead && !gameModeManager.isTutorialActive && !playerMovement.isLevelCompleted && !resumeDelayCounter.activeSelf)
        {
            PauseGameFunction();
        }
    }

    public void PauseGame()
    {
        Invoke("PauseGameFunction", commandExecutionDelay_inGame);
    }

    void PauseGameFunction()
    {
        inGameMenu.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        timelinePlayer.PlayPausePlayable();

        isPaused = true;
    }

    public void ResumeGame()
    {
        StartCoroutine(ResumeGameFunction());
    }

    IEnumerator ResumeGameFunction()
    {
        yield return new WaitForSecondsRealtime(commandExecutionDelay_pauseMenu);
        pauseMenu.SetActive(false);
        resumeDelayCounter.SetActive(true);
        afterResumeTime = 0;

        timelinePlayer.StopPausePlayable();
        timelinePlayer.PlayResumeCountDown();

        StartCoroutine(AfterResumeDalay());
    }

    IEnumerator AfterResumeDalay()
    {
        yield return new WaitForSecondsRealtime(afterResumeDelay);
        resumeDelayCounter.SetActive(false);

        if (playerSpawner.isDisolveEffectDone && !playerDeath.isDead)
        {
            inGameMenu.SetActive(true);
        }

        Time.timeScale = 1f;

        timelinePlayer.StopResumeCountDown();

        isPaused = false;
    }

    public void HomeButton()
    {
        StartCoroutine(HomeButtonFunction());
    }

    IEnumerator HomeButtonFunction()
    {
        yield return new WaitForSecondsRealtime(commandExecutionDelay_pauseMenu);
        gameModeManager.gameMode = GameModeManager.GameMode.endless;
        gameModeManager.isGameRestarted = false;
        loadLevel.Load(loadLevel.SAMPLE_SCENE_NAME);
    }

    public void RestartGame()
    {
        StartCoroutine(RestartButtonFunction());
    }

    IEnumerator RestartButtonFunction()
    {
        yield return new WaitForSecondsRealtime(commandExecutionDelay_pauseMenu);
        gameModeManager.isGameRestarted = true;
        loadLevel.Load(loadLevel.SAMPLE_SCENE_NAME);
    }
}
