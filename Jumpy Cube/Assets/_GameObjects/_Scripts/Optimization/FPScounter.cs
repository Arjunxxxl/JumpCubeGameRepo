using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPScounter : MonoBehaviour
{
    public float current, avgFrameRate;

    Optimizer optimizer;

    public TMP_Text fpsTxt;

    #region SingleTon
    public static FPScounter Instance;
    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private void Start()
    {
        optimizer = Optimizer.Instance;

        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!optimizer.isOptimizing)
        {
            //return;
        }

        current = 0;
        current = (1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;

        fpsTxt.text = avgFrameRate + "";
    }
    
}
