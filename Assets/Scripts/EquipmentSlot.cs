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
        AudioManager.Instance.PlaySound(AudioManager.Instance.hardSlotSound);
    }


    public void EquipPlayer()
    {
        playerDisplay.sprite = item.icon;

        potraitDisplay.sprite = item.icon;
        potraitDisplay.enabled = true;
    }


    public void UnequipPlayer()
    {
        playerDisplay.sprite = null; 
        // sprite renderer doesn't have white block like UI image

        potraitDisplay.sprite = null;
        potraitDisplay.enabled = false;
    }
}
