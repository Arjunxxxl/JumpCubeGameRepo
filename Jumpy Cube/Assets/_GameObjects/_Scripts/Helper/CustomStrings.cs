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

    #region Store Strings
    public string CUBE_SELECTED = "SELECTED";
    public string CUBE_UNLOCKED = "SELECT";
    public string CUBE_LOCKED = "UNLOCK NOW";
    #endregion
}
