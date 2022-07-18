using UnityEngine;
using UnityEngine.UI;

public class CloseButton : MonoBehaviour // attached to prefab
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(CloseWindow);
    }

    private void CloseWindow()
    {
        transform.parent.gameObject.SetActive(false); // close parent window
        AudioManager.Instance.PlayButtonClick();
    }
    

}
