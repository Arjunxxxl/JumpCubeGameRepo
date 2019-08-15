using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

/*Effect on FPS max to lowest
 * Hail Effect, 
 * SkyGradient,
 * Colour Grating,
 * chrom abbrv,
 * vigneet,
 * bloom [Whole pp volume and layer],
 * 
*/

public class Optimizer : MonoBehaviour
{
    [Header("Things to optimize")]
    public PostProcessProfile pp;
    public PostProcessLayer ppLayer;
    public PostProcessVolume ppVol;
    public GameObject hailEffect;
    public Imphenzia.GradientSkyCamera skyGradient;

    Bloom bloom;
    Vignette vignette;
    ChromaticAberration chromaticAberration;
    ColorGrading colorGrading;
    AutoExposure autoExposure;

    public bool isOptimizing;

    float checkingDelay = 0.75f;
    FPScounter fps;

    MainMenu mainMenu;
    TimelinePlayer timelinePlayer;
    OptimizedSavedData optimizedSavedData;
    SavedData savedData;

    float fps_val;

    #region SingleTon
    public static Optimizer Instance;
    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
        }
        else
        {
            if(Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        fps = FPScounter.Instance;
        mainMenu = MainMenu.Instance;
        timelinePlayer = TimelinePlayer.Instance;
        optimizedSavedData = OptimizedSavedData.Instance;
        savedData = SavedData.Instance;

        pp.TryGetSettings(out bloom);
        pp.TryGetSettings(out vignette);
        pp.TryGetSettings(out chromaticAberration);
        pp.TryGetSettings(out colorGrading);
        pp.TryGetSettings(out autoExposure);

        mainMenu.OptimizeTheGame_done_stop();

        if(savedData.isRunningForFirstTime)
        {
            Optimize();
        }
        else
        {
            LoadOptimisedData();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isOptimizing)
        {
            fps_val = fps.avgFrameRate;
        }
    }

    public void Optimize()
    {
        isOptimizing = true;
        mainMenu.OptimizeTheGame();

        mainMenu.optimizationRunning.SetActive(true);
        mainMenu.optimizationDone.SetActive(false);

        timelinePlayer.PlayOptimizationAnimation();

        StartCoroutine(OptimizeHail());
    }

    IEnumerator OptimizeHail()
    {
        yield return new WaitForSeconds(checkingDelay + 4f);

        if (fps_val < 26)
        {
            hailEffect.SetActive(false);
        }
        else
        {
            hailEffect.SetActive(true);
        }

        StartCoroutine(OptimizeGradient());
    }

    IEnumerator OptimizeGradient()
    {
        yield return new WaitForSeconds(checkingDelay);

        if (fps_val < 26)
        {
            skyGradient.enabled = (false);
        }
        else
        {
            skyGradient.enabled = (true);
        }

        StartCoroutine(OptimizeColourGrating());
    }

    IEnumerator OptimizeColourGrating()
    {
        yield return new WaitForSeconds(checkingDelay);

        if (fps_val < 26)
        {
            colorGrading.enabled.value = false;
        }
        else
        {
            colorGrading.enabled.value = true;
        }

        StartCoroutine(OptimizeChroomeAbbr());
    }

    IEnumerator OptimizeChroomeAbbr()
    {
        yield return new WaitForSeconds(checkingDelay);

        if (fps_val < 26)
        {
            chromaticAberration.enabled.value = false;
        }
        else
        {
            chromaticAberration.enabled.value = true;
        }

        StartCoroutine(OptimizeVigneet());
    }

    IEnumerator OptimizeVigneet()
    {
        yield return new WaitForSeconds(checkingDelay);

        if (fps_val < 26)
        {
            vignette.enabled.value = false;
        }
        else
        {
            vignette.enabled.value = true;
        }

        StartCoroutine(OptimizeBloom_wholePP());
    }

    IEnumerator OptimizeBloom_wholePP()
    {
        yield return new WaitForSeconds(checkingDelay);

        if (fps_val < 26)
        {
            bloom.enabled.value = false;
            ppVol.enabled = false;
            ppLayer.enabled = false;
        }
        else
        {
            bloom.enabled.value = true;
            ppLayer.enabled = true;
            ppVol.enabled = true;
        }

        mainMenu.optimizationRunning.SetActive(false);
        mainMenu.optimizationDone.SetActive(true);

        timelinePlayer.StopOptimizationAnimation();

        isOptimizing = false;

        Save_optimize_preference();
    }

    void Save_optimize_preference()
    {
        optimizedSavedData.SaveOptimizedData(hailEffect.activeSelf, skyGradient.isActiveAndEnabled,
                colorGrading.enabled.value, chromaticAberration.enabled.value, vignette.enabled.value, bloom.enabled.value);
    }

    void LoadOptimisedData()
    {
        if(optimizedSavedData.savedOptimisezData[0] == 1)
        {
            hailEffect.SetActive(true);
        }
        else
        {
            hailEffect.SetActive(false);
        }

        if(optimizedSavedData.savedOptimisezData[1] == 1)
        {
            skyGradient.enabled = true;
        }
        else
        {
            skyGradient.enabled = false;
        }

        if (optimizedSavedData.savedOptimisezData[6] == 1)
        {
            ppLayer.enabled = true;
            ppVol.enabled = true;
        }
        else
        {
            ppLayer.enabled = false;
            ppVol.enabled = false;

            return;
        }

        if (optimizedSavedData.savedOptimisezData[2] == 1)
        {
            colorGrading.enabled.value = true;
        }
        else
        {
            colorGrading.enabled.value = false;
        }

        if (optimizedSavedData.savedOptimisezData[3] == 1)
        {
            chromaticAberration.enabled.value = true;
        }
        else
        {
            chromaticAberration.enabled.value = false;
        }

        if (optimizedSavedData.savedOptimisezData[4] == 1)
        {
            vignette.enabled.value = true;
        }
        else
        {
            vignette.enabled.value = false;
        }

        if (optimizedSavedData.savedOptimisezData[5] == 1)
        {
            bloom.enabled.value = true;
        }
        else
        {
            bloom.enabled.value = false;
        }
    }
}
