using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform target;
    Vector3 currentPos;
    Vector3 finalPos;
    public Vector3 offSet;
    public float followSpeed = 5f;

    [Header("Offset Data")]
    public float offSetChangeSpeed = 2f;
    public float offSetChangeSpeedWhenGravityChanges = 1f;
    public float offSetChangeSpeed_whenDied = 0.5f;
    public Vector3 menuOffSet;
    public Vector3 startingOffset;
    public Vector3 normalOffset;
    public Vector3 upGravityOffset;
    public Vector3 deathOffset;


    Vector3 refVelocity;

    PlayerDeath playerDeath;
    PlayerSpawner playerSpawner;
    PlayerMovement playerMovement;
    MainMenu mainMenu;
    public bool isDead;
    public bool isDownGravity;
    public bool isGravityChanged;

    // Start is called before the first frame update
    void Start()
    {
        playerDeath = PlayerDeath.Instance;
        playerSpawner = PlayerSpawner.Instance;
        mainMenu = MainMenu.Instance;
        playerMovement = PlayerMovement.Instance;

        isDead = playerDeath.isDead;
        isDownGravity = playerMovement.isDownGravity;
        isGravityChanged = playerMovement.isGravityChanged;

        if(!target)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if(!mainMenu.isGameStart)
        {
            offSet = menuOffSet;
        }
    }

    private void Update()
    {
        isDead = playerDeath.isDead;
        isDownGravity = playerMovement.isDownGravity;
        isGravityChanged = playerMovement.isGravityChanged;

        if (isDead)
        {
            offSet = Vector3.Lerp(offSet, deathOffset, Time.deltaTime * offSetChangeSpeed_whenDied);
            return;
        }
        if (!mainMenu.isGameStart)
        {
            offSet = Vector3.Lerp(offSet, menuOffSet, Time.deltaTime * offSetChangeSpeed);
        }
        else if(playerSpawner.isDisolveEffectDone)
        {
            if (!isGravityChanged)
            {
                offSet = Vector3.Lerp(offSet, normalOffset, Time.deltaTime * offSetChangeSpeed);
            }
            else if (isGravityChanged && !isDownGravity)
            {
                offSet = Vector3.Lerp(offSet, upGravityOffset, Time.deltaTime * offSetChangeSpeedWhenGravityChanges);
            }
            else if (isGravityChanged && isDownGravity)
            {
                offSet = Vector3.Lerp(offSet, normalOffset, Time.deltaTime * offSetChangeSpeedWhenGravityChanges);
            }
        }
        else if(!playerSpawner.isDisolveEffectDone)
        {
            offSet = Vector3.Lerp(offSet, startingOffset, Time.deltaTime * offSetChangeSpeed);
        }
    }

    void FixedUpdate()
    {
        if (!target) { return; }

        currentPos = transform.position;
        finalPos = target.position + offSet;
        transform.position = Vector3.SmoothDamp(currentPos, finalPos, ref refVelocity, Time.deltaTime * followSpeed);
    }
}
