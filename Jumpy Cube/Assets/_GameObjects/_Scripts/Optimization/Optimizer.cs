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

        pp.TryGetSettings(out bloom);
        pp.TryGetSettings(out vignette);
        pp.TryGetSettings(out chromaticAberration);
        pp.TryGetSettings(out colorGrading);
        pp.TryGetSettings(out autoExposure);

        mainMenu.OptimizeTheGame_done_stop();
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
        yield return new WaitForSeconds(checkingDelay);

        if (fps_val < 30)
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

        if (fps_val < 30)
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

        if (fps_val < 30)
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

        if (fps_val < 30)
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

        if (fps_val < 30)
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

        if (fps_val < 30)
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
    }
}
