using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public string SAMPLE_SCENE_NAME = "SampleScene";
    public GameObject loadingScreen;
    public GameObject sliderObj;
    public Slider loadingBar;

    public float gameLoadingDelay = 0.75f;

    TimelinePlayer timelinePlayer;

    #region SingleTon
    public static LoadLevel Instance;
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

        loadingScreen.SetActive(false);
        sliderObj.SetActive(false);
    }
    #endregion

    private void Start()
    {
        timelinePlayer = TimelinePlayer.Instance;
    }

    public void Load(string sceneName)
    {
        StartCoroutine(StartLevelLoading(sceneName));
        loadingScreen.SetActive(true);
        timelinePlayer.PlayLoadingScreen();
    }

    IEnumerator StartLevelLoading(string sceneName)
    {
        yield return new WaitForSecondsRealtime(gameLoadingDelay);
        
        sliderObj.SetActive(true);
        StartCoroutine(LoadLevelAsync(sceneName));
    }

    IEnumerator LoadLevelAsync(string name)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name);
        float progress;
        
        //asyncOperation.allowSceneActivation = false;

        while(!asyncOperation.isDone)
        {
            progress = asyncOperation.progress;
            progress = Mathf.Clamp01(progress / 0.9f);

            Debug.Log(progress);

            loadingBar.value = progress;

            yield return null;
        }
    }

}
