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
    int rareCubeCase = 10;
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
    
    [Space]
    public CubeBoughtManager cubeBoughtManager;
    public DiamondScore diamondScore;
    public CustomStrings customStrings;


    private void Awake()
    {
        ownedDiamonds = diamondScore.GetDiamonds();
        ownedDiamondTxt.text = ownedDiamonds + "";

        totalCommonCubes = cubeBoughtManager.totalCommonCubes;
    }


    public void SetCommonCubeButton()
    {
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

    void SpendDiamondsToBuyCube(int amt)
    {
        diamondScore.CubeBought(amt);

        ownedDiamonds = diamondScore.GetDiamonds();
        ownedDiamondTxt.text = ownedDiamonds + "";
    }

    ///*   FUNCTIONS FOR STORE BUTTON - COMMON CUBES   *///
    public void CommonCubeType0()
    {
        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(0))
        {
            if (cubeBoughtManager.selectedCubeIndex != 0)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 0);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);
                
                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                SpendDiamondsToBuyCube(commonCubeCost);

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE0, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 0);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
    }

    public void CommonCubeType1()
    {
        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(1))
        {
            if (cubeBoughtManager.selectedCubeIndex != 1)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 1);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                SpendDiamondsToBuyCube(commonCubeCost);

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE1, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 1);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
    }

    public void CommonCubeType2()
    {
        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(2))
        {
            if (cubeBoughtManager.selectedCubeIndex != 2)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 2);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                SpendDiamondsToBuyCube(commonCubeCost);

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE2, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 2);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
    }

    public void CommonCubeType3()
    {
        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(3))
        {
            if (cubeBoughtManager.selectedCubeIndex != 3)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 3);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                SpendDiamondsToBuyCube(commonCubeCost);

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE3, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 3);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
    }

    public void CommonCubeType4()
    {
        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(4))
        {
            if (cubeBoughtManager.selectedCubeIndex != 4)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 4);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                SpendDiamondsToBuyCube(commonCubeCost);

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE4, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 4);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
    }

    public void CommonCubeType5()
    {
        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(5))
        {
            if (cubeBoughtManager.selectedCubeIndex != 5)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 5);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                SpendDiamondsToBuyCube(commonCubeCost);

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE5, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 5);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
    }

    public void CommonCubeType6()
    {
        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(6))
        {
            if (cubeBoughtManager.selectedCubeIndex != 6)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 6);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                SpendDiamondsToBuyCube(commonCubeCost);

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE6, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 6);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
    }

    public void CommonCubeType7()
    {
        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(7))
        {
            if (cubeBoughtManager.selectedCubeIndex != 7)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 7);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                SpendDiamondsToBuyCube(commonCubeCost);

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE7, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 7);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
    }

    public void CommonCubeType8()
    {
        if (cubeBoughtManager.ownedCubes_commonIndex.Contains(8))
        {
            if (cubeBoughtManager.selectedCubeIndex != 8)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 8);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
        else
        {
            if (ownedDiamonds > commonCubeCost)
            {
                SpendDiamondsToBuyCube(commonCubeCost);

                PlayerPrefs.SetInt(customStrings.COMMON_CUBE8, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 8);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.common);

                cubeBoughtManager.GetOwnedCommonCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetCommonCubeButton();
            }
        }
    }

}
