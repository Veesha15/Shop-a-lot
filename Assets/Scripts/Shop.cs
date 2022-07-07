using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private Transform player;
    [SerializeField] GameObject popupWindow;
    public bool playerInRange;


    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }


    private void Update()
    {
        if (Vector2.Distance(player.position, transform.position) < 2)
        {
            playerInRange = true;
        }

        else
        {
            playerInRange = false;
            GameManager.ShopWindowOpen = false;
        }
    }


    private void OnMouseDown()
    {
        if (playerInRange)
        {
            popupWindow.SetActive(true);
            GameManager.ShopWindowOpen = true;
        }
    }


}
