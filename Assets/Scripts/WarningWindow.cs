using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WarningWindow : MonoBehaviour // attached to Game Manager
{
    [SerializeField] GameObject warningWindow;
    [SerializeField] Image warningImage;
    [SerializeField] TextMeshProUGUI warningText;
    
    public WarningObject moneyWarning, inventoryWarning;

    public void DisplayWindow(WarningObject _object) // window is closed by assigning warning window game object to button in Inspector
    {
        warningText.text = _object.text;
        warningImage.sprite = _object.icon;
        warningWindow.SetActive(true);
    }
}
