using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreScrolling : MonoBehaviour
{
    public int currentPannelIndex;

    [Header("Pannel name and color")]
    public TMP_Text pannelNameText;
    public Image pannelBG;
    public string[] pannelNameTextValue;
    public Color[] pannelNameBGcolor;
    public bool changeBGcolor;
    public float colorLerpSpeed = 15f;

    [Header("Panels positions")]
    public Vector2[] pannelsPositions;

    [Header("Position Data")]
    public Vector3 finalPos;

    [Header("Data")]
    public int maxNumberOfPannel = 2;
    public float autoScrollSpeed = 10f;
    public bool isAutoScroll;
    public float disableAutoScrollDist = 0.1f;

    [Header("Touch Data")]
    public Vector3 startPos;
    public Vector3 endPos;
    public Vector2 dxn;
    public float dist;
    public float minDistForAutoScrolling = 200f;
    public float minDistForFullScrolling = 500f;
    public float anchorPosX;

    [Header("Panels for optimization")]
    public GameObject[] panels;

    public RectTransform contentHolder;

    // Start is called before the first frame update
    void Start()
    {
        currentPannelIndex = 0;
        contentHolder.anchoredPosition = pannelsPositions[currentPannelIndex];
        isAutoScroll = false;

        finalPos = contentHolder.anchoredPosition;

        changeBGcolor = false;

        SetPannelName_Color(currentPannelIndex, true);
    }

    private void OnEnable()
    {
        for(int i = 0; i < panels.Length; i++)
        {
            if(i == 0 || i == 1)
            {
                if(!panels[i].activeSelf)
                {
                    panels[i].SetActive(true);
                }
            }
            else
            {
                if(panels[i].activeSelf)
                {
                    panels[i].SetActive(false);
                }
            }
        }
    }

    private void OnDisable()
    {
        currentPannelIndex = 0;
        contentHolder.anchoredPosition = pannelsPositions[currentPannelIndex];
        isAutoScroll = false;

        finalPos = contentHolder.anchoredPosition;

        changeBGcolor = false;

        SetPannelName_Color(currentPannelIndex, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isAutoScroll)
        {
            contentHolder.anchoredPosition = Vector3.Lerp(contentHolder.anchoredPosition, pannelsPositions[currentPannelIndex], Time.deltaTime * autoScrollSpeed);
            
            ActivateDeActivatePanels();

            if ((contentHolder.anchoredPosition - pannelsPositions[currentPannelIndex]).magnitude < disableAutoScrollDist)
            {
                isAutoScroll = false;
            }
        }

        if(changeBGcolor)
        {
            pannelBG.color = Color.Lerp(pannelBG.color, pannelNameBGcolor[currentPannelIndex], Time.deltaTime * colorLerpSpeed);

            if(pannelBG.color == pannelNameBGcolor[currentPannelIndex])
            {
                changeBGcolor = false;
            }
        }

        TouchScrolling();
    }

    public void LeftButton()
    {
        if (currentPannelIndex == 0)
        {
            return;
        }

        currentPannelIndex--;

        SetPannelName_Color(currentPannelIndex, false);

        isAutoScroll = true;

        ActivateDeActivatePanels();
    }

    public void RightButton()
    {
        if (currentPannelIndex == maxNumberOfPannel - 1)
        {
            return;
        }

        currentPannelIndex++;

        SetPannelName_Color(currentPannelIndex, false);

        isAutoScroll = true;

        ActivateDeActivatePanels();
    }

    public void TouchScrolling()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    isAutoScroll = false;

                    break;

                case TouchPhase.Moved:
                    endPos = touch.position;
                    dxn = endPos - startPos;
                    dist = dxn.magnitude;
                    dxn.Normalize();


                    if (Vector2.Dot(dxn, Vector3.right) < 0 && Mathf.Abs(Vector2.Dot(dxn, Vector2.up)) < 0.2f)
                    {
                        MoveContentRight();
                    }
                    else if (Vector2.Dot(dxn, Vector3.right) > 0 && Mathf.Abs(Vector2.Dot(dxn, Vector2.up)) < 0.2f)
                    {
                        MoveContentLeft();
                    }
                    break;

                case TouchPhase.Ended:
                    if (dist > minDistForAutoScrolling && Vector2.Dot(dxn, Vector3.right) < 0 && Mathf.Abs(Vector2.Dot(dxn, Vector2.up)) < 0.2f)
                    {
                        currentPannelIndex++;

                        if (currentPannelIndex > maxNumberOfPannel - 1)
                        {
                            currentPannelIndex = maxNumberOfPannel - 1;
                        }
                    }
                    else if (dist > minDistForAutoScrolling && Vector2.Dot(dxn, Vector3.right) > 0 && Mathf.Abs(Vector2.Dot(dxn, Vector2.up)) < 0.2f)
                    {
                        currentPannelIndex--;

                        if (currentPannelIndex < 0)
                        {
                            currentPannelIndex = 0;
                        }
                    }

                    SetPannelName_Color(currentPannelIndex, false);

                    isAutoScroll = true;
                    break;
            }
        }
    }

    void MoveContentRight()
    {
        if (currentPannelIndex < maxNumberOfPannel - 1)
        {
            anchorPosX = pannelsPositions[currentPannelIndex].x + (dist / minDistForFullScrolling) * (pannelsPositions[currentPannelIndex + 1].x - pannelsPositions[currentPannelIndex].x);

            finalPos.x = anchorPosX;

            contentHolder.anchoredPosition = finalPos;

        }
    }

    void MoveContentLeft()
    {
        if (currentPannelIndex > 0)
        {
            anchorPosX = pannelsPositions[currentPannelIndex].x + (dist / minDistForFullScrolling) * (pannelsPositions[currentPannelIndex - 1].x - pannelsPositions[currentPannelIndex].x);

            finalPos.x = anchorPosX;

            contentHolder.anchoredPosition = finalPos;

        }
    }

    void SetPannelName_Color(int pannelIndex, bool isGameObjectDisabled)
    {
        if(isGameObjectDisabled)
        {
            pannelNameText.text = pannelNameTextValue[pannelIndex];
            pannelBG.color = pannelNameBGcolor[pannelIndex];
            return;
        }
        changeBGcolor = true;
        pannelNameText.text = pannelNameTextValue[pannelIndex];
    }

    void ActivateDeActivatePanels()
    {
        if(currentPannelIndex == 0)
        {
            for(int i = 0; i < panels.Length; i++)
            {
                if (i == currentPannelIndex || i == currentPannelIndex + 1)
                {
                    if (!panels[i].activeSelf)
                    {
                        panels[i].SetActive(true);
                    }
                }
                else
                {
                    if (panels[i].activeSelf)
                    {
                        panels[i].SetActive(false);
                    }
                }
            }
        }
        else if(currentPannelIndex == panels.Length - 1)
        {
            for (int i = 0; i < panels.Length; i++)
            {
                if (i == currentPannelIndex || i == currentPannelIndex - 1)
                {
                    if (!panels[i].activeSelf)
                    {
                        panels[i].SetActive(true);
                    }
                }
                else
                {
                    if (panels[i].activeSelf)
                    {
                        panels[i].SetActive(false);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < panels.Length; i++)
            {
                if (i == currentPannelIndex || i == currentPannelIndex + 1 || i == currentPannelIndex - 1)
                {
                    if (!panels[i].activeSelf)
                    {
                        panels[i].SetActive(true);
                    }
                }
                else
                {
                    if (panels[i].activeSelf)
                    {
                        panels[i].SetActive(false);
                    }
                }
            }
        }
    }

}
