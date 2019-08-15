﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Data")]
    public float movementSpeed = 5f;
    public float upVelocity = 8f;
    public Vector3 velocity;

    [Header("Jumping Data")]
    public int numberOfJumps;
    public int maxNumverOfJumps = 2;

    [Header("Rotational Data")]
    public bool rotateTheCube;
    public float rotationSpeed = 2.5f;
    public float editorRotationSpeed = 1f;
    public float androidRotationSpeed = 5f;

    [Header("Camera Shake")]
    public float cameraShakeMagnitude = 0.01f;

    [Header("Playable Director")]
    public PlayableDirector cameraShake;

    [Header("Ground detection")]
    public bool groundEnter;
    public bool groundExit;
    public float checkTime = 0.25f;
    public float currentTime;
    public bool isGrounded;

    [Header("Particle system data")]
    public Vector3 landEffectOffSet;
    public Vector3 landEffectRotation;

    public TrailRenderer playerTrail;
    public bool isDead;

    Rigidbody rb;

    PlayerDeath playerDeath;
    PlayerSpawner playerSpawner;
    MainMenu mainMenu;
    ObjectPooler objectPooler;
    PauseMenu pauseMenu;

    GameObject spawnedLandEffect;

    #region SingleTon
    public static PlayerMovement Instance;
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

#if UNITY_EDITOR
        rotationSpeed = editorRotationSpeed;
#elif UNITY_ANDROID
        rotationSpeed = androidRotationSpeed;
#endif
    }
#endregion

    // Start is called before the first frame update
    void Start()
    {
        playerDeath = PlayerDeath.Instance;
        playerSpawner = PlayerSpawner.Instance;
        mainMenu = MainMenu.Instance;
        objectPooler = ObjectPooler.Instance;
        pauseMenu = PauseMenu.Instance;

        rb = GetComponent<Rigidbody>();
        numberOfJumps = 0;
        rotateTheCube = false;
        isGrounded = false;
        isDead = playerDeath.isDead;

        groundEnter = false;
        groundExit = false;

        playerTrail = transform.GetComponentInChildren<TrailRenderer>();
        playerTrail.enabled = false;

        cameraShake.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        isDead = playerDeath.isDead;
        if (!playerSpawner.isDisolveEffectDone || !mainMenu.isGameStart)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        
        if(playerSpawner.isDisolveEffectDone)
        {
            if(!playerTrail.enabled)
            {
                playerTrail.enabled = true;
            }
        }

        if(isDead)
        {
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            return;
        }
        else
        {
            if(!rb.useGravity)
            {
                rb.useGravity = true;
            }
        }

        if(pauseMenu.isPaused)
        {
            return;
        }

        if(groundExit)
        {
            currentTime += Time.deltaTime;
        }

        if(Input.GetMouseButtonDown(0) && numberOfJumps < maxNumverOfJumps)
        {
            if (currentTime < checkTime && numberOfJumps < maxNumverOfJumps)
            {
                rb.velocity = new Vector3(rb.velocity.x, upVelocity, 0);
                //rb.AddForce(Vector3.up * upVelocity, ForceMode.VelocityChange);
                numberOfJumps++;
                rotateTheCube = true;
                isGrounded = false;
            }
            else
            {
                rb.velocity = new Vector3(rb.velocity.x, upVelocity, 0);
                //rb.AddForce(Vector3.up * upVelocity, ForceMode.VelocityChange);
                numberOfJumps+=2;
                rotateTheCube = true;
                isGrounded = false;
            }
        }

        if(rotateTheCube)
        {
            transform.Rotate(Vector3.forward * rotationSpeed, Space.World);
        }

    }

    private void FixedUpdate()
    {
        if (isDead || !playerSpawner.isDisolveEffectDone)
            return;

        //rb.MovePosition(transform.position + (Vector3.right * -1 * movementSpeed * Time.fixedDeltaTime));
        if (Mathf.Abs(rb.velocity.x) < movementSpeed - 2)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(-movementSpeed, rb.velocity.y, 0), Time.deltaTime * 15);
        }
        else
        {
            rb.velocity = new Vector3(-movementSpeed, rb.velocity.y, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            rb.useGravity = true;
            rotateTheCube = false;
            isGrounded = true;

            groundEnter = true;
            groundExit = false;

            PlayLandEffect();

            currentTime = 0;

            if (numberOfJumps == 2)
            {
                //cameraShake.Play();
            }

            numberOfJumps = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.useGravity = true;
            groundExit = true;
            groundEnter = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground") && playerSpawner.isDisolveEffectDone)
        {
            //StartCoroutine(cameraShake.Shake(0.15f, movementSpeed * cameraShakeMagnitude));
        }
    }

    void PlayLandEffect()
    {
        if(groundEnter && (numberOfJumps > 0 || currentTime > checkTime))
        {
            spawnedLandEffect = objectPooler.SpawnFormPool("land_particle", transform.position + landEffectOffSet, Quaternion.Euler(landEffectRotation));
            spawnedLandEffect.GetComponent<ParticleSystem>().Play();
        }
    }
}