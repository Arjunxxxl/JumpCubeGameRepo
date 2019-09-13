using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectColorScheme : MonoBehaviour
{
    [Header("Color Scheme Data")]
    public int totalColorSchemes;
    public int selectedColorScheme;
    public int tempColorScheme;
    public int previousColorScheme;
    public List<int> colorSchemeIndex;
    [Space]
    [Header("Color Scheme 1")]
    public Color col_scm_1_1;
    public Color col_scm_1_2;
    public Gradient col_scm_1_grad;
    public Color camBGcolor_1;
    public Color landParticleSystemColor_1;
    public Color spikesColor_1;
    [ColorUsage(true, true)]
    public Color gravityFieldColor_1;
    public Color io_sphereColor_main_1;
    public Color io_sphereColor_change_1;
    
    [Header("Color Scheme 2")]
    public Color col_scm_2_1;
    public Color col_scm_2_2;
    public Gradient col_scm_2_grad;
    public Color camBGcolor_2;
    public Color landParticleSystemColor_2;
    public Color spikesColor_2;
    [ColorUsage(true, true)]
    public Color gravityFieldColor_2;
    public Color io_sphereColor_main_2;
    public Color io_sphereColor_change_2;

    [Header("Material")]
    public Material playerMaterial;
    public Material[] floor;
    public Material[] ceil;
    public Material spikesMaterial;
    public Material[] gravityFieldMat;

    [Header("Particle System")]
    public ParticleSystem landParticleSystem;

    [Header("Data for io sphere color changer script")]
    public Shader ioSphereShader;
    public Color ioSphereMainColor;
    public Color ioSphereChangeColor;

    public Imphenzia.GradientSkyCamera gradientCamera;
    public Camera mainCamera;

    #region SingleTon
    public static SelectColorScheme Instance;
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

        tempColorScheme = SelectTempColor();
        //tempColorScheme = 2;

        previousColorScheme = tempColorScheme;
        PlayerPrefs.SetInt("PreviousColorScheme", previousColorScheme);

        selectedColorScheme = tempColorScheme;
        SetColor();
    }
    #endregion
    

    void SetColor()
    {
        if(selectedColorScheme == 1)
        {
            gradientCamera.gradient = col_scm_1_grad;
            var main = landParticleSystem.main;
            main.startColor = landParticleSystemColor_1;
            spikesMaterial.SetColor("_BaseColor", spikesColor_1);
            
            ioSphereMainColor = io_sphereColor_main_1;
            ioSphereChangeColor = io_sphereColor_change_1;

            mainCamera.backgroundColor = camBGcolor_1;

            for (int i = 0; i<30; i++)
            {
                if(i%2 == 0)
                {
                    floor[i].SetColor("_BaseColor", col_scm_1_1);
                    ceil[i].SetColor("_BaseColor", col_scm_1_2);
                }
                else
                {
                    floor[i].SetColor("_BaseColor", col_scm_1_2);
                    ceil[i].SetColor("_BaseColor", col_scm_1_1);
                }
            }

            foreach(Material mat in gravityFieldMat)
            {
                mat.SetColor("_EmissionColor", gravityFieldColor_1);
            }
        }
        else if (selectedColorScheme == 2)
        {
            gradientCamera.gradient = col_scm_2_grad;
            var main = landParticleSystem.main;
            main.startColor = landParticleSystemColor_2;
            spikesMaterial.SetColor("_BaseColor", spikesColor_2);
            
            ioSphereMainColor = io_sphereColor_main_2;
            ioSphereChangeColor = io_sphereColor_change_2;

            mainCamera.backgroundColor = camBGcolor_2;

            for (int i = 0; i < 30; i++)
            {
                if (i % 2 == 0)
                {
                    floor[i].SetColor("_BaseColor", col_scm_2_1);
                    ceil[i].SetColor("_BaseColor", col_scm_2_2);
                }
                else
                {
                    floor[i].SetColor("_BaseColor", col_scm_2_2);
                    ceil[i].SetColor("_BaseColor", col_scm_2_1);
                }
            }

            foreach (Material mat in gravityFieldMat)
            {
                mat.SetColor("_EmissionColor", gravityFieldColor_2);
            }
        }
        
    }

    int SelectTempColor()
    {
        previousColorScheme = PlayerPrefs.GetInt("PreviousColorScheme", 0);

        if (previousColorScheme == 0)
        {
            return 1;
        }
        else
        {
            colorSchemeIndex.Remove(previousColorScheme);
            int i = Random.Range(0, colorSchemeIndex.Count);

            i = colorSchemeIndex[i];

            return i;
        }
    }
}
