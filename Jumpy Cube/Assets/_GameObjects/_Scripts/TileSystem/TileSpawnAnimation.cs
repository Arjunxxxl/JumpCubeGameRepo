using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnAnimation : MonoBehaviour
{
    [Header("Data")]
    public float initialPosY;
    public float FinalPosY;
    public Vector3 initialPos;
    public Vector3 finalPos;
    public float offSet;
    public float speed;
    public float playerSpeed;

    public Transform player;

    public float its, players;
    public float differnce;

    PlayerMovement playerMovement;

    private void OnEnable()
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

        its = transform.position.x;
        players = player.position.x;
        differnce = transform.position.x - player.position.x;

        if (Mathf.Abs(transform.position.x - player.position.x) < offSet)
        {
            transform.localPosition = finalPos;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!player)
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
        }

    }

    // Update is called once per frame
    void Update()
    {
        its = transform.position.x;
        players = player.position.x;
        differnce = its - players;

        if (Mathf.Abs(its - players) < offSet)
        {
            playerSpeed = playerMovement.movementSpeed;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, finalPos, Time.deltaTime * speed * playerSpeed);
        }
    }

}
