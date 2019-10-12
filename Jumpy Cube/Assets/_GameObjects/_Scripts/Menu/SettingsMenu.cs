﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [Header("Game Audio Mixer")]
    public AudioMixer mainMixer;

    [Header("Button Images and text")]
    public Image soundImg;
    public Image soungBG;
    public Image vibrationImg;
    public Image vibrationBg;
    public TMP_Text highqualityText;
    public Image highQualityBg;

    [Header("Button Sprites")]
    public Sprite buttonON;
    public Sprite buttonOFF;
    public Sprite soundON;
    public Sprite soundOFF;
    public Sprite vibrationON;
    public Sprite vibrationOFF;

    [Header("Saved Data Info")]
    public int isSoundOn;
    public int isVibrationOn;
    public int isHighQalityOn;

    string on = "ON";
    string off = "OFF";

    CustomStrings customStrings;

    // Start is called before the first frame update
    void Start()
    {
        customStrings = CustomStrings.Instance;

        isSoundOn = PlayerPrefs.GetInt(customStrings.GAME_SOUND_STRING, 1);
        isVibrationOn = PlayerPrefs.GetInt(customStrings.VIBRATION_STRING, 1);
        isHighQalityOn = PlayerPrefs.GetInt(customStrings.HIGH_QUALITY_STRING, 1);

        if(isSoundOn == 1)
        {
            soundImg.sprite = soundON;
            soungBG.sprite = buttonON;
        }
        else
        {
            soundImg.sprite = soundOFF;
            soungBG.sprite = buttonOFF;
        }

        if (isVibrationOn == 1)
        {
            vibrationImg.sprite = vibrationON;
            vibrationBg.sprite = buttonON;
        }
        else
        {
            vibrationImg.sprite = vibrationOFF;
            vibrationBg.sprite = buttonOFF;
        }

        if (isHighQalityOn == 1)
        {
            highqualityText.text = on;
            highQualityBg.sprite = buttonON;
        }
        else
        {
            highqualityText.text = off;
            highQualityBg.sprite = buttonOFF;
        }
    }
    
    public void SoundButtonPressed()
    {
        isSoundOn = PlayerPrefs.GetInt(customStrings.GAME_SOUND_STRING, 1);

        if (isSoundOn == 1)
        {
            soundImg.sprite = soundOFF;
            soungBG.sprite = buttonOFF;
            isSoundOn = 0;
            mainMixer.SetFloat("mastervolume", -80f);
        }
        else
        {
            soundImg.sprite = soundON;
            soungBG.sprite = buttonON;
            isSoundOn = 1;
            mainMixer.SetFloat("mastervolume", 0f);
        }

        PlayerPrefs.SetInt(customStrings.GAME_SOUND_STRING, isSoundOn);
    }

    public void VibrationButtonPressed()
    {
        isVibrationOn = PlayerPrefs.GetInt(customStrings.VIBRATION_STRING, 1);

        if (isVibrationOn == 1)
        {
            vibrationImg.sprite = vibrationOFF;
            vibrationBg.sprite = buttonOFF;
            isVibrationOn = 0;
        }
        else
        {
            vibrationImg.sprite = vibrationON;
            vibrationBg.sprite = buttonON;
            isVibrationOn = 1;
        }

        PlayerPrefs.SetInt(customStrings.VIBRATION_STRING, isVibrationOn);
    }

    public void HighQualityButtonPressed()
    {
        isHighQalityOn = PlayerPrefs.GetInt(customStrings.HIGH_QUALITY_STRING, 1);

        if (isHighQalityOn == 1)
        {
            highqualityText.text = off;
            highQualityBg.sprite = buttonOFF;
            isHighQalityOn = 0;
        }
        else
        {
            highqualityText.text = on;
            highQualityBg.sprite = buttonON;
            isHighQalityOn = 1;
        }

        PlayerPrefs.SetInt(customStrings.HIGH_QUALITY_STRING, isHighQalityOn);
    }

}
