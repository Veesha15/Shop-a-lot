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


    private void Update()
    {
        if (Vector2.Distance(player.position, transform.position) < 2) // TODO: use vector point as trigger point
        {
            playerInRange = true;
        }

        else
        {
            playerInRange = false;
            CloseWindow();
        }
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
