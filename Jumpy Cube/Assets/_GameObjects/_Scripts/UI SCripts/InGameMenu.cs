﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text diamondsCollected_txt;
    public GameObject inGameMenu;
    public GameObject levelEndMenu;

    [Header("Data")]
    public bool isMenuActivated;

    [Header("Level complete data")]
    public TMP_Text distanceTxt;
    public TMP_Text diamondsTxt;
    public TMP_Text averageScoreTxt;
    int currentScore;
    public int currentDiamonds;
    float averageScore;

    [Header("watch ads and share button - level end menu")]
    public GameObject levelEnd_disableWatchAdsPannel_button;
    public GameObject levelEnd_disableWatchAdsPannel;
    public GameObject levelEnd_disableSharePannel_button;
    public GameObject levelEnd_disableSharePannel;

    [Header("Data")]
    public float levelCompeleteMenuDelay = 3.5f;

    [Header("Items Data")]
    public int diamondsCollected;
    public int diamondsMultiplier;
    public int diamondValue;
    public int realNumberOfDiamondsCollected;

    [Header("HighScore Data")]
    public GameObject score_best;
    public GameObject diamonds_best;
    public GameObject average_best;
    public float trophyShowingDelay = 1.25f;
    public float trophyScowingOffset = 0.5f;

    int highScore;
    int diamondBest;
    int averageBest;

    PlayerSpawner playerSpawner;
    TimelinePlayer timelinePlayer;
    CustomStrings customStrings;
    DistanceScore distanceScore;
    SavedData savedData;
    LevelMenu levelMenu;
    GameModeManager gameModeManager;
    NetworkManager networkManager;

    #region SingleTon
    public static InGameMenu Instance;
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
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        playerSpawner = PlayerSpawner.Instance;
        timelinePlayer = TimelinePlayer.Instance;
        customStrings = CustomStrings.Instance;
        distanceScore = DistanceScore.Instance;
        savedData = SavedData.Instance;
        levelMenu = LevelMenu.Instance;
        gameModeManager = GameModeManager.Instance;
        networkManager = NetworkManager.Instance;

        inGameMenu.SetActive(false);
        levelEndMenu.SetActive(false);

        isMenuActivated = false;

        diamondsMultiplier = 1;
        diamondsCollected = 0;
        realNumberOfDiamondsCollected = 0;
        diamondValue = 1;

        diamondsCollected_txt.text = diamondsCollected + "";

        score_best.SetActive(false);
        diamonds_best.SetActive(false);
        average_best.SetActive(false);
        highScore = PlayerPrefs.GetInt(customStrings.HIGHSCORE, 0);
        diamondBest = PlayerPrefs.GetInt(customStrings.DIAMONDS_COLLECTED_IN_ONE_RUN1, 0);
        averageBest = (int)PlayerPrefs.GetFloat(customStrings.AVERAGE_SCORE_2, 0);

        if (levelEnd_disableSharePannel_button.activeSelf) { levelEnd_disableSharePannel_button.SetActive(false); }
        if (levelEnd_disableSharePannel.activeSelf) { levelEnd_disableSharePannel.SetActive(false); }
        if (levelEnd_disableWatchAdsPannel_button.activeSelf) {  levelEnd_disableWatchAdsPannel_button.SetActive(false); }
        if (levelEnd_disableWatchAdsPannel.activeSelf) { levelEnd_disableWatchAdsPannel.SetActive(false);}
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMenuActivated)
        { 
            if (playerSpawner.isDisolveEffectDone)
            {
                if (!inGameMenu.activeSelf)
                {
                    inGameMenu.SetActive(true);
                }
                isMenuActivated = true;

                timelinePlayer.PlayIngameMenuActivated();
            }
        }
    }

    public void DiamondCollected()
    {
        diamondsCollected = diamondsCollected + (diamondValue * diamondsMultiplier);
        realNumberOfDiamondsCollected = realNumberOfDiamondsCollected + (diamondValue * diamondsMultiplier);

        diamondsCollected_txt.text = diamondsCollected + "";

        timelinePlayer.PlayDiamondCollectUiEffect();
    }

    public void ActivateLevelEndMenu()
    {
        inGameMenu.SetActive(false);
        Invoke("ActivateLevelEndMenu_Function", levelCompeleteMenuDelay);

        averageScore = PlayerPrefs.GetFloat(customStrings.AVERAGE_SCORE_2, 0);
        currentScore = distanceScore.distance;
        currentDiamonds = diamondsCollected;

        distanceTxt.text = currentScore + "m";
        diamondsTxt.text = currentDiamonds + "";
        averageScoreTxt.text = (int)averageScore + "";

        savedData.SavePlayerHighScore(distanceScore.distance);
        savedData.SavePlayerAverageScore(distanceScore.distance);
        savedData.SaveDiamondsCollectedinOneRun(diamondsCollected);

        levelMenu.UpdateLevelCompleteStatus(gameModeManager.currentLevel);

        if(!networkManager.CheckForInternet())
        {
            if (!levelEnd_disableWatchAdsPannel_button.activeSelf) { levelEnd_disableWatchAdsPannel_button.SetActive(true); }
            if (!levelEnd_disableWatchAdsPannel.activeSelf) { levelEnd_disableWatchAdsPannel.SetActive(true); }
        }
    }

    void ActivateLevelEndMenu_Function()
    {
        levelEndMenu.SetActive(true);
        CheckForHighScore();
    }

    void CheckForHighScore()
    {
        if (currentScore > highScore)
        {
            StartCoroutine("ShowScoreBestTophy");
        }

        if (currentDiamonds > diamondBest)
        {
            StartCoroutine("ShowDiamondBestTrophy");
        }

        if (averageScore > averageBest)
        {
            StartCoroutine("ShowAverageBestTrophy");
        }
    }

    IEnumerator ShowScoreBestTophy()
    {
        yield return new WaitForSeconds(trophyShowingDelay);
        score_best.SetActive(true);
        timelinePlayer.PlayScoreBest_lc();
    }

    IEnumerator ShowDiamondBestTrophy()
    {
        yield return new WaitForSeconds(trophyShowingDelay + trophyScowingOffset);
        diamonds_best.SetActive(true);
        timelinePlayer.PlayDiamondsBest_lc();
    }

    IEnumerator ShowAverageBestTrophy()
    {
        yield return new WaitForSeconds(trophyShowingDelay + trophyScowingOffset + trophyScowingOffset);
        average_best.SetActive(true);
        timelinePlayer.PlayAverageBest_lc();
    }
}
