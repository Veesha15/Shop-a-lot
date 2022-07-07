using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] EquipmentSlot[] equipmentSlots;


    private void OnEnable()
    {
        InventorySlot.EquipEvent += EquipItem;
    }

    private void OnDisable()
    {
        InventorySlot.EquipEvent -= EquipItem;
    }


    private void EquipItem(MainSlot _clickedSlot)
    {
        foreach(EquipmentSlot equipmentSlot in equipmentSlots)
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


}
