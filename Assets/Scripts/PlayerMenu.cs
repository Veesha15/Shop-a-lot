using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenu : MonoBehaviour
{
    private GameManager GM;

    [SerializeField] private InventorySlot[] inventorySlots; // change to list + dictionary for more complex inventory system
    [SerializeField] private EquipmentSlot[] equipmentSlots;
    [SerializeField] RectTransform infoWindow; // rect because we need to set anchor / pivot 
    [SerializeField] GameObject playerMenuWindow;


    private void OnEnable()
    {
        EquipmentSlot.UnequipEvent += UnequipItem;
        ShopSlot.BuyEvent += BuyItem;
        InventorySlot.SellEvent += SellItem;
        InventorySlot.EquipEvent += EquipItem;
        InventorySlot.InfoEvent += ToggleInfoWindow;
    }


    private void OnDisable()
    {
        EquipmentSlot.UnequipEvent -= UnequipItem;
        ShopSlot.BuyEvent -= BuyItem;
        InventorySlot.SellEvent -= SellItem;
        InventorySlot.EquipEvent -= EquipItem;
        InventorySlot.InfoEvent -= ToggleInfoWindow;
    }


    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
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
        }
    }

    private void ToggleInfoWindow(InventorySlot _clickedSlot)
    {
        infoWindow.anchoredPosition = Vector2.zero; // reset postion other it will use previous position
        infoWindow.gameObject.SetActive(!infoWindow.gameObject.activeSelf);
        infoWindow.SetParent(_clickedSlot.transform, false);
        infoWindow.SetParent(playerMenuWindow.transform, true); // need to unparent to display on top of other slots
    }


}
