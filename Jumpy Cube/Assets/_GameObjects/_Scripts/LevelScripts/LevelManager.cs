using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelNumbers { _0, _1, _2, _3, _4, _5, _6, _7, _8, _9, _10 }

public class LevelManager : MonoBehaviour
{
    public LevelNumbers selectedLevelNumber;

    GameModeManager gameModeManager;
    TileSequence tileSequence;
    public CustomStrings customStrings;

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

        if (gameModeManager.isTutorialActive)
        {
            selectedLevelNumber = LevelNumbers._0;
            tileSequence.LoadCurrentLevel();
        }
    }
    
}
