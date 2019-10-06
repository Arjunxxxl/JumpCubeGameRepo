using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBoughtManager : MonoBehaviour
{
    public enum CubeType
    { common, rare, legendary, mission_cube }

    public Transform player;

    public CubeType selectedCubeType;
    public int selectedCubeType_index;
    public int selectedCubeIndex;
    public GameObject selectedCube;

    [Header("Cube bought data - common")]
    public int totalCommonCubes;
    public Transform commonCubeParent;
    public List<int> ownedCubes_commonIndex;
    public List<GameObject> commonCubes;

    [Header("Cube bought data - rare")]
    public int totalRareCubes;
    public Transform rareCubeParent;
    public List<int> ownedCubes_rareIndex;
    public List<GameObject> rareCubes;

    [Header("Cube bought data - legendary")]
    public int totalLegndaryCubes;
    public Transform legendaryCubeParent;
    public List<int> ownedCubes_legendaryIndex;
    public List<GameObject> legendaryCubes;

    [Header("Cube bought data - MISSION")]
    public int totalMissionCubes;
    public Transform missionCubeParent;
    public List<int> ownedCubes_missionIndex;
    public List<GameObject> missionCubes;

    [Space]
    public CubeColorManager cubeColorManager;
    public Store store;
    public CustomStrings customStrings;
    public PlayerMovement playerMovement;
    public PlayerSpawner playerSpawner;
    public PlayerDeath playerDeath;

    private void Awake()
    {
        ownedCubes_commonIndex = new List<int>();

        GetOwnedCommonCubes();
        GetOwnedRareCubes();
        GetOwnedLegendaryCubes();
        GetOwnedMissionCubes();

        GetSelectedCubeType();

        SetCube();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = PlayerMovement.Instance;
        playerDeath = PlayerDeath.Instance;
        playerSpawner = PlayerSpawner.Instance;
        
        store.SetStoreButton(true);
    }

    void SetCube()
    {
        selectedCubeIndex = PlayerPrefs.GetInt(customStrings.SELECTED_CUBE_INDEX, 0);

        if (selectedCubeType == CubeType.common)
        {
            selectedCube = commonCubes[selectedCubeIndex];
            selectedCube.transform.SetParent(player);
            selectedCube.SetActive(true);

            cubeColorManager.SetCubeColor_CommonCube(selectedCubeIndex);
        }
        else if(selectedCubeType == CubeType.rare)
        {
            selectedCube = rareCubes[selectedCubeIndex];
            selectedCube.transform.SetParent(player);
            selectedCube.SetActive(true);

            cubeColorManager.SetCubeColor_RareCube(selectedCubeIndex);
        }
        else if (selectedCubeType == CubeType.legendary)
        {
            selectedCube = legendaryCubes[selectedCubeIndex];
            selectedCube.transform.SetParent(player);
            selectedCube.SetActive(true);

            cubeColorManager.SetCubeColor_LegendaryCube(selectedCubeIndex);
        }
        else if (selectedCubeType == CubeType.mission_cube)
        {
            selectedCube = missionCubes[selectedCubeIndex];
            selectedCube.transform.SetParent(player);
            selectedCube.SetActive(true);

            cubeColorManager.SetCubeColor_MissionCube(selectedCubeIndex);
        }
    }

    public void SetCube_From_Store()
    {
        selectedCubeIndex = PlayerPrefs.GetInt(customStrings.SELECTED_CUBE_INDEX, 0);

        GetSelectedCubeType();

        if (selectedCubeType == CubeType.common)
        {
            selectedCube = commonCubes[selectedCubeIndex];
            selectedCube.transform.SetParent(player);
            selectedCube.SetActive(true);

            playerMovement.playerTrail = player.transform.GetComponentInChildren<TrailRenderer>();
            playerMovement.playerTrail.enabled = false;

            cubeColorManager.SetCubeColor_CommonCube(selectedCubeIndex);

            playerSpawner.GetChildCubeMaterial();
            playerDeath.SetPlayerChildCube(selectedCube);
        }
        else if(selectedCubeType == CubeType.rare)
        {
            selectedCube = rareCubes[selectedCubeIndex];
            selectedCube.transform.SetParent(player);
            selectedCube.SetActive(true);

            playerMovement.playerTrail = player.transform.GetComponentInChildren<TrailRenderer>();
            playerMovement.playerTrail.enabled = false;

            cubeColorManager.SetCubeColor_RareCube(selectedCubeIndex);

            playerSpawner.GetChildCubeMaterial();
            playerDeath.SetPlayerChildCube(selectedCube);
        }
        else if (selectedCubeType == CubeType.legendary)
        {
            selectedCube = legendaryCubes[selectedCubeIndex];
            selectedCube.transform.SetParent(player);
            selectedCube.SetActive(true);

            playerMovement.playerTrail = player.transform.GetComponentInChildren<TrailRenderer>();
            playerMovement.playerTrail.enabled = false;

            cubeColorManager.SetCubeColor_LegendaryCube(selectedCubeIndex);

            playerSpawner.GetChildCubeMaterial();
            playerDeath.SetPlayerChildCube(selectedCube);
        }
        else if (selectedCubeType == CubeType.mission_cube)
        {
            selectedCube = missionCubes[selectedCubeIndex];
            selectedCube.transform.SetParent(player);
            selectedCube.SetActive(true);

            playerMovement.playerTrail = player.transform.GetComponentInChildren<TrailRenderer>();
            playerMovement.playerTrail.enabled = false;

            cubeColorManager.SetCubeColor_MissionCube(selectedCubeIndex);

            playerSpawner.GetChildCubeMaterial();
            playerDeath.SetPlayerChildCube(selectedCube);
        }
    }

    public void ResetExistingCube()
    {
        if(selectedCubeType == CubeType.common)
        {
            if (player.GetChild(1))
            {
                player.GetChild(1).gameObject.SetActive(false);
                player.GetChild(1).transform.SetParent(commonCubeParent);
            }
        }
        else if (selectedCubeType == CubeType.rare)
        {
            if (player.GetChild(1))
            {
                player.GetChild(1).gameObject.SetActive(false);
                player.GetChild(1).transform.SetParent(rareCubeParent);
            }
        }
        else if (selectedCubeType == CubeType.legendary)
        {
            if (player.GetChild(1))
            {
                player.GetChild(1).gameObject.SetActive(false);
                player.GetChild(1).transform.SetParent(legendaryCubeParent);
            }
        }
        else if (selectedCubeType == CubeType.mission_cube)
        {
            if (player.GetChild(1))
            {
                player.GetChild(1).gameObject.SetActive(false);
                player.GetChild(1).transform.SetParent(missionCubeParent);
            }
        }
    }

    public void GetOwnedCommonCubes()
    {
        if (PlayerPrefs.GetInt(customStrings.COMMON_CUBE0, 1) == 1)
        {
            if (!ownedCubes_commonIndex.Contains(0))
            {
                ownedCubes_commonIndex.Add(0);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.COMMON_CUBE1, 0) == 1)
        {
            if (!ownedCubes_commonIndex.Contains(1))
            {
                ownedCubes_commonIndex.Add(1);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.COMMON_CUBE2, 0) == 1)
        {
            if (!ownedCubes_commonIndex.Contains(2))
            {
                ownedCubes_commonIndex.Add(2);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.COMMON_CUBE3, 0) == 1)
        {
            if (!ownedCubes_commonIndex.Contains(3))
            {
                ownedCubes_commonIndex.Add(3);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.COMMON_CUBE4, 0) == 1)
        {
            if (!ownedCubes_commonIndex.Contains(4))
            {
                ownedCubes_commonIndex.Add(4);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.COMMON_CUBE5, 0) == 1)
        {
            if (!ownedCubes_commonIndex.Contains(5))
            {
                ownedCubes_commonIndex.Add(5);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.COMMON_CUBE6, 0) == 1)
        {
            if (!ownedCubes_commonIndex.Contains(6))
            {
                ownedCubes_commonIndex.Add(6);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.COMMON_CUBE7, 0) == 1)
        {
            if (!ownedCubes_commonIndex.Contains(7))
            {
                ownedCubes_commonIndex.Add(7);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.COMMON_CUBE8, 0) == 1)
        {
            if (!ownedCubes_commonIndex.Contains(8))
            {
                ownedCubes_commonIndex.Add(8);
            }
        }
    }

    public void GetOwnedRareCubes()
    {
        if (PlayerPrefs.GetInt(customStrings.RARE_CUBE0, 0) == 1)
        {
            if (!ownedCubes_rareIndex.Contains(0))
            {
                ownedCubes_rareIndex.Add(0);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.RARE_CUBE1, 0) == 1)
        {
            if (!ownedCubes_rareIndex.Contains(1))
            {
                ownedCubes_rareIndex.Add(1);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.RARE_CUBE2, 0) == 1)
        {
            if (!ownedCubes_rareIndex.Contains(2))
            {
                ownedCubes_rareIndex.Add(2);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.RARE_CUBE3, 0) == 1)
        {
            if (!ownedCubes_rareIndex.Contains(3))
            {
                ownedCubes_rareIndex.Add(3);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.RARE_CUBE4, 0) == 1)
        {
            if (!ownedCubes_rareIndex.Contains(4))
            {
                ownedCubes_rareIndex.Add(4);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.RARE_CUBE5, 0) == 1)
        {
            if (!ownedCubes_rareIndex.Contains(5))
            {
                ownedCubes_rareIndex.Add(5);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.RARE_CUBE6, 0) == 1)
        {
            if (!ownedCubes_rareIndex.Contains(6))
            {
                ownedCubes_rareIndex.Add(6);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.RARE_CUBE7, 0) == 1)
        {
            if (!ownedCubes_rareIndex.Contains(7))
            {
                ownedCubes_rareIndex.Add(7);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.RARE_CUBE8, 0) == 1)
        {
            if (!ownedCubes_rareIndex.Contains(8))
            {
                ownedCubes_rareIndex.Add(8);
            }
        }
    }

    public void GetOwnedLegendaryCubes()
    {
        if (PlayerPrefs.GetInt(customStrings.LEGENDARY_CUBE0, 0) == 1)
        {
            if (!ownedCubes_legendaryIndex.Contains(0))
            {
                ownedCubes_legendaryIndex.Add(0);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.LEGENDARY_CUBE1, 0) == 1)
        {
            if (!ownedCubes_legendaryIndex.Contains(1))
            {
                ownedCubes_legendaryIndex.Add(1);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.LEGENDARY_CUBE2, 0) == 1)
        {
            if (!ownedCubes_legendaryIndex.Contains(2))
            {
                ownedCubes_legendaryIndex.Add(2);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.LEGENDARY_CUBE3, 0) == 1)
        {
            if (!ownedCubes_legendaryIndex.Contains(3))
            {
                ownedCubes_legendaryIndex.Add(3);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.LEGENDARY_CUBE4, 0) == 1)
        {
            if (!ownedCubes_legendaryIndex.Contains(4))
            {
                ownedCubes_legendaryIndex.Add(4);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.LEGENDARY_CUBE5, 0) == 1)
        {
            if (!ownedCubes_legendaryIndex.Contains(5))
            {
                ownedCubes_legendaryIndex.Add(5);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.LEGENDARY_CUBE6, 0) == 1)
        {
            if (!ownedCubes_legendaryIndex.Contains(6))
            {
                ownedCubes_legendaryIndex.Add(6);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.LEGENDARY_CUBE7, 0) == 1)
        {
            if (!ownedCubes_legendaryIndex.Contains(7))
            {
                ownedCubes_legendaryIndex.Add(7);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.LEGENDARY_CUBE8, 0) == 1)
        {
            if (!ownedCubes_legendaryIndex.Contains(8))
            {
                ownedCubes_legendaryIndex.Add(8);
            }
        }
    }

    public void GetOwnedMissionCubes()
    {
        if (PlayerPrefs.GetInt(customStrings.MISSION_CUBE0, 0) == 1)
        {
            if (!ownedCubes_missionIndex.Contains(0))
            {
                ownedCubes_missionIndex.Add(0);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.MISSION_CUBE1, 0) == 1)
        {
            if (!ownedCubes_missionIndex.Contains(1))
            {
                ownedCubes_missionIndex.Add(1);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.MISSION_CUBE2, 0) == 1)
        {
            if (!ownedCubes_missionIndex.Contains(2))
            {
                ownedCubes_missionIndex.Add(2);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.MISSION_CUBE3, 0) == 1)
        {
            if (!ownedCubes_missionIndex.Contains(3))
            {
                ownedCubes_missionIndex.Add(3);
            }
        }
        if (PlayerPrefs.GetInt(customStrings.MISSION_CUBE4, 0) == 1)
        {
            if (!ownedCubes_missionIndex.Contains(4))
            {
                ownedCubes_missionIndex.Add(4);
            }
        }
    }

    public void GetSelectedCubeType()
    {
        selectedCubeType_index = PlayerPrefs.GetInt(customStrings.SELECTED_CUBE_TYPE, 0);

        switch (selectedCubeType_index)
        {
            case 0:
                selectedCubeType = CubeType.common;
                break;

            case 1:
                selectedCubeType = CubeType.rare;
                break;

            case 2:
                selectedCubeType = CubeType.legendary;
                break;

            case 3:
                selectedCubeType = CubeType.mission_cube;
                break;

            default:
                selectedCubeType = CubeType.common;
                break;
        }
    }
    
    public void SetSelectedCubeType(CubeType cubeType)
    {
        switch (cubeType)
        {
            case CubeType.common: PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_TYPE, 0);
                break;

            case CubeType.rare:
                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_TYPE, 1);
                break;

            case CubeType.legendary:
                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_TYPE, 2);
                break;

            case CubeType.mission_cube:
                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_TYPE, 3);
                break;
        }
    }
}
