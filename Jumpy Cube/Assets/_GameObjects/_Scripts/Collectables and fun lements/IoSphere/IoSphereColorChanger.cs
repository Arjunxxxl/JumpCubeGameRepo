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
    Shader iosphereShader;

    static string TILE_SYSTEM_TAG = "TileSystem";
    public static string SOUND_TAG = "IO_SphereHitSound";

    float currentTime = 0;
    float soundDelay = 0.5f;

    SelectColorScheme selectColorScheme;
    ObjectPooler objectPooler;

    // Start is called before the first frame update
    void Start()
    {
        if (!selectColorScheme)
        {
            selectColorScheme = SelectColorScheme.Instance;
        }

        if (!objectPooler)
        {
            objectPooler = ObjectPooler.Instance;
        }

        currentColor = selectColorScheme.ioSphereMainColor;
        finalColor = selectColorScheme.ioSphereChangeColor;

        if (!iosphereShader || !ioSphereMat)
        {
            iosphereShader = selectColorScheme.ioSphereShader;
            ioSphereMat = GetComponent<MeshRenderer>().material;
            //ioSphereMat = new Material(iosphereShader);
        }

        ioSphereMat.SetColor("_BaseColor", currentColor);
        GetComponent<MeshRenderer>().material = ioSphereMat;

        triggered = false;
        currentTime = 0;
    }

    private void OnEnable()
    {
        if (!selectColorScheme)
        {
            selectColorScheme = SelectColorScheme.Instance;

            if(!selectColorScheme)
            {
                selectColorScheme = GameObject.FindGameObjectWithTag(TILE_SYSTEM_TAG).GetComponent<SelectColorScheme>();
            }
        }

        if (!objectPooler)
        {
            objectPooler = ObjectPooler.Instance;
        }

        currentColor = selectColorScheme.ioSphereMainColor;
        finalColor = selectColorScheme.ioSphereChangeColor;

        if (!iosphereShader || !ioSphereMat)
        {
            iosphereShader = selectColorScheme.ioSphereShader;
            ioSphereMat = new Material(iosphereShader);
        }

        ioSphereMat.SetColor("_BaseColor", currentColor);
        GetComponent<MeshRenderer>().material = ioSphereMat;

        triggered = false;
        currentTime = 0;
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

            currentTime += Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(PLAYER_TAG) || collision.gameObject.CompareTag(IOSPHERE_TAG))
        {
            if(!triggered)
            {
                triggered = true;

                var obj = objectPooler.SpawnFormPool(SOUND_TAG, transform.position, Quaternion.identity);
                obj.GetComponent<AudioSource>().Play();
            }

            if (currentTime > soundDelay)
            {
                var obj1 = objectPooler.SpawnFormPool(SOUND_TAG, transform.position, Quaternion.identity);
                obj1.GetComponent<AudioSource>().Play();

                soundDelay += 0.1f;
                currentTime = 0;
            }
        }
    }

}
