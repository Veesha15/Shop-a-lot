using System;
using System.Collections.Generic;
using UnityEngine;

// collider is around door only
// collider needs to be on front of collider preventing movement to allow mouse click
public class Shop : MonoBehaviour // attached to "building" game object
{
    [SerializeField] private GameObject shopWindow;
    [SerializeField] private SpriteRenderer signText;
    [SerializeField] private Sprite enterBright, enterDull, exitBright;
    
    [SerializeField] private List<ItemObject> allItems = new List<ItemObject>(); // stays constant
    [SerializeField] private ShopSlot[] shopSlots;
    [SerializeField] private List<ItemObject> currentItems = new List<ItemObject>(); // gets removed from

    private Animator anim;   
    private bool playerInRange;
    private bool windowIsOpen;

    public static event Action OpenWindowEvent; // allow inventory window to open simutaniously
    public static event Action CloseWindowEvent;


    // ***** DEFAULT METHODS *****
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        playerInRange = true;
        signText.sprite = enterBright;
        anim.Play("Boutique_Appear");
        AudioManager.Instance.PlaySound(AudioManager.Instance.lightBulbSound);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        CloseWindow(); // close method plays sound
        playerInRange = false;
        signText.sprite = enterDull; // needs to be after close because close sets it to bright
        anim.Play("Boutique_Disappear");
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


    // ***** CUSTOM METHODS *****
    private void OpenWindow()
    {
        shopWindow.SetActive(true);
        GameManager.ShopWindowOpen = true;
        OpenWindowEvent?.Invoke();
        signText.sprite = exitBright;
        DisplayShopItem();
        windowIsOpen = true;
        AudioManager.Instance.PlaySound(AudioManager.Instance.doorBellSound);
    }


    private void CloseWindow()
    {
        shopWindow.SetActive(false);
        GameManager.ShopWindowOpen = false;
        CloseWindowEvent?.Invoke();
        signText.sprite = enterBright;
        windowIsOpen = false;
        AudioManager.Instance.PlaySound(AudioManager.Instance.lightBulbSound);
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
