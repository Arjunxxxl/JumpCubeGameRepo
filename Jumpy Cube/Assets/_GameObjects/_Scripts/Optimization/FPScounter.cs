using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPScounter : MonoBehaviour
{
    public float current, avgFrameRate;

    public float delay = 0.5f;
    public float t;
    

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
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(t < delay)
        {
            t += Time.deltaTime;
            return;
        }

        t = 0;

        current = 0;
        current = (1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;

        fpsTxt.text = avgFrameRate + "";
    }
    
}
