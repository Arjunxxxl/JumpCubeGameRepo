using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevelEndParticleSystem : MonoBehaviour
{
    public ParticleSystem levelEndEffect1;
    public ParticleSystem levelEndEffect2;

    string PLAYER_TAG = "Player";

    GameModeManager gameModeManager;

    private void Start()
    {
        gameModeManager = GameModeManager.Instance;

        if (levelEndEffect1.gameObject.activeSelf)
        {
            levelEndEffect1.gameObject.SetActive(false);
        }

        if (levelEndEffect2.gameObject.activeSelf)
        {
            levelEndEffect2.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {
            if(!gameModeManager)
            {
                gameModeManager = GameModeManager.Instance;
            }

            if (gameModeManager.gameMode == GameModeManager.GameMode.level)
            {
                if (!levelEndEffect1.gameObject.activeSelf)
                {
                    levelEndEffect1.gameObject.SetActive(true);
                }

                if (!levelEndEffect2.gameObject.activeSelf)
                {
                    levelEndEffect2.gameObject.SetActive(true);
                }

                levelEndEffect1.Play();
                levelEndEffect2.Play();
            }
        }
    }
}
