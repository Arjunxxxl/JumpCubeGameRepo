using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Data")]
    [SerializeField]
    bool isMovementActivated;
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

    [Header("Gravity for player data")]
    public Vector3 downGravity = new Vector3(0, -25f, 0);
    public Vector3 upGravity = new Vector3(0, 25f, 0);
    public Vector3 changingGravity = new Vector3(0, 50f, 0);
    public bool isDownGravity;
    public bool isGravityChanged;

    [Header("Ground Tag")]
    public static string GroundFloor = "Ground_Floor";
    public static string GroundCeil = "Ground_Ceil";
    public string currentGround;


    public TrailRenderer playerTrail;
    public bool isDead;
    public bool isReviving;

    Rigidbody rb;

    PlayerDeath playerDeath;
    PlayerSpawner playerSpawner;
    MainMenu mainMenu;
    ObjectPooler objectPooler;
    PauseMenu pauseMenu;
    InGameMenu inGameMenu;
    MissionManager missionManager;
    Vibration1 vibration;

    GameObject spawnedLandEffect;
    GameObject diamondCollectEffect;

    bool checkerForVibration;

    #region SingleTon
    public static PlayerMovement Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        isDownGravity = true;
        isGravityChanged = false;

        Physics.gravity = downGravity;

        currentGround = GroundFloor;

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
        inGameMenu = InGameMenu.Instance;
        missionManager = MissionManager.Instance;
        vibration = Vibration1.Instance;

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

        Physics.gravity = downGravity;
        isDownGravity = true;
        isGravityChanged = false;

        currentGround = GroundFloor;

        isMovementActivated = true;
        isReviving = false;
        checkerForVibration = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMovementActivated)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        isDead = playerDeath.isDead;
        if (!playerSpawner.isDisolveEffectDone || !mainMenu.isGameStart)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        if (playerSpawner.isDisolveEffectDone)
        {
            if (!playerTrail.enabled)
            {
                playerTrail.enabled = true;
            }
        }

        if (isDead)
        {
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            return;
        }
        else
        {
            if (!rb.useGravity)
            {
                rb.useGravity = true;
            }
        }

        if (pauseMenu.isPaused)
        {
            return;
        }

        if (groundExit)
        {
            currentTime += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && numberOfJumps < maxNumverOfJumps)
        {
            if (currentTime < checkTime && numberOfJumps < maxNumverOfJumps)
            {
                rb.velocity = new Vector3(rb.velocity.x, upVelocity, 0);
                //rb.AddForce(Vector3.up * upVelocity, ForceMode.VelocityChange);
                numberOfJumps++;
                rotateTheCube = true;
                isGrounded = false;

                missionManager.CheckingForJumpMission();
            }
            else
            {
                rb.velocity = new Vector3(rb.velocity.x, upVelocity, 0);
                //rb.AddForce(Vector3.up * upVelocity, ForceMode.VelocityChange);
                numberOfJumps += 2;
                rotateTheCube = true;
                isGrounded = false;

                missionManager.CheckingForJumpMission();
            }
        }

        if (rotateTheCube)
        {
            if (isDownGravity)
            {
                transform.Rotate(Vector3.forward * rotationSpeed, Space.World);
            }
            else
            {
                transform.Rotate(Vector3.forward * rotationSpeed * -1f, Space.World);
            }
        }

    }

    private void FixedUpdate()
    {
        if (!isMovementActivated)
        {
            return;
        }

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
        if (collision.gameObject.CompareTag(currentGround))
        {
            if(!isGrounded && checkerForVibration)
            {
                vibration.Vibrate(vibration.landVibrationAmt);
            }

            if(!checkerForVibration)
            {
                checkerForVibration = true;
            }

            rb.useGravity = true;
            rotateTheCube = false;
            isGrounded = true;

            groundEnter = true;
            groundExit = false;

            PlayLandEffect();

            if (isDownGravity)
            {
                if (Physics.gravity != downGravity)
                {
                    Physics.gravity = downGravity;
                }
            }
            else
            {
                if (Physics.gravity != upGravity)
                {
                    Physics.gravity = upGravity;
                }
            }

            currentTime = 0;

            if (numberOfJumps == 2)
            {
                //cameraShake.Play();
            }

            numberOfJumps = 0;
        }

        if (collision.gameObject.CompareTag(GroundCeil) && currentGround == GroundFloor)
        {
            PlayLandHitEffect();
        }
        else if (collision.gameObject.CompareTag(GroundFloor) && currentGround == GroundCeil)
        {
            PlayLandHitEffect();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(currentGround))
        {
            rb.useGravity = true;
            groundExit = true;
            groundEnter = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(currentGround) && playerSpawner.isDisolveEffectDone)
        {
            //StartCoroutine(cameraShake.Shake(0.15f, movementSpeed * cameraShakeMagnitude));
        }

        if (other.gameObject.CompareTag("ChangeGravityArea"))
        {
            Physics.gravity = changingGravity;
            isDownGravity = false;
            isGravityChanged = true;

            if (upVelocity > 0)
            {
                upVelocity *= -1;
            }

            currentGround = GroundCeil;
        }

        if(other.gameObject.CompareTag("Diamonds"))
        {
            diamondCollectEffect = objectPooler.SpawnFormPool("DiamondCollect", other.gameObject.transform.position, Quaternion.identity);
            diamondCollectEffect.GetComponent<ParticleSystem>().Play();
            other.gameObject.SetActive(false);

            inGameMenu.DiamondCollected();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ChangeGravityArea") && Physics.gravity != upGravity)
        {
            Physics.gravity = upGravity;
            isDownGravity = false;
            isGravityChanged = true;

            if (upVelocity > 0)
            {
                upVelocity *= -1;
            }

            if (currentGround != GroundCeil)
            {
                currentGround = GroundCeil;
            }
        }

        if (other.gameObject.CompareTag("Diamonds"))
        {
            if (other.gameObject.activeSelf)
            {
                diamondCollectEffect = objectPooler.SpawnFormPool("DiamondCollect", other.gameObject.transform.position, Quaternion.identity);
                diamondCollectEffect.GetComponent<ParticleSystem>().Play();
                other.gameObject.SetActive(false);

                inGameMenu.DiamondCollected();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ChangeGravityArea"))
        {
            Physics.gravity = changingGravity * -1f;
            isDownGravity = true;
            isGravityChanged = true;

            if (upVelocity < 0)
            {
                upVelocity *= -1;
            }

            currentGround = GroundFloor;
        }
    }

    void PlayLandEffect()
    {
        if(isReviving)
        {
            return;
        }

        if (groundEnter && (numberOfJumps > 0 || currentTime > checkTime))
        {
            spawnedLandEffect = objectPooler.SpawnFormPool("land_particle", transform.position + landEffectOffSet, Quaternion.Euler(landEffectRotation));
            spawnedLandEffect.GetComponent<ParticleSystem>().Play();
        }
    }

    void PlayLandHitEffect()
    {
        if (isReviving)
        {
            return;
        }

        spawnedLandEffect = objectPooler.SpawnFormPool("land_particle", transform.position + landEffectOffSet, Quaternion.Euler(landEffectRotation));
        spawnedLandEffect.GetComponent<ParticleSystem>().Play();
    }

    public void SetMovementActivateState(bool state)
    {
        isMovementActivated = state;
    }

}
