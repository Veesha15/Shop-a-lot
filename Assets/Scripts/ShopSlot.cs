using System;

public class ShopSlot : MainSlot
{
    public static event Action<ShopSlot> BuyEvent;

    public override void InteractWithSlot()
    {
        base.InteractWithSlot();
        BuyEvent?.Invoke(this);
    }
}
