using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] EquipmentSlot[] equipmentSlots;


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
        foreach(EquipmentSlot equipmentSlot in equipmentSlots)
        {
            if (equipmentSlot.bodyPart == _itemSlot.item.bodyPart)
            {
                equipmentSlot.AddItem(_itemSlot.item);

                _itemSlot.RemoveItem();
            }
        }
    }
}
