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

    [Header("Mission rewards [Skin indexes]")]
    public int missionRewardTire1;
    public int missionRewardTire2;
    public int missionRewardTire3;

    [Header("Mission Goals")]
    public MissionGoal missionGoalTire1;
    public MissionGoal missionGoalTire2;
    public MissionGoal missionGoalTire3;

    public MissionType missionType;


    public enum MissionType
    {
        coins_collection, distance_score, times_gamePlayed, times_player_died, times_player_jumped,
        time_spendInGame, diamonds_spend, color_changed_io_sphere, times_score_shared
    }
}
