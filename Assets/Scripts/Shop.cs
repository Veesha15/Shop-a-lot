using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private Transform player;
    [SerializeField] GameObject popupWindow;
    public bool playerInRange;

    public static event Action OpenWindowEvent;
    public static event Action CloseWindowEvent;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }


    private void OnMouseDown()
    {
        print("clicked on building");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
        CloseWindow();
    }


}
