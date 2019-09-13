using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public bool overrideShowDiamonds;

    [Header("Total diamonds in tile")]
    public GameObject[] diamonds;
    public int totalDiamonds;
    public bool[] finalPosReached;

    [Header("Rotaion data")]
    public float rotationSpeed = 50f;
    public float startAngle = 0;
    public float angleOffset = 30f;

    [Header("Probability data")]
    public bool showDiamonds;
    public int maxProb = 100;
    public int currentProb;
    int minChance = 35;
    int maxChance = 70;

    [Header("Data")]
    public float[] initialPosY;
    public float[] FinalPosY;
    public Vector3[] initialPos;
    public Vector3[] finalPos;
    public float offSet;
    public float speed;
    public float playerSpeed;

    public Transform player;
    
    Vector3 tempAngle;

    PlayerMovement playerMovement;


    void OnEnable()
    {
        currentProb = Random.Range(1, maxProb);
        if (currentProb > minChance && currentProb < maxChance)
        {
            showDiamonds = true;
        }
        else
        {
            showDiamonds = false;
        }

        if (showDiamonds)
        {
            totalDiamonds = diamonds.Length;

            tempAngle = new Vector3(90, 0, 0);

            initialPos = new Vector3[totalDiamonds];
            finalPos = new Vector3[totalDiamonds];

            finalPosReached = new bool[totalDiamonds];

            for (int i = 0; i < totalDiamonds; i++)
            {
                if (!diamonds[i].activeSelf)
                {
                    diamonds[i].SetActive(true);
                }

                tempAngle.y = i * angleOffset;
                diamonds[i].transform.localRotation = Quaternion.Euler(tempAngle);

                if (!player)
                {
                    player = GameObject.FindGameObjectWithTag("Player").transform;
                }

                playerMovement = PlayerMovement.Instance;
                playerSpeed = playerMovement.movementSpeed;

                initialPos[i] = new Vector3(diamonds[i].transform.localPosition.x, initialPosY[i], diamonds[i].transform.localPosition.z);
                finalPos[i] = new Vector3(diamonds[i].transform.localPosition.x, FinalPosY[i], diamonds[i].transform.localPosition.z);
                diamonds[i].transform.localPosition = initialPos[i];

                if (Mathf.Abs(diamonds[i].transform.position.x - player.position.x) < offSet)
                {
                    diamonds[i].transform.localPosition = finalPos[i];

                    finalPosReached[i] = true;
                }
                else
                {
                    finalPosReached[i] = false;
                }
            }

        }
        else
        {
            totalDiamonds = diamonds.Length;

            for (int i = 0; i < totalDiamonds; i++)
            {
                if (diamonds[i].activeSelf)
                {
                    diamonds[i].SetActive(false);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!overrideShowDiamonds)
        {
            currentProb = Random.Range(1, maxProb);
            if (currentProb > minChance && currentProb < maxChance)
            {
                showDiamonds = true;
            }
            else
            {
                showDiamonds = false;
            }
        }
        else
        {
            showDiamonds = overrideShowDiamonds;
        }

        if(showDiamonds)
        {
            totalDiamonds = diamonds.Length;

            tempAngle = new Vector3(90, 0, 0);

            initialPos = new Vector3[totalDiamonds];
            finalPos = new Vector3[totalDiamonds];

            finalPosReached = new bool[totalDiamonds];

            for (int i = 0; i < totalDiamonds; i++)
            {
                if (!diamonds[i].activeSelf)
                {
                    diamonds[i].SetActive(true);
                }

                tempAngle.y = i * angleOffset;
                diamonds[i].transform.localRotation = Quaternion.Euler(tempAngle);

                if (!player)
                {
                    player = GameObject.FindGameObjectWithTag("Player").transform;
                }

                playerMovement = PlayerMovement.Instance;
                playerSpeed = playerMovement.movementSpeed;

                initialPos[i] = new Vector3(diamonds[i].transform.localPosition.x, initialPosY[i], diamonds[i].transform.localPosition.z);
                finalPos[i] = new Vector3(diamonds[i].transform.localPosition.x, FinalPosY[i], diamonds[i].transform.localPosition.z);
                diamonds[i].transform.localPosition = initialPos[i];

                if (Mathf.Abs(diamonds[i].transform.position.x - player.position.x) < offSet)
                {
                    diamonds[i].transform.localPosition = finalPos[i];

                    finalPosReached[i]= true;
                }
                else
                {
                    finalPosReached[i] = false;
                }
            }

        }
        else
        {
            totalDiamonds = diamonds.Length;

            for (int i = 0; i < totalDiamonds; i++)
            {
                if (diamonds[i].activeSelf)
                {
                    diamonds[i].SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(showDiamonds)
        {
            for (int i = 0; i < totalDiamonds; i++)
            {
                diamonds[i].transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

                if (!finalPosReached[i])
                {
                    if ((diamonds[i].transform.localPosition - finalPos[i]).magnitude < 0.02f)
                    {
                        finalPosReached[i] = true;
                    }

                    if (Mathf.Abs(diamonds[i].transform.position.x - player.transform.position.x) < offSet)
                    {
                        playerSpeed = playerMovement.movementSpeed;
                        diamonds[i].transform.localPosition = Vector3.MoveTowards(diamonds[i].transform.localPosition, finalPos[i], Time.deltaTime * speed * playerSpeed);
                    }
                }
            }
        }
    }
}
