using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBoughtManager : MonoBehaviour
{
    public enum CubeType
    { common, rare, ultraRare, legendary, ancient}

    public Transform player;

    public CubeType selectedCubeType;
    public int selectedCubeIndex;

    
    [Header("Cube bought data")]
    public GameObject selectedCube;
    public List<GameObject> ownedCubes_common;
    public List<GameObject> commonCubes;
    
    public CubeColorManager cubeColorManager;

    private void Awake()
    {
        SetCube();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCube()
    {
        if(selectedCubeType == CubeType.common)
        {
            selectedCube = ownedCubes_common[selectedCubeIndex];
            selectedCube.transform.SetParent(player);
            selectedCube.SetActive(true);

            cubeColorManager.SetCubeColor_CommonCube(selectedCubeIndex);
        }
    }

}
