using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class ItemSlot : MainSlot
{
    public static event Action<ItemSlot> EquipEvent;

    public override void InteractWithSlot()
    {
        base.InteractWithSlot();
        EquipEvent?.Invoke(this);
    }

}


