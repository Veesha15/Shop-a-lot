using UnityEngine;
using System;
using UnityEngine.UI;

public class EquipmentSlot : MainSlot
{
    [SerializeField] private SpriteRenderer playerDisplay; // used to show equipment on player
    [SerializeField] private Image potraitDisplay; // used to show equipment on player
    public EquipmentType equipmentType;

    public static event Action<EquipmentSlot> UnequipEvent;


    public override void InteractWithSlot()
    {
        base.InteractWithSlot();
        UnequipEvent?.Invoke(this);  
    }


    public void EquipPlayer()
    {
        playerDisplay.sprite = item.icon;
        //playerDisplay.enabled = true;

        potraitDisplay.sprite = item.icon;
        potraitDisplay.enabled = true;
    }


    public void UnequipPlayer()
    {
        playerDisplay.sprite = null;
        //playerDisplay.enabled = false;

        potraitDisplay.sprite = null;
        potraitDisplay.enabled = false;
    }
}
