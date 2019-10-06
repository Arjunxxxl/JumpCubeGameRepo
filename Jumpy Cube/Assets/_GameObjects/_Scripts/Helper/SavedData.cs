using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedData : MonoBehaviour
{
    public CustomStrings customStrings;

    int GAME_FIRST_RUN_INT;
    public bool isRunningForFirstTime;

    int timesGamePlayed;
    int diamondsSpendInStore;
    int timesScoreShared;

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
}
