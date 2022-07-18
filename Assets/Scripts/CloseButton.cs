using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour // attached to prefab
{
    private AudioManager AM;

    private void Awake()
    {
        AM = FindObjectOfType<AudioManager>();
        GetComponent<Button>().onClick.AddListener(CloseWindow);
    }

    private void CloseWindow()
    {
        transform.parent.gameObject.SetActive(false); // close parent window
        AM.PlayButtonClick();
    }
    

}
