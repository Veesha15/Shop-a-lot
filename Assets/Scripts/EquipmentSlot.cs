using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EquipmentSlot : MainSlot
{
    [SerializeField] private SpriteRenderer spriteRenderer; // used to show equipment on player
    public EquipmentType equipmentType;

    public static event Action<EquipmentSlot> Unequip;


    public override void InteractWithSlot()
    {
        base.InteractWithSlot();
        Unequip?.Invoke(this);  
    }


    public void EquipPlayer()
    {
        spriteRenderer.sprite = item.icon;
    }


    public void UnequipPlayer()
    {
        spriteRenderer.sprite = null;
    }
}
