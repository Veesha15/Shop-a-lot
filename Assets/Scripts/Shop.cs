using System;
using UnityEngine;

// collider is around door only

public class Shop : MonoBehaviour // attached to "building" 
{
    [SerializeField] GameObject popupWindow;
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
    }


    private void CloseWindow()
    {
        popupWindow.SetActive(false);
        GameManager.ShopWindowOpen = false;
        CloseWindowEvent?.Invoke();
    }




}
