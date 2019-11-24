using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public enum GameState { gameStart, gamePlaying, playerDead, inTheMenues, gamePaused, adsOpened}

public class BackgroundAudioManager : MonoBehaviour
{
    public GameState gameState;
    GameState previousState;

    public AudioSource audioSource;

    float gameStartVolume = 0.15f;
    float gamePlayingVolume = 0.7f;
    float playerDeadVolume = 0.2f;
    float inTheMenuesVolume = 0.08f;
    float gamePausedVolume = 0.3f;

    float currentVolume;
    float volumeLerpSpeed = 5f;

    #region SingleTon
    public static BackgroundAudioManager Instance;
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

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if (!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
        }

        currentVolume = gameStartVolume;
        audioSource.volume = currentVolume;

        previousState = GameState.gameStart;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState == GameState.gameStart)
        {
            if (currentVolume != gameStartVolume)
            {
                currentVolume = Mathf.Lerp(currentVolume, gameStartVolume, Time.unscaledDeltaTime * volumeLerpSpeed);
                audioSource.volume = currentVolume;
            }
        }
        else if (gameState == GameState.gamePlaying)
        {
            if (currentVolume != gamePlayingVolume)
            {
                currentVolume = Mathf.Lerp(currentVolume, gamePlayingVolume, Time.unscaledDeltaTime * 1);
                audioSource.volume = currentVolume;
            }
        }
        else if (gameState == GameState.playerDead)
        {
            if (currentVolume != playerDeadVolume)
            {
                currentVolume = Mathf.Lerp(currentVolume, playerDeadVolume, Time.unscaledDeltaTime * 1);
                audioSource.volume = currentVolume;
            }
        }
        else if (gameState == GameState.gamePaused)
        {
            if (currentVolume != gamePausedVolume)
            {
                currentVolume = Mathf.Lerp(currentVolume, gamePausedVolume, Time.unscaledDeltaTime * volumeLerpSpeed);
                audioSource.volume = currentVolume;
            }
        }
        else if (gameState == GameState.inTheMenues)
        {
            if (currentVolume != inTheMenuesVolume)
            {
                currentVolume = Mathf.Lerp(currentVolume, inTheMenuesVolume, Time.unscaledDeltaTime * volumeLerpSpeed);
                audioSource.volume = currentVolume;
            }
        }
        else if (gameState == GameState.adsOpened)
        {
            if (currentVolume != 0)
            {
                currentVolume = 0;
                audioSource.volume = currentVolume;
            }
        }
    }
    

    private void OnApplicationQuit()
    {
        currentVolume = 0;
        previousState = gameState;
        audioSource.volume = currentVolume;
    }

    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            currentVolume = 0;
            previousState = gameState;
            audioSource.volume = currentVolume;
        }
        else
        {
            gameState = previousState;
        }
    }
}
