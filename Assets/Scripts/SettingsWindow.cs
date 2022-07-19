using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : MonoBehaviour
{
    [SerializeField] private GameObject settingsWindow;

    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;

    [SerializeField] private Toggle musicToggle;
    [SerializeField] private AudioSource musicSource;

    [SerializeField] private Toggle soundToggle;
    [SerializeField] private AudioSource soundSource;


    private void Awake()
    {
        settingsButton.onClick.AddListener(OpenSettingsWindow);
        quitButton.onClick.AddListener(QuitGame);
        musicToggle.onValueChanged.AddListener(delegate { ToggleMusic(musicToggle); });
        soundToggle.onValueChanged.AddListener(delegate { ToggleSound(soundToggle); });
    }

    private void OpenSettingsWindow()
    {
        settingsWindow.SetActive(true);
        AudioManager.Instance.PlayButtonClick();
    }

    private void QuitGame()
    {
        Application.Quit();
    }


    // TODO: these are the same, find way to reduce code
    private void ToggleMusic(Toggle _toggle)
    {
        AudioManager.Instance.PlayButtonClick();

        if (_toggle.isOn)
        {
            musicSource.enabled = true;
        }

        else
        {
            musicSource.enabled = false;
        }  
    }


    private void ToggleSound(Toggle _toggle)
    {
        AudioManager.Instance.PlayButtonClick();

        if (_toggle.isOn)
        {
            soundSource.mute = false;
        }

        else
        {
            soundSource.mute = true;
        }
    }



}

