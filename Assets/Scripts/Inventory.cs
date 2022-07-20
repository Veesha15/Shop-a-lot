using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour // attached to Game Manager
{
    private GameManager GM;
    [SerializeField] private GameObject inventoryWindow;
    [SerializeField] private WarningWindow warningWindow;
       
    [SerializeField] private InventorySlot[] inventorySlots; // change to list + dictionary for more complex inventory system
    [SerializeField] private GarmentSlot[] garmentSlots;

   
    private void OnEnable()
    {
        GarmentSlot.UnequipEvent += UnequipItem;
        ShopSlot.BuyEvent += BuyItem;
        InventorySlot.SellEvent += SellItem;
        InventorySlot.EquipEvent += EquipItem;
    }


    private void OnDisable()
    {
        GarmentSlot.UnequipEvent -= UnequipItem;
        ShopSlot.BuyEvent -= BuyItem;
        InventorySlot.SellEvent -= SellItem;
        InventorySlot.EquipEvent -= EquipItem;
    }


    // ***** DEFAULT METHODS *****
    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        foreach (GarmentSlot _slot in garmentSlots) //TODO: is for loop still better for gc
        {
            if (_slot.item != null)
            {
                _slot.EquipPlayer();
            }
        }
    }


    // ***** CUSTOM METHODS *****
    private int EmptySlotIndex() // TODO: maybe change to bool (slot is empty or not) and out the index?
    {
        int returnValue = -1; // negative number will indicate no empty slot found

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
        foreach (GarmentSlot garmentSlot in garmentSlots) //TODO: is for loop still better for gc
        {
            if (garmentSlot.garmentType == _clickedSlot.item.garmentType)
            {
                ItemObject equippedItem = garmentSlot.item; // if an item is already equipped need this reference to swap

                garmentSlot.AddItem(_clickedSlot.item);
                garmentSlot.EquipPlayer();

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

    private void UnequipItem(GarmentSlot _clickedSlot)
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

            else
            {
                warningWindow.DisplayWindow(warningWindow.inventoryWarning); //TODO: event might work better
            }
        }

        else
        {
            warningWindow.DisplayWindow(warningWindow.moneyWarning);
        }
    }


}
