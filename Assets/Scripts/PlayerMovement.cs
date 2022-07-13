using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform movePoint; // empty game object that works like a movement tracker
    [SerializeField] private LayerMask obstacle;
    private float moveSpeed = 5;

    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        if (Physics2D.OverlapCircle(movePoint.position, 0.2f, obstacle))
        {
            print("collide");
        }

        if (!Physics2D.OverlapCircle(movePoint.position, 0.2f, obstacle))
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        }

        else
        {
            movePoint.position = Vector3Int.RoundToInt(transform.position);
        }


        if (Vector3.Distance(transform.position, movePoint.position) < 0.1f)
        {
            float xInput = Input.GetAxisRaw("Horizontal");
            float yInput = Input.GetAxisRaw("Vertical");

            movePoint.Translate(xInput, yInput, 0);
        }
    }
}
