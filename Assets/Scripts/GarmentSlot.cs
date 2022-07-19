using UnityEngine;
using System;
using UnityEngine.UI;

public class GarmentSlot : MainSlot
{
    [SerializeField] private SpriteRenderer playerDisplay; // used to show garment on player in world
    [SerializeField] private Image potraitDisplay; // used to show garment on player in inventory
    public GarmentType garmentType;

    public static event Action<GarmentSlot> UnequipEvent;


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
