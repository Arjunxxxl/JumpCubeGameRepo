using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectColorScheme : MonoBehaviour
{
    public TileColorThemeBoughtManager tileColorThemeManager;
    
    [Header("Color Scheme Data")]
    public int totalColorSchemes;
    public int selectedColorScheme;
    public int tempColorScheme;
    public int previousColorScheme;

    [System.Serializable]
    public class ColorScheme
    {
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
        [ColorUsage(true, true)]
        public Color shootingSpikeTrailColor_1;
        [ColorUsage(true, true)]
        public Color shootingSpikeParticleColor_1;

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
        [ColorUsage(true, true)]
        public Color shootingSpikeTrailColor_2;
        [ColorUsage(true, true)]
        public Color shootingSpikeParticleColor_2;

        [Header("Color Scheme 3")]
        public Color col_scm_3_1;
        public Color col_scm_3_2;
        public Gradient col_scm_3_grad;
        public Color camBGcolor_3;
        public Color landParticleSystemColor_3;
        public Color spikesColor_3;
        [ColorUsage(true, true)]
        public Color gravityFieldColor_3;
        public Color io_sphereColor_main_3;
        public Color io_sphereColor_change_3;
        [ColorUsage(true, true)]
        public Color shootingSpikeTrailColor_3;
        [ColorUsage(true, true)]
        public Color shootingSpikeParticleColor_3;

        [Header("Color Scheme 4")]
        public Color col_scm_4_1;
        public Color col_scm_4_2;
        public Gradient col_scm_4_grad;
        public Color camBGcolor_4;
        public Color landParticleSystemColor_4;
        public Color spikesColor_4;
        [ColorUsage(true, true)]
        public Color gravityFieldColor_4;
        public Color io_sphereColor_main_4;
        public Color io_sphereColor_change_4;
        [ColorUsage(true, true)]
        public Color shootingSpikeTrailColor_4;
        [ColorUsage(true, true)]
        public Color shootingSpikeParticleColor_4;

        [Header("Color Scheme 5")]
        public Color col_scm_5_1;
        public Color col_scm_5_2;
        public Gradient col_scm_5_grad;
        public Color camBGcolor_5;
        public Color landParticleSystemColor_5;
        public Color spikesColor_5;
        [ColorUsage(true, true)]
        public Color gravityFieldColor_5;
        public Color io_sphereColor_main_5;
        public Color io_sphereColor_change_5;
        [ColorUsage(true, true)]
        public Color shootingSpikeTrailColor_5;
        [ColorUsage(true, true)]
        public Color shootingSpikeParticleColor_5;

        [Header("Color Scheme 6")]
        public Color col_scm_6_1;
        public Color col_scm_6_2;
        public Gradient col_scm_6_grad;
        public Color camBGcolor_6;
        public Color landParticleSystemColor_6;
        public Color spikesColor_6;
        [ColorUsage(true, true)]
        public Color gravityFieldColor_6;
        public Color io_sphereColor_main_6;
        public Color io_sphereColor_change_6;
        [ColorUsage(true, true)]
        public Color shootingSpikeTrailColor_6;
        [ColorUsage(true, true)]
        public Color shootingSpikeParticleColor_6;

        [Header("Color Scheme 7")]
        public Color col_scm_7_1;
        public Color col_scm_7_2;
        public Gradient col_scm_7_grad;
        public Color camBGcolor_7;
        public Color landParticleSystemColor_7;
        public Color spikesColor_7;
        [ColorUsage(true, true)]
        public Color gravityFieldColor_7;
        public Color io_sphereColor_main_7;
        public Color io_sphereColor_change_7;
        [ColorUsage(true, true)]
        public Color shootingSpikeTrailColor_7;
        [ColorUsage(true, true)]
        public Color shootingSpikeParticleColor_7;

        [Header("Color Scheme 8")]
        public Color col_scm_8_1;
        public Color col_scm_8_2;
        public Gradient col_scm_8_grad;
        public Color camBGcolor_8;
        public Color landParticleSystemColor_8;
        public Color spikesColor_8;
        [ColorUsage(true, true)]
        public Color gravityFieldColor_8;
        public Color io_sphereColor_main_8;
        public Color io_sphereColor_change_8;
        [ColorUsage(true, true)]
        public Color shootingSpikeTrailColor_8;
        [ColorUsage(true, true)]
        public Color shootingSpikeParticleColor_8;

        [Header("Color Scheme 9")]
        public Color col_scm_9_1;
        public Color col_scm_9_2;
        public Gradient col_scm_9_grad;
        public Color camBGcolor_9;
        public Color landParticleSystemColor_9;
        public Color spikesColor_9;
        [ColorUsage(true, true)]
        public Color gravityFieldColor_9;
        public Color io_sphereColor_main_9;
        public Color io_sphereColor_change_9;
        [ColorUsage(true, true)]
        public Color shootingSpikeTrailColor_9;
        [ColorUsage(true, true)]
        public Color shootingSpikeParticleColor_9;
    }
    [SerializeField]
    public ColorScheme colorScheme; 

    [Space]
    [Header("Material")]
    public Material playerMaterial;
    public Material[] floor;
    public Material[] ceil;
    public Material spikesMaterial;
    public Material[] gravityFieldMat;
    public Material shootingSpikeTrailMat;
    public Material shootingSpikeParticleMat;

    [Header("Particle System")]
    public ParticleSystem landParticleSystem;
    public List<ParticleSystem> landParticleSystems;
    
    [Header("Data for io sphere color changer script")]
    public Shader ioSphereShader;
    public Color ioSphereMainColor;
    public Color ioSphereChangeColor;

    public Imphenzia.GradientSkyCamera gradientCamera;
    public Camera mainCamera;
    public CustomStrings customStrings;
    public TileColorThemeBoughtManager tileColorThemeBoughtManager;
    ObjectPooler objectPooler;


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

        GetCuttentColorSchme();

        previousColorScheme = tempColorScheme;
        PlayerPrefs.SetInt("PreviousColorScheme", previousColorScheme);

        selectedColorScheme = tempColorScheme;
        SetColor();
    }
    #endregion

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;

        totalColorSchemes = tileColorThemeBoughtManager.totalColorScheme;

        landParticleSystems = objectPooler.landEffect;
    }

    public void SetColor(bool updateFromStore = false)
    {
        if(selectedColorScheme == 0)
        {
            gradientCamera.gradient = colorScheme.col_scm_1_grad;
            var main = landParticleSystem.main;
            main.startColor = colorScheme.landParticleSystemColor_1;
            spikesMaterial.SetColor("_BaseColor", colorScheme.spikesColor_1);
            
            if(updateFromStore)
            {
                foreach(ParticleSystem ps in landParticleSystems)
                {
                    var main2 = ps.main;
                    main2.startColor = colorScheme.landParticleSystemColor_1;
                }
            }

            ioSphereMainColor = colorScheme.io_sphereColor_main_1;
            ioSphereChangeColor = colorScheme.io_sphereColor_change_1;

            mainCamera.backgroundColor = colorScheme.camBGcolor_1;

            for (int i = 0; i<floor.Length; i++)
            {
                if(i%2 == 0)
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_1_1);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_1_2);
                }
                else
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_1_2);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_1_1);
                }
            }

            foreach(Material mat in gravityFieldMat)
            {
                mat.SetColor("_EmissionColor", colorScheme.gravityFieldColor_1);
            }
            
            shootingSpikeTrailMat.SetColor("_EmissionColor", colorScheme.shootingSpikeTrailColor_1);
            shootingSpikeParticleMat.SetColor("_EmissionColor", colorScheme.shootingSpikeParticleColor_1);
        }
        else if (selectedColorScheme == 1)
        {
            gradientCamera.gradient = colorScheme.col_scm_2_grad;
            var main = landParticleSystem.main;
            main.startColor = colorScheme.landParticleSystemColor_2;
            spikesMaterial.SetColor("_BaseColor", colorScheme.spikesColor_2);

            if (updateFromStore)
            {
                foreach (ParticleSystem ps in landParticleSystems)
                {
                    var main2 = ps.main;
                    main2.startColor = colorScheme.landParticleSystemColor_2;
                }
            }

            ioSphereMainColor = colorScheme.io_sphereColor_main_2;
            ioSphereChangeColor = colorScheme.io_sphereColor_change_2;

            mainCamera.backgroundColor = colorScheme.camBGcolor_2;

            for (int i = 0; i < floor.Length; i++)
            {
                if (i % 2 == 0)
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_2_1);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_2_2);
                }
                else
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_2_2);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_2_1);
                }
            }

            foreach (Material mat in gravityFieldMat)
            {
                mat.SetColor("_EmissionColor", colorScheme.gravityFieldColor_2);
            }

            shootingSpikeTrailMat.SetColor("_EmissionColor", colorScheme.shootingSpikeTrailColor_2);
            shootingSpikeParticleMat.SetColor("_EmissionColor", colorScheme.shootingSpikeParticleColor_2);
        }
        else if (selectedColorScheme == 2)
        {
            gradientCamera.gradient = colorScheme.col_scm_3_grad;
            var main = landParticleSystem.main;
            main.startColor = colorScheme.landParticleSystemColor_3;
            spikesMaterial.SetColor("_BaseColor", colorScheme.spikesColor_3);

            if (updateFromStore)
            {
                foreach (ParticleSystem ps in landParticleSystems)
                {
                    var main2 = ps.main;
                    main2.startColor = colorScheme.landParticleSystemColor_3;
                }
            }

            ioSphereMainColor = colorScheme.io_sphereColor_main_3;
            ioSphereChangeColor = colorScheme.io_sphereColor_change_3;

            mainCamera.backgroundColor = colorScheme.camBGcolor_3;

            for (int i = 0; i < floor.Length; i++)
            {
                if (i % 2 == 0)
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_3_1);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_3_2);
                }
                else
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_3_2);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_3_1);
                }
            }

            foreach (Material mat in gravityFieldMat)
            {
                mat.SetColor("_EmissionColor", colorScheme.gravityFieldColor_3);
            }

            shootingSpikeTrailMat.SetColor("_EmissionColor", colorScheme.shootingSpikeTrailColor_3);
            shootingSpikeParticleMat.SetColor("_EmissionColor", colorScheme.shootingSpikeParticleColor_3);
        }
        else if (selectedColorScheme == 3)
        {
            gradientCamera.gradient = colorScheme.col_scm_4_grad;
            var main = landParticleSystem.main;
            main.startColor = colorScheme.landParticleSystemColor_4;
            spikesMaterial.SetColor("_BaseColor", colorScheme.spikesColor_4);

            if (updateFromStore)
            {
                foreach (ParticleSystem ps in landParticleSystems)
                {
                    var main2 = ps.main;
                    main2.startColor = colorScheme.landParticleSystemColor_4;
                }
            }

            ioSphereMainColor = colorScheme.io_sphereColor_main_4;
            ioSphereChangeColor = colorScheme.io_sphereColor_change_4;

            mainCamera.backgroundColor = colorScheme.camBGcolor_4;

            for (int i = 0; i < floor.Length; i++)
            {
                if (i % 2 == 0)
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_4_1);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_4_2);
                }
                else
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_4_2);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_4_1);
                }
            }

            foreach (Material mat in gravityFieldMat)
            {
                mat.SetColor("_EmissionColor", colorScheme.gravityFieldColor_4);
            }

            shootingSpikeTrailMat.SetColor("_EmissionColor", colorScheme.shootingSpikeTrailColor_4);
            shootingSpikeParticleMat.SetColor("_EmissionColor", colorScheme.shootingSpikeParticleColor_4);
        }
        else if (selectedColorScheme == 4)
        {
            gradientCamera.gradient = colorScheme.col_scm_5_grad;
            var main = landParticleSystem.main;
            main.startColor = colorScheme.landParticleSystemColor_5;
            spikesMaterial.SetColor("_BaseColor", colorScheme.spikesColor_5);

            if (updateFromStore)
            {
                foreach (ParticleSystem ps in landParticleSystems)
                {
                    var main2 = ps.main;
                    main2.startColor = colorScheme.landParticleSystemColor_5;
                }
            }

            ioSphereMainColor = colorScheme.io_sphereColor_main_5;
            ioSphereChangeColor = colorScheme.io_sphereColor_change_5;

            mainCamera.backgroundColor = colorScheme.camBGcolor_5;

            for (int i = 0; i < floor.Length; i++)
            {
                if (i % 2 == 0)
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_5_1);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_5_2);
                }
                else
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_5_2);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_5_1);
                }
            }

            foreach (Material mat in gravityFieldMat)
            {
                mat.SetColor("_EmissionColor", colorScheme.gravityFieldColor_5);
            }

            shootingSpikeTrailMat.SetColor("_EmissionColor", colorScheme.shootingSpikeTrailColor_5);
            shootingSpikeParticleMat.SetColor("_EmissionColor", colorScheme.shootingSpikeParticleColor_5);
        }
        else if (selectedColorScheme == 5)
        {
            gradientCamera.gradient = colorScheme.col_scm_6_grad;
            var main = landParticleSystem.main;
            main.startColor = colorScheme.landParticleSystemColor_6;
            spikesMaterial.SetColor("_BaseColor", colorScheme.spikesColor_6);

            if (updateFromStore)
            {
                foreach (ParticleSystem ps in landParticleSystems)
                {
                    var main2 = ps.main;
                    main2.startColor = colorScheme.landParticleSystemColor_6;
                }
            }

            ioSphereMainColor = colorScheme.io_sphereColor_main_6;
            ioSphereChangeColor = colorScheme.io_sphereColor_change_6;

            mainCamera.backgroundColor = colorScheme.camBGcolor_6;

            for (int i = 0; i < floor.Length; i++)
            {
                if (i % 2 == 0)
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_6_1);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_6_2);
                }
                else
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_6_2);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_6_1);
                }
            }

            foreach (Material mat in gravityFieldMat)
            {
                mat.SetColor("_EmissionColor", colorScheme.gravityFieldColor_6);
            }

            shootingSpikeTrailMat.SetColor("_EmissionColor", colorScheme.shootingSpikeTrailColor_6);
            shootingSpikeParticleMat.SetColor("_EmissionColor", colorScheme.shootingSpikeParticleColor_6);
        }
        else if (selectedColorScheme == 6)
        {
            gradientCamera.gradient = colorScheme.col_scm_7_grad;
            var main = landParticleSystem.main;
            main.startColor = colorScheme.landParticleSystemColor_7;
            spikesMaterial.SetColor("_BaseColor", colorScheme.spikesColor_7);

            if (updateFromStore)
            {
                foreach (ParticleSystem ps in landParticleSystems)
                {
                    var main2 = ps.main;
                    main2.startColor = colorScheme.landParticleSystemColor_7;
                }
            }

            ioSphereMainColor = colorScheme.io_sphereColor_main_7;
            ioSphereChangeColor = colorScheme.io_sphereColor_change_7;

            mainCamera.backgroundColor = colorScheme.camBGcolor_7;

            for (int i = 0; i < floor.Length; i++)
            {
                if (i % 2 == 0)
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_7_1);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_7_2);
                }
                else
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_7_2);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_7_1);
                }
            }

            foreach (Material mat in gravityFieldMat)
            {
                mat.SetColor("_EmissionColor", colorScheme.gravityFieldColor_7);
            }

            shootingSpikeTrailMat.SetColor("_EmissionColor", colorScheme.shootingSpikeTrailColor_7);
            shootingSpikeParticleMat.SetColor("_EmissionColor", colorScheme.shootingSpikeParticleColor_7);
        }
        else if (selectedColorScheme == 7)
        {
            gradientCamera.gradient = colorScheme.col_scm_8_grad;
            var main = landParticleSystem.main;
            main.startColor = colorScheme.landParticleSystemColor_8;
            spikesMaterial.SetColor("_BaseColor", colorScheme.spikesColor_8);

            if (updateFromStore)
            {
                foreach (ParticleSystem ps in landParticleSystems)
                {
                    var main2 = ps.main;
                    main2.startColor = colorScheme.landParticleSystemColor_8;
                }
            }

            ioSphereMainColor = colorScheme.io_sphereColor_main_8;
            ioSphereChangeColor = colorScheme.io_sphereColor_change_8;

            mainCamera.backgroundColor = colorScheme.camBGcolor_8;

            for (int i = 0; i < floor.Length; i++)
            {
                if (i % 2 == 0)
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_8_1);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_8_2);
                }
                else
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_8_2);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_8_1);
                }
            }

            foreach (Material mat in gravityFieldMat)
            {
                mat.SetColor("_EmissionColor", colorScheme.gravityFieldColor_8);
            }

            shootingSpikeTrailMat.SetColor("_EmissionColor", colorScheme.shootingSpikeTrailColor_8);
            shootingSpikeParticleMat.SetColor("_EmissionColor", colorScheme.shootingSpikeParticleColor_8);
        }
        else if (selectedColorScheme == 8)
        {
            gradientCamera.gradient = colorScheme.col_scm_9_grad;
            var main = landParticleSystem.main;
            main.startColor = colorScheme.landParticleSystemColor_9;
            spikesMaterial.SetColor("_BaseColor", colorScheme.spikesColor_9);

            if (updateFromStore)
            {
                foreach (ParticleSystem ps in landParticleSystems)
                {
                    var main2 = ps.main;
                    main2.startColor = colorScheme.landParticleSystemColor_9;
                }
            }

            ioSphereMainColor = colorScheme.io_sphereColor_main_9;
            ioSphereChangeColor = colorScheme.io_sphereColor_change_9;

            mainCamera.backgroundColor = colorScheme.camBGcolor_9;

            for (int i = 0; i < floor.Length; i++)
            {
                if (i % 2 == 0)
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_9_1);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_9_2);
                }
                else
                {
                    floor[i].SetColor("_BaseColor", colorScheme.col_scm_9_2);
                    ceil[i].SetColor("_BaseColor", colorScheme.col_scm_9_1);
                }
            }

            foreach (Material mat in gravityFieldMat)
            {
                mat.SetColor("_EmissionColor", colorScheme.gravityFieldColor_9);
            }

            shootingSpikeTrailMat.SetColor("_EmissionColor", colorScheme.shootingSpikeTrailColor_9);
            shootingSpikeParticleMat.SetColor("_EmissionColor", colorScheme.shootingSpikeParticleColor_9);
        }
    }

    public void GetCuttentColorSchme()
    {
        tempColorScheme = PlayerPrefs.GetInt(customStrings.SELECTED_COLOR_SCHEME, 0);

        selectedColorScheme = tempColorScheme;
    }
    
}
