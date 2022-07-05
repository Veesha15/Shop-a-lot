using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    private enum SlotType
    {
        Equipt,
        Buy,
        Sell,
        Inventory
    }

    [SerializeField] private SlotType slotType; // can select in inspector or via code
    // scriptable object
    private Image itemImage;


    private void Awake()
    {
        itemImage = GetComponent<Image>();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            InteractWithSlot();
        }
    }

    private void InteractWithSlot()
    {
        switch (slotType)
        {
            case SlotType.Inventory:
                print("Inventory");
                // call equip event
                // check bodypart
                // swop scriptable item
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
}


