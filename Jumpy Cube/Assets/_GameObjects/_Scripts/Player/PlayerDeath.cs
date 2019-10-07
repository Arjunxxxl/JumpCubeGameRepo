using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject deathParticleSystem;
    public bool isDead;
    public GameObject cube;

    GameOverMenu gameOverMenu;
    InGameMenu inGameMenu;
    DiamondScore diamondScore;
    DistanceScore distanceScore;
    SavedData savedData;

    [Header("Revival Data")]
    public GameObject hitEnemy;
    public GameObject revialPointObj;
    public RevivePoints revivalPoint;


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
        inGameMenu = InGameMenu.Instance;
        diamondScore = DiamondScore.Instance;
        distanceScore = DistanceScore.Instance;
        savedData = SavedData.Instance;

        SetPlayerChildCube();

        deathParticleSystem.SetActive(false);
        isDead = false;
    }

    private void OnApplicationQuit()
    {
        if(!isDead)
        {
            savedData.SavePlayerAverageScore(distanceScore.distance);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            hitEnemy = other.gameObject;
            revivalPoint = hitEnemy.GetComponent<RevivePoints>();
            revialPointObj = revivalPoint.revitalPoint;

            deathParticleSystem.SetActive(true);
            deathParticleSystem.transform.position = transform.position;
            cube.SetActive(false);
            isDead = true;

            diamondScore.SaveDiamondsCollected(inGameMenu.realNumberOfDiamondsCollected, false);

            savedData.SavePlayerHighScore(distanceScore.distance);
            savedData.SavePlayerAverageScore(distanceScore.distance);
            savedData.SaveDiamondsCollectedinOneRun(inGameMenu.diamondsCollected);

            inGameMenu.realNumberOfDiamondsCollected = 0;

            gameOverMenu.CaptureScreenShot();
        }
    }

    public void SetPlayerChildCube(GameObject overrideCube = null)
    {
        if(overrideCube)
        {
            cube = overrideCube;
            return;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).CompareTag("Cube"))
            {
                cube = transform.GetChild(i).gameObject;
            }
        }
    }
}
