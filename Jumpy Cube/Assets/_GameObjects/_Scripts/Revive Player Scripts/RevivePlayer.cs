using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivePlayer : MonoBehaviour
{
    [Header("Menues")]
    public GameObject inGameMenu;
    public GameObject gameOverMenuObj;
    public GameObject revivalMenu;
    public GameObject countDownMenu;
    
    [Header("Revival Data")]
    public float afterRevivalTime = 0;
    public float afterReviveDelay = 2.95f;

    public GameObject player;
    public GameObject revivalPoint;
    public bool isDead;
    public GameObject cube;
    public GameObject deathParticleSystem;

    PlayerDeath playerDeath;
    PlayerMovement playerMovement;
    PlayerSpawner playerSpawner;
    GameOverMenu gameOverMenu;
    TimelinePlayer timelinePlayer;
    PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        playerDeath = PlayerDeath.Instance;
        gameOverMenu = GameOverMenu.Instance;
        playerMovement = PlayerMovement.Instance;
        playerSpawner = PlayerSpawner.Instance;
        timelinePlayer = TimelinePlayer.Instance;
        pauseMenu = PauseMenu.Instance;

        isDead = playerDeath.isDead;
        
        afterRevivalTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        isDead = playerDeath.isDead;

        if (countDownMenu.activeSelf)
        {
            afterRevivalTime += Time.unscaledDeltaTime;
            pauseMenu.afterResumeTxt.text = "" + (3 - (int)afterRevivalTime);
        }
    }

    public void ReviePlayerFunction()
    {
        if(isDead)
        {
            revivalPoint = playerDeath.revialPointObj;
            player.transform.position = revivalPoint.transform.position;
            player.transform.rotation = Quaternion.identity;

            cube = playerDeath.cube;
            deathParticleSystem = playerDeath.deathParticleSystem;

            cube.SetActive(true);
            deathParticleSystem.SetActive(false);

            PlayerIsRevived();
            playerDeath.isDead = false;

            playerMovement.SetMovementActivateState(false);
            playerMovement.isReviving = true;
            playerMovement.playerTrail.enabled = false;

            playerSpawner.isDisolveEffectDone = false;
            playerSpawner.disolveEffect = 0;
        }
    }

    public void SkipRevivalMenuButton()
    {
        revivalMenu.SetActive(false);
        gameOverMenuObj.SetActive(true);
    }

    public void PlayerIsRevived()
    {
        revivalMenu.SetActive(false);
        countDownMenu.SetActive(true);

        afterRevivalTime = 0;

        timelinePlayer.PlayResumeCountDown();

        StartCoroutine(AfterReviveDelayDalay());
    }

    IEnumerator AfterReviveDelayDalay()
    {
        yield return new WaitForSecondsRealtime(afterReviveDelay);
        countDownMenu.SetActive(false);
        inGameMenu.SetActive(true);

        timelinePlayer.StopResumeCountDown();

        gameOverMenu.checker = false;
        gameOverMenu.currentTime = 0;

        playerMovement.isReviving = false;
        playerMovement.playerTrail.enabled = true;
        playerMovement.SetMovementActivateState(true);
    }

}
