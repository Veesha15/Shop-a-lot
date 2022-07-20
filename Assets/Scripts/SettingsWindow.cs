using UnityEngine;
using UnityEngine.UI;

public class SettingsWindow : MonoBehaviour
{
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private Button settingsButton;
    
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private AudioSource musicSource;

    [SerializeField] private Toggle soundToggle;
    [SerializeField] private AudioSource soundSource;

    [SerializeField] private Button quitButton;
    [SerializeField] private Sprite defaultQuit, pendingQuit;
    private bool quitPending;
    private Image quitImage;

    private void Awake()
    {
        quitImage = quitButton.GetComponent<Image>();
        settingsButton.onClick.AddListener(OpenSettingsWindow);
        quitButton.onClick.AddListener(QuitGame);
        musicToggle.onValueChanged.AddListener(delegate { ToggleMusic(musicToggle); });
        soundToggle.onValueChanged.AddListener(delegate { ToggleSound(soundToggle); });
    }


    private void OpenSettingsWindow()
    {
        settingsWindow.SetActive(true);
        AudioManager.Instance.PlayButtonClick();
        quitPending = false;
        quitImage.sprite = defaultQuit;
    }


    private void QuitGame()
    {
        if (quitPending)
        {
            AudioManager.Instance.PlayButtonClick();
            Application.Quit();
        }

        else
        {
            AudioManager.Instance.PlaySound(AudioManager.Instance.notificationSound);
            quitPending = true;
            quitImage.sprite = pendingQuit;
        }
        
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

