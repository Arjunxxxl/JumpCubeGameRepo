using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceScore : MonoBehaviour
{
    public Transform player;
    public float initialPosX;
    public float finalPosX;
    public float distanceMultiplier = 0.8f;
    public float dist;
    public int distance;

    public TMP_Text scoreTxt;
    public GameObject highScoreUI;
    public float highScoreUIDuaration = 3f;

    public bool isTutorialActive;       // set from tutorial manager
    public bool isLevelCompleted;

    MainMenu mainMenu;
    MissionManager missionManager;
    GameModeManager gameModeManager;
    ObjectPooler objectPooler;
    CustomStrings customStrings;
    TimelinePlayer timelinePlayer;

    int highScore;
    bool isHighScoreMade;
    Vector3 playerLeftPos, playerRightPos;

    string empty_str = "";
    string PLAYER_TAG = "Player";

    #region SingleTon
    public static DistanceScore Instance;
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
        missionManager = MissionManager.Instance;
        mainMenu = MainMenu.Instance;
        gameModeManager = GameModeManager.Instance;
        objectPooler = ObjectPooler.Instance;
        customStrings = CustomStrings.Instance;
        timelinePlayer = TimelinePlayer.Instance;

        if(!player)
        {
            player = GameObject.FindGameObjectWithTag(PLAYER_TAG).transform;
        }

        initialPosX = player.position.x;

        distance = 0;
        scoreTxt.text = empty_str;

        isLevelCompleted = false;

        highScore = PlayerPrefs.GetInt(customStrings.HIGHSCORE, 0);
        isHighScoreMade = false;

        playerLeftPos = new Vector3(-0.5f, 0, 1);
        playerRightPos = new Vector3(-0.5f, 0, -1);

        if(highScoreUI.activeSelf)
        {
            highScoreUI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!mainMenu.isGameStart)
        {
            return;
        }

        if (isTutorialActive && gameModeManager.gameMode == GameModeManager.GameMode.endless)
        {
            initialPosX = player.position.x;
            return;
        }

        if(gameModeManager.gameMode == GameModeManager.GameMode.level)
        {
            if(isLevelCompleted)
            {
                return;
            }
        }

        finalPosX = player.position.x;
        dist = (initialPosX - finalPosX);
        dist *= distanceMultiplier;
        distance = (int)(dist);
        scoreTxt.text = distance + "";

        if (!isHighScoreMade)
        {
            if (distance > highScore)
            {
                isHighScoreMade = true;

                if (highScore != 0)
                {
                    if (!highScoreUI.activeSelf)
                    {
                        highScoreUI.SetActive(true);
                        StartCoroutine(DisableHighScoreUI());
                    }

                    timelinePlayer.PlayHighScore();
                    objectPooler.SpawnFormPool("HighScoreEffect", player.transform.position + playerLeftPos, Quaternion.identity);
                    objectPooler.SpawnFormPool("HighScoreEffect", player.transform.position + playerRightPos, Quaternion.identity);
                }
            }
        }

        missionManager.CheckingForDiatanceScoreMission(distance);
    }

    IEnumerator DisableHighScoreUI()
    {
        yield return new WaitForSeconds(highScoreUIDuaration);

        if (highScoreUI.activeSelf)
        {
            highScoreUI.SetActive(false);
        }
    }

    public bool IsLevelCompleted
    {
        set
        {
            isLevelCompleted = value;
        }
    }
}
