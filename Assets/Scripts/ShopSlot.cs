using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class ShopSlot : MainSlot
{
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemFunction;
    [SerializeField] TextMeshProUGUI itemPrice;
 
    public static event Action<ShopSlot> BuyEvent;


    public override void InteractWithSlot()
    {
        base.InteractWithSlot();
        BuyEvent?.Invoke(this);
        AudioManager.Instance.PlaySound(AudioManager.Instance.hardSlotSound);
    }

    public void DisplayItem(ItemObject _item)
    {
        AddItem(_item);
        itemName.text = item.name;
        itemFunction.text = ($"Wearable: {item.equipmentType}");
        itemPrice.text = item.buyPrice.ToString();
    }
}
