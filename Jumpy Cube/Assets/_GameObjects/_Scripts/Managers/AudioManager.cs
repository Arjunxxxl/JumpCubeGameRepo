using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("Player Sounds")]
    public AudioSource playerAudioSource_jump;
    public AudioSource playerAudioSource_land;
    public AudioSource playerAudioSource_death;
    public AudioSource gravitySwitchSource;
    [Space]
    public AudioClip jumpAudio;
    public AudioClip landAudio;
    public AudioClip deathAudio;
    public AudioClip gravitySwitchAudio;

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
        gravitySwitchSource.clip = gravitySwitchAudio;
    }
    #endregion

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

    public void PlayGravitySwitch()
    {
        gravitySwitchSource.Play();
    }
}
