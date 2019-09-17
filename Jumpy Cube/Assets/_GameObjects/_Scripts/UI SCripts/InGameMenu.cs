using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text score;
    public TMP_Text itemsCollected1_txt;
    public Image items_img_1;
    public GameObject inGameMenu;

    [Header("Data")]
    public bool isMenuActivated;

    [Header("Items Data")]
    public int itemsCollected1_total;

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
}
