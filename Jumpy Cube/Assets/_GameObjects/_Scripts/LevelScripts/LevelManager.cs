using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelNumbers { _1, _2, _3, _4, _5, _6, _7, _8, _9, _10 }

public class LevelManager : MonoBehaviour
{
    public LevelNumbers selectedLevelNumber;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
