using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SharingAppScript : MonoBehaviour
{
    public Sprite socialMediaShareImg;

    Texture2D shareTexture;
    byte[] imageBytes;

    string path;
    string directory;

    bool sharing, sharingChecker;
    int sharingRewardGiven;
    
    float buttonClickDelay;

    ButtonClickCommandExecutionDelay buttonClickCommandExecutionDelay;
    CustomStrings customStrings;
    CustomSocialMediaScript customSocialMediaScript;
    CustomAnalytics customAnalytics;

    void Awake()
    {
        #if UNITY_ANDROID
        path = Path.Combine(Application.persistentDataPath, "SocialMedia/SocialMediaImage.png");
        #endif
        #if UNITY_EDITOR
        path = "SocialMediaImage.png";
        #endif

        customSocialMediaScript = GetComponent<CustomSocialMediaScript>();

        if (!File.Exists(path))
        {
            #if UNITY_ANDROID
            directory = Path.Combine(Application.persistentDataPath, "SocialMedia");
            Directory.CreateDirectory(directory);
            #endif

            SaveImageToDevice();
        }
    }

    private void Start()
    {
        buttonClickCommandExecutionDelay = ButtonClickCommandExecutionDelay.Instance;
        customStrings = CustomStrings.Instance;
        customAnalytics = CustomAnalytics.Instance;

        buttonClickDelay = buttonClickCommandExecutionDelay.storeMenuCommandExecutionDelay;

        sharingRewardGiven = PlayerPrefs.GetInt(customStrings.SHARE_REWARD, 0);
    }

    private void OnApplicationPause(bool pause)
    {
        if (sharing)
        {
            if (!pause)
            {
                if (sharingChecker)
                {
                    if (sharingRewardGiven == 0)
                    {
                        sharingRewardGiven++;

                        StartCoroutine(customSocialMediaScript.GiveReward_ForSharing());
                    }
                }
                sharing = false;
                sharingChecker = false;
            }
            else
            {
                sharingChecker = true;
            }
        }
    }

    void SaveImageToDevice()
    {
        shareTexture = socialMediaShareImg.texture;

        imageBytes = new byte[0];
        imageBytes = shareTexture.EncodeToPNG();
        File.WriteAllBytes(path, imageBytes);
    }

    public void ShareSocialMedia_Store()
    {
        customAnalytics.GameShare_Store();
        Invoke("ShareSocialMedia_Store_Function", buttonClickDelay);
    }

    void ShareSocialMedia_Store_Function()
    {
        sharing = true;

        PlayerPrefs.SetInt(customStrings.SHARE_BUFFER, 1);

        new NativeShare().AddFile(path).SetSubject(customStrings.MSG_SUBJECT).SetText(customStrings.MSG_TEXT).SetTitle(customStrings.MSG_TITLE).Share();
    }

    public void ShareSocialMedia_Home()
    {
        customAnalytics.GameShared_Home();
        Invoke("ShareSocialMedia_Home_Function", buttonClickDelay);
    }

    void ShareSocialMedia_Home_Function()
    {
        new NativeShare().AddFile(path).SetSubject(customStrings.MSG_SUBJECT).SetText(customStrings.MSG_TEXT).SetTitle(customStrings.MSG_TITLE).Share();
    }
}
