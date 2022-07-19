using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : MonoBehaviour
{
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;


    private void Awake()
    {
        settingsButton.onClick.AddListener(OpenSettingsWindow);
        quitButton.onClick.AddListener(QuitGame);
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

}
