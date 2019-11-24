using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class LifetimeStats : MonoBehaviour
{
    [Header("Text fields")]
    public TMP_Text highscore_txt;
    public TMP_Text averagescore_txt;
    public TMP_Text max_diamondsCollected_txt;
    public TMP_Text max_diamondsOwned_txt;
    public TMP_Text totalCubesOwned_txt;

    string screenshotfilename = "Stats.png";
    string path;
    float clickDelay;

    float timeout = 2f;
    float currentT;

    [Space]
    public CustomStrings customStrings;
    ButtonClickCommandExecutionDelay buttonClickCommandExecutionDelay;
    CustomAnalytics customAnalytics;

    // Start is called before the first frame update
    void Start()
    {
        if(!customStrings)
        {
            customStrings = CustomStrings.Instance;
        }

        buttonClickCommandExecutionDelay = ButtonClickCommandExecutionDelay.Instance;
        customAnalytics = CustomAnalytics.Instance;

        clickDelay = buttonClickCommandExecutionDelay.statsMenuCommendExecutionDelay;
    }

    //function is called from saved data get total owned cubes function
    public void SetLifeTimeStats()
    {
        highscore_txt.text = PlayerPrefs.GetInt(customStrings.HIGHSCORE, 0) + "m";
        averagescore_txt.text = (int)PlayerPrefs.GetFloat(customStrings.AVERAGE_SCORE_2, 0) + "m";
        max_diamondsCollected_txt.text = PlayerPrefs.GetInt(customStrings.DIAMONDS_COLLECTED_IN_ONE_RUN1, 0) + "";
        max_diamondsOwned_txt.text = PlayerPrefs.GetInt(customStrings.MAX_DIAMONDS_OWNED, 0) + "";
        totalCubesOwned_txt.text = PlayerPrefs.GetInt(customStrings.TOTAL_CUBES_OWNED, 0) + "";
    }


    public void ShareStats()
    {
        CaptureScreenShot();
    }

    public void CaptureScreenShot()
    {
        StartCoroutine(takeScreenShot());
    }

    IEnumerator takeScreenShot()
    {
        ScreenCapture.CaptureScreenshot(screenshotfilename);

        yield return new WaitForSeconds(clickDelay);

        currentT = 0;

        StartCoroutine(ShareScreenShotFunction());
    }

    IEnumerator ShareScreenShotFunction()
    {
#if UNITY_ANDROID
        path = Path.Combine(Application.persistentDataPath, screenshotfilename);
#endif
#if UNITY_EDITOR
        path = screenshotfilename;
#endif

        while (!File.Exists(path))
        {
            #if UNITY_ANDROID
            path = Path.Combine(Application.persistentDataPath, screenshotfilename);
            #endif
            #if UNITY_EDITOR
            path = screenshotfilename;
            #endif

            currentT += Time.deltaTime;

            if(currentT >= timeout || File.Exists(path))
            {
                break;
            }

            yield return null;
        }

        customAnalytics.StatsShared();

        //new method
        new NativeShare().AddFile(path).SetSubject("Subject").SetText("Text").SetTitle("Title").Share();
    }

    public void Leaderboard()
    {
        customAnalytics.Leaderboard_Opened();
    }
}
