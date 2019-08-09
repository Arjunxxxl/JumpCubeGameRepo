using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedData : MonoBehaviour
{
    public static string GAME_FIRST_RUN = "GAME FIRST RUN";
    int GAME_FIRST_RUN_INT;
    public bool isRunningForFirstTime;

    #region SingleTon
    public static SavedData Instance;
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

        GameRunningForFirstTime();

    }
    #endregion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameRunningForFirstTime()
    {
        GAME_FIRST_RUN_INT = PlayerPrefs.GetInt(GAME_FIRST_RUN, 0);
        if (GAME_FIRST_RUN_INT == 0)
        {
            isRunningForFirstTime = true;
            PlayerPrefs.SetInt(GAME_FIRST_RUN, 1);
        }
        else
        {
            isRunningForFirstTime = false;
        }
    }
}
