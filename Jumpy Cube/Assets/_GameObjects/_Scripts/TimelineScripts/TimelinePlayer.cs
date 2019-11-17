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

    [Header("best score timelines - game over")]
    public PlayableDirector score_best;
    public PlayableDirector diamonds_best;
    public PlayableDirector average_best;

    [Header("best score timelines - level complete")]
    public PlayableDirector score_best_lc;
    public PlayableDirector diamonds_best_lc;
    public PlayableDirector average_best_lc;

    [Header("Level number showing timeline")]
    public PlayableDirector levelnumberShowingPlayable;

    [Header("Tutorial Show Hide timelines")]
    public PlayableDirector tryAgainMessage;
    public PlayableDirector[] showTutorialMessageTimeLines;
    public PlayableDirector[] hideTutorialMessageTimeLines;

    [Header("Average and Best Score timelines")]
    public PlayableDirector bestScoreTimeline;

    [Header("Start Dark canvas and loadingscreen")]
    public PlayableDirector loadingScreen;
    public PlayableDirector startingDarkCanvasPlayable;

    [Header("Diamond reward timeline")]
    public GameObject diamondRewardParent;
    public PlayableDirector diamondRewardPlayable;
    public float disablediamondRewardAfter = 3f;

    bool s_m1, s_m2, s_m3, s_m4, s_m5, s_m6, s_m7, s_m8;
    bool h_m1, h_m2, h_m3, h_m4, h_m5, h_m6, h_m7, h_m8;

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
        
        loadingScreen.Stop();

        diamondRewardParent.SetActive(false);

        s_m1 = s_m2 = s_m3 = s_m4 = s_m5 = s_m6 = s_m7 = s_m8 = false;
        h_m1 = h_m2 = h_m3 = h_m4 = h_m5 = h_m6 = h_m7 = h_m8 = false;
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

    public void PlayScoreBest_lc()
    {
        score_best_lc.Play();
    }

    public void PlayDiamondsBest_lc()
    {
        diamonds_best_lc.Play();
    }

    public void PlayAverageBest_lc()
    {
        average_best_lc.Play();
    }

    public void PlayHighScore()
    {
        bestScoreTimeline.Play();
    }

    public void PlayLoadingScreen()
    {
        loadingScreen.Play();
    }

    public void PlayStartingDarkCanvas()
    {
        startingDarkCanvasPlayable.Play();
    }

    public void PlayDiamondReward()
    {
        diamondRewardParent.SetActive(true);
        diamondRewardPlayable.Play();

        Invoke("DisableDiamondReward", disablediamondRewardAfter);
    }

    void DisableDiamondReward()
    {
        diamondRewardParent.SetActive(false);
        diamondRewardPlayable.Stop();
    }

    #region TUTORIAL MESSAGE
    
    public void PlayTryAgainMessage()
    {
        tryAgainMessage.Play();
    }

    public void ShowTutorialMsg1()
    {
        if (!s_m1)
        {
            hideTutorialMessageTimeLines[0].Stop();
            showTutorialMessageTimeLines[0].Play();

            s_m1 = true;
        }
    }
    public void ShowTutorialMsg2()
    {
        if (!s_m2)
        {
            hideTutorialMessageTimeLines[1].Stop();
            showTutorialMessageTimeLines[1].Play();
            s_m2 = true;
        }
    }
    public void ShowTutorialMsg3()
    {
        if (!s_m3)
        {
            hideTutorialMessageTimeLines[2].Stop();
            showTutorialMessageTimeLines[2].Play();
            s_m3 = true;
        }
    }
    public void ShowTutorialMsg4()
    {
        if (!s_m4)
        {
            hideTutorialMessageTimeLines[3].Stop();
            showTutorialMessageTimeLines[3].Play();
            s_m4 = true;
        }
    }
    public void ShowTutorialMsg5()
    {
        if (!s_m5)
        {
            hideTutorialMessageTimeLines[4].Stop();
            showTutorialMessageTimeLines[4].Play();
            s_m5 = true;
        }
    }
    public void ShowTutorialMsg6()
    {
        if (!s_m6)
        {
            hideTutorialMessageTimeLines[5].Stop();
            showTutorialMessageTimeLines[5].Play();
            s_m6 = true;
        }
    }
    public void ShowTutorialMsg7()
    {
        if (!s_m7)
        {
            hideTutorialMessageTimeLines[6].Stop();
            showTutorialMessageTimeLines[6].Play();
            s_m7 = true;
        }
    }
    public void ShowTutorialMsg8()
    {
        if (!s_m8)
        {
            hideTutorialMessageTimeLines[7].Stop();
            showTutorialMessageTimeLines[7].Play();
            s_m8 = true;
        }
    }

    public void HideTutorialMsg1()
    {
        if (!h_m1)
        {
            showTutorialMessageTimeLines[0].Stop();
            hideTutorialMessageTimeLines[0].Play();
            h_m1 = true;
        }
    }
    public void HideTutorialMsg2()
    {
        if (!h_m2)
        {
            showTutorialMessageTimeLines[1].Stop();
            hideTutorialMessageTimeLines[1].Play();
            h_m2 = true;
        }
    }
    public void HideTutorialMsg3()
    {
        if (!h_m3)
        {
            showTutorialMessageTimeLines[2].Stop();
            hideTutorialMessageTimeLines[2].Play();
            h_m3 = true;
        }
    }
    public void HideTutorialMsg4()
    {
        if (!h_m4)
        {
            showTutorialMessageTimeLines[3].Stop();
            hideTutorialMessageTimeLines[3].Play();
            h_m4 = true;
        }
    }
    public void HideTutorialMsg5()
    {
        if (!h_m5)
        {
            showTutorialMessageTimeLines[4].Stop();
            hideTutorialMessageTimeLines[4].Play();
            h_m5 = true;
        }
    }
    public void HideTutorialMsg6()
    {
        if (!h_m6)
        {
            showTutorialMessageTimeLines[5].Stop();
            hideTutorialMessageTimeLines[5].Play();
            h_m6 = true;
        }
    }
    public void HideTutorialMsg7()
    {
        if (!h_m7)
        {
            showTutorialMessageTimeLines[6].Stop();
            hideTutorialMessageTimeLines[6].Play();
            h_m7 = true;
        }
    }
    public void HideTutorialMsg8()
    {
        if (!h_m8)
        {
            showTutorialMessageTimeLines[7].Stop();
            hideTutorialMessageTimeLines[7].Play();
            h_m8 = true;
        }
    }
    #endregion
}
