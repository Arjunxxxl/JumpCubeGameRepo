using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomStrings : MonoBehaviour
{
    #region SingleTon
    public static CustomStrings Instance;
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

    #region Selected Cube Index And selected cube type
    public string SELECTED_CUBE_INDEX = "selected_cube_index";
    public string SELECTED_CUBE_TYPE = "selected_cube_type";
    #endregion

    #region Common cubes string
    public string COMMON_CUBE0 = "Common Cube 1";
    public string COMMON_CUBE1 = "Common Cube 2";
    public string COMMON_CUBE2 = "Common Cube 3";
    public string COMMON_CUBE3 = "Common Cube 4";
    public string COMMON_CUBE4 = "Common Cube 5";
    public string COMMON_CUBE5 = "Common Cube 6";
    public string COMMON_CUBE6 = "Common Cube 7";
    public string COMMON_CUBE7 = "Common Cube 8";
    public string COMMON_CUBE8 = "Common Cube 9";
    #endregion

    #region Rare cubes string
    public string RARE_CUBE0 = "Rare Cube 1";
    public string RARE_CUBE1 = "Rare Cube 2";
    public string RARE_CUBE2 = "Rare Cube 3";
    public string RARE_CUBE3 = "Rare Cube 4";
    public string RARE_CUBE4 = "Rare Cube 5";
    public string RARE_CUBE5 = "Rare Cube 6";
    public string RARE_CUBE6 = "Rare Cube 7";
    public string RARE_CUBE7 = "Rare Cube 8";
    public string RARE_CUBE8 = "Rare Cube 9";
    #endregion

    #region Legendary cubes string
    public string LEGENDARY_CUBE0 = "Legendary Cube 1";
    public string LEGENDARY_CUBE1 = "Legendary Cube 2";
    public string LEGENDARY_CUBE2 = "Legendary Cube 3";
    public string LEGENDARY_CUBE3 = "Legendary Cube 4";
    public string LEGENDARY_CUBE4 = "Legendary Cube 5";
    public string LEGENDARY_CUBE5 = "Legendary Cube 6";
    public string LEGENDARY_CUBE6 = "Legendary Cube 7";
    public string LEGENDARY_CUBE7 = "Legendary Cube 8";
    public string LEGENDARY_CUBE8 = "Legendary Cube 9";
    #endregion

    #region Store Strings
    public string CUBE_SELECTED = "SELECTED";
    public string CUBE_UNLOCKED = "SELECT";
    public string CUBE_LOCKED = "UNLOCK NOW";
    #endregion

    #region Color Sceheme Strings
    public string SELECTED_COLOR_SCHEME = "SELECTED COLOR SCHEME";
    public string COLOR_SCHEME_DEFAULT1 = "cs_d1";
    public string COLOR_SCHEME_1 = "cs_1";
    public string COLOR_SCHEME_2 = "cs_2";
    public string COLOR_SCHEME_3 = "cs_3";
    public string COLOR_SCHEME_4 = "cs_4";
    public string COLOR_SCHEME_5 = "cs_5";
    public string COLOR_SCHEME_6 = "cs_6";
    public string COLOR_SCHEME_7 = "cs_7";
    public string COLOR_SCHEME_8 = "cs_8";
    #endregion

}
