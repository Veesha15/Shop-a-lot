using UnityEngine;


// specific to wearable items but name kept as "item" for simplicity

[CreateAssetMenu(menuName =("Scriptable Object / Item"), fileName = ("New Item"))]
public class ItemObject : ScriptableObject
{
    public Sprite icon;
    public int sellPrice;
    public int buyPrice;
    public GarmentType garmentType;
}

public enum GarmentType
{
    Head,
    Chest,
    Waist,
    Legs
}

