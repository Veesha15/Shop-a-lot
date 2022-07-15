using System;
using System.Collections.Generic;
using UnityEngine;

// collider is around door only

public class Shop : MonoBehaviour // attached to "building" 
{
    [SerializeField] private GameObject popupWindow;
    
    [SerializeField] private List<ItemObject> allItems = new List<ItemObject>(); // stays constant
    [SerializeField] private ShopSlot[] shopSlots;
    [SerializeField] private List<ItemObject> currentItems = new List<ItemObject>(); // gets removed from
    
    private bool playerInRange;

    public static event Action OpenWindowEvent;
    public static event Action CloseWindowEvent;


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        playerInRange = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
        CloseWindow();
    }


    private void OnMouseDown()
    {
        if (playerInRange)
        {
            OpenWindow();
        }
    }


    private void OpenWindow()
    {
        popupWindow.SetActive(true);
        GameManager.ShopWindowOpen = true;
        OpenWindowEvent?.Invoke();
        DisplayShopItem();
    }


    private void CloseWindow()
    {
        popupWindow.SetActive(false);
        GameManager.ShopWindowOpen = false;
        CloseWindowEvent?.Invoke();
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
