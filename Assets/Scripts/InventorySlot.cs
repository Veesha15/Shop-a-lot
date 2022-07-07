using System;

public class InventorySlot : MainSlot
{
    public static event Action<InventorySlot> EquipEvent;
    public static event Action<InventorySlot> SellEvent;

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

}


