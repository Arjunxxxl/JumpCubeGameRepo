using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizedSavedData : MonoBehaviour
{
    public static string HAIL_EFFECT_STRING = "hail effect string";
    public static string GRADIENT_EFFECT_STRING = "gradient effect string";
    public static string GRADING_EFFECT_STRING = "grading effect string";
    public static string CHROME_EFFECT_STRING = "chrom abbrv effect string";
    public static string VIGNEET_EFFECT_STRING = "vigneet effect string";
    public static string BLOOM_EFFECT_STRING = "bloom effect string";
    public static string PP_EFFECT_STRING = "pp effect string";

    public int HAIL_EFFECT_INT;
    public int GRADIENT_EFFECT_INT;
    public int GRADING_EFFECT_INT;
    public int CHROME_EFFECT_INT;
    public int VIGNEET_EFFECT_INT;
    public int BLOOM_EFFECT_INT;
    public int PP_EFFECT_INT;

    public int[] savedOptimisezData;

    #region SingleTon
    public static OptimizedSavedData Instance;
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

        GetSavedOptimizedData();
    }
    #endregion

    public void SaveOptimizedData(bool hail, bool gradient, bool grading, bool chrome, bool vigneet, bool bloom)
    {
        if(hail)
        {
            HAIL_EFFECT_INT = 1;
        }
        else
        {
            HAIL_EFFECT_INT = 0;
        }

        if (gradient)
        {
            GRADIENT_EFFECT_INT = 1;
        }
        else
        {
            GRADIENT_EFFECT_INT = 0;
        }

        if (grading)
        {
            GRADING_EFFECT_INT = 1;
        }
        else
        {
            GRADING_EFFECT_INT = 0;
        }

        if (chrome)
        {
            CHROME_EFFECT_INT = 1;
        }
        else
        {
            CHROME_EFFECT_INT = 0;
        }

        if (vigneet)
        {
            VIGNEET_EFFECT_INT = 1;
        }
        else
        {
            VIGNEET_EFFECT_INT = 0;
        }

        if (bloom)
        {
            BLOOM_EFFECT_INT = 1;
            PP_EFFECT_INT = 1;
        }
        else
        {
            BLOOM_EFFECT_INT = 0;
            PP_EFFECT_INT = 0;
        }

        PlayerPrefs.SetInt(HAIL_EFFECT_STRING, HAIL_EFFECT_INT);
        PlayerPrefs.SetInt(GRADIENT_EFFECT_STRING, GRADIENT_EFFECT_INT);
        PlayerPrefs.SetInt(GRADING_EFFECT_STRING, GRADING_EFFECT_INT);
        PlayerPrefs.SetInt(CHROME_EFFECT_STRING, CHROME_EFFECT_INT);
        PlayerPrefs.SetInt(VIGNEET_EFFECT_STRING, VIGNEET_EFFECT_INT);
        PlayerPrefs.SetInt(BLOOM_EFFECT_STRING, BLOOM_EFFECT_INT);
        PlayerPrefs.SetInt(PP_EFFECT_STRING, PP_EFFECT_INT);
    }

    public void GetSavedOptimizedData()
    {
        savedOptimisezData = new int[7];

        HAIL_EFFECT_INT = PlayerPrefs.GetInt(HAIL_EFFECT_STRING, 0);
        GRADIENT_EFFECT_INT = PlayerPrefs.GetInt(GRADIENT_EFFECT_STRING, 0);
        GRADING_EFFECT_INT = PlayerPrefs.GetInt(GRADING_EFFECT_STRING, 0);
        CHROME_EFFECT_INT = PlayerPrefs.GetInt(CHROME_EFFECT_STRING, 0);
        VIGNEET_EFFECT_INT = PlayerPrefs.GetInt(VIGNEET_EFFECT_STRING, 0);
        BLOOM_EFFECT_INT = PlayerPrefs.GetInt(BLOOM_EFFECT_STRING, 0);
        PP_EFFECT_INT = PlayerPrefs.GetInt(PP_EFFECT_STRING, 0);

        savedOptimisezData[0] = HAIL_EFFECT_INT;
        savedOptimisezData[1] = GRADIENT_EFFECT_INT;
        savedOptimisezData[2] = GRADING_EFFECT_INT;
        savedOptimisezData[3] = CHROME_EFFECT_INT;
        savedOptimisezData[4] = VIGNEET_EFFECT_INT;
        savedOptimisezData[5] = BLOOM_EFFECT_INT;
        savedOptimisezData[6] = PP_EFFECT_INT;
    }
}
