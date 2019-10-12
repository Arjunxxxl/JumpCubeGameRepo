using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    [Header("Killer data")]
    public bool killPlayer;
    public float playerSpeed;
    public float stationatyDelay = 5f;
    public float currentTime;

    [Header("Ground Tag")]
    public static string GroundFloor = "Ground_Floor";
    public static string GroundCeil = "Ground_Ceil";
    public static string currentGroundTag;

    Rigidbody rb;

    PlayerSpawner playerSpawner;
    PlayerMovement playerMovement;
    PlayerDeath playerDeath;

    #region SingleTon
    public static PlayerKiller Instance;
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
        playerSpawner = PlayerSpawner.Instance;
        playerMovement = PlayerMovement.Instance;
        playerDeath = PlayerDeath.Instance;

        rb = GetComponent<Rigidbody>();

        currentTime = 0;
        killPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerSpawner.isDisolveEffectDone)
        {
            return;
        }

        playerSpeed = rb.velocity.magnitude;

        if (playerSpeed < 0.1f && !playerDeath.isDead)
        {
            currentTime += Time.deltaTime;
            if (currentTime > stationatyDelay && !killPlayer)
            {
                killPlayer = true;
                currentGroundTag = playerMovement.currentGround;
                currentTime = 0;
            }
        }
        else
        {
            if (currentTime != 0)
            {
                currentTime = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(killPlayer && !playerDeath.isDead)
        {
            if(collision.gameObject.CompareTag(currentGroundTag))
            {
                collision.gameObject.GetComponent<TileSpawnAnimation>().killPlayer = true;
                playerMovement.movementSpeed = 0;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (killPlayer && !playerDeath.isDead)
        {
            if (collision.gameObject.CompareTag(currentGroundTag))
            {
                collision.gameObject.GetComponent<TileSpawnAnimation>().killPlayer = true;
                playerMovement.movementSpeed = 0;
            }
        }
    }
}
