using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScore : MonoBehaviour
{
    public string TOTAL_DIAMOND_STR = "TOTAL_DIAMOND_STR";
    public string TOTAL_COLLECTED_STR = "TOTAL_COLLECTED_STR";
    public int totalDiamonds;
    public int collectedDiamonds;
    
    public MissionManager missionManager;
    public SavedData savedData;

    int temp;
    int temp2;
    int temp3;
    
    #region SingleTon
    public static DiamondScore Instance;
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

    public void SaveDiamondsCollected(int diamonds, bool isDiamondsBought_OR_ADs)
    {
        totalDiamonds = GetDiamonds();
        collectedDiamonds = GetInGameCollectedDiamonds();

        temp = totalDiamonds + diamonds;

        PlayerPrefs.SetInt(TOTAL_DIAMOND_STR, temp);

        savedData.SaveMAxDiamondsOwned(temp);

        if(!isDiamondsBought_OR_ADs)
        {
            temp3 = collectedDiamonds + diamonds;
            missionManager.CheckingForDiamondCollectMission(temp);

            PlayerPrefs.SetInt(TOTAL_COLLECTED_STR, temp);
        }
    }

    public int GetInGameCollectedDiamonds()
    {
        int d = PlayerPrefs.GetInt(TOTAL_COLLECTED_STR, 0);
        return d;
    }

    public int GetDiamonds()
    {
        int v = PlayerPrefs.GetInt(TOTAL_DIAMOND_STR, 0);
        return v;
    }

    public void CubeBought(int diamond_amt)
    {
        temp2 = -1 * diamond_amt;
        SaveDiamondsCollected(temp2, false);
    }

}
