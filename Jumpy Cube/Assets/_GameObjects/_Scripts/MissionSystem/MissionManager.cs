using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public List<Mission> missionsList;

    Mission coinCollectMissions;
    Mission distanceScoreMissions;
    Mission timeGamePlayedMissions;
    Mission timePlayerDiedMissions;
    Mission timePlayerJumpedMissions;
    Mission timeSpendInGameMissions;
    Mission diamondsSpendMissions;
    Mission ioSphereColorMissions;
    Mission scoreShareMissions;

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
        SetupLists();
    }
    #endregion

    void SetupLists()
    {
        foreach(Mission m in missionsList)
        {
            if(m.isActiveTire1 || m.isActiveTire2 || m.isActiveTire3)
            {
                if (m.missionType == Mission.MissionType.coins_collection) { coinCollectMissions = m; }
                else if (m.missionType == Mission.MissionType.distance_score) { distanceScoreMissions = m; }
                else if (m.missionType == Mission.MissionType.times_gamePlayed) { timeGamePlayedMissions = m; }
                else if (m.missionType == Mission.MissionType.times_player_died) { timePlayerDiedMissions = m; }
                else if (m.missionType == Mission.MissionType.times_player_jumped) { timePlayerJumpedMissions = m; }
                else if (m.missionType == Mission.MissionType.time_spendInGame) { timeSpendInGameMissions = m; }
                else if (m.missionType == Mission.MissionType.diamonds_spend) { diamondsSpendMissions = m; }
                else if (m.missionType == Mission.MissionType.color_changed_io_sphere) { ioSphereColorMissions = m; }
                else if (m.missionType == Mission.MissionType.times_score_shared) { scoreShareMissions = m; }
            }
        }
    }

    public void CheckingForDiatanceScoreMission(int distance)
    {
            if(!distanceScoreMissions)
            {
                return;
            }

            if (distanceScoreMissions.isActiveTire1)
            {
                if (distance >= distanceScoreMissions.missionGoalTire1.requiredDistance)
                {
                    distanceScoreMissions.isActiveTire1 = false;
                    //Debug.Log("distance mission completed 1");
                }
            }
            else if (distanceScoreMissions.isActiveTire2)
            {
                if (distance >= distanceScoreMissions.missionGoalTire2.requiredDistance)
                {
                    distanceScoreMissions.isActiveTire2 = false;
                    //Debug.Log("distance mission completed 2");
                }
            }
            else if (distanceScoreMissions.isActiveTire3)
            {
                if (distance >= distanceScoreMissions.missionGoalTire3.requiredDistance)
                {
                    distanceScoreMissions.isActiveTire3 = false;
                    //Debug.Log("distance mission completed 3");
                }
            }

    }
}
