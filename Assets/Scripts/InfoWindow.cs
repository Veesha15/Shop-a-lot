using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoWindow : MonoBehaviour // attached to Game Manager
{
    [SerializeField] private RectTransform infoWindow; // rect because need to set anchor / pivot 
    [SerializeField] private Transform inventoryWindow;

    [SerializeField] TextMeshProUGUI infoName;
    [SerializeField] TextMeshProUGUI infoType;
    [SerializeField] TextMeshProUGUI infoPrice;

    [SerializeField] Button destroyButton;
    [SerializeField] Sprite binPending;
    [SerializeField] Sprite binConfirm;
    private Image destroyImage;

    private InventorySlot selectedSlot;

    private bool infoWindowIsOpen;
    private bool destroyIsPending;


    private void OnEnable()
    {
        InventorySlot.InfoEvent += ToggleInfoWindow;
        InventorySlot.SellEvent += CloseInfoWindow;
        InventorySlot.EquipEvent += CloseInfoWindow;
    }

    private void OnDisable()
    {
        InventorySlot.InfoEvent -= ToggleInfoWindow;
        InventorySlot.SellEvent -= CloseInfoWindow;
        InventorySlot.EquipEvent -= CloseInfoWindow;
    }


    private void Awake()
    {
        destroyButton.onClick.AddListener(DestroyItem);
        destroyImage = destroyButton.GetComponent<Image>();
    }

    private void ToggleInfoWindow(InventorySlot _clickedSlot)
    {
        if (infoWindowIsOpen && _clickedSlot == selectedSlot)
        {
            CloseInfoWindow(selectedSlot);
        }

        else
        {
            OpenInfoWindow(_clickedSlot);
        }
    }


    private void OpenInfoWindow(InventorySlot _clickedSlot)
    {
        selectedSlot = _clickedSlot;
        infoWindow.anchoredPosition = Vector2.zero; // reset postion other it will use previous position
        infoWindow.SetParent(_clickedSlot.transform, false);
        infoWindow.SetParent(inventoryWindow, true); // need to unparent to display on top of other slots

        infoName.text = _clickedSlot.item.name;
        infoType.text = ($"Wearable: {_clickedSlot.item.garmentType}");
        infoPrice.text = _clickedSlot.item.sellPrice.ToString();

        infoWindow.gameObject.SetActive(true);
        infoWindowIsOpen = true;

        ResetBin();
    }

    private void CloseInfoWindow(MainSlot _clickedSlot) // needs parameter because of event signature
    {
        infoWindow.gameObject.SetActive(false);
        selectedSlot = null;
        ResetBin();
    }


    public void DestroyItem()
    {
        if (destroyIsPending)
        {
            selectedSlot.RemoveItem();
            AudioManager.Instance.PlaySound(AudioManager.Instance.binSound);
            CloseInfoWindow(selectedSlot);
        }

        else
        {
            AudioManager.Instance.PlaySound(AudioManager.Instance.notificationSound);
            destroyImage.sprite = binConfirm;
            destroyIsPending = true;
        }

    }

    private void ResetBin()
    {
        destroyImage.sprite = binPending;
        destroyIsPending = false;
    }


}
