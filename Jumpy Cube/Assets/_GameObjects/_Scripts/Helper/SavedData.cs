using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedData : MonoBehaviour
{
    public CustomStrings customStrings;
    public LifetimeStats lifetimeStats;

    int GAME_FIRST_RUN_INT;
    public bool isRunningForFirstTime;

    public int timesGamePlayed;
    int diamondsSpendInStore;
    int timesScoreShared;
    float previousAverage;
    int diamondsInOneRun;
    int maxDiamondsOwned;

    int totalCubesOwned;
    int commonCubesOwned;
    int rareCubesOwned;
    int legendaryCubesOwned;
    int missionCubesOwned;

    #region SingleTon
    public static SavedData Instance;
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

        GameRunningForFirstTime();

    }
    #endregion;
    

    void GameRunningForFirstTime()
    {
        GAME_FIRST_RUN_INT = PlayerPrefs.GetInt(customStrings.GAME_FIRST_RUN, 0);
        if (GAME_FIRST_RUN_INT == 0)
        {
            isRunningForFirstTime = true;
            PlayerPrefs.SetInt(customStrings.GAME_FIRST_RUN, 1);
        }
        else
        {
            isRunningForFirstTime = false;
        }
    }

    public void UpdateTimesGamePlayed()
    {
        timesGamePlayed = PlayerPrefs.GetInt(customStrings.TIMES_GAME_PLAYED, 0);
        timesGamePlayed++;
        PlayerPrefs.SetInt(customStrings.TIMES_GAME_PLAYED, timesGamePlayed);
    }

    public void UpdateDiamondsSpendInStore(int amt)
    {
        diamondsSpendInStore = PlayerPrefs.GetInt(customStrings.TOTAL_DIAMONDS_SPEND, 0);
        diamondsSpendInStore += amt;
        PlayerPrefs.SetInt(customStrings.TOTAL_DIAMONDS_SPEND, diamondsSpendInStore);
    }

    public void UpdateTimesScoreShared()
    {
        timesScoreShared = PlayerPrefs.GetInt(customStrings.TIMES_SCORE_SHARED, 0);
        timesScoreShared++;
        PlayerPrefs.SetInt(customStrings.TIMES_SCORE_SHARED, timesScoreShared);
    }

    public void SavePlayerHighScore(int score)
    {
        if(score > PlayerPrefs.GetInt(customStrings.HIGHSCORE, 0))
        {
            PlayerPrefs.SetInt(customStrings.HIGHSCORE, score);
        }
    }

    public void SavePlayerAverageScore(int score)
    {
        timesGamePlayed = PlayerPrefs.GetInt(customStrings.TIMES_GAME_PLAYED, 0);
        previousAverage = PlayerPrefs.GetFloat(customStrings.AVERAGE_SCORE_2, 0);

        previousAverage *= (timesGamePlayed - 1);

        previousAverage = (previousAverage + score) / timesGamePlayed;

        PlayerPrefs.SetFloat(customStrings.AVERAGE_SCORE_2, previousAverage);
    }

    public void SaveDiamondsCollectedinOneRun(int amt)
    {
        diamondsInOneRun = PlayerPrefs.GetInt(customStrings.DIAMONDS_COLLECTED_IN_ONE_RUN1, 0);

        if (amt > diamondsInOneRun)
        {
            diamondsInOneRun = amt;
            PlayerPrefs.SetInt(customStrings.DIAMONDS_COLLECTED_IN_ONE_RUN1, diamondsInOneRun);
        }
    }

    public void SaveMAxDiamondsOwned(int amt)
    {
        maxDiamondsOwned = PlayerPrefs.GetInt(customStrings.MAX_DIAMONDS_OWNED, 0);

        if(amt > maxDiamondsOwned)
        {
            maxDiamondsOwned = amt;
            PlayerPrefs.SetInt(customStrings.MAX_DIAMONDS_OWNED, maxDiamondsOwned);
        }
    }

    public void SaveMaxCubeOwned(int commonCubesAmt, int rareCubeAmt, int legendaryCubesAmt, int missionCubesAmt)
    {
        commonCubesOwned =  PlayerPrefs.GetInt(customStrings.COMMON_CUNES_OWNED, 0);
        rareCubesOwned = PlayerPrefs.GetInt(customStrings.RARE_CUNES_OWNED, 0);
        legendaryCubesOwned = PlayerPrefs.GetInt(customStrings.LEGENDARY_CUNES_OWNED, 0);
        missionCubesOwned = PlayerPrefs.GetInt(customStrings.MISSION_CUNES_OWNED, 0);

        commonCubesOwned = commonCubesOwned > commonCubesAmt ? commonCubesOwned : commonCubesAmt;
        rareCubesOwned = rareCubesOwned > rareCubeAmt ? rareCubesOwned : rareCubeAmt;
        legendaryCubesOwned = legendaryCubesOwned > legendaryCubesAmt ? legendaryCubesOwned : legendaryCubesAmt;
        missionCubesOwned = missionCubesOwned > missionCubesAmt ? missionCubesOwned : missionCubesAmt;

        PlayerPrefs.SetInt(customStrings.COMMON_CUNES_OWNED, commonCubesOwned);
        PlayerPrefs.SetInt(customStrings.RARE_CUNES_OWNED, rareCubesOwned);
        PlayerPrefs.SetInt(customStrings.LEGENDARY_CUNES_OWNED, legendaryCubesOwned);
        PlayerPrefs.SetInt(customStrings.MISSION_CUNES_OWNED, missionCubesOwned);

        totalCubesOwned = commonCubesOwned + rareCubesOwned + legendaryCubesOwned + missionCubesOwned;

        PlayerPrefs.SetInt(customStrings.TOTAL_CUBES_OWNED, totalCubesOwned);

        lifetimeStats.SetLifeTimeStats();
    }
    

}
