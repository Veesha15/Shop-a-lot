using UnityEngine;

[CreateAssetMenu(menuName =("Scriptable Object / Item"), fileName = ("New Item"))]
public class ItemObject : ScriptableObject
{
    public Sprite icon;
    public int sellPrice;
    public int buyPrice;
    public BodyPart bodyPart;
}

public enum BodyPart
{
    Head,
    Chest,
    Legs
}

// TODO: should be setup to be used by all items (food, tools, etc)
