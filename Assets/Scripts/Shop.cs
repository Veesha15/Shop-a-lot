using System;
using System.Collections.Generic;
using UnityEngine;

// collider is around door only

public class Shop : MonoBehaviour // attached to "building" 
{
    [SerializeField] private GameObject popupWindow;
    [SerializeField] private SpriteRenderer signText;
    [SerializeField] private Sprite enterBright, enterDull, exitBright;
    
    [SerializeField] private List<ItemObject> allItems = new List<ItemObject>(); // stays constant
    [SerializeField] private ShopSlot[] shopSlots;
    [SerializeField] private List<ItemObject> currentItems = new List<ItemObject>(); // gets removed from
    
    private bool playerInRange;
    private bool windowIsOpen;

    public static event Action OpenWindowEvent;
    public static event Action CloseWindowEvent;


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        playerInRange = true;
        signText.sprite = enterBright;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
        CloseWindow();
        signText.sprite = enterDull; // needs to be after close because close sets it to bright
    }


    private void OnMouseDown()
    {
        if (playerInRange)
        {
            if (!windowIsOpen)
            {
                OpenWindow();
            }

            else
            {
                CloseWindow();
            }
            
        }
    }


    private void OpenWindow()
    {
        popupWindow.SetActive(true);
        GameManager.ShopWindowOpen = true;
        OpenWindowEvent?.Invoke();
        signText.sprite = exitBright;
        DisplayShopItem();
        windowIsOpen = true;
    }


    private void CloseWindow()
    {
        popupWindow.SetActive(false);
        GameManager.ShopWindowOpen = false;
        CloseWindowEvent?.Invoke();
        signText.sprite = enterBright;
        windowIsOpen = false;
    }


    private void DisplayShopItem()
    {
        if (currentItems.Count == 0)
        {
            currentItems = new List<ItemObject>(allItems);
        }

        for (int i = 0; i < shopSlots.Length; i++)
        {
            if (currentItems.Count > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, currentItems.Count);
                shopSlots[i].DisplayItem(currentItems[randomIndex]);
                currentItems.RemoveAt(randomIndex);
            }
        }
    }

}
