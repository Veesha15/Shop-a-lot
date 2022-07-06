using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int money;

    public static bool ShopWindowOpen;

    private void OnEnable()
    {
        ItemSlot.SellEvent += ReceiveMoney;
    }

    private void OnDisable()
    {
        
    }

    private void ReceiveMoney(ItemObject _item)
    {
        money += _item.sellPrice;
    }

}
