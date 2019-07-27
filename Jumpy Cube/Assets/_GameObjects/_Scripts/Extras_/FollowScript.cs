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

    // Start is called before the first frame update
    void Start()
    {
        playerSpawner = PlayerSpawner.Instance;
        playerDeath = PlayerDeath.Instance;

        if (!target)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        hailEffect = transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    private void Update()
    {
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
