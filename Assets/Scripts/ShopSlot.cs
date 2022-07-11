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

    protected override void Start()
    {
        base.Start(); // displays image if item in no null
        itemName.text = item.name;
        itemFunction.text = ($"Wearable: {item.equipmentType}");
        itemPrice.text = item.buyPrice.ToString();
    }

    public override void InteractWithSlot()
    {
        base.InteractWithSlot();
        BuyEvent?.Invoke(this);
    }
}
