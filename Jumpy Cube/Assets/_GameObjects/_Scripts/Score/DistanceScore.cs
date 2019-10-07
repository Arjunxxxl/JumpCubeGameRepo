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

    MainMenu mainMenu;
    MissionManager missionManager;

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

        if(!player)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        initialPosX = player.position.x;

        distance = 0;
        scoreTxt.text = distance + "";
    }

    // Update is called once per frame
    void Update()
    {
        if(!mainMenu.isGameStart)
        {
            return;
        }

        finalPosX = player.position.x;
        dist = (initialPosX - finalPosX);
        dist *= distanceMultiplier;
        distance = (int)(dist);
        scoreTxt.text = distance + "";

        missionManager.CheckingForDiatanceScoreMission(distance);
    }

}
