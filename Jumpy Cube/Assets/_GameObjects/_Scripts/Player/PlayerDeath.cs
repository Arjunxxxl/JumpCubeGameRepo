using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject deathParticleSystem;
    public bool isDead;
    public GameObject cube;

    GameOverMenu gameOverMenu;

    #region SingleTon
    public static PlayerDeath Instance;
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

    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu = GameOverMenu.Instance;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("Cube"))
            {
                cube = transform.GetChild(i).gameObject;
            }
        }

        deathParticleSystem.SetActive(false);
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            deathParticleSystem.SetActive(true);
            deathParticleSystem.transform.position = transform.position;
            cube.SetActive(false);
            isDead = true;

            gameOverMenu.CaptureScreenShot();
        }
    }

}
