using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [Header("Menues")]
    public GameObject inGameMenu;
    public GameObject gameOverMenu;

    [Header("Screen Shot Data")]
    public RawImage screenShotImg;
    public string path;

    [Header("Data")]
    public float currentTime;
    public float gameOverMenuShowDelay = 4f;
    public float screenShotDelay = 2.5f;
    public float screenshotDiaplayDelay = 1f;

    bool checker;
    bool isProcessing;

    Texture2D screenCapture;

    PlayerDeath playerDeath;
    LoadLevel loadLevel;

    #region SingleTon
    public static GameOverMenu Instance;
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

    // Start is called before the first frame update
    void Start()
    {
        playerDeath = PlayerDeath.Instance;
        loadLevel = LoadLevel.Instance;

        gameOverMenu.SetActive(false);
        currentTime = 0;
        checker = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDeath.isDead && !checker)
        {
            if (inGameMenu.activeSelf)
            {
                inGameMenu.SetActive(false);
            }

            currentTime += Time.deltaTime;

            if (currentTime > gameOverMenuShowDelay)
            {
                gameOverMenu.SetActive(true);
                checker = true;
            }
        }
    }

    public void CaptureScreenShot()
    {
        StartCoroutine(takeScreenShot());
    }

    IEnumerator takeScreenShot()
    {
        yield return new WaitForSeconds(screenShotDelay);

        path = "ScreenShot.png";

        ScreenCapture.CaptureScreenshot("ScreenShot.png");

        StartCoroutine(DisplayScreenShotCoroutine());
    }

    IEnumerator DisplayScreenShotCoroutine()
    {
        yield return new WaitForSeconds(screenshotDiaplayDelay);
        DisplayScreenShot();
    }

    void DisplayScreenShot()
    {
#if UNITY_ANDROID
        path = Path.Combine(Application.persistentDataPath, "ScreenShot.png");
#endif
#if UNITY_EDITOR
        path = "ScreenShot.png";
#endif


        var bytes = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(73, 73);
        texture.LoadImage(bytes);
        screenShotImg.texture = texture;
    }

    public void ShareScreenshotButtonPressed()
    {
        StartCoroutine(ShareScreenshot());
    }

    IEnumerator ShareScreenshot()
    {
        isProcessing = true;

        if(path == "")
        {
#if UNITY_ANDROID
            path = Path.Combine(Application.persistentDataPath, "ScreenShot.png");
#endif
#if UNITY_EDITOR
            path = "ScreenShot.png";
#endif
        }

        //yield return null;
        yield return new WaitForSecondsRealtime(0.3f);

        if (!Application.isEditor)
        {
            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + path);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"),
                uriObject);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"),
                "Can you beat my score?");
            intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject chooser = intentClass.CallStatic<AndroidJavaObject>("createChooser",
                intentObject, "Share your new score");
            currentActivity.Call("startActivity", chooser);

            yield return new WaitForSecondsRealtime(1);
        }

        isProcessing = false;
    }

    public void HomeButton()
    {
        loadLevel.Load(loadLevel.SAMPLE_SCENE_NAME);
    }
}
