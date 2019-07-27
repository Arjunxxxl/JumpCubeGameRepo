using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PPDebugScript : MonoBehaviour
{
    public PostProcessProfile pp;

    public InputField blooom_intisity, bloomthreshold, vigneetIntensity, vigneetSmoothing, ChromAbb_intensity, colorgrattPostExp, colorgratContrast, autoExpMin, autoExpMax;

    Bloom bloom;
    Vignette vignette;
    ChromaticAberration chromaticAberration;
    ColorGrading colorGrading;
    AutoExposure autoExposure;

    private void Start()
    {
        pp.TryGetSettings(out bloom);
        pp.TryGetSettings(out vignette);
        pp.TryGetSettings(out chromaticAberration);
        pp.TryGetSettings(out colorGrading);
        pp.TryGetSettings(out autoExposure);
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

    public void SetChrom_intensity()
    {
        chromaticAberration.intensity.value = float.Parse(ChromAbb_intensity.text);
    }

    public void SetColorGradPostExp()
    {
        colorGrading.postExposure.value = float.Parse(colorgrattPostExp.text);
    }

    public void SetColorGradContrast()
    {
        colorGrading.contrast.value = float.Parse(colorgratContrast.text);
    }

    public void SetAutoExpMin()
    {
        autoExposure.minLuminance.value = float.Parse(autoExpMin.text);
    }

    public void SetAutoExpMax()
    {
        autoExposure.maxLuminance.value = float.Parse(autoExpMax.text);
    }
}
