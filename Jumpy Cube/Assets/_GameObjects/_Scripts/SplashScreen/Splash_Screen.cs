using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Splash_Screen : MonoBehaviour
{
    [Header("Splas screen objects")]
    public GameObject complanyNameScreen;
    public GameObject gameNameScreen;

    [Header("Slider")]
    public GameObject sliderObj;
    public Slider loadingBar;

    [Space]
    public PlayableDirector complanyNamePlayable;
    [Space]

    [Header("Display data")]
    public float animationStartDelay = 0.25f;
    public float gameNameDisplayDelay = 2.5f;
    public float gameLoadDelay = 1.5f;

    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        complanyNameScreen.SetActive(true);
        gameNameScreen.SetActive(false);
        sliderObj.SetActive(false);

        complanyNamePlayable.Stop();

        sceneName = "SampleScene";

        Invoke("PlayComplanyNamePlayable", animationStartDelay);
    }

    void PlayComplanyNamePlayable()
    {
        complanyNamePlayable.Play();

        Invoke("ChangeScreen", gameNameDisplayDelay);
    }

    void ChangeScreen()
    {
        complanyNameScreen.SetActive(false);
        gameNameScreen.SetActive(true);

        Invoke("LoadNextScene", gameLoadDelay);
    }

    void LoadNextScene()
    {
        sliderObj.SetActive(true);
        StartCoroutine(LoadNextSceneAsync());
    }

    IEnumerator LoadNextSceneAsync()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName); 

        float progress;
        
        while (!asyncOperation.isDone)
        {
            progress = asyncOperation.progress;
            progress = Mathf.Clamp01(progress / 0.9f);

            Debug.Log(progress);

            loadingBar.value = progress;

            yield return null;
        }
    }
}
