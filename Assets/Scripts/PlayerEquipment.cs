using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Equipment slot will need to have empty item with correct bodypart assigned
// when removing item this empty item would need to be reassigned
// inheritance might work better since equipment slot works slightly different to other slots

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] ItemSlot[] equipmentSlots;


    private void OnEnable()
    {
        ItemSlot.EquipEvent += EquipItem;
    }

    private void OnDisable()
    {
        ItemSlot.EquipEvent -= EquipItem;
    }


    private void EquipItem(ItemSlot _itemSlot)
    {
        
        foreach(ItemSlot equipmentSlot in equipmentSlots)
        {
            if (equipmentSlot.item.bodyPart == _itemSlot.item.bodyPart)
            {
                equipmentSlot.ReceiveItem(_itemSlot.item);

                _itemSlot.RemoveItem();
            }
        }
    }
}
