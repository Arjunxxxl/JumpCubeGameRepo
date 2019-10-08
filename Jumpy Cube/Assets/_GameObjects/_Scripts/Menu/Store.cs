using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    [Header("Diamond data")]
    public TMP_Text ownedDiamondTxt;
    public int ownedDiamonds;
    public int inGameCollectedDiamonds;

    [Header("Cubes and color scheme Cost")]
    int colorSchemeCost = 1;
    int commonCubeCost = 5;
    int rareCubeCost = 10;
    int legendaryCubeCost = 20;
    int missionCubeCost = 30;

    [Header("Button color data")]
    public Color colorLocked;
    public Color colorLockedShine;
    public Color colorUnlocked;
    public Color colorUnlockedShine;
    public Color colorSelected;
    public Color colorSelectedShine;

    [Header("Color Theme Data")]
    public int totalColorScheme;
    public Image[] colorSchemeButton;
    public Image[] colorSchemeShine;
    public TMP_Text[] colorSchemeText;
    public GameObject[] colorSchemeInfo;

    [Header("Common cubes data")]
    public int totalCommonCubes;
    public Image[] commonCubesButton;
    public Image[] commonCubeShine;
    public TMP_Text[] commonCubeText;
    public GameObject[] commonCubeInfo;

    [Header("Rare cubes data")]
    public int totalRareCubes;
    public Image[] rareCubesButton;
    public Image[] rareCubeShine;
    public TMP_Text[] rareCubeText;
    public GameObject[] rareCubeInfo;

    [Header("Legendary cubes data")]
    public int totalLegendaryCubes;
    public Image[] legendaryCubesButton;
    public Image[] legendaryCubeShine;
    public TMP_Text[] legendaryCubeText;
    public GameObject[] legendaryCubeInfo;

    [Header("Mission cubes data")]
    public int totalMissionCubes;
    public Image[] missionCubesButton;
    public Image[] missionCubeShine;
    public TMP_Text[] missionCubeText;
    public GameObject[] missionCubeSkipInfo;
    public GameObject[] missionCubeInfo;
    public TMP_Text[] missionStatus;

    [Space]
    public CubeBoughtManager cubeBoughtManager;
    public DiamondScore diamondScore;
    public CustomStrings customStrings;
    public TileColorThemeBoughtManager tileColorThemeBoughtManager;
    public SelectColorScheme selectColorScheme;
    public MissionManager missionManager;

    int diamondsSpend;

    CubeBoughtManager.CubeType previousType;



    private void Awake()
    {
        ownedDiamonds = diamondScore.GetDiamonds();
        inGameCollectedDiamonds = diamondScore.GetInGameCollectedDiamonds();
        ownedDiamondTxt.text = ownedDiamonds + "";

        totalCommonCubes = cubeBoughtManager.totalCommonCubes;
        totalRareCubes = cubeBoughtManager.totalRareCubes;
        totalLegendaryCubes = cubeBoughtManager.totalLegndaryCubes;
        totalColorScheme = tileColorThemeBoughtManager.totalColorScheme;
        totalMissionCubes = cubeBoughtManager.totalMissionCubes;
    }


    public void SetStoreButton(bool _override = false)
    {
        SetCommonCubeButton(_override);
        SetRareCubeButton(_override);
        SetLegendaryCubeButton(_override);
        SetColorSchemeButton(_override);
        SetMissionCubeButton(_override);
        SetMissionDescription(_override);
    }

    public void SetColorSchemeButton(bool _override = false)
    {
        if (!_override)
        {
            return;
        }

        for (int i = 0; i < totalColorScheme; i++)
        {
            if (tileColorThemeBoughtManager.colorSchemeUnlocked.Contains(i))
            {
                if (tileColorThemeBoughtManager.selectedColorScheme == i)
                {
                    colorSchemeButton[i].color = colorSelected;
                    colorSchemeShine[i].color = colorSelectedShine;

                    colorSchemeText[i].text = customStrings.CUBE_SELECTED;
                }
                else
                {
                    colorSchemeButton[i].color = colorUnlocked;
                    colorSchemeShine[i].color = colorUnlockedShine;

                    colorSchemeText[i].text = customStrings.CUBE_UNLOCKED;
                }

                colorSchemeInfo[i].SetActive(false);
            }
            else
            {
                colorSchemeButton[i].color = colorLocked;
                colorSchemeShine[i].color = colorLockedShine;

                colorSchemeText[i].text = customStrings.CUBE_LOCKED;

                colorSchemeInfo[i].SetActive(true);
            }
        }
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
        if (!_override)
        {
            if (cubeBoughtManager.selectedCubeType != CubeBoughtManager.CubeType.rare && previousType != CubeBoughtManager.CubeType.rare)
            {
                return;
            }
        }

        for (int i = 0; i < totalRareCubes; i++)
        {
            if (cubeBoughtManager.ownedCubes_rareIndex.Contains(i))
            {
                if (cubeBoughtManager.selectedCubeIndex == i)
                {
                    if (cubeBoughtManager.selectedCubeType == CubeBoughtManager.CubeType.rare)
                    {
                        rareCubesButton[i].color = colorSelected;
                        rareCubeShine[i].color = colorSelectedShine;

                        rareCubeText[i].text = customStrings.CUBE_SELECTED;
                    }
                    else
                    {
                        rareCubesButton[i].color = colorUnlocked;
                        rareCubeShine[i].color = colorUnlockedShine;

                        rareCubeText[i].text = customStrings.CUBE_UNLOCKED;
                    }
                }
                else
                {
                    rareCubesButton[i].color = colorUnlocked;
                    rareCubeShine[i].color = colorUnlockedShine;

                    rareCubeText[i].text = customStrings.CUBE_UNLOCKED;
                }

                rareCubeInfo[i].SetActive(false);
            }
            else
            {
                rareCubesButton[i].color = colorLocked;
                rareCubeShine[i].color = colorLockedShine;

                rareCubeText[i].text = customStrings.CUBE_LOCKED;

                rareCubeInfo[i].SetActive(true);
            }
        }
    }

    public void SetLegendaryCubeButton(bool _override = false)
    {
        if (!_override)
        {
            if (cubeBoughtManager.selectedCubeType != CubeBoughtManager.CubeType.legendary && previousType != CubeBoughtManager.CubeType.legendary)
            {
                return;
            }
        }

        for (int i = 0; i < totalLegendaryCubes; i++)
        {
            if (cubeBoughtManager.ownedCubes_legendaryIndex.Contains(i))
            {
                if (cubeBoughtManager.selectedCubeIndex == i)
                {
                    if (cubeBoughtManager.selectedCubeType == CubeBoughtManager.CubeType.legendary)
                    {
                        legendaryCubesButton[i].color = colorSelected;
                        legendaryCubeShine[i].color = colorSelectedShine;

                        legendaryCubeText[i].text = customStrings.CUBE_SELECTED;
                    }
                    else
                    {
                        legendaryCubesButton[i].color = colorUnlocked;
                        legendaryCubeShine[i].color = colorUnlockedShine;

                        legendaryCubeText[i].text = customStrings.CUBE_UNLOCKED;
                    }
                }
                else
                {
                    legendaryCubesButton[i].color = colorUnlocked;
                    legendaryCubeShine[i].color = colorUnlockedShine;

                    legendaryCubeText[i].text = customStrings.CUBE_UNLOCKED;
                }

                legendaryCubeInfo[i].SetActive(false);
            }
            else
            {
                legendaryCubesButton[i].color = colorLocked;
                legendaryCubeShine[i].color = colorLockedShine;

                legendaryCubeText[i].text = customStrings.CUBE_LOCKED;

                legendaryCubeInfo[i].SetActive(true);
            }
        }
    }

    public void SetMissionCubeButton(bool _override = false)
    {
        if (!_override)
        {
            if (cubeBoughtManager.selectedCubeType != CubeBoughtManager.CubeType.mission_cube && previousType != CubeBoughtManager.CubeType.mission_cube)
            {
                return;
            }
        }

        for (int i = 0; i < totalMissionCubes; i++)
        {
            if (cubeBoughtManager.ownedCubes_missionIndex.Contains(i))
            {
                if (cubeBoughtManager.selectedCubeIndex == i)
                {
                    if (cubeBoughtManager.selectedCubeType == CubeBoughtManager.CubeType.mission_cube)
                    {
                        missionCubesButton[i].color = colorSelected;
                        missionCubeShine[i].color = colorSelectedShine;

                        missionCubeText[i].text = customStrings.CUBE_SELECTED;
                    }
                    else
                    {
                        missionCubesButton[i].color = colorUnlocked;
                        missionCubeShine[i].color = colorUnlockedShine;

                        missionCubeText[i].text = customStrings.CUBE_UNLOCKED;
                    }
                }
                else
                {
                    missionCubesButton[i].color = colorUnlocked;
                    missionCubeShine[i].color = colorUnlockedShine;

                    missionCubeText[i].text = customStrings.CUBE_UNLOCKED;
                }

                missionCubeInfo[i].SetActive(false);
                missionCubeSkipInfo[i].SetActive(false);
            }
            else
            {
                missionCubesButton[i].color = colorLocked;
                missionCubeShine[i].color = colorLockedShine;

                missionCubeText[i].text = customStrings.MISSION_NOTDONE;

                missionCubeInfo[i].SetActive(true);
                missionCubeSkipInfo[i].SetActive(true);
            }
        }
    }

    public void SetMissionDescription(bool _override = false)
    {
        if (!_override)
        {
            return;
        }
        
        for (int i = 0; i < totalMissionCubes; i++)
        {
            if (!cubeBoughtManager.ownedCubes_missionIndex.Contains(i))
            {
                switch(i)
                {
                    case 0:
                        missionStatus[i].text = "Collect " + inGameCollectedDiamonds + "/" + 200;
                        break;

                    case 1:
                        missionStatus[i].text = "Reach 60 Points";
                        break;

                    case 2:
                        missionStatus[i].text = "Play game " + PlayerPrefs.GetInt(customStrings.TIMES_GAME_PLAYED, 0) + "/" + 2; 
                        break;

                    case 3:
                        missionStatus[i].text = "Share Score " + PlayerPrefs.GetInt(customStrings.TIMES_SCORE_SHARED, 0) + "/" + 1;
                        break;

                    case 4:
                        missionStatus[i].text = "Spend " + PlayerPrefs.GetInt(customStrings.TOTAL_DIAMONDS_SPEND, 0) + "/" + 200;
                        break;

                    case 5:
                        missionStatus[i].text = "Jump " + PlayerPrefs.GetInt(customStrings.TIMES_PLAYER_JUMPED, 0) + "/" + 10;
                        break;
                }
            }
        }
    }

    void SpendDiamondsToBuyCube(int amt)
    {
        diamondScore.CubeBought(amt);

        ownedDiamonds = diamondScore.GetDiamonds();
        ownedDiamondTxt.text = ownedDiamonds + "";

        diamondsSpend = PlayerPrefs.GetInt(customStrings.TOTAL_DIAMONDS_SPEND, 0);
        diamondsSpend += amt;

        PlayerPrefs.SetInt(customStrings.TOTAL_DIAMONDS_SPEND, diamondsSpend);
        //CODE TO UPDATE THE DIAMOND SPEND PLAYER PREF BEFORE THIS LINE
        missionManager.CheckingForDiamondSpendMission(diamondsSpend);

        cubeBoughtManager.GetOwnedMissionCubes();
        SetMissionCubeButton(true);
    }

    ///*   FUNCTION FOR STORE BUTTON - COLOR SCHEME   *///
    public void ColorScheme0()
    {
        if (tileColorThemeBoughtManager.colorSchemeUnlocked.Contains(0))
        {
            if (tileColorThemeBoughtManager.selectedColorScheme != 0)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 0);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();

                SetColorSchemeButton(true);
            }
        }
        else
        {
            if (ownedDiamonds >= colorSchemeCost)
            {
                SpendDiamondsToBuyCube(colorSchemeCost);

                tileColorThemeBoughtManager.BuyColorScheme(TileColorThemeBoughtManager.ColorScheme.cs_d1);

                tileColorThemeBoughtManager.GetUnlockedColorScheme();

                tileColorThemeBoughtManager.GetColorSchemeUnlockState();

                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 0);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();

                SetColorSchemeButton(true);
            }
        }
    }

    public void ColorScheme1()
    {
        if (tileColorThemeBoughtManager.colorSchemeUnlocked.Contains(1))
        {
            if (tileColorThemeBoughtManager.selectedColorScheme != 1)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 1);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();
                
                SetColorSchemeButton(true);
            }
        }
        else
        {
            if (ownedDiamonds >= colorSchemeCost)
            {
                SpendDiamondsToBuyCube(colorSchemeCost);

                tileColorThemeBoughtManager.BuyColorScheme(TileColorThemeBoughtManager.ColorScheme.cs_1);

                tileColorThemeBoughtManager.GetUnlockedColorScheme();

                tileColorThemeBoughtManager.GetColorSchemeUnlockState();

                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 1);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();
                
                SetColorSchemeButton(true);
            }
        }
    }

    public void ColorScheme2()
    {
        if (tileColorThemeBoughtManager.colorSchemeUnlocked.Contains(2))
        {
            if (tileColorThemeBoughtManager.selectedColorScheme != 2)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 2);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();

                SetColorSchemeButton(true);
            }
        }
        else
        {
            if (ownedDiamonds >= colorSchemeCost)
            {
                SpendDiamondsToBuyCube(colorSchemeCost);

                tileColorThemeBoughtManager.BuyColorScheme(TileColorThemeBoughtManager.ColorScheme.cs_2);

                tileColorThemeBoughtManager.GetUnlockedColorScheme();

                tileColorThemeBoughtManager.GetColorSchemeUnlockState();

                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 2);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();

                SetColorSchemeButton(true);
            }
        }
    }

    public void ColorScheme3()
    {
        if (tileColorThemeBoughtManager.colorSchemeUnlocked.Contains(3))
        {
            if (tileColorThemeBoughtManager.selectedColorScheme != 3)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 3);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();

                SetColorSchemeButton(true);
            }
        }
        else
        {
            if (ownedDiamonds >= colorSchemeCost)
            {
                SpendDiamondsToBuyCube(colorSchemeCost);

                tileColorThemeBoughtManager.BuyColorScheme(TileColorThemeBoughtManager.ColorScheme.cs_3);

                tileColorThemeBoughtManager.GetUnlockedColorScheme();

                tileColorThemeBoughtManager.GetColorSchemeUnlockState();

                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 3);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();

                SetColorSchemeButton(true);
            }
        }
    }

    public void ColorScheme4()
    {
        if (tileColorThemeBoughtManager.colorSchemeUnlocked.Contains(4))
        {
            if (tileColorThemeBoughtManager.selectedColorScheme != 4)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 4);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();

                SetColorSchemeButton(true);
            }
        }
        else
        {
            if (ownedDiamonds >= colorSchemeCost)
            {
                SpendDiamondsToBuyCube(colorSchemeCost);

                tileColorThemeBoughtManager.BuyColorScheme(TileColorThemeBoughtManager.ColorScheme.cs_4);

                tileColorThemeBoughtManager.GetUnlockedColorScheme();

                tileColorThemeBoughtManager.GetColorSchemeUnlockState();

                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 4);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();

                SetColorSchemeButton(true);
            }
        }
    }

    public void ColorScheme5()
    {
        if (tileColorThemeBoughtManager.colorSchemeUnlocked.Contains(5))
        {
            if (tileColorThemeBoughtManager.selectedColorScheme != 5)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 5);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();

                SetColorSchemeButton(true);
            }
        }
        else
        {
            if (ownedDiamonds >= colorSchemeCost)
            {
                SpendDiamondsToBuyCube(colorSchemeCost);

                tileColorThemeBoughtManager.BuyColorScheme(TileColorThemeBoughtManager.ColorScheme.cs_5);

                tileColorThemeBoughtManager.GetUnlockedColorScheme();

                tileColorThemeBoughtManager.GetColorSchemeUnlockState();

                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 5);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();

                SetColorSchemeButton(true);
            }
        }
    }

    public void ColorScheme6()
    {
        if (tileColorThemeBoughtManager.colorSchemeUnlocked.Contains(6))
        {
            if (tileColorThemeBoughtManager.selectedColorScheme != 6)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 6);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();

                SetColorSchemeButton(true);
            }
        }
        else
        {
            if (ownedDiamonds >= colorSchemeCost)
            {
                SpendDiamondsToBuyCube(colorSchemeCost);

                tileColorThemeBoughtManager.BuyColorScheme(TileColorThemeBoughtManager.ColorScheme.cs_6);

                tileColorThemeBoughtManager.GetUnlockedColorScheme();

                tileColorThemeBoughtManager.GetColorSchemeUnlockState();

                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 6);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();

                SetColorSchemeButton(true);
            }
        }
    }

    public void ColorScheme7()
    {
        if (tileColorThemeBoughtManager.colorSchemeUnlocked.Contains(7))
        {
            if (tileColorThemeBoughtManager.selectedColorScheme != 7)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 7);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();

                SetColorSchemeButton(true);
            }
        }
        else
        {
            if (ownedDiamonds >= colorSchemeCost)
            {
                SpendDiamondsToBuyCube(colorSchemeCost);

                tileColorThemeBoughtManager.BuyColorScheme(TileColorThemeBoughtManager.ColorScheme.cs_7);

                tileColorThemeBoughtManager.GetUnlockedColorScheme();

                tileColorThemeBoughtManager.GetColorSchemeUnlockState();

                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 7);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();

                SetColorSchemeButton(true);
            }
        }
    }

    public void ColorScheme8()
    {
        if (tileColorThemeBoughtManager.colorSchemeUnlocked.Contains(8))
        {
            if (tileColorThemeBoughtManager.selectedColorScheme != 8)
            {
                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 8);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();

                SetColorSchemeButton(true);
            }
        }
        else
        {
            if (ownedDiamonds >= colorSchemeCost)
            {
                SpendDiamondsToBuyCube(colorSchemeCost);

                tileColorThemeBoughtManager.BuyColorScheme(TileColorThemeBoughtManager.ColorScheme.cs_8);

                tileColorThemeBoughtManager.GetUnlockedColorScheme();

                tileColorThemeBoughtManager.GetColorSchemeUnlockState();

                PlayerPrefs.SetInt(customStrings.SELECTED_COLOR_SCHEME, 8);

                tileColorThemeBoughtManager.GetSelectedColorScheme();

                selectColorScheme.GetCuttentColorSchme();

                selectColorScheme.SetColor();

                SetColorSchemeButton(true);
            }
        }
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
            if (ownedDiamonds >= commonCubeCost)
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
            if (ownedDiamonds >= commonCubeCost)
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
            if (ownedDiamonds >= commonCubeCost)
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
            if (ownedDiamonds >= commonCubeCost)
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
            if (ownedDiamonds >= commonCubeCost)
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
            if (ownedDiamonds >= commonCubeCost)
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
            if (ownedDiamonds >= commonCubeCost)
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
            if (ownedDiamonds >= commonCubeCost)
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
            if (ownedDiamonds >= commonCubeCost)
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
            if (ownedDiamonds >= rareCubeCost)
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
            if (ownedDiamonds >= rareCubeCost)
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
            if (ownedDiamonds >= rareCubeCost)
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
            if (ownedDiamonds >= rareCubeCost)
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
            if (ownedDiamonds >= rareCubeCost)
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
            if (ownedDiamonds >= rareCubeCost)
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
            if (ownedDiamonds >= rareCubeCost)
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
            if (ownedDiamonds >= rareCubeCost)
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
            if (ownedDiamonds >= rareCubeCost)
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


    ///*   FUNCTIONS FOR STORE BUTTON - Legendary CUBES   *///
    public void LegendaryCubeType0()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_legendaryIndex.Contains(0))
        {
            if (cubeBoughtManager.selectedCubeIndex != 0 || previousType != CubeBoughtManager.CubeType.legendary)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 0);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds >= legendaryCubeCost)
            {
                SpendDiamondsToBuyCube(legendaryCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.LEGENDARY_CUBE0, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 0);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.GetOwnedLegendaryCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void LegendaryCubeType1()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_legendaryIndex.Contains(1))
        {
            if (cubeBoughtManager.selectedCubeIndex != 1 || previousType != CubeBoughtManager.CubeType.legendary)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 1);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds >= legendaryCubeCost)
            {
                SpendDiamondsToBuyCube(legendaryCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.LEGENDARY_CUBE1, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 1);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.GetOwnedLegendaryCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void LegendaryCubeType2()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_legendaryIndex.Contains(2))
        {
            if (cubeBoughtManager.selectedCubeIndex != 2 || previousType != CubeBoughtManager.CubeType.legendary)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 2);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds >= legendaryCubeCost)
            {
                SpendDiamondsToBuyCube(legendaryCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.LEGENDARY_CUBE2, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 2);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.GetOwnedLegendaryCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void LegendaryCubeType3()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_legendaryIndex.Contains(3))
        {
            if (cubeBoughtManager.selectedCubeIndex != 3 || previousType != CubeBoughtManager.CubeType.legendary)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 3);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds >= legendaryCubeCost)
            {
                SpendDiamondsToBuyCube(legendaryCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.LEGENDARY_CUBE3, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 3);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.GetOwnedLegendaryCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void LegendaryCubeType4()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_legendaryIndex.Contains(4))
        {
            if (cubeBoughtManager.selectedCubeIndex != 4 || previousType != CubeBoughtManager.CubeType.legendary)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 4);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds >= legendaryCubeCost)
            {
                SpendDiamondsToBuyCube(legendaryCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.LEGENDARY_CUBE4, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 4);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.GetOwnedLegendaryCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void LegendaryCubeType5()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_legendaryIndex.Contains(5))
        {
            if (cubeBoughtManager.selectedCubeIndex != 5 || previousType != CubeBoughtManager.CubeType.legendary)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 5);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds >= legendaryCubeCost)
            {
                SpendDiamondsToBuyCube(legendaryCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.LEGENDARY_CUBE5, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 5);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.GetOwnedLegendaryCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void LegendaryCubeType6()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_legendaryIndex.Contains(6))
        {
            if (cubeBoughtManager.selectedCubeIndex != 6 || previousType != CubeBoughtManager.CubeType.legendary)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 6);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds >= legendaryCubeCost)
            {
                SpendDiamondsToBuyCube(legendaryCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.LEGENDARY_CUBE6, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 6);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.GetOwnedLegendaryCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void LegendaryCubeType7()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_legendaryIndex.Contains(7))
        {
            if (cubeBoughtManager.selectedCubeIndex != 7 || previousType != CubeBoughtManager.CubeType.legendary)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 7);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds >= legendaryCubeCost)
            {
                SpendDiamondsToBuyCube(legendaryCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.LEGENDARY_CUBE7, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 7);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.GetOwnedLegendaryCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void LegendaryCubeType8()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_legendaryIndex.Contains(8))
        {
            if (cubeBoughtManager.selectedCubeIndex != 8 || previousType != CubeBoughtManager.CubeType.legendary)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 8);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds >= legendaryCubeCost)
            {
                SpendDiamondsToBuyCube(legendaryCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.LEGENDARY_CUBE8, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 8);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.legendary);

                cubeBoughtManager.GetOwnedLegendaryCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }


    ///** FUNCTIONS FOR STORE BUTTON - MISSION CUBES   *///
    public void MissionCybeType0()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_missionIndex.Contains(0))
        {
            if (cubeBoughtManager.selectedCubeIndex != 0 || previousType != CubeBoughtManager.CubeType.mission_cube)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 0);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.mission_cube);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds >= missionCubeCost)
            {
                SpendDiamondsToBuyCube(missionCubeCost);

                cubeBoughtManager.ResetExistingCube();
                
                PlayerPrefs.SetInt(customStrings.MISSION_CUBE0, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 0);

                missionManager.GetMissionActiveStatus();
                missionManager.SetupMission();

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.mission_cube);

                cubeBoughtManager.GetOwnedMissionCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void MissionCybeType1()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_missionIndex.Contains(1))
        {
            if (cubeBoughtManager.selectedCubeIndex != 1 || previousType != CubeBoughtManager.CubeType.mission_cube)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 1);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.mission_cube);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds >= missionCubeCost)
            {
                SpendDiamondsToBuyCube(missionCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.MISSION_CUBE1, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 1);

                missionManager.GetMissionActiveStatus();
                missionManager.SetupMission();

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.mission_cube);

                cubeBoughtManager.GetOwnedMissionCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void MissionCybeType2()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_missionIndex.Contains(2))
        {
            if (cubeBoughtManager.selectedCubeIndex != 2 || previousType != CubeBoughtManager.CubeType.mission_cube)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 2);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.mission_cube);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds >= missionCubeCost)
            {
                SpendDiamondsToBuyCube(missionCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.MISSION_CUBE2, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 2);

                missionManager.GetMissionActiveStatus();
                missionManager.SetupMission();

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.mission_cube);

                cubeBoughtManager.GetOwnedMissionCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void MissionCybeType3()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_missionIndex.Contains(3))
        {
            if (cubeBoughtManager.selectedCubeIndex != 3 || previousType != CubeBoughtManager.CubeType.mission_cube)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 3);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.mission_cube);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds >= missionCubeCost)
            {
                SpendDiamondsToBuyCube(missionCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.MISSION_CUBE3, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 3);

                missionManager.GetMissionActiveStatus();
                missionManager.SetupMission();

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.mission_cube);

                cubeBoughtManager.GetOwnedMissionCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void MissionCybeType4()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_missionIndex.Contains(4))
        {
            if (cubeBoughtManager.selectedCubeIndex != 4 || previousType != CubeBoughtManager.CubeType.mission_cube)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 4);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.mission_cube);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds >= missionCubeCost)
            {
                SpendDiamondsToBuyCube(missionCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.MISSION_CUBE4, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 4);

                missionManager.GetMissionActiveStatus();
                missionManager.SetupMission();

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.mission_cube);

                cubeBoughtManager.GetOwnedMissionCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }

    public void MissionCybeType5()
    {
        previousType = cubeBoughtManager.selectedCubeType;

        if (cubeBoughtManager.ownedCubes_missionIndex.Contains(5))
        {
            if (cubeBoughtManager.selectedCubeIndex != 5 || previousType != CubeBoughtManager.CubeType.mission_cube)
            {
                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 5);

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.mission_cube);

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
        else
        {
            if (ownedDiamonds >= missionCubeCost)
            {
                SpendDiamondsToBuyCube(missionCubeCost);

                cubeBoughtManager.ResetExistingCube();

                PlayerPrefs.SetInt(customStrings.MISSION_CUBE5, 1);

                PlayerPrefs.SetInt(customStrings.SELECTED_CUBE_INDEX, 5);

                missionManager.GetMissionActiveStatus();
                missionManager.SetupMission();

                cubeBoughtManager.SetSelectedCubeType(CubeBoughtManager.CubeType.mission_cube);

                cubeBoughtManager.GetOwnedMissionCubes();

                cubeBoughtManager.SetCube_From_Store();

                SetStoreButton();
            }
        }
    }
}
