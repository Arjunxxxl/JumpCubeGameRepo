using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifetimeStats : MonoBehaviour
{
    [Header("Text fields")]
    public TMP_Text highscore_txt;
    public TMP_Text averagescore_txt;
    public TMP_Text max_diamondsCollected_txt;
    public TMP_Text max_diamondsOwned_txt;
    public TMP_Text totalCubesOwned_txt;

    [Space]
    public CustomStrings customStrings;

    // Start is called before the first frame update
    void Start()
    {
        if(!customStrings)
        {
            customStrings = CustomStrings.Instance;
        }
    }

    //function is called from saved data get total owned cubes function
    public void SetLifeTimeStats()
    {
        highscore_txt.text = PlayerPrefs.GetInt(customStrings.HIGHSCORE, 0) + "";
        averagescore_txt.text = (int)PlayerPrefs.GetFloat(customStrings.AVERAGE_SCORE_2, 0) + "";
        max_diamondsCollected_txt.text = PlayerPrefs.GetInt(customStrings.DIAMONDS_COLLECTED_IN_ONE_RUN1, 0) + "";
        max_diamondsOwned_txt.text = PlayerPrefs.GetInt(customStrings.MAX_DIAMONDS_OWNED, 0) + "";
        totalCubesOwned_txt.text = PlayerPrefs.GetInt(customStrings.TOTAL_CUBES_OWNED, 0) + "";
    }
}
