using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColorManager : MonoBehaviour
{
    [Header("Cube Color Data")]
    public Color[] common_color;

    [Header("Cube disolve effect color data")]
    [ColorUsage(true, true)]
    public Color[] glow_common_color;

    [Header("Cube trail color data")]
    [ColorUsage(true, true)]
    public Color[] trail_common_cube;

    [Header("Cube death trail color data")]
    [ColorUsage(true, true)]
    public Color[] death_trail_common_cube;

    [Header("Cube material Data")]
    public Material commonCubeMat;
    public Material commonCubeTrailMat;
    public Material playerDeathParticleMat;
    public Material deathTrailMat;

    #region SingleTon
    public static CubeColorManager Instance;
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


    public void SetCubeColor_CommonCube(int selectedCubeIndex)
    {
        commonCubeMat.SetColor("Color_726517DF", common_color[selectedCubeIndex]);
        commonCubeMat.SetColor("Color_1E66CDFD", glow_common_color[selectedCubeIndex]);

        playerDeathParticleMat.SetColor("_BaseColor", common_color[selectedCubeIndex]);
        commonCubeTrailMat.SetColor("_EmissionColor", trail_common_cube[selectedCubeIndex]);
        deathTrailMat.SetColor("_EmissionColor", death_trail_common_cube[selectedCubeIndex]);
    }

}
