using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMenu : MonoBehaviour
{
    private GameManager GM;

    [SerializeField] private InventorySlot[] inventorySlots; // change to list + dictionary for more complex inventory system
    [SerializeField] private EquipmentSlot[] equipmentSlots;
    [SerializeField] GameObject playerMenuWindow;

    [SerializeField] RectTransform infoWindow; // rect because we need to set anchor / pivot 
    private bool infoOpen;
    private InventorySlot infoedSlot;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemFunction;
    [SerializeField] TextMeshProUGUI itemPrice;

    [SerializeField] GameObject warningWindow;
    [SerializeField] TextMeshProUGUI warningText;
    [SerializeField] Image warningIcon;
    [SerializeField] WarningObject coindWarning, spaceWarning;



    private void OnEnable()
    {
        EquipmentSlot.UnequipEvent += UnequipItem;
        ShopSlot.BuyEvent += BuyItem;
        InventorySlot.SellEvent += SellItem;
        InventorySlot.EquipEvent += EquipItem;
        InventorySlot.InfoEvent += ToggleInfoWindow;
        Shop.OpenWindowEvent += OpenInventory;
        Shop.CloseWindowEvent += CloseInventory;
    }


    private void OnDisable()
    {
        EquipmentSlot.UnequipEvent -= UnequipItem;
        ShopSlot.BuyEvent -= BuyItem;
        InventorySlot.SellEvent -= SellItem;
        InventorySlot.EquipEvent -= EquipItem;
        InventorySlot.InfoEvent -= ToggleInfoWindow;
        Shop.OpenWindowEvent -= OpenInventory;
        Shop.CloseWindowEvent -= CloseInventory;
    }


    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }


    private void Start()
    {
        foreach (EquipmentSlot _slot in equipmentSlots)
        {
            if (_slot.item != null)
            {
                _slot.EquipPlayer();
            }
        }
    }


    private int EmptySlotIndex()
    {
        int returnValue = -1;

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].item == null)
            {
                returnValue = i;
                break;
            }
        }

        return returnValue;
    }


    private void EquipItem(MainSlot _clickedSlot)
    {
        foreach (EquipmentSlot equipmentSlot in equipmentSlots)
        {
            if (equipmentSlot.equipmentType == _clickedSlot.item.equipmentType)
            {
                ItemObject equippedItem = equipmentSlot.item; // if an item is already equipped - swop items

                equipmentSlot.AddItem(_clickedSlot.item);
                equipmentSlot.EquipPlayer();

                if (equippedItem == null)
                {
                    _clickedSlot.RemoveItem();
                }

                else
                {
                    _clickedSlot.AddItem(equippedItem);
                }

                CloseInfo();
                return;
            }
        }
        
    }


    private void UnequipItem(EquipmentSlot _clickedSlot)
    {
        int index = EmptySlotIndex();

        if (index >= 0) // negative number means no empty slot was found
        {
            inventorySlots[index].AddItem(_clickedSlot.item);
            _clickedSlot.RemoveItem();
            _clickedSlot.UnequipPlayer();
        }
    }


    private void SellItem(InventorySlot _clickedSlot)
    {
        GM.AddMoney(_clickedSlot.item.sellPrice);
        _clickedSlot.RemoveItem();
        CloseInfo();
    }


    private void BuyItem(ShopSlot _clickedSlot)
    {
        if (GM.money >= _clickedSlot.item.buyPrice)
        {
            int index = EmptySlotIndex();

            if (index >= 0) // negative number means no empty slot was found
            {
                inventorySlots[index].AddItem(_clickedSlot.item);
                GM.RemoveMoney(_clickedSlot.item.buyPrice);
            }

            else
            {
                DisplayWarningWindow(spaceWarning);
            }
        }

        else
        {
            DisplayWarningWindow(coindWarning);
        }
    }

    private void DisplayWarningWindow(WarningObject _object) // window is closed by assigning game object to button
    {
        warningText.text = _object.text;
        warningIcon.sprite = _object.icon;
        warningWindow.SetActive(true);
    }

    private void ToggleInfoWindow(InventorySlot _clickedSlot)
    {
        if (infoOpen && _clickedSlot == infoedSlot)
        {
            CloseInfo();
        }

        else
        {
            infoedSlot = _clickedSlot;
            infoWindow.anchoredPosition = Vector2.zero; // reset postion other it will use previous position
            infoWindow.SetParent(_clickedSlot.transform, false);
            infoWindow.SetParent(playerMenuWindow.transform, true); // need to unparent to display on top of other slots

            itemName.text = _clickedSlot.item.name;
            itemFunction.text = ($"Wearable: {_clickedSlot.item.equipmentType}");
            itemPrice.text = _clickedSlot.item.sellPrice.ToString();

            infoWindow.gameObject.SetActive(true);
            infoOpen = true;
        }
    }

    public void DestroyItem()
    {
        infoedSlot.RemoveItem();
        CloseInfo();
    }

    private void CloseInfo()
    {
        infoWindow.gameObject.SetActive(false);
        infoedSlot = null;
    }

    public void OpenInventory() 
    {
        playerMenuWindow.SetActive(true);
    }


    public void CloseInventory() 
    {
        playerMenuWindow.SetActive(false);
    }


}
