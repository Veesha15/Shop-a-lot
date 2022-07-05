using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClothingItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image headSlot;
    [SerializeField] SpriteRenderer headPlayer;
    private Sprite itemIcon;


    private void Awake()
    {
        itemIcon = GetComponent<Image>().sprite;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            print("put on clothing");
            headSlot.sprite = itemIcon;
            headPlayer.sprite = itemIcon;
        }
    }
}

// TODO: Trigger equip event to show on player and in slot
// TODO: Create scriptable object with icon image, bodypart, sell price, buy price
