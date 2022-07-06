using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private ItemSlot[] inventorySlots; // change to list + dictionary for more complex inventory system

    private void OnEnable()
    {
        EquipmentSlot.Unequip += AddToInventory;
    }


    private void OnDisable()
    {
        EquipmentSlot.Unequip -= AddToInventory;
    }


    public int FindEmptySlot()
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

    private void AddToInventory(ItemObject _item)
    {
        if (FindEmptySlot() >= 0)
        {
            inventorySlots[FindEmptySlot()].AddItem(_item);
        }
    }



}
