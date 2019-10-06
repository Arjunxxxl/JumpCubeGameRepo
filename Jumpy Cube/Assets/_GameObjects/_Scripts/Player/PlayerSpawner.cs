using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject Player;
    public Vector3 position;

    [Header("Disolve Effect Parameter")]
    public float disloveSpeed = 0.5f;
    public float disolveEffect;
    public bool isDisolveEffectDone;
    public bool startDisolveEffect;
    public float disolveEffectDelay = 0.2f;

    [Header("Selected Cube Data")]
    public CubeBoughtManager cubeBoughtManager;

    [Header("Common Cube mat")]
    public Material playerMaterial;

    [System.Serializable]
    public class RareCubeMat
    {
        public Material commonMat;
        public Material[] rareMat1;
        public Material[] rareMat2;
        public Material[] rareMat3;
        public Material[] rareMat4;
        public Material[] rareMat5;
        public Material[] rareMat6;
        public Material[] rareMat7;
        public Material[] rareMat8;
        public Material[] rareMat9;
    }
    [SerializeField]
    [Space]
    public RareCubeMat rareCubeMat;

    [System.Serializable]
    public class LegendaryCubeMat
    {
        public Material commonMat;
        public Material[] legendaryMat1;
        public Material[] legendaryMat2;
        public Material[] legendaryMat3;
        public Material[] legendaryMat4;
        public Material[] legendaryMat5;
        public Material[] legendaryMat6;
        public Material[] legendaryMat7;
        public Material[] legendaryMat8;
        public Material[] legendaryMat9;
    }
    [SerializeField]
    [Space]
    public LegendaryCubeMat legendaryCubeMat;

    [System.Serializable]
    public class MissionCubeMat
    {
        public Material commonMat;
        public Material[] missionMat1;
        public Material[] missionMat2;
        public Material[] missionMat3;
        public Material[] missionMat4;
        public Material[] missionMat5;
        public Material[] missionMat6;
        public Material[] missionMat7;
        public Material[] missionMat8;
        public Material[] missionMat9;
    }
    [SerializeField]
    [Space]
    public MissionCubeMat missionCubeMat;

    MainMenu mainmenu;
    MissionManager missionManager;

    int i;
    int totalMat;

    #region SingleTon
    public static PlayerSpawner Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        if (!Player)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        Player.SetActive(true);
        Player.transform.position = position;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        mainmenu = MainMenu.Instance;
        missionManager = MissionManager.Instance;

        GetChildCubeMaterial();

        isDisolveEffectDone = false;
        startDisolveEffect = false;
        StartCoroutine(DisolveEffectDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (!mainmenu.isGameStart)
        {
            return;
        }

        if (disolveEffect < 1.2 && !isDisolveEffectDone)
        {
            if (startDisolveEffect)
            {
                disolveEffect += Time.deltaTime * disloveSpeed;
            }

            UpdatePlayerMat();
        }
        else if (!isDisolveEffectDone)
        {
            isDisolveEffectDone = true;
            missionManager.CheckingForTimesGamePlayedMission();
        }
    }

    void UpdatePlayerMat()
    {
        if (cubeBoughtManager.selectedCubeType == CubeBoughtManager.CubeType.common)
        {
            playerMaterial.SetFloat("Vector1_D57CEFD5", disolveEffect);
        }
        else if (cubeBoughtManager.selectedCubeType == CubeBoughtManager.CubeType.rare)
        {
            rareCubeMat.commonMat.SetFloat("Vector1_D57CEFD5", disolveEffect);

            switch (cubeBoughtManager.selectedCubeIndex)
            {
                case 0:
                    totalMat = rareCubeMat.rareMat1.Length;

                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        rareCubeMat.rareMat1[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat1[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;

                case 1:
                    totalMat = rareCubeMat.rareMat2.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        rareCubeMat.rareMat2[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat2[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 2:
                    totalMat = rareCubeMat.rareMat3.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        rareCubeMat.rareMat3[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat3[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 3:
                    totalMat = rareCubeMat.rareMat4.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        rareCubeMat.rareMat4[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat4[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 4:
                    totalMat = rareCubeMat.rareMat5.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        rareCubeMat.rareMat5[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat5[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 5:
                    totalMat = rareCubeMat.rareMat6.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        rareCubeMat.rareMat6[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat6[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 6:
                    totalMat = rareCubeMat.rareMat7.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        rareCubeMat.rareMat7[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat7[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 7:
                    totalMat = rareCubeMat.rareMat8.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        rareCubeMat.rareMat8[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat8[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 8:
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else totalMat = rareCubeMat.rareMat9.Length;
                    if (totalMat == 1)
                    {
                        rareCubeMat.rareMat9[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat9[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
            }
        }
        else if (cubeBoughtManager.selectedCubeType == CubeBoughtManager.CubeType.legendary)
        {
            legendaryCubeMat.commonMat.SetFloat("Vector1_D57CEFD5", disolveEffect);

            switch (cubeBoughtManager.selectedCubeIndex)
            {
                case 0:
                    totalMat = legendaryCubeMat.legendaryMat1.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat1[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat1[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;

                case 1:
                    totalMat = legendaryCubeMat.legendaryMat2.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat2[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat2[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 2:
                    totalMat = legendaryCubeMat.legendaryMat3.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat3[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat3[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 3:
                    totalMat = legendaryCubeMat.legendaryMat4.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat4[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat4[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 4:
                    totalMat = legendaryCubeMat.legendaryMat5.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat5[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat5[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 5:
                    totalMat = legendaryCubeMat.legendaryMat6.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat6[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat6[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 6:
                    totalMat = legendaryCubeMat.legendaryMat7.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat7[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat7[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 7:
                    totalMat = legendaryCubeMat.legendaryMat8.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat8[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat8[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 8:
                    totalMat = legendaryCubeMat.legendaryMat9.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat9[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat9[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
            }
        }
        else if (cubeBoughtManager.selectedCubeType == CubeBoughtManager.CubeType.mission_cube)
        {
            missionCubeMat.commonMat.SetFloat("Vector1_D57CEFD5", disolveEffect);

            switch (cubeBoughtManager.selectedCubeIndex)
            {
                case 0:
                    totalMat = missionCubeMat.missionMat1.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat1[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat1[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;

                case 1:
                    totalMat = missionCubeMat.missionMat2.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat2[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat2[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 2:
                    totalMat = missionCubeMat.missionMat3.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat3[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat3[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 3:
                    totalMat = missionCubeMat.missionMat4.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat4[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat4[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 4:
                    totalMat = missionCubeMat.missionMat5.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat5[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat5[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 5:
                    totalMat = missionCubeMat.missionMat6.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat6[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat6[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 6:
                    totalMat = missionCubeMat.missionMat7.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat7[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat7[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 7:
                    totalMat = missionCubeMat.missionMat8.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat8[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat8[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 8:
                    totalMat = missionCubeMat.missionMat9.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat9[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat9[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
            }
        }
    }

    public void GetChildCubeMaterial()
    {
        if (cubeBoughtManager.selectedCubeType == CubeBoughtManager.CubeType.common)
        {
            disolveEffect = playerMaterial.GetFloat("Vector1_D57CEFD5");
            disolveEffect = 0;
            playerMaterial.SetFloat("Vector1_D57CEFD5", disolveEffect);
        }
        else if (cubeBoughtManager.selectedCubeType == CubeBoughtManager.CubeType.rare)
        {
            disolveEffect = 0;

            rareCubeMat.commonMat.SetFloat("Vector1_D57CEFD5", disolveEffect);

            switch (cubeBoughtManager.selectedCubeIndex)
            {
                case 0:
                    totalMat = rareCubeMat.rareMat1.Length;

                    if(totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        rareCubeMat.rareMat1[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat1[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;

                case 1:
                    totalMat = rareCubeMat.rareMat2.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        rareCubeMat.rareMat2[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat2[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 2:
                    totalMat = rareCubeMat.rareMat3.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        rareCubeMat.rareMat3[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat3[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 3:
                    totalMat = rareCubeMat.rareMat4.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        rareCubeMat.rareMat4[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat4[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 4:
                    totalMat = rareCubeMat.rareMat5.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        rareCubeMat.rareMat5[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat5[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 5:
                    totalMat = rareCubeMat.rareMat6.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        rareCubeMat.rareMat6[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat6[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 6:
                    totalMat = rareCubeMat.rareMat7.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        rareCubeMat.rareMat7[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat7[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 7:
                    totalMat = rareCubeMat.rareMat8.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        rareCubeMat.rareMat8[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat8[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 8:
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else totalMat = rareCubeMat.rareMat9.Length;
                    if (totalMat == 1)
                    {
                        rareCubeMat.rareMat9[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            rareCubeMat.rareMat9[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
            }
        }
        else if (cubeBoughtManager.selectedCubeType == CubeBoughtManager.CubeType.legendary)
        {
            disolveEffect = 0;

            legendaryCubeMat.commonMat.SetFloat("Vector1_D57CEFD5", disolveEffect);

            switch (cubeBoughtManager.selectedCubeIndex)
            {
                case 0:
                    totalMat = legendaryCubeMat.legendaryMat1.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat1[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat1[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;

                case 1:
                    totalMat = legendaryCubeMat.legendaryMat2.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat2[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat2[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 2:
                    totalMat = legendaryCubeMat.legendaryMat3.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat3[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat3[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 3:
                    totalMat = legendaryCubeMat.legendaryMat4.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat4[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat4[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 4:
                    totalMat = legendaryCubeMat.legendaryMat5.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat5[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat5[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 5:
                    totalMat = legendaryCubeMat.legendaryMat6.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat6[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat6[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 6:
                    totalMat = legendaryCubeMat.legendaryMat7.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat7[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat7[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 7:
                    totalMat = legendaryCubeMat.legendaryMat8.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat8[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat8[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 8:
                    totalMat = legendaryCubeMat.legendaryMat9.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        legendaryCubeMat.legendaryMat9[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            legendaryCubeMat.legendaryMat9[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
            }
        }
        else if (cubeBoughtManager.selectedCubeType == CubeBoughtManager.CubeType.mission_cube)
        {
            disolveEffect = 0;

            missionCubeMat.commonMat.SetFloat("Vector1_D57CEFD5", disolveEffect);

            switch (cubeBoughtManager.selectedCubeIndex)
            {
                case 0:
                    totalMat = missionCubeMat.missionMat1.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat1[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat1[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;

                case 1:
                    totalMat = missionCubeMat.missionMat2.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat2[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat2[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 2:
                    totalMat = missionCubeMat.missionMat3.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat3[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat3[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 3:
                    totalMat = missionCubeMat.missionMat4.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat4[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat4[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 4:
                    totalMat = missionCubeMat.missionMat5.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat5[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat5[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 5:
                    totalMat = missionCubeMat.missionMat6.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat6[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat6[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 6:
                    totalMat = missionCubeMat.missionMat7.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat7[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat7[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 7:
                    totalMat = missionCubeMat.missionMat8.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat8[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat8[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
                case 8:
                    totalMat = missionCubeMat.missionMat9.Length;
                    if (totalMat == 0)
                    {
                        return;
                    }
                    else if (totalMat == 1)
                    {
                        missionCubeMat.missionMat9[0].SetFloat("Vector1_D57CEFD5", disolveEffect);
                    }
                    else
                    {
                        for (i = 0; i < totalMat; i++)
                        {
                            missionCubeMat.missionMat9[i].SetFloat("Vector1_D57CEFD5", disolveEffect);
                        }
                    }
                    break;
            }
        }
    }

    IEnumerator DisolveEffectDelay()
    {
        yield return new WaitForSeconds(disolveEffectDelay);
        startDisolveEffect = true;
    }
}
