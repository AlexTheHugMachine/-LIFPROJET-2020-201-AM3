﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;
public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public Dropdown resolutionDropdown;
    
    Resolution[] resolutions;

    public Slider musicSlider;
    public Slider soundSlider;

    public GameObject settingsWindow;


    //Procédure d'initialisation
    public void Start()
    {
        audioMixer.GetFloat("Music", out float musicValueForSlider);
        musicSlider.value = musicValueForSlider;

        audioMixer.GetFloat("Sound", out float soundValueForSlider);
        soundSlider.value = soundValueForSlider;
        

        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        resolutionDropdown.ClearOptions();
        
        List<string> options = new List<string>();
        
        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            
            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
            
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        
        Screen.fullScreen = true;
    }
    
    //Procédure modifier la musique du jeux
    public void SetVolume(float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("Music", volume);
    }

    //Procédure modifier les effets sonores du jeux
    public void SetSoundVolume(float volume)
    {
        audioMixer.SetFloat("Sound", volume);
    }
    
    //Procédure plein écran 
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    
    //Procédure changement de résolution
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //Procédure fermer la fenêtre de paramêtres
    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }

    //Procédure qui supprime tous les données pour recommencer à zéro
    public void ClearSaveData()
    {
        PlayerPrefs.DeleteAll();
    }
   
}