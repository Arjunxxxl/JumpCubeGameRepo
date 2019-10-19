using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TutorialMessageIndex
{ m1, m2, m3, m4, m5, m6, m7, m8 }

public class TutorialMessage : MonoBehaviour
{
    public TutorialMessageIndex messageIndex;

    TimelinePlayer timelinePlayer;

    private void Start()
    {
        timelinePlayer = TimelinePlayer.Instance;
    }

    public void ShowMessage()
    {
        StartCoroutine("ShowMsg");
    }

    public void HideMessage()
    {
        switch (messageIndex)
        {
            case TutorialMessageIndex.m1:
                timelinePlayer.HideTutorialMsg1();
                break;

            case TutorialMessageIndex.m2:
                timelinePlayer.HideTutorialMsg2();
                break;

            case TutorialMessageIndex.m3:
                timelinePlayer.HideTutorialMsg3();
                break;

            case TutorialMessageIndex.m4:
                timelinePlayer.HideTutorialMsg4();
                break;

            case TutorialMessageIndex.m5:
                timelinePlayer.HideTutorialMsg5();
                break;

            case TutorialMessageIndex.m6:
                timelinePlayer.HideTutorialMsg6();
                break;

            case TutorialMessageIndex.m7:
                timelinePlayer.HideTutorialMsg7();
                break;

            case TutorialMessageIndex.m8:
                timelinePlayer.HideTutorialMsg8();
                break;
        }
    }

    IEnumerator ShowMsg()
    {
        yield return new WaitForSecondsRealtime(0.05f);

        switch (messageIndex)
        {
            case TutorialMessageIndex.m1:
                timelinePlayer.ShowTutorialMsg1();
                break;

            case TutorialMessageIndex.m2:
                timelinePlayer.ShowTutorialMsg2();
                break;

            case TutorialMessageIndex.m3:
                timelinePlayer.ShowTutorialMsg3();
                break;

            case TutorialMessageIndex.m4:
                timelinePlayer.ShowTutorialMsg4();
                break;

            case TutorialMessageIndex.m5:
                timelinePlayer.ShowTutorialMsg5();
                break;

            case TutorialMessageIndex.m6:
                timelinePlayer.ShowTutorialMsg6();
                break;

            case TutorialMessageIndex.m7:
                timelinePlayer.ShowTutorialMsg7();
                break;

            case TutorialMessageIndex.m8:
                timelinePlayer.ShowTutorialMsg8();
                break;
        }
    }
}
