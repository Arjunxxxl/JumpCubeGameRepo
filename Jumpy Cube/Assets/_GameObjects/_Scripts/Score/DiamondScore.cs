using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScore : MonoBehaviour
{
    public string TOTAL_DIAMOND_STR = "TOTAL_DIAMOND_STR";
    public int totalDiamonds;

    int temp;
    int temp2;

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

    public void SaveDiamondsCollected(int diamonds)
    {
        totalDiamonds = GetDiamonds();
        temp = totalDiamonds + diamonds;
        PlayerPrefs.SetInt(TOTAL_DIAMOND_STR, temp);
    }

    public int GetDiamonds()
    {
        int v = PlayerPrefs.GetInt(TOTAL_DIAMOND_STR, 0);
        return v;
    }

    public void CubeBought(int diamond_amt)
    {
        temp2 = -1 * diamond_amt;
        SaveDiamondsCollected(temp2);
    }

}
