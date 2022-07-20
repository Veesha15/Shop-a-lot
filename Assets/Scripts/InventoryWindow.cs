using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private GameObject inventoryWindow;
    [SerializeField] private Button inventoryButton;
    [SerializeField] private GameObject closeButton;

    [SerializeField] TextMeshProUGUI instructionsRightClick;

    private void OnEnable()
    {
        Shop.OpenWindowEvent += OpenInventory;
        Shop.CloseWindowEvent += CloseInventory;
    }

    private void OnDisable()
    {
        Shop.OpenWindowEvent -= OpenInventory;
        Shop.CloseWindowEvent -= CloseInventory;
    }


    private void Awake()
    {
        inventoryButton.onClick.AddListener(ToggleInventory);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    private void ToggleInventory()
    {
        AudioManager.Instance.PlayButtonClick();

        if (inventoryWindow.activeSelf == false)
        {
            OpenInventory();
        }

        else
        {
            if (!GameManager.ShopWindowOpen) // prevent inventory being closed when shop window is open
            {
                CloseInventory();
            }
            
        }
    }

    public void OpenInventory()
    {
        if (GameManager.ShopWindowOpen)
        {
            instructionsRightClick.text = "buy/\nsell";
            closeButton.SetActive(false);
        }

        else
        {
            instructionsRightClick.text = "equip/\nunequip";
            closeButton.SetActive(true);
        }

        inventoryWindow.SetActive(true);
    }

    public void CloseInventory()
    {
        inventoryWindow.SetActive(false);
    }
}
