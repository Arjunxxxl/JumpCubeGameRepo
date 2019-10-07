using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text diamondsCollected_txt;
    public GameObject inGameMenu;

    [Header("Data")]
    public bool isMenuActivated;

    [Header("Items Data")]
    public int diamondsCollected;
    public int diamondsMultiplier;
    public int diamondValue;
    public int realNumberOfDiamondsCollected;
    

    PlayerSpawner playerSpawner;
    TimelinePlayer timelinePlayer;

    #region SingleTon
    public static InGameMenu Instance;
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
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        playerSpawner = PlayerSpawner.Instance;
        timelinePlayer = TimelinePlayer.Instance;

        inGameMenu.SetActive(false);

        isMenuActivated = false;

        diamondsMultiplier = 1;
        diamondsCollected = 0;
        realNumberOfDiamondsCollected = 0;
        diamondValue = 1;

        diamondsCollected_txt.text = diamondsCollected + "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMenuActivated)
        {
            if (playerSpawner.isDisolveEffectDone)
            {
                inGameMenu.SetActive(true);
                isMenuActivated = true;

                timelinePlayer.PlayIngameMenuActivated();
            }
        }
    }

    public void DiamondCollected()
    {
        diamondsCollected = diamondsCollected + (diamondValue * diamondsMultiplier);
        realNumberOfDiamondsCollected = realNumberOfDiamondsCollected + (diamondValue * diamondsMultiplier);

        diamondsCollected_txt.text = diamondsCollected + "";

        timelinePlayer.PlayDiamondCollectUiEffect();
    }
}
