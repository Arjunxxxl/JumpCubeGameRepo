using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable][CreateAssetMenu]
public class Mission : ScriptableObject
{
    [Header("Mission active State")]
    public bool isActiveTire1;
    public bool isActiveTire2;
    public bool isActiveTire3;
    

    [Header("Mission Goals")]
    public MissionGoal missionGoalTire1;
    public MissionGoal missionGoalTire2;
    public MissionGoal missionGoalTire3;

    public MissionType missionType;


    public enum MissionType
    {
        coins_collection, distance_score, times_gamePlayed,
        diamonds_spend, times_score_shared, jump_mission
    }
}
