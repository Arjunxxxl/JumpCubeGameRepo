using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IoSphereColorChanger : MonoBehaviour
{
    public static string PLAYER_TAG = "Player";
    public static string IOSPHERE_TAG = "iosphere";

    [SerializeField]
    bool triggered;

    
    float colorChangeSpeed = 5f;
    [SerializeField]
    Color currentColor;
    [SerializeField]
    Color finalColor;

    public Material ioSphereMat;
    public MeshRenderer meshRenderer;
    Shader iosphereShader;
    
    SelectColorScheme selectColorScheme;
    

    // Start is called before the first frame update
    void Start()
    {
        if (!selectColorScheme)
        {
            selectColorScheme = SelectColorScheme.Instance;
        }

        currentColor = selectColorScheme.ioSphereMainColor;
        finalColor = selectColorScheme.ioSphereChangeColor;

        if (!meshRenderer || !iosphereShader || !ioSphereMat)
        {
            meshRenderer = GetComponent<MeshRenderer>();
            iosphereShader = selectColorScheme.ioSphereShader;
            ioSphereMat = new Material(iosphereShader);
        }

        ioSphereMat.SetColor("_BaseColor", currentColor);
        meshRenderer.material = ioSphereMat;

        triggered = false;

    }

    private void OnEnable()
    {
        if (!selectColorScheme)
        {
            selectColorScheme = SelectColorScheme.Instance;
        }

        currentColor = selectColorScheme.ioSphereMainColor;
        finalColor = selectColorScheme.ioSphereChangeColor;

        if (!meshRenderer || !iosphereShader || !ioSphereMat)
        {
            meshRenderer = GetComponent<MeshRenderer>();
            iosphereShader = selectColorScheme.ioSphereShader;
            ioSphereMat = new Material(iosphereShader);
        }

        ioSphereMat.SetColor("_BaseColor", currentColor);
        meshRenderer.material = ioSphereMat;

        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(triggered)
        {
            currentColor = ioSphereMat.GetColor("_BaseColor");
            if(currentColor != finalColor)
            {
                currentColor = Color.Lerp(currentColor, finalColor, Time.deltaTime * colorChangeSpeed);

                ioSphereMat.SetColor("_BaseColor", currentColor);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(PLAYER_TAG) || collision.gameObject.CompareTag(IOSPHERE_TAG))
        {
            if(!triggered)
            {
                triggered = true;
            }
        }
    }

}
