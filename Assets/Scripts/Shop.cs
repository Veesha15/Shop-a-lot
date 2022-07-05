using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject popupWindow;
    public bool playerInRange;


    private void OnMouseDown()
    {
        if (playerInRange)
        {
            popupWindow.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInRange = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
    }


}
