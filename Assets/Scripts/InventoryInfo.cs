using UnityEngine;
using TMPro;

public class InventoryInfo : MonoBehaviour // attached to Game Manager
{
    [SerializeField] private RectTransform infoWindow; // rect because need to set anchor / pivot 
    [SerializeField] private Transform inventoryWindow;

    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemFunction;
    [SerializeField] TextMeshProUGUI itemPrice;
    [SerializeField] TextMeshProUGUI destroyText;

    private InventorySlot selectedSlot;
    private bool infoWindowIsOpen;
    private bool destroyBool;


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

        itemName.text = _clickedSlot.item.name;
        itemFunction.text = ($"Wearable: {_clickedSlot.item.equipmentType}");
        itemPrice.text = _clickedSlot.item.sellPrice.ToString();

        infoWindow.gameObject.SetActive(true);
        infoWindowIsOpen = true;

        destroyText.text = "Bin Item";
        destroyBool = false;
    }

    private void CloseInfoWindow(MainSlot _clickedSlot) // needs parameter because of event signature
    {
        infoWindow.gameObject.SetActive(false);
        selectedSlot = null;
        destroyText.text = "Bin Item";
        destroyBool = false;
    }


    public void DestroyItem()
    {
        if (destroyBool)
        {
            selectedSlot.RemoveItem();
            CloseInfoWindow(selectedSlot);
        }

        else
        {
            destroyText.text = "I'm sure";
            destroyBool = true;
        }

    }


}
