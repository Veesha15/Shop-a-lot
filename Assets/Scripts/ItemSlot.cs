using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{ 
    private enum SlotType // controls what happens when you interact with slot
    {
        Equipt,
        Buy,
        Sell,
        Inventory
    }

    [SerializeField] private Image itemImage;

    [Header("Assign in Scene")]
    [SerializeField] private SlotType slotType; // can select in inspector or via code
    public ItemObject item;
    
    public static event Action<ItemSlot> EquipEvent;

   
    // ***** DEFAULT METHODS *****
    private void Start()
    {
        itemImage.sprite = item.icon;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            InteractWithSlot();
        }
    }

    // ***** CUSTOM METHODS *****
    private void InteractWithSlot()
    {
        switch (slotType)
        {
            case SlotType.Inventory:
                print("Inventory");
                EquipEvent?.Invoke(this);
                break;

            case SlotType.Equipt:
                print("Equipt");
                // find empty slot
                // swop scriptable item
                break;

            case SlotType.Buy:
                print("Buy");
                // check current money
                // find empty slot
                // swop scriptable item
                // deduct money
                break;

            case SlotType.Sell:
                print("Sell");
                // remove item
                // add money
                break;


        }
    }

    public void ReceiveItem(ItemObject _receivedItem)
    {
        item = _receivedItem;
        itemImage.sprite = _receivedItem.icon;
    }

    public void RemoveItem()
    {
        itemImage.enabled = false;
        item = null;

    }
}


