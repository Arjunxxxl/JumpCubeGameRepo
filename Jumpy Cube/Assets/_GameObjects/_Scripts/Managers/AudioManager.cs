using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Player Sounds")]
    public AudioSource playerAudioSource_jump;
    public AudioSource playerAudioSource_land;
    public AudioSource playerAudioSource_death;
    public AudioSource playerAudioSource_diamond;
    public AudioSource gravitySwitchSource;
    [Space]
    public AudioClip jumpAudio;
    public AudioClip landAudio;
    public AudioClip deathAudio;
    public AudioClip diamondAudio;
    public AudioClip gravitySwitchAudio;

    [Header("Level Complete and highscore crossed Sound")]
    public AudioSource particleSystem_Source;
    public AudioSource clappingSource;
    [Space]
    public AudioClip particleSystemBoomAudio;
    public AudioClip clappingAudio;

    [Header("Mission Sound")]
    public AudioSource missionCompleteSource;
    [Space]
    public AudioClip missionCompleteAudio;

    [Header("Button Click")]
    public AudioSource buttonClickSource;
    public AudioSource buttonExitSource;
    [Space]
    public AudioClip buttonClickAudio;
    public AudioClip buttonExitAudio;

    [Header("Buy Sounds")]
    public AudioSource buySource;
    [Space]
    public AudioClip buyAudio;

    BackgroundAudioManager backgroundAudioManager;
    float buttonClickLowVolume = 0.3f;
    float buttonClickMedVolume = 0.5f;
    float buttonClickHighVolume = 0.8f;

    #region SingleTon
    public static AudioManager Instance;
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

        playerAudioSource_jump.clip = jumpAudio;
        playerAudioSource_land.clip = landAudio;
        playerAudioSource_death.clip = deathAudio;
        playerAudioSource_diamond.clip = diamondAudio;
        gravitySwitchSource.clip = gravitySwitchAudio;

        particleSystem_Source.clip = particleSystemBoomAudio;
        clappingSource.clip = clappingAudio;

        missionCompleteSource.clip = missionCompleteAudio;

        buttonClickSource.clip = buttonClickAudio;
        buttonExitSource.clip = buttonExitAudio;

        buySource.clip = buyAudio;
    }
    #endregion

    private void Start()
    {
        backgroundAudioManager = BackgroundAudioManager.Instance;

        buttonClickSource.volume = buttonClickLowVolume;
    }

    private void Update()
    {
        if(backgroundAudioManager.gameState == GameState.gamePlaying)
        {
            if(buttonClickSource.volume != buttonClickHighVolume)
            {
                buttonClickSource.volume = buttonClickHighVolume;
            }
        }
        else if (backgroundAudioManager.gameState == GameState.playerDead || backgroundAudioManager.gameState == GameState.gamePaused)
        {
            if (buttonClickSource.volume != buttonClickMedVolume)
            {
                buttonClickSource.volume = buttonClickMedVolume;
            }
        }
        else if (backgroundAudioManager.gameState == GameState.gameStart || backgroundAudioManager.gameState == GameState.inTheMenues)
        {
            if (buttonClickSource.volume != buttonClickLowVolume)
            {
                buttonClickSource.volume = buttonClickLowVolume;
            }
        }
    }

    public void PlayJumpAudio()
    {
        playerAudioSource_jump.Play();
    }

    public void PlayLandAudio()
    {
        playerAudioSource_land.Play();
    }

    public void PlayDeathAudio()
    {
        playerAudioSource_death.Play();
    }

    public void PlayDiamondAudio()
    {
        playerAudioSource_diamond.Play();
    }

    public void PlayGravitySwitch()
    {
        gravitySwitchSource.Play();
    }

    public void Play_LevelComplete_HighScoreCrossed()
    {
        particleSystem_Source.Play();
        clappingSource.Play();
    }

    public void Play_MissionCompleteAudio()
    {
        missionCompleteSource.Play();
    }

    public void PlayButtonClickAudio()
    {
        buttonClickSource.Play();
    }

    public void PlayButtonExitAudio()
    {
        buttonExitSource.Play();
    }

    public void PlayBuy_Success_Audio()
    {
        buySource.Play();
    }

    public void PlayBuy_Fail_Audio()
    {
        buttonExitSource.Play();
    }

    public void Set_InTheMenues()
    {
        backgroundAudioManager.gameState = GameState.inTheMenues;
    }

    public void Set_GamePlaying()
    {
        backgroundAudioManager.gameState = GameState.gamePlaying;
    }

    public void Set_PlayerDead()
    {
        backgroundAudioManager.gameState = GameState.playerDead;
    }

    public void Set_GameStart()
    {
        backgroundAudioManager.gameState = GameState.gameStart;
    }

    public void Set_AdsOpen()
    {
        backgroundAudioManager.gameState = GameState.adsOpened;
    }
}
