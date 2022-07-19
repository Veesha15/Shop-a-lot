using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField] Button playButton;

    private void Awake()
    {
        playButton.onClick.AddListener(LoadMainScene);
    }


    private void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }
}
