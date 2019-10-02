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

        GetSelectedCubeType();

        SetCube();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = PlayerMovement.Instance;
        playerDeath = PlayerDeath.Instance;
        playerSpawner = PlayerSpawner.Instance;
        
        store.SetCommonCubeButton();
    }

    // Update is called once per frame
    void Update()
    {

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
    }

    public void SetCube_From_Store()
    {
        selectedCubeIndex = PlayerPrefs.GetInt(customStrings.SELECTED_CUBE_INDEX, 0);

        GetSelectedCubeType();

        if (selectedCubeType == CubeType.common)
        {
            if (player.GetChild(1))
            {
                player.GetChild(1).gameObject.SetActive(false);
                player.GetChild(1).transform.SetParent(commonCubeParent);
            }

            selectedCube = commonCubes[selectedCubeIndex];
            selectedCube.transform.SetParent(player);
            selectedCube.SetActive(true);

            playerMovement.playerTrail = player.transform.GetComponentInChildren<TrailRenderer>();
            playerMovement.playerTrail.enabled = false;

            cubeColorManager.SetCubeColor_CommonCube(selectedCubeIndex);

            playerSpawner.GetChildCubeMaterial();
            playerDeath.SetPlayerChildCube();
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
