using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EquipmentSlot : MainSlot
{
    public SpriteRenderer spriteRenderer;
    public BodyPart bodyPart;

    public static event Action<ItemObject> Unequip;

    public override void InteractWithSlot()
    {
        base.InteractWithSlot();
        // TODO: if empty slot is found
        Unequip?.Invoke(item);
        UnequipPlayer();
        RemoveItem();
    }

    public void EquipPlayer()
    {
        spriteRenderer.sprite = item.icon;
    }

    private void UnequipPlayer()
    {
        spriteRenderer.sprite = null;
    }
}
