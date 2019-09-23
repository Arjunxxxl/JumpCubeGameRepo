using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColorThemeBoughtManager : MonoBehaviour
{
    public enum ColorScheme { cs_1, cs_2, cs_3, cs_4 }

    public class ColorSchemeString
    {
        public string COLOR_SCHEME_DEFAULT1 = "cs_d1";
        public string COLOR_SCHEME_DEFAULT2 = "cs_d2";
        public string COLOR_SCHEME_1 = "cs_1";
        public string COLOR_SCHEME_2 = "cs_2";
        public string COLOR_SCHEME_3 = "cs_3";
        public string COLOR_SCHEME_4 = "cs_4";
    }
    public ColorSchemeString colorSchemeString;

    [Header("Tile theme unlock status")]            //colorSchemeUnlocked and colorSchemeIndex(in SelectColorScheme class)
    public int color_scheme_Default1 = 0;           //1
    public int color_scheme_Default2 = 0;           //2
    public int color_scheme_1 = 0;                  //3
    public int color_scheme_2 = 0;                  //4
    public int color_scheme_3 = 0;                  //5
    public int color_scheme_4 = 0;                  //6

    public List<int> colorSchemeUnlocked;

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

    }
    #endregion

    public List<int> GetColorSchemeUnlockState()
    {
        GetUnlockedColorScheme();

        colorSchemeUnlocked = new List<int>();

        colorSchemeUnlocked.Add(1);
        colorSchemeUnlocked.Add(2);

        if (color_scheme_1 == 1)
        {
            colorSchemeUnlocked.Add(3);
        }

        if (color_scheme_1 == 2)
        {
            colorSchemeUnlocked.Add(4);
        }

        if (color_scheme_1 == 3)
        {
            colorSchemeUnlocked.Add(5);
        }

        if (color_scheme_1 == 4)
        {
            colorSchemeUnlocked.Add(6);
        }

        return colorSchemeUnlocked;
    }

    public void GetUnlockedColorScheme()
    {
        colorSchemeString = new ColorSchemeString();

        color_scheme_Default1 = PlayerPrefs.GetInt(colorSchemeString.COLOR_SCHEME_DEFAULT1, 1);
        color_scheme_Default1 = PlayerPrefs.GetInt(colorSchemeString.COLOR_SCHEME_DEFAULT1, 1);
        color_scheme_1 = PlayerPrefs.GetInt(colorSchemeString.COLOR_SCHEME_1, 1);
        color_scheme_2 = PlayerPrefs.GetInt(colorSchemeString.COLOR_SCHEME_2, 0);
        color_scheme_3 = PlayerPrefs.GetInt(colorSchemeString.COLOR_SCHEME_3, 0);
        color_scheme_4 = PlayerPrefs.GetInt(colorSchemeString.COLOR_SCHEME_4, 0);

        color_scheme_Default1 = color_scheme_Default2 = 1;          //safe code
    }

    //Use this function to save the theme when user buy a color it.
    public void BuyAndUnlockColorScheme(ColorScheme cs)
    {
        if (cs == ColorScheme.cs_1)
        {
            PlayerPrefs.SetInt(colorSchemeString.COLOR_SCHEME_1, 1);
        }
        else if (cs == ColorScheme.cs_2)
        {
            PlayerPrefs.SetInt(colorSchemeString.COLOR_SCHEME_2, 1);
        }
        else if (cs == ColorScheme.cs_3)
        {
            PlayerPrefs.SetInt(colorSchemeString.COLOR_SCHEME_3, 1);
        }
        else if (cs == ColorScheme.cs_4)
        {
            PlayerPrefs.SetInt(colorSchemeString.COLOR_SCHEME_4, 1);
        }

        GetUnlockedColorScheme();
    }
}
