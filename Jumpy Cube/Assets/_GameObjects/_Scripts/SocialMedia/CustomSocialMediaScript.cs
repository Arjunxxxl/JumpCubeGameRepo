using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSocialMediaScript : MonoBehaviour
{
    [Header("Social Media Reward UI")]
    public GameObject rateRewardUI;
    public GameObject facebookRewardUI;
    public GameObject youtubeRewardUI;
    public GameObject instagramRewardUI;
    public GameObject shareRewardUI;

    #region LINKS FOR STORE PANEL
    string googlePlayLink_App = "market://details?id=com.kumobius.android.highrisers";
    string googlePlayLink_Browser = "https://play.google.com/store/apps/details?id=com.kumobius.android.highrisers";

    string facebookPageLink_App = "fb://page/page_id";
    string facebookPageLink_Browser = "https://www.facebook.com/Green-Leaf-Games-115076666594458/";

    string youtubePageLink_App = "https://www.youtube.com/channel/UCkK8xx0OXhQ6-5a4stKV7GQ";
    string youtubePageLink_Browser = "https://www.youtube.com/channel/UCkK8xx0OXhQ6-5a4stKV7GQ";

    string instagramPageLink_App = "https://www.facebook.com/Green-Leaf-Games-115076666594458/";
    string instagramPageLink_Browser = "https://www.facebook.com/Green-Leaf-Games-115076666594458/";
    #endregion

    #region LINKS FOR MAIN MENU
    string googlePlayLink_Home_App = "market://details?id=com.kumobius.android.highrisers";
    string googlePlayLink_Home_Browser = "https://play.google.com/store/apps/details?id=com.kumobius.android.highrisers";
    #endregion

    /*
      //  fb://page/PAGEIDNUMBER
      //  instagram://user?username=USERNAME
      //  tumblr://x-callback-url/blog?blogName=BLOGNAME
      //  twitter://user?user_id=USERID
      //  https://youtube.com/user/USERNAME
    */

    float rewardGivingDelay = 1.5f;
    int rewardValue = 100;

    bool rateOpen, rateOpenChecker, activateRateReward;
    bool facebookOpen, facebookOpenChecker, activateFacebookReward;
    bool youtubeOpen, youtubeOpenChecker, activateYoutubeReward;
    bool instagramOpen, instagramOpenChecker, activateInstagramReward;

    int rateRewardGiven;
    int facebookRewardGiven;
    int youtubeRewardGiven;
    int instagramRewardGiven;
    int shareRewardGiven;

    bool pageIsOpened;

    float buttomClickDelay;

    CustomStrings customStrings;
    Store store;
    DiamondScore diamondScore;
    ButtonClickCommandExecutionDelay buttonClickCommandExecutionDelay;
    TimelinePlayer timelinePlayer;

    // Start is called before the first frame update
    void Start()
    {
        customStrings = CustomStrings.Instance;
        store = Store.Instance;
        diamondScore = DiamondScore.Instance;
        buttonClickCommandExecutionDelay = ButtonClickCommandExecutionDelay.Instance;
        timelinePlayer = TimelinePlayer.Instance;

        buttomClickDelay = buttonClickCommandExecutionDelay.storeMenuCommandExecutionDelay;

        pageIsOpened = false;

        rateOpen = false;
        rateOpenChecker = false;
        activateRateReward = false;
        rateRewardGiven = PlayerPrefs.GetInt(customStrings.RATE_REWARD, 0);

        facebookOpen = false;
        facebookOpenChecker = false;
        activateFacebookReward = false;
        facebookRewardGiven = PlayerPrefs.GetInt(customStrings.FACEBOOK_REWARD, 0);

        youtubeOpen = false;
        youtubeOpenChecker = false;
        activateYoutubeReward = false;
        youtubeRewardGiven = PlayerPrefs.GetInt(customStrings.YOUTUBE_REWARD, 0);

        instagramOpen = false;
        instagramOpenChecker = false;
        activateInstagramReward = false;
        instagramRewardGiven = PlayerPrefs.GetInt(customStrings.INSTAGRAM_REWARD, 0);

        
        shareRewardGiven = PlayerPrefs.GetInt(customStrings.SHARE_REWARD, 0);

        if (facebookRewardGiven == 0) { facebookRewardUI.SetActive(true); } else { facebookRewardUI.SetActive(false); }
        if (rateRewardGiven == 0) { rateRewardUI.SetActive(true); } else { rateRewardUI.SetActive(false); }
        if (youtubeRewardGiven == 0) { youtubeRewardUI.SetActive(true); } else { youtubeRewardUI.SetActive(false); }
        if (instagramRewardGiven == 0) { instagramRewardUI.SetActive(true); } else { instagramRewardUI.SetActive(false); }
        if (shareRewardGiven == 0) { shareRewardUI.SetActive(true); } else { shareRewardUI.SetActive(false); }
    } 

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            pageIsOpened = pause;
        }

        if (facebookOpen)
        {
            if (!pause)
            {
                if (facebookOpenChecker)
                {
                    activateFacebookReward = true;
                    if (facebookRewardGiven == 0)
                    {
                        StartCoroutine("GiveReward");
                    }
                }
                facebookOpen = false;
                facebookOpenChecker = false;
            }
            else
            {
                facebookOpenChecker = true;
            }
        }
        else if (rateOpen)
        {
            if (!pause)
            {
                if (rateOpenChecker)
                {
                    activateRateReward = true;
                    if (rateRewardGiven == 0)
                    {
                        StartCoroutine("GiveReward");
                    }
                }
                rateOpen = false;
                rateOpenChecker = false;
            }
            else
            {
                rateOpenChecker = true;
            }
        }
        else if (youtubeOpen)
        {
            if (!pause)
            {
                if (youtubeOpenChecker)
                {
                    activateYoutubeReward = true;
                    if (youtubeRewardGiven == 0)
                    {
                        StartCoroutine("GiveReward");
                    }
                }
                youtubeOpen = false;
                youtubeOpenChecker = false;
            }
            else
            {
                youtubeOpenChecker = true;
            }
        }
        else if (instagramOpen)
        {
            if (!pause)
            {
                if (instagramOpenChecker)
                {
                    activateInstagramReward = true;
                    if (instagramRewardGiven == 0)
                    {
                        StartCoroutine("GiveReward");
                    }
                }
                instagramOpen = false;
                instagramOpenChecker = false;
            }
            else
            {
                instagramOpenChecker = true;
            }
        }
    }

    public void Open_GooglePlay_Store()
    {
       Invoke("OpenPlayStore_Function", buttomClickDelay);
    }
    
    void OpenPlayStore_Function()
    {
        pageIsOpened = false;
        rateOpen = true;
        StartCoroutine("OpenPlayStore");
    }

    IEnumerator OpenPlayStore()
    {
        Application.OpenURL(googlePlayLink_App);
        yield return null;

        if(!pageIsOpened)
        {
            Application.OpenURL(googlePlayLink_Browser);
        }

        pageIsOpened = true;
    }

    public void Open_Facebook_Store()
    {
        Invoke("OpenFacebook_Function", buttomClickDelay);
    }

    void OpenFacebook_Function()
    {
        pageIsOpened = false;
        facebookOpen = true;
        StartCoroutine("OpenFacebookPage");
    }

    IEnumerator OpenFacebookPage()
    {
        Application.OpenURL(facebookPageLink_App);

        yield return null;

        if (!pageIsOpened)
        {
            Application.OpenURL(facebookPageLink_Browser);
        }

        pageIsOpened = true;
    }

    public void Open_Youtube_Store()
    {
        Invoke("OpenYoutube_Function", buttomClickDelay);
    }

    void OpenYoutube_Function()
    {
        pageIsOpened = false;
        youtubeOpen = true;
        StartCoroutine("OpenYoutube");
    }

    IEnumerator OpenYoutube()
    {
        Application.OpenURL(youtubePageLink_App);
        yield return null;

        if (!pageIsOpened)
        {
            Application.OpenURL(youtubePageLink_Browser);
        }

        pageIsOpened = true;
    }

    public void Open_Instagram_Store()
    {
        Invoke("OpenInstagram_Function", buttomClickDelay);
    }

    void OpenInstagram_Function()
    {
        pageIsOpened = false;
        instagramOpen = true;
        StartCoroutine("OpenInstagram");
    }

    IEnumerator OpenInstagram()
    {
        Application.OpenURL(instagramPageLink_App);
        yield return null;

        if (!pageIsOpened)
        {
            Application.OpenURL(instagramPageLink_Browser);
        }

        pageIsOpened = true;
    }

    IEnumerator GiveReward()
    {
        yield return new WaitForSeconds(rewardGivingDelay);

        diamondScore.SaveDiamondsCollected(rewardValue, true);

        store.ownedDiamonds = diamondScore.GetDiamonds();
        store.ownedDiamondTxt.text = store.ownedDiamonds + "";

        if (activateFacebookReward)
        {
            facebookRewardGiven++;
            PlayerPrefs.SetInt(customStrings.FACEBOOK_REWARD, facebookRewardGiven);

            if (facebookRewardGiven == 0) { facebookRewardUI.SetActive(true); } else { facebookRewardUI.SetActive(false); }

            activateFacebookReward = false;
            
            timelinePlayer.PlayDiamondReward();
        }
        else if (activateRateReward)
        {
            rateRewardGiven++;
            PlayerPrefs.SetInt(customStrings.RATE_REWARD, rateRewardGiven);

            if (rateRewardGiven == 0) { rateRewardUI.SetActive(true); } else { rateRewardUI.SetActive(false); }

            activateRateReward = false;

            timelinePlayer.PlayDiamondReward();
        }
        else if (activateYoutubeReward)
        {
            youtubeRewardGiven++;
            PlayerPrefs.SetInt(customStrings.YOUTUBE_REWARD, youtubeRewardGiven);

            if (youtubeRewardGiven == 0) { youtubeRewardUI.SetActive(true); } else { youtubeRewardUI.SetActive(false); }

            activateYoutubeReward = false;

            timelinePlayer.PlayDiamondReward();
        }
        else if (activateInstagramReward)
        {
            instagramRewardGiven++;
            PlayerPrefs.SetInt(customStrings.INSTAGRAM_REWARD, instagramRewardGiven);

            if (instagramRewardGiven == 0) { instagramRewardUI.SetActive(true); } else { instagramRewardUI.SetActive(false); }

            activateInstagramReward = false;

            timelinePlayer.PlayDiamondReward();
        }
    }

    public IEnumerator GiveReward_ForSharing()
    {
        yield return new WaitForSeconds(rewardGivingDelay);

        diamondScore.SaveDiamondsCollected(rewardValue, true);

        store.ownedDiamonds = diamondScore.GetDiamonds();
        store.ownedDiamondTxt.text = store.ownedDiamonds + "";

        shareRewardGiven++;
        PlayerPrefs.SetInt(customStrings.SHARE_REWARD, shareRewardGiven);

        if (shareRewardGiven == 0) { shareRewardUI.SetActive(true); } else { shareRewardUI.SetActive(false); }
        
        timelinePlayer.PlayDiamondReward();
    }

    public void Open_GooglePlay_Home()
    {
        Invoke("OpenPlayStore_Home_Function", buttomClickDelay);
    }

    void OpenPlayStore_Home_Function()
    {
        pageIsOpened = false;
        StartCoroutine("OpenPlayStore_Home");
    }

    IEnumerator OpenPlayStore_Home()
    {
        Application.OpenURL(googlePlayLink_Home_App);
        yield return null;

        if (!pageIsOpened)
        {
            Application.OpenURL(googlePlayLink_Home_Browser);
        }

        pageIsOpened = true;
    }
}
