using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MainSlot
{
    public static event Action<InventorySlot> EquipEvent;
    public static event Action<InventorySlot> SellEvent;
    public static event Action<InventorySlot> InfoEvent;
  

    public override void InteractWithSlot()
    {
        base.InteractWithSlot();

        if (GameManager.ShopWindowOpen)
        {
            SellEvent?.Invoke(this);
        }

        else
        {
            EquipEvent?.Invoke(this);
        }   
    }

    public override void OtherSlotAction()
    {
        base.OtherSlotAction();
        InfoEvent?.Invoke(this);
    }



}


