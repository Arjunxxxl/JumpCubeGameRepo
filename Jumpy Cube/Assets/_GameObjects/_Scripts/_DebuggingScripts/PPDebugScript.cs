using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PPDebugScript : MonoBehaviour
{
    public PostProcessProfile pp, g_pp;

    public GameObject PPset;

    public InputField blooom_intisity, bloomthreshold, vigneetIntensity, vigneetSmoothing, colorgrattPostExp, colorgratContrast, saturation;

    [Space]
    public bool b;

    public InputField g_blooom_intisity, g_bloomthreshold, g_vigneetIntensity, g_vigneetSmoothing, g_colorgrattPostExp, g_colorgratContrast, g_saturation;

    Bloom bloom;
    Vignette vignette;
    ColorGrading colorGrading;

    Bloom g_bloom;
    Vignette g_vignette;
    ColorGrading g_colorGrading;

    private void Start()
    {
        pp.TryGetSettings(out bloom);
        pp.TryGetSettings(out vignette);
        pp.TryGetSettings(out colorGrading);

        g_pp.TryGetSettings(out g_bloom);
        g_pp.TryGetSettings(out g_vignette);
        g_pp.TryGetSettings(out g_colorGrading);

        PPset.SetActive(false);
        b = false;
    }

    public void SetBoomIntensity()
    {
        bloom.intensity.value = float.Parse(blooom_intisity.text);
    }

    public void SetBoomThreshold()
    {
        bloom.threshold.value = float.Parse(bloomthreshold.text);
    }

    public void SetVigneetIntensity()
    {
        vignette.intensity.value = float.Parse(vigneetIntensity.text);
    }

    public void SetVigneetSmoothing()
    {
        vignette.smoothness.value = float.Parse(vigneetSmoothing.text);
    }
    

    public void SetColorGradPostExp()
    {
        colorGrading.postExposure.value = float.Parse(colorgrattPostExp.text);
    }

    public void SetColorGradContrast()
    {
        colorGrading.contrast.value = float.Parse(colorgratContrast.text);
    }

    public void SetColorGradSAturation()
    {
        colorGrading.saturation.value = float.Parse(saturation.text);
    }

    /// <summary>
    /// //////////////////////////////////////////////////////
    /// </summary>

    public void G_SetBoomIntensity()
    {
        g_bloom.intensity.value = float.Parse(g_blooom_intisity.text);
    }

    public void G_SetBoomThreshold()
    {
        g_bloom.threshold.value = float.Parse(g_bloomthreshold.text);
    }

    public void G_SetVigneetIntensity()
    {
        g_vignette.intensity.value = float.Parse(g_vigneetIntensity.text);
    }

    public void G_SetVigneetSmoothing()
    {
        g_vignette.smoothness.value = float.Parse(g_vigneetSmoothing.text);
    }


    public void G_SetColorGradPostExp()
    {
        g_colorGrading.postExposure.value = float.Parse(g_colorgrattPostExp.text);
    }

    public void G_SetColorGradContrast()
    {
        g_colorGrading.contrast.value = float.Parse(g_colorgratContrast.text);
    }

    public void G_SetColorGradSAturation()
    {
        g_colorGrading.saturation.value = float.Parse(g_saturation.text);
    }

    public void TogglePPSet()
    {
        Time.timeScale = 0;
        if(!b)
        {
            b = true;
            PPset.SetActive(true);
        }
        else
        {
            b = false;
            PPset.SetActive(false);
        }
    }

}
