using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject Player;
    public Vector3 position;

    [Header("Disolve Effect Parameter")]
    public float disloveSpeed = 0.5f;
    public float disolveEffect;
    public bool isDisolveEffectDone;
    public bool startDisolveEffect;
    public float disolveEffectDelay = 0.2f;

    public Material playerMaterial;

    MainMenu mainmenu;

    #region SingleTon
    public static PlayerSpawner Instance;
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

        if(!Player)
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }

        Player.SetActive(true);
        Player.transform.position = position;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        mainmenu = MainMenu.Instance;

        GetChildCubeMaterial();

        isDisolveEffectDone = false;
        startDisolveEffect = false;
        StartCoroutine(DisolveEffectDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if(!mainmenu.isGameStart)
        {
            return;
        }

        if(disolveEffect < 1.2 && !isDisolveEffectDone)
        {
            if(startDisolveEffect)
                disolveEffect += Time.deltaTime * disloveSpeed;
        }
        else if(!isDisolveEffectDone)
        {
            isDisolveEffectDone = true;
        }
        playerMaterial.SetFloat("Vector1_D57CEFD5", disolveEffect);
    }

    public void GetChildCubeMaterial()
    {
        /*for (int i = 0; i < Player.transform.childCount; i++)
        {
            if (Player.transform.GetChild(i).CompareTag("Cube"))
            {
                playerMaterial = Player.transform.GetChild(i).GetComponent<Renderer>().material;
            }
        }*/

        disolveEffect = playerMaterial.GetFloat("Vector1_D57CEFD5");
        disolveEffect = 0;
        playerMaterial.SetFloat("Vector1_D57CEFD5", disolveEffect);
    }

    IEnumerator DisolveEffectDelay()
    {
        yield return new WaitForSeconds(disolveEffectDelay);
        startDisolveEffect = true;
    }
}
