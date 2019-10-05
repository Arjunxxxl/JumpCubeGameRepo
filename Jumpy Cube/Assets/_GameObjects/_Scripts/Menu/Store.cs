using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    [Header("Diamond data")]
    public TMP_Text ownedDiamondTxt;
    public int ownedDiamonds;

    [Header("Cubes Cost")]
    int commonCubeCost = 5;
    int rareCubeCost = 10;
    int legendaryCubeCost = 20;

    [Header("Button color data")]
    public Color colorLocked;
    public Color colorLockedShine;
    public Color colorUnlocked;
    public Color colorUnlockedShine;
    public Color colorSelected;
    public Color colorSelectedShine;

    [Header("Common cubes data")]
    public int totalCommonCubes;
    public Image[] commonCubesButton;
    public Image[] commonCubeShine;
    public TMP_Text[] commonCubeText;
    public GameObject[] commonCubeInfo;

    [Header("'Rare cubes data")]
    public int totalRareCubes;
    public Image[] rareCubesButton;
    public Image[] rareCubeShine;
    public TMP_Text[] rareCubeText;
    public GameObject[] rareCubeInfo;

    [Space]
    public CubeBoughtManager cubeBoughtManager;
    public DiamondScore diamondScore;
    public CustomStrings customStrings;

    CubeBoughtManager.CubeType previousType;


    private void Awake()
    {
        ownedDiamonds = diamondScore.GetDiamonds();
        ownedDiamondTxt.text = ownedDiamonds + "";

        totalCommonCubes = cubeBoughtManager.totalCommonCubes;
        totalRareCubes = cubeBoughtManager.totalRareCubes;
    }


    public void SetStoreButton(bool _override = false)
    {
        SetCommonCubeButton(_override);
        SetRareCubeButton(_override);
    }

    public void SetCommonCubeButton(bool _overrivde = false)
    {
        if (!_overrivde)
        {
            if (cubeBoughtManager.selectedCubeType != CubeBoughtManager.CubeType.common && previousType != CubeBoughtManager.CubeType.common)
            {
                return;
            }
        }

        for (int i = 0; i < totalCommonCubes; i++)
        {
            if (cubeBoughtManager.ownedCubes_commonIndex.Contains(i))
            {
                if (cubeBoughtManager.selectedCubeIndex == i)
                {
                    if (cubeBoughtManager.selectedCubeType == CubeBoughtManager.CubeType.common)
                    {
                        commonCubesButton[i].color = colorSelected;
                        commonCubeShine[i].color = colorSelectedShine;

                        commonCubeText[i].text = customStrings.CUBE_SELECTED;
                    }
                    else
                    {
                        commonCubesButton[i].color = colorUnlocked;
                        commonCubeShine[i].color = colorUnlockedShine;

                        commonCubeText[i].text = customStrings.CUBE_UNLOCKED;
                    }
                }
                else
                {
                    commonCubesButton[i].color = colorUnlocked;
                    commonCubeShine[i].color = colorUnlockedShine;

                    commonCubeText[i].text = customStrings.CUBE_UNLOCKED;
                }
                
                commonCubeInfo[i].SetActive(false);
            }
            else
            {
                commonCubesButton[i].color = colorLocked;
                commonCubeShine[i].color = colorLockedShine;

                commonCubeText[i].text = customStrings.CUBE_LOCKED;
                
                commonCubeInfo[i].SetActive(true);
            }
        }
    }

    public void SetRareCubeButton(bool _override = false)
    {
        Debug.Log("Here1");
        if (!_override)
        {
            if (cubeBoughtManager.selectedCubeType != CubeBoughtManager.CubeType.rare && previousType != CubeBoughtManager.CubeType.rare)
            {
                return;
            }
            Debug.Log("Here2");
        }

        for (int i = 0; i < totalRareCubes; i++)
        {
            Debug.Log("Here 3 " + i);
            if (cubeBoughtManager.ownedCubes_rareIndex.Contains(i))
            {
                if (cubeBoughtManager.selectedCubeIndex == i)
                {
                    Debug.Log("Here4 " + i);
                    if (cubeBoughtManager.selectedCubeType == CubeBoughtManager.CubeType.rare)
                    {
                        Debug.Log("Here5");
                        rareCubesButton[i].color = colorSelected;
                        rareCubeShine[i].color = colorSelectedShine;

                        rareCubeText[i].text = customStrings.CUBE_SELECTED;
                    }
                    else
                    {
                        Debug.Log("Here6 " + i);
                        rareCubesButton[i].color = colorUnlocked;
                        rareCubeShine[i].color = colorUnlockedShine;

                        rareCubeText[i].text = customStrings.CUBE_UNLOCKED;
                    }
                }
                else
                {
                    Debug.Log("Here 7 " + i);
                    rareCubesButton[i].color = colorUnlocked;
                    rareCubeShine[i].color = colorUnlockedShine;

                    rareCubeText[i].text = customStrings.CUBE_UNLOCKED;
                }

                rareCubeInfo[i].SetActive(false);
            }
            else
            {
                Debug.Log("Here 8 " + i);
                rareCubesButton[i].color = colorLocked;
                rareCubeShine[i].color = colorLockedShine;

                rareCubeText[i].text = customStrings.CUBE_LOCKED;

                rareCubeInfo[i].SetActive(true);
            }
        }
    }

    void SpendDiamondsToBuyCube(int amt)
    {
        diamondScore.CubeBought(amt);

        ownedDiamonds = diamondScore.GetDiamonds();
        ownedDiamondTxt.text = ownedDiamonds + "";
    }

    ///*   FUNCTIONS FOR STORE BUTTON - COMMON CUBES   *///
    public void CommonCubeType0()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(0))
        {
            if (cubeBoughtManager.selectedCubeIndex != 0 || previousType != CubeBoughtManager.CubeType.common)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 0);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);
                
                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                SpendDiamondsToBuyCube(commonCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE0, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 0);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void CommonCubeType1()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(1))
        {
            if (cubeBoughtManager.selectedCubeIndex != 1 || previousType != CubeBoughtManager.CubeType.common)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 1);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                cubeBoughtManager.ResetExistingCube();

                SpendDiamondsToBuyCube(commonCubeCost);

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE1, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 1);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void CommonCubeType2()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(2))
        {
            if (cubeBoughtManager.selectedCubeIndex != 2 || previousType != CubeBoughtManager.CubeType.common)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 2);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                cubeBoughtManager.ResetExistingCube();

                SpendDiamondsToBuyCube(commonCubeCost);

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE2, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 2);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void CommonCubeType3()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(3))
        {
            if (cubeBoughtManager.selectedCubeIndex != 3 || previousType != CubeBoughtManager.CubeType.common)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 3);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                cubeBoughtManager.ResetExistingCube();

                SpendDiamondsToBuyCube(commonCubeCost);

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE3, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 3);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void CommonCubeType4()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(4))
        {
            if (cubeBoughtManager.selectedCubeIndex != 4 || previousType != CubeBoughtManager.CubeType.common)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 4);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                cubeBoughtManager.ResetExistingCube();

                SpendDiamondsToBuyCube(commonCubeCost);

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE4, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 4);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void CommonCubeType5()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(5))
        {
            if (cubeBoughtManager.selectedCubeIndex != 5 || previousType != CubeBoughtManager.CubeType.common)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 5);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                cubeBoughtManager.ResetExistingCube();

                SpendDiamondsToBuyCube(commonCubeCost);

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE5, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 5);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void CommonCubeType6()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(6))
        {
            if (cubeBoughtManager.selectedCubeIndex != 6 || previousType != CubeBoughtManager.CubeType.common)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 6);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                cubeBoughtManager.ResetExistingCube();

                SpendDiamondsToBuyCube(commonCubeCost);

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE6, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 6);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void CommonCubeType7()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(7))
        {
            if (cubeBoughtManager.selectedCubeIndex != 7 || previousType != CubeBoughtManager.CubeType.common)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 7);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                cubeBoughtManager.ResetExistingCube();

                SpendDiamondsToBuyCube(commonCubeCost);

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE7, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 7);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void CommonCubeType8()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(8))
        {
            if (cubeBoughtManager.selectedCubeIndex != 8 || previousType != CubeBoughtManager.CubeType.common)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 8);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                cubeBoughtManager.ResetExistingCube();

                SpendDiamondsToBuyCube(commonCubeCost);

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE8, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 8);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }


    ///*   FUNCTIONS FOR STORE BUTTON - RARE CUBES   *///
    public void RareCubeType0()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_rareIndex.Contains(0))
        {
            if (cubeBoughtManager.selectedCubeIndex != 0 || previousType != CubeBoughtManager.CubeType.rare)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 0);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > rareCubeCost)
            {
                SpendDiamondsToBuyCube(rareCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.RARE_CUBE0, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 0);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.GetOwnedRareCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void RareCubeType1()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_rareIndex.Contains(1))
        {
            if (cubeBoughtManager.selectedCubeIndex != 1 || previousType != CubeBoughtManager.CubeType.rare)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 1);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > rareCubeCost)
            {
                SpendDiamondsToBuyCube(rareCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.RARE_CUBE1, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 1);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.GetOwnedRareCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void RareCubeType2()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_rareIndex.Contains(2))
        {
            if (cubeBoughtManager.selectedCubeIndex != 2 || previousType != CubeBoughtManager.CubeType.rare)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 2);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > rareCubeCost)
            {
                SpendDiamondsToBuyCube(rareCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.RARE_CUBE2, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 2);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.GetOwnedRareCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void RareCubeType3()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_rareIndex.Contains(3))
        {
            if (cubeBoughtManager.selectedCubeIndex != 3 || previousType != CubeBoughtManager.CubeType.rare)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 3);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > rareCubeCost)
            {
                SpendDiamondsToBuyCube(rareCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.RARE_CUBE3, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 3);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.GetOwnedRareCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void RareCubeType4()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_rareIndex.Contains(4))
        {
            if (cubeBoughtManager.selectedCubeIndex != 4 || previousType != CubeBoughtManager.CubeType.rare)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 4);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > rareCubeCost)
            {
                SpendDiamondsToBuyCube(rareCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.RARE_CUBE4, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 4);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.GetOwnedRareCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void RareCubeType5()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_rareIndex.Contains(5))
        {
            if (cubeBoughtManager.selectedCubeIndex != 5 || previousType != CubeBoughtManager.CubeType.rare)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 5);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > rareCubeCost)
            {
                SpendDiamondsToBuyCube(rareCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.RARE_CUBE5, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 5);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.GetOwnedRareCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void RareCubeType6()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_rareIndex.Contains(6))
        {
            if (cubeBoughtManager.selectedCubeIndex != 6 || previousType != CubeBoughtManager.CubeType.rare)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 6);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > rareCubeCost)
            {
                SpendDiamondsToBuyCube(rareCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.RARE_CUBE6, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 6
);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.GetOwnedRareCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void RareCubeType7()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_rareIndex.Contains(7))
        {
            if (cubeBoughtManager.selectedCubeIndex != 7 || previousType != CubeBoughtManager.CubeType.rare)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 7);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > rareCubeCost)
            {
                SpendDiamondsToBuyCube(rareCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.RARE_CUBE7, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 7);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.GetOwnedRareCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void RareCubeType8()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_rareIndex.Contains(8))
        {
            if (cubeBoughtManager.selectedCubeIndex != 8 || previousType != CubeBoughtManager.CubeType.rare)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 8);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds > rareCubeCost)
            {
                SpendDiamondsToBuyCube(rareCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.RARE_CUBE8, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 8);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.rare);

                cubeBoughtManager.GetOwnedRareCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

}
