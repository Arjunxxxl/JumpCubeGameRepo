using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour
{
    [Header("Diamond collect ui effect director")]
    public PlayableDirector diamondCollectPlayable;

    [Header("Pause Playable Directors")]
    public PlayableDirector pausePlayable;
    public PlayableDirector pause_PlayButtonPlayable;
    public PlayableDirector resumeCountDownPlayable;

    [Header("Tap to play pressed Playables")]
    public PlayableDirector menuDiableDirector;

    [Header("Level optimization")]
    public PlayableDirector optimizationAnimation;

    [Header("Ingame menu playable")]
    public PlayableDirector inGamemenuActivatedDirector;

    [Header("Mission Complete UI Animation")]
    public PlayableDirector missionCompleteUiPlayable;

    [Header("best score timelines")]
    public PlayableDirector score_best;
    public PlayableDirector diamonds_best;
    public PlayableDirector average_best;

    #region SingleTon
    public static TimelinePlayer Instance;
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

    private void Start()
    {
        pausePlayable.Stop();
        optimizationAnimation.Stop();
    }

    public void PlayPausePlayable()
    {
        pausePlayable.Play();
        pause_PlayButtonPlayable.Play();
    }

    public void StopPausePlayable()
    {
        pausePlayable.Stop();
        pause_PlayButtonPlayable.Stop();
    }

    public void PlayResumeCountDown()
    {
        resumeCountDownPlayable.Play();
    }

    public void StopResumeCountDown()
    {
        resumeCountDownPlayable.Stop();
    }

    public void MainmenuDiaable()
    {
        menuDiableDirector.Play();
    }

    public void PlayOptimizationAnimation()
    {
        optimizationAnimation.Play();
    }

    public void StopOptimizationAnimation()
    {
        optimizationAnimation.Stop();
    }

    public void PlayIngameMenuActivated()
    {
        inGamemenuActivatedDirector.Play();
    }

    public void PlayDiamondCollectUiEffect()
    {
        diamondCollectPlayable.Play();
    }

    public void PlayMisionCompleteAnimation()
    {
        missionCompleteUiPlayable.Play();
    }

    public void PlayScoreBest()
    {
        score_best.Play();
    }

    public void PlayDiamondsBest()
    {
        diamonds_best.Play();
    }

    public void PlayAverageBest()
    {
        average_best.Play();
    }
}
