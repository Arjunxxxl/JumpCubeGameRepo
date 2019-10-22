using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnAnimation : MonoBehaviour
{
    public bool finalPosReached;
    public bool disablePlayerKiller;

    [Header("Data")]
    public float initialPosY;
    public float FinalPosY;
    public Vector3 initialPos;
    public Vector3 finalPos;
    public float offSet;
    public float speed;
    public float playerSpeed;

    [Header("Ground Tag")]
    public static string GroundFloor = "Ground_Floor";
    public static string GroundCeil = "Ground_Ceil";

    [Space]
    public Transform player;

    public float its, players;
    public float differnce;

    public bool killPlayer;
    public Vector3 finalPosKillPlayer;

    PlayerMovement playerMovement;

    private void OnEnable()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }


        playerMovement = PlayerMovement.Instance;

        if(!playerMovement)
        {
            playerMovement = player.GetComponent<PlayerMovement>();
        }

        playerSpeed = playerMovement.movementSpeed;

        initialPos = new Vector3(transform.localPosition.x, initialPosY, transform.localPosition.z);
        finalPos = new Vector3(transform.localPosition.x, FinalPosY, transform.localPosition.z);
        transform.localPosition = initialPos;

        its = transform.position.x;
        players = player.position.x;
        differnce = transform.position.x - player.position.x;

        if (Mathf.Abs(transform.position.x - player.position.x) < offSet)
        {
            transform.localPosition = finalPos;
            finalPosReached = true;
        }
        else
        {
            finalPosReached = false;
        }

        killPlayer = false;
        if (gameObject.CompareTag(GroundFloor))
        {
            finalPosKillPlayer = new Vector3(transform.localPosition.x, -45f, transform.localPosition.z);
        }
        else if (gameObject.CompareTag(GroundCeil))
        {
            finalPosKillPlayer = new Vector3(transform.localPosition.x, 30f, transform.localPosition.z);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        playerMovement = PlayerMovement.Instance;
        playerSpeed = playerMovement.movementSpeed;

        initialPos = new Vector3(transform.localPosition.x, initialPosY, transform.localPosition.z);
        finalPos = new Vector3(transform.localPosition.x, FinalPosY, transform.localPosition.z);
        transform.localPosition = initialPos;

        if (Mathf.Abs(transform.position.x - player.position.x) < offSet)
        {
            transform.localPosition = finalPos;
            finalPosReached = true;
        }
        else
        {
            finalPosReached = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        its = transform.position.x;
        players = player.position.x;
        differnce = its - players;

        if (killPlayer && !disablePlayerKiller)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, finalPosKillPlayer, Time.deltaTime * 30);

            return;
        }

        if (!finalPosReached)
        {
            if ((transform.localPosition - finalPos).magnitude == 0)
            {
                finalPosReached = true;
            }

            if (Mathf.Abs(its - players) < offSet)
            {
                playerSpeed = playerMovement.movementSpeed;
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, finalPos, Time.deltaTime * speed * playerSpeed);
            }
        }
    }

}
