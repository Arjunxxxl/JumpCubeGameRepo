using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelNumbers { _0, _1, _2, _3, _4, _5, _6, _7, _8, _9,
                        _10, _11, _12, _13, _14, _15, _16, _17, _18,
                        _19, _20, _21, _22, _23, _24, _25, _26, _27,
                        _28, _29, _30, _31, _32, _33, _34, _35, _36,
                        _37, _38, _39, _40, _41, _42, _43, _44, _45,
                        _46, _47, _48, _49, _50, _51, _52, _53, _54}

public class LevelManager : MonoBehaviour
{
    public LevelNumbers selectedLevelNumber;

    GameModeManager gameModeManager;
    TileSequence tileSequence;
    public CustomStrings customStrings;

    LevelNumbers nextLevel;

    #region SingleTon
    public static LevelManager Instance;
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

    // Start is called before the first frame update
    void Start()
    {
        gameModeManager = GameModeManager.Instance;
        tileSequence = TileSequence.Instance;

        if (!customStrings)
        {
            customStrings = CustomStrings.Instance;
        }

        gameModeManager.isTutorialActive = PlayerPrefs.GetInt(customStrings.TUTORIAL_COMPLETED, 0) == 0 ? true : false /*false*/;

        if (gameModeManager.isTutorialActive && gameModeManager.gameMode == GameModeManager.GameMode.endless)
        {
            selectedLevelNumber = LevelNumbers._0;
            tileSequence.LoadCurrentLevel();
        }
        else
        {
            selectedLevelNumber = gameModeManager.currentLevel;
            tileSequence.LoadCurrentLevel();
        }

        nextLevel = LevelNumbers._1;
    }
    
    public LevelNumbers NextLevel(LevelNumbers currentLevel)
    {
        switch(currentLevel)
        {
            case LevelNumbers._1:
                nextLevel = LevelNumbers._2;
                break;

            case LevelNumbers._2:
                nextLevel = LevelNumbers._3;
                break;

            case LevelNumbers._3:
                nextLevel = LevelNumbers._4;
                break;

            case LevelNumbers._4:
                nextLevel = LevelNumbers._5;
                break;

            case LevelNumbers._5:
                nextLevel = LevelNumbers._6;
                break;

            case LevelNumbers._6:
                nextLevel = LevelNumbers._7;
                break;

            case LevelNumbers._7:
                nextLevel = LevelNumbers._8;
                break;

            case LevelNumbers._8:
                nextLevel = LevelNumbers._9;
                break;

            case LevelNumbers._9:
                nextLevel = LevelNumbers._10;
                break;

            case LevelNumbers._10:
                nextLevel = LevelNumbers._11;
                break;

            case LevelNumbers._11:
                nextLevel = LevelNumbers._12;
                break;

            case LevelNumbers._12:
                nextLevel = LevelNumbers._13;
                break;

            case LevelNumbers._13:
                nextLevel = LevelNumbers._14;
                break;

            case LevelNumbers._14:
                nextLevel = LevelNumbers._15;
                break;

            case LevelNumbers._15:
                nextLevel = LevelNumbers._16;
                break;

            case LevelNumbers._16:
                nextLevel = LevelNumbers._17;
                break;

            case LevelNumbers._17:
                nextLevel = LevelNumbers._18;
                break;

            case LevelNumbers._18:
                nextLevel = LevelNumbers._19;
                break;

            case LevelNumbers._19:
                nextLevel = LevelNumbers._20;
                break;

            case LevelNumbers._20:
                nextLevel = LevelNumbers._21;
                break;

            case LevelNumbers._21:
                nextLevel = LevelNumbers._22;
                break;

            case LevelNumbers._22:
                nextLevel = LevelNumbers._23;
                break;

            case LevelNumbers._23:
                nextLevel = LevelNumbers._24;
                break;

            case LevelNumbers._24:
                nextLevel = LevelNumbers._25;
                break;

            case LevelNumbers._25:
                nextLevel = LevelNumbers._26;
                break;

            case LevelNumbers._26:
                nextLevel = LevelNumbers._27;
                break;

            case LevelNumbers._27:
                nextLevel = LevelNumbers._28;
                break;

            case LevelNumbers._28:
                nextLevel = LevelNumbers._29;
                break;

            case LevelNumbers._29:
                nextLevel = LevelNumbers._30;
                break;

            case LevelNumbers._30:
                nextLevel = LevelNumbers._31;
                break;

            case LevelNumbers._31:
                nextLevel = LevelNumbers._32;
                break;

            case LevelNumbers._32:
                nextLevel = LevelNumbers._33;
                break;

            case LevelNumbers._33:
                nextLevel = LevelNumbers._34;
                break;

            case LevelNumbers._34:
                nextLevel = LevelNumbers._35;
                break;

            case LevelNumbers._35:
                nextLevel = LevelNumbers._36;
                break;

            case LevelNumbers._36:
                nextLevel = LevelNumbers._37;
                break;

            case LevelNumbers._37:
                nextLevel = LevelNumbers._38;
                break;

            case LevelNumbers._38:
                nextLevel = LevelNumbers._39;
                break;

            case LevelNumbers._39:
                nextLevel = LevelNumbers._40;
                break;

            case LevelNumbers._40:
                nextLevel = LevelNumbers._41;
                break;

            case LevelNumbers._41:
                nextLevel = LevelNumbers._42;
                break;

            case LevelNumbers._42:
                nextLevel = LevelNumbers._43;
                break;

            case LevelNumbers._43:
                nextLevel = LevelNumbers._44;
                break;

            case LevelNumbers._44:
                nextLevel = LevelNumbers._45;
                break;

            case LevelNumbers._45:
                nextLevel = LevelNumbers._46;
                break;

            case LevelNumbers._46:
                nextLevel = LevelNumbers._47;
                break;

            case LevelNumbers._47:
                nextLevel = LevelNumbers._48;
                break;

            case LevelNumbers._48:
                nextLevel = LevelNumbers._49;
                break;

            case LevelNumbers._49:
                nextLevel = LevelNumbers._50;
                break;

            case LevelNumbers._50:
                nextLevel = LevelNumbers._51;
                break;

            case LevelNumbers._51:
                nextLevel = LevelNumbers._52;
                break;

            case LevelNumbers._52:
                nextLevel = LevelNumbers._53;
                break;

            case LevelNumbers._53:
                nextLevel = LevelNumbers._54;
                break;

            case LevelNumbers._54:
                nextLevel = LevelNumbers._1;
                break;
        }
        return nextLevel;
    }
}
