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

    #region Mission cubes string
    public string MISSION_CUBE0 = "Mission Cube 1";         //coin tire1
    public string MISSION_CUBE1 = "Mission Cube 2";         //distance tire1
    public string MISSION_CUBE2 = "Mission Cube 3";         //times game played tire1
    public string MISSION_CUBE3 = "Mission Cube 4";         //times score shared tire1
    public string MISSION_CUBE4 = "Mission Cube 5";         //diamond spend tire1
    public string MISSION_CUBE5 = "Mission Cube 6";         //number of jumps tire1
    #endregion

    #region Store Strings
    public string CUBE_SELECTED = "SELECTED";
    public string CUBE_UNLOCKED = "SELECT";
    public string CUBE_LOCKED = "UNLOCK NOW";
    public string MISSION_NOTDONE = "SKIP";
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

    #region Saved Data String for missions and game running for first time
    public string GAME_FIRST_RUN = "GAME FIRST RUN";
    public string TIMES_GAME_PLAYED = "Times game played";
    public string TIMES_PLAYER_DIED = "TIMES PLAYER DIED";
    public string TIME_SPEND_INGAME = "TIME SPEND IN GAME";
    public string TOTAL_DIAMONDS_SPEND = "TOTAL DIAMONDS SPEND";
    public string TIMES_SCORE_SHARED = "TIMES SCORE SHARED";
    public string TIMES_PLAYER_JUMPED = "TIMES PLAYER JUMPED";
    #endregion

    #region Saved Data strings for stats
    public string HIGHSCORE = "HIGHSCORE";
    public string AVERAGE_SCORE_2 = "AVERAGE_SCORE_player";
    public string DIAMONDS_COLLECTED_IN_ONE_RUN1 = "MAX DIAMONDS COLLECTED IN ONE RUN1";
    public string MAX_DIAMONDS_OWNED = "MAX DIAMONDS OWNED";
    public string TOTAL_CUBES_OWNED = "TOTAL CUBES OWNED";

    public string COMMON_CUNES_OWNED = "COMMON CUBES OWNED";
    public string RARE_CUNES_OWNED = "RARE CUBES OWNED";
    public string LEGENDARY_CUNES_OWNED = "LEGENDARY CUBES OWNED";
    public string MISSION_CUNES_OWNED = "MISSION CUBES OWNED";
    #endregion

    #region SETTINGS STRINGS
    public string GAME_SOUND_STRING = "GAME SOUND STRING";
    public string VIBRATION_STRING = "VIBRATION STRING";
    public string HIGH_QUALITY_STRING = "HIGH QUALITY STRING";
    #endregion

    #region TUTORIAL STRINGS
    public string TUTORIAL_COMPLETED = "TUTORIAL COMPLETED";
    #endregion
}
