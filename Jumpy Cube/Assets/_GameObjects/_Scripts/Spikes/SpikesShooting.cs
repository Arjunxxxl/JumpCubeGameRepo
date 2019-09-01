using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesShooting : MonoBehaviour
{
    [Header("Data")]
    public float initialPosZ;
    public float FinalPosZ;
    public Vector3 initialPos;
    public Vector3 finalPos;
    public float offSet;
    public float speed;
    public float playerSpeed;

    [Header("Shooting data")]
    public float offSetForShooting;
    public float shootingSpeed = 5;

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

        initialPos = new Vector3(transform.localPosition.x, transform.localPosition.y, initialPosZ);
        finalPos = new Vector3(transform.localPosition.x, transform.localPosition.y, FinalPosZ);
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
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        playerMovement = PlayerMovement.Instance;
        playerSpeed = playerMovement.movementSpeed;

        initialPos = new Vector3(transform.localPosition.x, transform.localPosition.y, initialPosZ);
        finalPos = new Vector3(transform.localPosition.x, transform.localPosition.y, FinalPosZ);
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
        differnce = transform.position.x - player.position.x;

        if (Mathf.Abs(transform.position.x - player.position.x) < offSetForShooting)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * shootingSpeed);
        }
        else if (Mathf.Abs(transform.position.x - player.position.x) < offSet)
        {
            playerSpeed = playerMovement.movementSpeed;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, finalPos, Time.deltaTime * speed * playerSpeed);
        }
    }
}
