using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public string TUTORIAL_MESSAGE = "TutorialMessage";
    public string TUTORIAL_COMPLETE = "TutorialCompleted";

    [Space]
    public GameObject tutorialMessageParent;

    [Header("Time Slowing Data")]
    public float normalDeltaTime = 1;
    public float slowingDeltaTime = 0.25f;
    public float slowingSpeed = 0.2f;
    public float increasingSpeed = 0.5f;
    public bool slowTime;
    public bool slowTimeLastTutorialTile;

    Touch touch;
    bool isTutorialActive;
    int i;

    bool disableTouch;
    float disableTouchDuration = 0.25f;

    List<TutorialMessage> messageList;
    TutorialMessage message;

    GameModeManager gameModeManager;
    CustomStrings customStrings;
    PlayerDeath playerDeath;
    TimelinePlayer timelinePlayer;
    PauseMenu pauseMenu;
    DistanceScore distanceScore;

    private void Start()
    {
        gameModeManager = GameModeManager.Instance;
        customStrings = CustomStrings.Instance;
        playerDeath = PlayerDeath.Instance;
        timelinePlayer = TimelinePlayer.Instance;
        pauseMenu = PauseMenu.Instance;
        distanceScore = DistanceScore.Instance;

        slowTime = false;
        slowTimeLastTutorialTile = false;
        Time.timeScale = 1;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;

        isTutorialActive = PlayerPrefs.GetInt(customStrings.TUTORIAL_COMPLETED, 0) == 0 ? true : true /*false*/;

        distanceScore.isTutorialActive = isTutorialActive;

        disableTouch = false;

        if (isTutorialActive)
        {
            if(!tutorialMessageParent.activeSelf)
            {
                tutorialMessageParent.SetActive(true);
            }

            messageList = new List<TutorialMessage>();
        }
        else
        {
            if (tutorialMessageParent.activeSelf)
            {
                tutorialMessageParent.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if(!gameModeManager.isTutorialActive && !slowTimeLastTutorialTile)
        {
            return;
        }

        if(pauseMenu.isPaused)
        {
            return;
        }

        if(slowTime)
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, slowingDeltaTime, slowingSpeed * Time.unscaledDeltaTime);
        }
        else
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, normalDeltaTime, increasingSpeed * Time.unscaledDeltaTime);
        }
        
        Time.fixedDeltaTime = Time.timeScale * 0.02f;

        if (slowTimeLastTutorialTile && !slowTime)
        {
            if (Mathf.Abs(Time.timeScale - normalDeltaTime) < 0.1f)
            {
                Time.timeScale = 1;
                slowTimeLastTutorialTile = false;
                DeactivateTutorial();
            }
        }

        if(playerDeath.isDead)
        {
            if(messageList.Count > 0)
            {
                for (i = 0; i < messageList.Count; i++)
                {
                    if (messageList[i])
                    {
                        messageList[i].HideMessage();

                        messageList.Remove(messageList[i]);
                    }
                }
            }

            timelinePlayer.PlayTryAgainMessage();

            slowTime = false;
        }

        #region EDITOR CONTROLS
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            slowTime = false;

            if(disableTouch)
            {
                return;
            }

            if (messageList.Count > 0)
            {
                for (i = messageList.Count - 1; i >= 0; i--)
                {
                    if (messageList[i])
                    {
                        messageList[i].HideMessage();

                        messageList.Remove(messageList[i]);
                    }
                }
            }
        }
#endif
        #endregion

        #region ANDROID CONTROLS
#if UNITY_ANDROID
        if (Input.touchCount > 1)
        {
            touch = Input.GetTouch(1);

            if (touch.phase == TouchPhase.Began)
            {
                slowTime = false;

                if (messageList.Count > 0)
                {
                    for (i = messageList.Count - 1; i >= 0; i--)
                    {
                        if (messageList[i])
                        {
                            messageList[i].HideMessage();

                            messageList.Remove(messageList[i]);
                        }
                    }
                }
            }
        }
        else if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                slowTime = false;

                if (messageList.Count > 0)
                {
                    for (i = messageList.Count - 1; i >= 0; i--)
                    {
                        if (messageList[i])
                        {
                            messageList[i].HideMessage();

                            messageList.Remove(messageList[i]);
                        }
                    }
                }
            }
        }
#endif
        #endregion
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(TUTORIAL_MESSAGE))
        {
            slowTime = true;

            if (messageList.Count > 0)
            {
                for (i = 0; i < messageList.Count; i++)
                {
                    if (messageList[i])
                    {
                        messageList[i].HideMessage();

                        messageList.Remove(messageList[i]);
                    }
                }
            }

            message = other.GetComponent<TutorialMessage>();
            message.ShowMessage();
            messageList.Add(message);

            disableTouch = true;
            StartCoroutine(EnableTouch());
        }

        if (other.CompareTag(TUTORIAL_COMPLETE))
        {
            slowTime = true;
            slowTimeLastTutorialTile = true;

            if (messageList.Count > 0)
            {
                for (i = 0; i < messageList.Count; i++)
                {
                    if (messageList[i])
                    {
                        messageList[i].HideMessage();

                        messageList.Remove(messageList[i]);
                    }
                }
            }

            message = other.GetComponent<TutorialMessage>();
            message.ShowMessage();
            messageList.Add(message);

            PlayerPrefs.SetInt(customStrings.TUTORIAL_COMPLETED, 1);

            distanceScore.isTutorialActive = false;

            disableTouch = true;
            StartCoroutine(EnableTouch());
        }
    }

    void DeactivateTutorial()
    {
        gameModeManager.isTutorialActive = false;         // used in player killer and other scripts

        if (tutorialMessageParent.activeSelf)
        {
            tutorialMessageParent.SetActive(false);
        }
    }

    IEnumerator EnableTouch()
    {
        yield return new WaitForSecondsRealtime(disableTouchDuration);
        
        disableTouch = false;
    }
}
