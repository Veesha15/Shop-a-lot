using UnityEngine;

[CreateAssetMenu(menuName =("Scriptable Object / Warning"), fileName =("New Warning"))]
public class WarningObject : ScriptableObject
{
    public Sprite icon;
    public string text;

}
