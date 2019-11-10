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
    int minChance = 25;
    int maxChance = 86;

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

    int i;
    int _i1;
    float val;

    PlayerMovement playerMovement;

    void OnEnable()
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

        if (showDiamonds)
        {
            totalDiamonds = diamonds.Length;

            tempAngle = new Vector3(90, 0, 0);

            initialPos = new Vector3[totalDiamonds];
            finalPos = new Vector3[totalDiamonds];

            finalPosReached = new bool[totalDiamonds];

            for (_i1 = 0; _i1 < totalDiamonds; _i1++)
            {
                if (!diamonds[_i1].activeSelf)
                {
                    diamonds[_i1].SetActive(true);
                }

                tempAngle.y = _i1 * angleOffset;
                diamonds[_i1].transform.localRotation = Quaternion.Euler(tempAngle);

                if (!player)
                {
                    player = GameObject.FindGameObjectWithTag("Player").transform;
                }

                playerMovement = PlayerMovement.Instance;

                playerSpeed = playerMovement.movementSpeed;

                initialPos[_i1] = new Vector3(diamonds[_i1].transform.localPosition.x, initialPosY[_i1], diamonds[_i1].transform.localPosition.z);
                finalPos[_i1] = new Vector3(diamonds[_i1].transform.localPosition.x, FinalPosY[_i1], diamonds[_i1].transform.localPosition.z);
                diamonds[_i1].transform.localPosition = initialPos[_i1];

                val = (diamonds[_i1].transform.position.x - player.transform.position.x) > 0 ?
                            (diamonds[_i1].transform.position.x - player.transform.position.x) :
                            (player.transform.position.x - diamonds[_i1].transform.position.x);

                if (val < offSet)
                {
                    diamonds[_i1].transform.localPosition = finalPos[_i1];

                    finalPosReached[_i1] = true;
                }
                else
                {
                    finalPosReached[_i1] = false;
                }
            }

        }
        else
        {
            totalDiamonds = diamonds.Length;

            for (_i1 = 0; _i1 < totalDiamonds; _i1++)
            {
                if (diamonds[_i1].activeSelf)
                {
                    diamonds[_i1].SetActive(false);
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

            for (_i1 = 0; _i1 < totalDiamonds; _i1++)
            {
                if (!diamonds[_i1].activeSelf)
                {
                    diamonds[_i1].SetActive(true);
                }

                tempAngle.y = _i1 * angleOffset;
                diamonds[_i1].transform.localRotation = Quaternion.Euler(tempAngle);

                if (!player)
                {
                    player = GameObject.FindGameObjectWithTag("Player").transform;
                }

                playerMovement = PlayerMovement.Instance;

                playerSpeed = playerMovement.movementSpeed;

                initialPos[_i1] = new Vector3(diamonds[_i1].transform.localPosition.x, initialPosY[_i1], diamonds[_i1].transform.localPosition.z);
                finalPos[_i1] = new Vector3(diamonds[_i1].transform.localPosition.x, FinalPosY[_i1], diamonds[_i1].transform.localPosition.z);
                diamonds[_i1].transform.localPosition = initialPos[_i1];

                val = (diamonds[_i1].transform.position.x - player.transform.position.x) > 0 ?
                            (diamonds[_i1].transform.position.x - player.transform.position.x) :
                            (player.transform.position.x - diamonds[_i1].transform.position.x);

                if (val < offSet)
                {
                    diamonds[_i1].transform.localPosition = finalPos[_i1];

                    finalPosReached[_i1] = true;
                }
                else
                {
                    finalPosReached[_i1] = false;
                }
            }

        }
        else
        {
            totalDiamonds = diamonds.Length;

            for (_i1 = 0; _i1 < totalDiamonds; _i1++)
            {
                if (diamonds[_i1].activeSelf)
                {
                    diamonds[_i1].SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(showDiamonds)
        {
            for (i = 0; i < totalDiamonds; i++)
            {
                diamonds[i].transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

                if (!finalPosReached[i])
                {
                    if ((diamonds[i].transform.localPosition - finalPos[i]).magnitude < 0.02f)
                    {
                        finalPosReached[i] = true;
                    }

                    val = (diamonds[i].transform.position.x - player.transform.position.x) > 0 ?
                            (diamonds[i].transform.position.x - player.transform.position.x) :
                            (player.transform.position.x - diamonds[i].transform.position.x);

                    if (val < offSet)
                    {
                        playerSpeed = playerMovement.movementSpeed;
                        diamonds[i].transform.localPosition = Vector3.MoveTowards(diamonds[i].transform.localPosition, finalPos[i], Time.deltaTime * speed * playerSpeed);
                    }
                }
            }
        }
    }
}
