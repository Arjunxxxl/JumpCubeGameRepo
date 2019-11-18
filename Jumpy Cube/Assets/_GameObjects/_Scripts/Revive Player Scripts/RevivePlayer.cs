using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RevivePlayer : MonoBehaviour
{
    public float reviveScreenCommandExecutionDelay;

    [Header("Menues")]
    public GameObject inGameMenu;
    public GameObject gameOverMenuObj;
    public GameObject revivalMenu;
    public GameObject countDownMenu;
    
    [Header("Revival Data")]
    public float afterRevivalTime = 0;
    public float afterReviveDelay = 2.95f;
    public TMP_Text reviveTimer;

    [Header("Game Over Menu Text fields")]
    public TMP_Text currentScoreTxt;
    public TMP_Text currentDiamondsTxt;
    public TMP_Text averageScoreTxt;

    [Header("HighScore Data")]
    public GameObject score_best;
    public GameObject diamonds_best;
    public GameObject average_best;
    public int highScore;
    public int diamondBest;
    public int averageBest;
    public float trophyShowingDelay = 1.25f;
    public float trophyScowingOffset = 0.5f;

    [Header("Score Data")]
    public int currentScore;
    public int currentDiamonds;
    public float averageScore;

    [Header("Revival Menu Buttons")]
    public Button watchAdsButton;
    public Button useCoinButton;
    public Button skipButton;
    [Space]
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
    DistanceScore distanceScore;
    InGameMenu inGamemenu;
    CustomStrings customStrings;
    ButtonClickCommandExecutionDelay buttonClickCommandExecutionDelay;
    PlayerKiller playerKiller;
    CustomAdManager customAdManager;
    DiamondScore diamondScore;

    #region SingleTon
    public static RevivePlayer Instance;
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
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        playerDeath = PlayerDeath.Instance;
        gameOverMenu = GameOverMenu.Instance;
        playerMovement = PlayerMovement.Instance;
        playerSpawner = PlayerSpawner.Instance;
        timelinePlayer = TimelinePlayer.Instance;
        distanceScore = DistanceScore.Instance;
        inGamemenu = InGameMenu.Instance;
        customStrings = CustomStrings.Instance;
        buttonClickCommandExecutionDelay = ButtonClickCommandExecutionDelay.Instance;
        playerKiller = PlayerKiller.Instance;
        customAdManager = CustomAdManager.Instance;
        diamondScore = DiamondScore.Instance;

        reviveScreenCommandExecutionDelay = buttonClickCommandExecutionDelay.revivalMenuCommandExecutionDelay;

        isDead = playerDeath.isDead;
        
        afterRevivalTime = 0;

        score_best.SetActive(false);
        diamonds_best.SetActive(false);
        average_best.SetActive(false);
        highScore = PlayerPrefs.GetInt(customStrings.HIGHSCORE, 0);
        diamondBest = PlayerPrefs.GetInt(customStrings.DIAMONDS_COLLECTED_IN_ONE_RUN1, 0);
        averageBest = (int)PlayerPrefs.GetFloat(customStrings.AVERAGE_SCORE_2, 0);

        if(!watchAdsButton.interactable)
        {
            watchAdsButton.interactable = true;
        }
        if (!useCoinButton.interactable)
        {
            useCoinButton.interactable = true;
        }
        if (!skipButton.interactable)
        {
            skipButton.interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isDead = playerDeath.isDead;

        if (countDownMenu.activeSelf)
        {
            afterRevivalTime += Time.unscaledDeltaTime;
            reviveTimer.text = "" + (3 - (int)afterRevivalTime);
        }
    }

    public void ReviePlayerFunction()
    {
        DisableAllButtons();

        diamondScore.CubeBought(100);

        Invoke("RevivePlayer_Function", reviveScreenCommandExecutionDelay);
    }

    public void RevivePlayer_Tutorial()
    {
        Invoke("RevivePlayer_Function", reviveScreenCommandExecutionDelay);
    }

    public void ReviePlayerFunction_AdReward()
    {
        Invoke("RevivePlayer_Function", reviveScreenCommandExecutionDelay);
    }

    public void ReviePlayerFunction_Ads()
    {
        DisableAllButtons();

        Invoke("WatchAds_Function", reviveScreenCommandExecutionDelay);
    }

    void WatchAds_Function()
    {
        customAdManager.ShowRewardingAds_ExtraLife();
        EnableAllButtons();
    }

    void RevivePlayer_Function()
    {
        if (isDead)
        {
            revivalPoint = playerDeath.revialPointObj;
            player.transform.position = revivalPoint.transform.position;
            player.transform.rotation = Quaternion.identity;

            cube = playerDeath.cube;
            deathParticleSystem = playerDeath.deathParticleSystem;

            cube.SetActive(true);
            deathParticleSystem.SetActive(false);

            if (playerKiller.killPlayer)
            {
                playerKiller.killPlayer = false;
                playerKiller.currentTime = 0;
            }

            PlayerIsRevived();
            playerDeath.isDead = false;

            playerMovement.SetMovementActivateState(false);
            playerMovement.isReviving = true;
            playerMovement.playerTrail.enabled = false;
            playerMovement.movementSpeed = playerMovement.speed_setThisToSetMovementSpeed;

            playerSpawner.isDisolveEffectDone = false;
            playerSpawner.disolveEffect = 0;
        }
        
        EnableAllButtons();
    }

    public void SkipRevivalMenuButton()
    {
        DisableAllButtons();
        Invoke("SkipRevival_Function", reviveScreenCommandExecutionDelay);
    }

    void SkipRevival_Function()
    {
        revivalMenu.SetActive(false);
        gameOverMenuObj.SetActive(true);

        averageScore = PlayerPrefs.GetFloat(customStrings.AVERAGE_SCORE_2, 0);
        currentScore = distanceScore.distance;
        currentDiamonds = inGamemenu.diamondsCollected;

        currentScoreTxt.text = currentScore + "m";
        currentDiamondsTxt.text = currentDiamonds + "";
        averageScoreTxt.text = (int)averageScore + "m";

        CheckForHighScore();

        EnableAllButtons();
    }

    public void PlayerIsRevived()
    {
        revivalMenu.SetActive(false);
        countDownMenu.SetActive(true);

        afterRevivalTime = 0;

        timelinePlayer.PlayResumeCountDown();

        StartCoroutine(AfterReviveDelayDalay());

        EnableAllButtons();
    }

    IEnumerator AfterReviveDelayDalay()
    {
        yield return new WaitForSecondsRealtime(afterReviveDelay);
        countDownMenu.SetActive(false);
        inGameMenu.SetActive(true);

        timelinePlayer.StopResumeCountDown();
        timelinePlayer.PlayIngameMenuActivated();

        gameOverMenu.checker = false;
        gameOverMenu.currentTime = 0;

        playerMovement.isReviving = false;
        playerMovement.playerTrail.enabled = true;
        playerMovement.SetMovementActivateState(true);
    }

    void CheckForHighScore()
    {
        if (currentScore > highScore)
        {
            StartCoroutine("ShowScoreBestTophy");
        }
        
        if (currentDiamonds > diamondBest)
        {
            StartCoroutine("ShowDiamondBestTrophy");
        }

        if (averageScore > averageBest)
        {
            StartCoroutine("ShowAverageBestTrophy");
        }
    }

    IEnumerator ShowScoreBestTophy()
    {
        yield return new WaitForSeconds(trophyShowingDelay);
        score_best.SetActive(true);
        timelinePlayer.PlayScoreBest();
    }

    IEnumerator ShowDiamondBestTrophy()
    {
        yield return new WaitForSeconds(trophyShowingDelay + trophyScowingOffset);
        diamonds_best.SetActive(true);
        timelinePlayer.PlayDiamondsBest();
    }

    IEnumerator ShowAverageBestTrophy()
    {
        yield return new WaitForSeconds(trophyShowingDelay + trophyScowingOffset + trophyScowingOffset);
        average_best.SetActive(true);
        timelinePlayer.PlayAverageBest();
    }

    void DisableAllButtons()
    {
        if (watchAdsButton.interactable)
        {
            watchAdsButton.interactable = false;
        }
        if (useCoinButton.interactable)
        {
            useCoinButton.interactable = false;
        }
        if (skipButton.interactable)
        {
            skipButton.interactable = false;
        }
    }

    void EnableAllButtons()
    {
        if (!watchAdsButton.interactable)
        {
            watchAdsButton.interactable = true;
        }
        if (!useCoinButton.interactable)
        {
            useCoinButton.interactable = true;
        }
        if (!skipButton.interactable)
        {
            skipButton.interactable = true;
        }
    }
}
