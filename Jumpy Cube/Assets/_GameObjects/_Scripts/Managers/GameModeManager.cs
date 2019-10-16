using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    public enum GameMode { endless, level}

    public GameMode gameMode;

    public bool isGameRestarted;

    #region SingleTon
    public static GameModeManager Instance;
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
        
        gameMode = GameMode.endless;
        isGameRestarted = false;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
