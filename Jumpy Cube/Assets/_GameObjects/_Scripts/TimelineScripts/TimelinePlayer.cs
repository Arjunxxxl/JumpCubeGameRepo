using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour
{
    [Header("Pause Playable Directors")]
    public PlayableDirector pausePlayable;
    public PlayableDirector pause_PlayButtonPlayable;
    public PlayableDirector resumeCountDownPlayable;

    [Header("Tap to play pressed Playables")]
    public PlayableDirector menuToInGameMenuDirector;

    [Header("Level optimization")]
    public PlayableDirector optimizationAnimation;

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

    public void PlayMenuToInGameMenu()
    {
        menuToInGameMenuDirector.Play();
    }

    public void PlayOptimizationAnimation()
    {
        optimizationAnimation.Play();
    }

    public void StopOptimizationAnimation()
    {
        optimizationAnimation.Stop();
    }
}
