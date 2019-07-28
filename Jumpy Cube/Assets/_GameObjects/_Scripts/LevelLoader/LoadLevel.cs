using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    public string SAMPLE_SCENE_NAME = "SampleScene";
    public GameObject loadingScreen;
    public Slider loadingBar;

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
    }
    #endregion

    private void Update()
    {
    }

    public void Load(string sceneName)
    {
        StartCoroutine(LoadLevelAsync(sceneName));
        loadingScreen.SetActive(true);
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
