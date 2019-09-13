using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IoSphere : MonoBehaviour
{

    [Header("Total io spheres in tile")]
    public GameObject[] io_sphere;
    public int totalDiamonds;

    [Header("Bool checker")]
    public bool[] finalPosReached;

    [Header("Data")]
    public float[] initialPosY;
    public float[] FinalPosY;
    public Vector3[] initialPos;
    public Vector3[] finalPos;
    public float offSet = 20;
    public float speed = 5;
    public float playerSpeed;

    public Transform player;

    Vector3 tempAngle;

    PlayerMovement playerMovement;

    void OnEnable()
    {
        totalDiamonds = io_sphere.Length;

        tempAngle = new Vector3(90, 0, 0);

        initialPos = new Vector3[totalDiamonds];
        finalPos = new Vector3[totalDiamonds];

        finalPosReached = new bool[totalDiamonds];

        for (int i = 0; i < totalDiamonds; i++)
        {
            if (!io_sphere[i].activeSelf)
            {
                io_sphere[i].SetActive(true);
            }


            if (!player)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }

            playerMovement = PlayerMovement.Instance;
            playerSpeed = playerMovement.movementSpeed;

            initialPos[i] = new Vector3(io_sphere[i].transform.localPosition.x, initialPosY[i], io_sphere[i].transform.localPosition.z);
            finalPos[i] = new Vector3(io_sphere[i].transform.localPosition.x, FinalPosY[i], io_sphere[i].transform.localPosition.z);
            io_sphere[i].transform.localPosition = initialPos[i];

            if (Mathf.Abs(io_sphere[i].transform.position.x - player.position.x) < offSet)
            {
                io_sphere[i].transform.localPosition = finalPos[i];

                finalPosReached[i] = true;
            }
            else
            {
                finalPosReached[i] = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        totalDiamonds = io_sphere.Length;

        tempAngle = new Vector3(90, 0, 0);

        initialPos = new Vector3[totalDiamonds];
        finalPos = new Vector3[totalDiamonds];

        finalPosReached = new bool[totalDiamonds];

        for (int i = 0; i < totalDiamonds; i++)
        {
            if (!io_sphere[i].activeSelf)
            {
                io_sphere[i].SetActive(true);
            }


            if (!player)
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
            }

            playerMovement = PlayerMovement.Instance;
            playerSpeed = playerMovement.movementSpeed;

            initialPos[i] = new Vector3(io_sphere[i].transform.localPosition.x, initialPosY[i], io_sphere[i].transform.localPosition.z);
            finalPos[i] = new Vector3(io_sphere[i].transform.localPosition.x, FinalPosY[i], io_sphere[i].transform.localPosition.z);
            io_sphere[i].transform.localPosition = initialPos[i];

            if (Mathf.Abs(io_sphere[i].transform.position.x - player.position.x) < offSet)
            {
                io_sphere[i].transform.localPosition = finalPos[i];

                finalPosReached[i] = true;
            }
            else
            {
                finalPosReached[i] = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < totalDiamonds; i++)
        {
            if (!finalPosReached[i])
            {
                if ((io_sphere[i].transform.localPosition - finalPos[i]).magnitude < 0.02f)
                {
                    finalPosReached[i] = true;
                }

                if (Mathf.Abs(io_sphere[i].transform.position.x - player.transform.position.x) < offSet)
                {
                    playerSpeed = playerMovement.movementSpeed;

                    if (!finalPosReached[i])
                    {
                        io_sphere[i].transform.localPosition = Vector3.MoveTowards(io_sphere[i].transform.localPosition, finalPos[i], Time.deltaTime * speed * playerSpeed);
                    }
                }
            }
        }
    }
}