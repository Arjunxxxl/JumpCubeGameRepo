using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Transform target;
    Vector3 currentPos;
    Vector3 finalPos;
    public Vector3 offSet;
    public float followSpeed = 5f;
    
    Vector3 refVelocity;

    ParticleSystem hailEffect;

    PlayerSpawner playerSpawner;
    PlayerDeath playerDeath;
    PlayerMovement playerMovement;
    public bool isDownGravity;

    // Start is called before the first frame update
    void Start()
    {
        playerSpawner = PlayerSpawner.Instance;
        playerDeath = PlayerDeath.Instance;
        playerMovement = PlayerMovement.Instance;

        isDownGravity = playerMovement.isDownGravity;

        if (!target)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        hailEffect = transform.GetChild(0).GetComponent<ParticleSystem>();

        var main = hailEffect.main;
        main.gravityModifier = 1f;
    }

    private void Update()
    {
        isDownGravity = playerMovement.isDownGravity;

        if (!playerSpawner.isDisolveEffectDone || playerDeath.isDead)
        {
            var vel = hailEffect.velocityOverLifetime;
            if (vel.enabled)
            {
                vel.enabled = false;
            }
        }
        else
        {
            var vel = hailEffect.velocityOverLifetime;
            if (!vel.enabled)
            {
                vel.enabled = true;
            }
        }

        if (isDownGravity)
        {
            var main = hailEffect.main;
            main.gravityModifier = 1f;
        }
        else
        {
            var main = hailEffect.main;
            main.gravityModifier = -1f;
        }
    }

    void FixedUpdate()
    {
        if (!target) { return; }

        currentPos = transform.position;
        finalPos =  target.position + offSet;
        finalPos.y = currentPos.y;
        finalPos.z = currentPos.z;
        transform.position = Vector3.SmoothDamp(currentPos, finalPos, ref refVelocity, Time.deltaTime * followSpeed);
    }
}
