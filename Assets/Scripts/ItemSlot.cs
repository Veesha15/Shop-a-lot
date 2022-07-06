using System;

public class ItemSlot : MainSlot
{
    public static event Action<ItemSlot> EquipEvent;
    public static event Action<ItemObject> SellEvent;

    public override void InteractWithSlot()
    {
        base.InteractWithSlot();

        if (!GameManager.ShopWindowOpen)
        {
            EquipEvent?.Invoke(this);
        }

        else if (GameManager.ShopWindowOpen)
        {
            SellEvent?.Invoke(item);
            RemoveItem();
        }
        
    }

}


