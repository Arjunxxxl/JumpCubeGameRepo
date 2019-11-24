using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public List<Mission> missionsList;

    List<Mission> coinCollectMissionsList;
    List<Mission> distanceScoreMissionsList;
    List<Mission> timeGamePlayedMissionsList;
    List<Mission> timePlayerJumpedMissionsList;
    List<Mission> diamondsSpendMissionsList;
    List<Mission> scoreShareMissionsList;
    List<Mission> jumpMissionsList;

    int timesGamePlayed;
    int diamondsSpend;
    int shareCount;
    int jumps;

    public CustomStrings customStrings;
    public TimelinePlayer timelinePlayer;
    AudioManager audioManager;

    #region SingleTon
    public static MissionManager Instance;
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

        GetMissionActiveStatus();
        SetupMission();
    }
    #endregion

    private void Start()
    {
        timelinePlayer = TimelinePlayer.Instance;
        audioManager = AudioManager.Instance;
    }

    public void GetMissionActiveStatus()
    {
        foreach(Mission mission in missionsList)
        {
            switch(mission.missionType)
            {
                case Mission.MissionType.coins_collection:
                    mission.isActiveTire1 = PlayerPrefs.GetInt(customStrings.MISSION_CUBE0, 0) == 1 ? false : true;
                    break;

                case Mission.MissionType.distance_score:
                    mission.isActiveTire1 = PlayerPrefs.GetInt(customStrings.MISSION_CUBE1, 0) == 1 ? false : true;
                    break;

                case Mission.MissionType.times_gamePlayed:
                    mission.isActiveTire1 = PlayerPrefs.GetInt(customStrings.MISSION_CUBE2, 0) == 1 ? false : true;
                    break;
                    
                case Mission.MissionType.times_score_shared:
                    mission.isActiveTire1 = PlayerPrefs.GetInt(customStrings.MISSION_CUBE3, 0) == 1 ? false : true;
                    break;

                case Mission.MissionType.diamonds_spend:
                    mission.isActiveTire1 = PlayerPrefs.GetInt(customStrings.MISSION_CUBE4, 0) == 1 ? false : true;
                    break;

                case Mission.MissionType.jump_mission:
                    mission.isActiveTire1 = PlayerPrefs.GetInt(customStrings.MISSION_CUBE5, 0) == 1 ? false : true;
                    break;
            }
        }
    }

    public void SetupMission()
    {
        coinCollectMissionsList = new List<Mission>();
        distanceScoreMissionsList = new List<Mission>();
        timeGamePlayedMissionsList = new List<Mission>();
        diamondsSpendMissionsList = new List<Mission>();
        scoreShareMissionsList = new List<Mission>();
        jumpMissionsList = new List<Mission>();

        foreach (Mission m in missionsList)
        {
            if(m.isActiveTire1 || m.isActiveTire2 || m.isActiveTire3)
            {
                if (m.missionType == Mission.MissionType.coins_collection) { coinCollectMissionsList.Add(m); }
                else if (m.missionType == Mission.MissionType.distance_score) { distanceScoreMissionsList.Add(m); }
                else if (m.missionType == Mission.MissionType.times_gamePlayed) { timeGamePlayedMissionsList.Add(m); }
                else if (m.missionType == Mission.MissionType.diamonds_spend) { diamondsSpendMissionsList.Add(m); }
                else if (m.missionType == Mission.MissionType.times_score_shared) { scoreShareMissionsList.Add(m); }
                else if (m.missionType == Mission.MissionType.jump_mission) { jumpMissionsList.Add(m); }
            }
        }
    }

    public void CheckingForDiamondCollectMission(int diamonds)
    {
        if (coinCollectMissionsList.Count == 0)
        {
            return;
        }

        foreach (Mission coinCollectMissions in coinCollectMissionsList)
        {
            if (coinCollectMissions.isActiveTire1)
            {
                if (diamonds >= coinCollectMissions.missionGoalTire1.requiredCoins)
                {
                    coinCollectMissions.isActiveTire1 = false;
                    PlayerPrefs.SetInt(customStrings.MISSION_CUBE0, 1);

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
            if (coinCollectMissions.isActiveTire2)
            {
                if (diamonds >= coinCollectMissions.missionGoalTire2.requiredCoins)
                {
                    coinCollectMissions.isActiveTire2 = false;

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
            if (coinCollectMissions.isActiveTire3)
            {
                if (diamonds >= coinCollectMissions.missionGoalTire3.requiredCoins)
                {
                    coinCollectMissions.isActiveTire3 = false;

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
        }

    }

    public void CheckingForDiatanceScoreMission(int distance)
    {
            if(distanceScoreMissionsList.Count == 0)
            {
                return;
            }

        foreach (Mission distanceScoreMissions in distanceScoreMissionsList)
        {
            if (distanceScoreMissions.isActiveTire1)
            {
                if (distance >= distanceScoreMissions.missionGoalTire1.requiredDistance)
                {
                    distanceScoreMissions.isActiveTire1 = false;
                    PlayerPrefs.SetInt(customStrings.MISSION_CUBE1, 1);

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
            if (distanceScoreMissions.isActiveTire2)
            {
                if (distance >= distanceScoreMissions.missionGoalTire2.requiredDistance)
                {
                    distanceScoreMissions.isActiveTire2 = false;

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
            if (distanceScoreMissions.isActiveTire3)
            {
                if (distance >= distanceScoreMissions.missionGoalTire3.requiredDistance)
                {
                    distanceScoreMissions.isActiveTire3 = false;

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
        }

    }

    public void CheckingForTimesGamePlayedMission()
    {
        if (timeGamePlayedMissionsList.Count == 0)
        {
            return;
        }

        timesGamePlayed = PlayerPrefs.GetInt(customStrings.TIMES_GAME_PLAYED, 0) + 1;

        foreach (Mission timesGameplayedMission in timeGamePlayedMissionsList)
        {
            if (timesGameplayedMission.isActiveTire1)
            {
                if (timesGamePlayed >= timesGameplayedMission.missionGoalTire1.requiredPlayCount)
                {
                    timesGameplayedMission.isActiveTire1 = false;
                    PlayerPrefs.SetInt(customStrings.MISSION_CUBE2, 1);

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
            if (timesGameplayedMission.isActiveTire2)
            {
                if (timesGamePlayed >= timesGameplayedMission.missionGoalTire2.requiredPlayCount)
                {
                    timesGameplayedMission.isActiveTire2 = false;

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
            if (timesGameplayedMission.isActiveTire3)
            {
                if (timesGamePlayed >= timesGameplayedMission.missionGoalTire3.requiredPlayCount)
                {
                    timesGameplayedMission.isActiveTire3 = false;

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
        }

    }

    public void CheckingForDiamondSpendMission(int amt)
    {
        if (diamondsSpendMissionsList.Count == 0)
        {
            return;
        }

        diamondsSpend = amt;

        foreach (Mission diamondsSpendMissions in diamondsSpendMissionsList)
        {
            if (diamondsSpendMissions.isActiveTire1)
            {
                if (diamondsSpend >= diamondsSpendMissions.missionGoalTire1.requiedDiamondsSpendInStore)
                {
                    diamondsSpendMissions.isActiveTire1 = false;
                    PlayerPrefs.SetInt(customStrings.MISSION_CUBE4, 1);

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
            if (diamondsSpendMissions.isActiveTire2)
            {
                if (diamondsSpend >= diamondsSpendMissions.missionGoalTire2.requiedDiamondsSpendInStore)
                {
                    diamondsSpendMissions.isActiveTire2 = false;

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
            if (diamondsSpendMissions.isActiveTire3)
            {
                if (diamondsSpend >= diamondsSpendMissions.missionGoalTire3.requiedDiamondsSpendInStore)
                {
                    diamondsSpendMissions.isActiveTire3 = false;

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
        }

    }

    public void CheckingForShareScoreMission()
    {
        if (scoreShareMissionsList.Count == 0)
        {
            return;
        }

        shareCount = PlayerPrefs.GetInt(customStrings.TIMES_SCORE_SHARED, 0) + 1;
        PlayerPrefs.SetInt(customStrings.TIMES_SCORE_SHARED, shareCount);


        foreach (Mission scoreShareMissions in scoreShareMissionsList)
        {
            if (scoreShareMissions.isActiveTire1)
            {
                if (shareCount >= scoreShareMissions.missionGoalTire1.scoreShareCount)
                {
                    scoreShareMissions.isActiveTire1 = false;
                    PlayerPrefs.SetInt(customStrings.MISSION_CUBE3, 1);

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
            if (scoreShareMissions.isActiveTire2)
            {
                if (shareCount >= scoreShareMissions.missionGoalTire2.scoreShareCount)
                {
                    scoreShareMissions.isActiveTire2 = false;

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
            if (scoreShareMissions.isActiveTire3)
            {
                if (shareCount >= scoreShareMissions.missionGoalTire3.scoreShareCount)
                {
                    scoreShareMissions.isActiveTire3 = false;

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
        }

    }

    public void CheckingForJumpMission()
    {
        if (jumpMissionsList.Count == 0)
        {
            return;
        }
        
        foreach (Mission jumpMissions in jumpMissionsList)
        {
            if(!jumpMissions.isActiveTire1 && !jumpMissions.isActiveTire2 && !jumpMissions.isActiveTire3)
            {
                return;
            }

            jumps = PlayerPrefs.GetInt(customStrings.TIMES_PLAYER_JUMPED, 0) + 1;
            PlayerPrefs.SetInt(customStrings.TIMES_PLAYER_JUMPED, jumps);

            if (jumpMissions.isActiveTire1)
            {
                if (jumps >= jumpMissions.missionGoalTire1.requiredJumps)
                {
                    jumpMissions.isActiveTire1 = false;
                    PlayerPrefs.SetInt(customStrings.MISSION_CUBE5, 1);

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
            if (jumpMissions.isActiveTire2)
            {
                if (jumps >= jumpMissions.missionGoalTire2.requiredJumps)
                {
                    jumpMissions.isActiveTire2 = false;

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
            if (jumpMissions.isActiveTire3)
            {
                if (jumps >= jumpMissions.missionGoalTire3.requiredJumps)
                {
                    jumpMissions.isActiveTire3 = false;

                    timelinePlayer.PlayMisionCompleteAnimation();

                    audioManager.Play_MissionCompleteAudio();
                }
            }
        }

    }
}
