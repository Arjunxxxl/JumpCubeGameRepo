using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPScounter : MonoBehaviour
{
    public float current, avgFrameRate;

    Optimizer optimizer;

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
            return;
        }

        current = 0;
        current = (1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;
    }
}
