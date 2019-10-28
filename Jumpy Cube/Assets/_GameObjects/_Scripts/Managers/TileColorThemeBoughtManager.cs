using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColorThemeBoughtManager : MonoBehaviour
{
    public enum ColorScheme { cs_d1, cs_1, cs_2, cs_3, cs_4, cs_5, cs_6, cs_7, cs_8 }
    
    public CustomStrings customeString;

    [Header("Tile theme unlock status")]            //colorSchemeUnlocked and colorSchemeIndex(in SelectColorScheme class)
    public int color_scheme_Default1 = 0;           //1
    public int color_scheme_1 = 0;                  //2
    public int color_scheme_2 = 0;                  //3
    public int color_scheme_3 = 0;                  //4
    public int color_scheme_4 = 0;                  //5
    public int color_scheme_5 = 0;                  //6
    public int color_scheme_6 = 0;                  //7
    public int color_scheme_7 = 0;                  //8
    public int color_scheme_8 = 0;                  //9

    public List<int> colorSchemeUnlocked;
    public int selectedColorScheme;
    public int totalColorScheme;
    
    #region SingleTon
    public static TileColorThemeBoughtManager Instances;
    private void Awake()
    {
        if (!Instances)
        {
            Instances = this;
        }
        else if (Instances != this)
        {
            Destroy(gameObject);
        }

        colorSchemeUnlocked = new List<int>();

        GetUnlockedColorScheme();
        GetColorSchemeUnlockState();

        GetSelectedColorScheme();
    }
    #endregion

    public void GetColorSchemeUnlockState()
    {
        if (!colorSchemeUnlocked.Contains(0))
        {
            colorSchemeUnlocked.Add(0);
        }

        if (color_scheme_1 == 1 && !colorSchemeUnlocked.Contains(1))
        {
            colorSchemeUnlocked.Add(1);
        }

        if (color_scheme_2 == 1 && !colorSchemeUnlocked.Contains(2))
        {
            colorSchemeUnlocked.Add(2);
        }

        if (color_scheme_3 == 1 && !colorSchemeUnlocked.Contains(3))
        {
            colorSchemeUnlocked.Add(3);
        }

        if (color_scheme_4 == 1 && !colorSchemeUnlocked.Contains(4))
        {
            colorSchemeUnlocked.Add(4);
        }

        if (color_scheme_5 == 1 && !colorSchemeUnlocked.Contains(5))
        {
            colorSchemeUnlocked.Add(5);
        }

        if (color_scheme_6 == 1 && !colorSchemeUnlocked.Contains(6))
        {
            colorSchemeUnlocked.Add(6);
        }

        if (color_scheme_7 == 1 && !colorSchemeUnlocked.Contains(7))
        {
            colorSchemeUnlocked.Add(7);
        }

        if (color_scheme_8 == 1 && !colorSchemeUnlocked.Contains(8))
        {
            colorSchemeUnlocked.Add(8);
        }
    }

    public void GetUnlockedColorScheme()
    {
        color_scheme_Default1 = PlayerPrefs.GetInt(customeString.COLOR_SCHEME_DEFAULT1, 1);
        color_scheme_1 = PlayerPrefs.GetInt(customeString.COLOR_SCHEME_1, 0);
        color_scheme_2 = PlayerPrefs.GetInt(customeString.COLOR_SCHEME_2, 0);
        color_scheme_3 = PlayerPrefs.GetInt(customeString.COLOR_SCHEME_3, 0);
        color_scheme_4 = PlayerPrefs.GetInt(customeString.COLOR_SCHEME_4, 0);
        color_scheme_5 = PlayerPrefs.GetInt(customeString.COLOR_SCHEME_5, 0);
        color_scheme_6 = PlayerPrefs.GetInt(customeString.COLOR_SCHEME_6, 0);
        color_scheme_7 = PlayerPrefs.GetInt(customeString.COLOR_SCHEME_7, 0);
        color_scheme_8 = PlayerPrefs.GetInt(customeString.COLOR_SCHEME_8, 0);

        color_scheme_Default1 = 1;          //safe code
    }

    public void GetSelectedColorScheme()
    {
        selectedColorScheme = PlayerPrefs.GetInt(customeString.SELECTED_COLOR_SCHEME, 0);
    }

    //Use this function to save the theme when user buy a color it.
    public void BuyColorScheme(ColorScheme cs)
    {
        switch(cs)
        {
            case ColorScheme.cs_d1:
                PlayerPrefs.SetInt(customeString.COLOR_SCHEME_DEFAULT1, 1);
                break;

            case ColorScheme.cs_1:
                PlayerPrefs.SetInt(customeString.COLOR_SCHEME_1, 1);
                break;

            case ColorScheme.cs_2:
                PlayerPrefs.SetInt(customeString.COLOR_SCHEME_2, 1);
                break;

            case ColorScheme.cs_3:
                PlayerPrefs.SetInt(customeString.COLOR_SCHEME_3, 1);
                break;

            case ColorScheme.cs_4:
                PlayerPrefs.SetInt(customeString.COLOR_SCHEME_4, 1);
                break;

            case ColorScheme.cs_5:
                PlayerPrefs.SetInt(customeString.COLOR_SCHEME_5, 1);
                break;

            case ColorScheme.cs_6:
                PlayerPrefs.SetInt(customeString.COLOR_SCHEME_6, 1);
                break;

            case ColorScheme.cs_7:
                PlayerPrefs.SetInt(customeString.COLOR_SCHEME_7, 1);
                break;

            case ColorScheme.cs_8:
                PlayerPrefs.SetInt(customeString.COLOR_SCHEME_8, 1);
                break;
        }
        
    }
}
