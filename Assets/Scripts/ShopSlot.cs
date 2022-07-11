using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class ShopSlot : MainSlot
{
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemFunction;
    [SerializeField] TextMeshProUGUI itemPrice;
    //[SerializeField] Image itemImage; 
 
    public static event Action<ShopSlot> BuyEvent;

    protected override void Start()
    {
        base.Start();
        itemName.text = item.name;
        itemFunction.text = ($"Wearable: {item.equipmentType}");
        itemPrice.text = item.buyPrice.ToString();
       // itemImage.sprite = item.icon;

    }

    public override void InteractWithSlot()
    {
        base.InteractWithSlot();
        BuyEvent?.Invoke(this);
    }
}
