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
    public TMP_Text itemsCollected2_txt;
    public Image items_img_1;
    public Image items_img_2;

    [Header("Data")]
    public bool showItemsCollected1;
    public bool showItemsCollected2;
    public Color visibleColor;
    public Color invisibleColor;
    public float fadeOutSpeed = 15f;
    public float fadeOutDelay = 2f;
    public float currentTime_items1;
    public float currentTime_items2;

    [Header("Items Data")]
    public int itemsCollected1_total;
    public int itemsCollected2_total;

    PlayerSpawner playerSpawner;

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

        score.color = invisibleColor;
        itemsCollected1_txt.color = invisibleColor;
        itemsCollected2_txt.color = invisibleColor;
        items_img_1.color = invisibleColor;
        items_img_2.color = invisibleColor;

        currentTime_items1 = 0;
        currentTime_items2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerSpawner.isDisolveEffectDone)
        {
            score.color = visibleColor;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            UpdateItemsCollected1();
            UpdateItemsCollected2();
        }

        if(showItemsCollected1)
        {
            currentTime_items1 += Time.deltaTime;
            if(currentTime_items1 > fadeOutDelay)
            {
                showItemsCollected1 = false;
            }
        }
        else if (!showItemsCollected1)
        {
            HideItemsCollected(itemsCollected1_txt, items_img_1);
        }


        if (showItemsCollected2)
        {
            currentTime_items2 += Time.deltaTime;
            if (currentTime_items2 > fadeOutDelay)
            {
                showItemsCollected2 = false;
            }
        }
        else if (!showItemsCollected2)
        {
            HideItemsCollected(itemsCollected2_txt, items_img_2);
        }
    }

    public void UpdateItemsCollected1()
    {
        ShowItemsCollected(itemsCollected1_txt, items_img_1);

        itemsCollected1_total++;
        itemsCollected1_txt.text = "" + itemsCollected1_total;
        showItemsCollected1 = true;
        currentTime_items1 = 0;
    }

    public void UpdateItemsCollected2()
    {
        ShowItemsCollected(itemsCollected2_txt, items_img_2);

        itemsCollected2_total++;
        itemsCollected2_txt.text = "" + itemsCollected2_total;
        showItemsCollected2 = true;
        currentTime_items2 = 0;
    }
    
    void HideItemsCollected(TMP_Text txt, Image img)
    {
        if (txt.color != invisibleColor)
        {
            txt.color = Color.Lerp(txt.color, invisibleColor, Time.deltaTime * fadeOutSpeed);
        }

        if (img.color != invisibleColor)
        {
            img.color = Color.Lerp(img.color, invisibleColor, Time.deltaTime * fadeOutSpeed);
        }
    }


    void ShowItemsCollected(TMP_Text txt, Image img)
    {
        txt.color = visibleColor;

        img.color = visibleColor;
    }
}
