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

    int timesGamePlayed;
    int diamondsSpend;
    int shareCount;

    public CustomStrings customStrings;

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

        foreach (Mission m in missionsList)
        {
            if(m.isActiveTire1 || m.isActiveTire2 || m.isActiveTire3)
            {
                if (m.missionType == Mission.MissionType.coins_collection) { coinCollectMissionsList.Add(m); }
                else if (m.missionType == Mission.MissionType.distance_score) { distanceScoreMissionsList.Add(m); }
                else if (m.missionType == Mission.MissionType.times_gamePlayed) { timeGamePlayedMissionsList.Add(m); }
                else if (m.missionType == Mission.MissionType.diamonds_spend) { diamondsSpendMissionsList.Add(m); }
                else if (m.missionType == Mission.MissionType.times_score_shared) { scoreShareMissionsList.Add(m); }
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
                }
            }
            else if (coinCollectMissions.isActiveTire2)
            {
                if (diamonds >= coinCollectMissions.missionGoalTire2.requiredCoins)
                {
                    coinCollectMissions.isActiveTire2 = false;
                }
            }
            else if (coinCollectMissions.isActiveTire3)
            {
                if (diamonds >= coinCollectMissions.missionGoalTire3.requiredCoins)
                {
                    coinCollectMissions.isActiveTire3 = false;
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
                }
            }
            else if (distanceScoreMissions.isActiveTire2)
            {
                if (distance >= distanceScoreMissions.missionGoalTire2.requiredDistance)
                {
                    distanceScoreMissions.isActiveTire2 = false;
                }
            }
            else if (distanceScoreMissions.isActiveTire3)
            {
                if (distance >= distanceScoreMissions.missionGoalTire3.requiredDistance)
                {
                    distanceScoreMissions.isActiveTire3 = false;
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
                if (timesGamePlayed >= timesGameplayedMission.missionGoalTire1.requiredDistance)
                {
                    timesGameplayedMission.isActiveTire1 = false;
                    PlayerPrefs.SetInt(customStrings.MISSION_CUBE2, 1);
                }
            }
            else if (timesGameplayedMission.isActiveTire2)
            {
                if (timesGamePlayed >= timesGameplayedMission.missionGoalTire2.requiredDistance)
                {
                    timesGameplayedMission.isActiveTire2 = false;
                }
            }
            else if (timesGameplayedMission.isActiveTire3)
            {
                if (timesGamePlayed >= timesGameplayedMission.missionGoalTire3.requiredDistance)
                {
                    timesGameplayedMission.isActiveTire3 = false;
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
                if (diamondsSpend >= diamondsSpendMissions.missionGoalTire1.requiredDistance)
                {
                    diamondsSpendMissions.isActiveTire1 = false;
                    PlayerPrefs.SetInt(customStrings.MISSION_CUBE4, 1);
                }
            }
            else if (diamondsSpendMissions.isActiveTire2)
            {
                if (diamondsSpend >= diamondsSpendMissions.missionGoalTire2.requiredDistance)
                {
                    diamondsSpendMissions.isActiveTire2 = false;
                }
            }
            else if (diamondsSpendMissions.isActiveTire3)
            {
                if (diamondsSpend >= diamondsSpendMissions.missionGoalTire3.requiredDistance)
                {
                    diamondsSpendMissions.isActiveTire3 = false;
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
                if (shareCount >= scoreShareMissions.missionGoalTire1.requiredDistance)
                {
                    scoreShareMissions.isActiveTire1 = false;
                    PlayerPrefs.SetInt(customStrings.MISSION_CUBE3, 1);
                }
            }
            else if (scoreShareMissions.isActiveTire2)
            {
                if (shareCount >= scoreShareMissions.missionGoalTire2.requiredDistance)
                {
                    scoreShareMissions.isActiveTire2 = false;
                }
            }
            else if (scoreShareMissions.isActiveTire3)
            {
                if (shareCount >= scoreShareMissions.missionGoalTire3.requiredDistance)
                {
                    scoreShareMissions.isActiveTire3 = false;
                }
            }
        }

    }
}
