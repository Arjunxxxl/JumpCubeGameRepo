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

    [Header("Level number showing timeline")]
    public PlayableDirector levelnumberShowingPlayable;

    [Header("Tutorial Show Hide timelines")]
    public PlayableDirector tryAgainMessage;
    public PlayableDirector[] showTutorialMessageTimeLines;
    public PlayableDirector[] hideTutorialMessageTimeLines;

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

    public void PlayShowLevelNumber()
    {
        levelnumberShowingPlayable.Play();
    }

    #region TUTORIAL MESSAGE
    public void PlayTryAgainMessage()
    {
        tryAgainMessage.Play();
    }

    public void ShowTutorialMsg1()
    {
        hideTutorialMessageTimeLines[0].Stop();
        showTutorialMessageTimeLines[0].Play();
    }
    public void ShowTutorialMsg2()
    {
        hideTutorialMessageTimeLines[1].Stop();
        showTutorialMessageTimeLines[1].Play();
    }
    public void ShowTutorialMsg3()
    {
        hideTutorialMessageTimeLines[2].Stop();
        showTutorialMessageTimeLines[2].Play();
    }
    public void ShowTutorialMsg4()
    {
        hideTutorialMessageTimeLines[3].Stop();
        showTutorialMessageTimeLines[3].Play();
    }
    public void ShowTutorialMsg5()
    {
        hideTutorialMessageTimeLines[4].Stop();
        showTutorialMessageTimeLines[4].Play();
    }
    public void ShowTutorialMsg6()
    {
        hideTutorialMessageTimeLines[5].Stop();
        showTutorialMessageTimeLines[5].Play();
    }
    public void ShowTutorialMsg7()
    {
        hideTutorialMessageTimeLines[6].Stop();
        showTutorialMessageTimeLines[6].Play();
    }
    public void ShowTutorialMsg8()
    {
        hideTutorialMessageTimeLines[7].Stop();
        showTutorialMessageTimeLines[7].Play();
    }

    public void HideTutorialMsg1()
    {
        showTutorialMessageTimeLines[0].Stop();
        hideTutorialMessageTimeLines[0].Play();
    }
    public void HideTutorialMsg2()
    {
        showTutorialMessageTimeLines[1].Stop();
        hideTutorialMessageTimeLines[1].Play();
    }
    public void HideTutorialMsg3()
    {
        showTutorialMessageTimeLines[2].Stop();
        hideTutorialMessageTimeLines[2].Play();
    }
    public void HideTutorialMsg4()
    {
        showTutorialMessageTimeLines[3].Stop();
        hideTutorialMessageTimeLines[3].Play();
    }
    public void HideTutorialMsg5()
    {
        showTutorialMessageTimeLines[4].Stop();
        hideTutorialMessageTimeLines[4].Play();
    }
    public void HideTutorialMsg6()
    {
        showTutorialMessageTimeLines[5].Stop();
        hideTutorialMessageTimeLines[5].Play();
    }
    public void HideTutorialMsg7()
    {
        showTutorialMessageTimeLines[6].Stop();
        hideTutorialMessageTimeLines[6].Play();
    }
    public void HideTutorialMsg8()
    {
        showTutorialMessageTimeLines[7].Stop();
        hideTutorialMessageTimeLines[7].Play();
    }
    #endregion
}
