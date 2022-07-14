using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] private Transform movePoint; // empty game object that works like a movement tracker
    [SerializeField] private LayerMask obstacle;
    private float moveSpeed = 5;
    private bool atMovePoint = true; // whether the player has reached the move point

    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        if (atMovePoint) // if player is at the move point, the move point is able to be moved using the WASD keys
        {
            anim.SetBool("IsWalking", false);
            float xInput = Input.GetAxisRaw("Horizontal");
            float yInput = Input.GetAxisRaw("Vertical");

            movePoint.Translate(xInput, yInput, 0);

            if (Vector3.Distance(transform.position, movePoint.position) >= 1 && !HitObstacle()) // with == had bug (player stops moving) when moving diagonally 
            {
                atMovePoint = false;
            }
        }

        if (!atMovePoint) // if the move point is a certain distance away from the player
        {
            anim.SetBool("IsWalking", true);
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movePoint.position) == 0)
            {
                atMovePoint = true;
            }
        }

        else
        {
            movePoint.position = transform.position; // reset move point
        }

    }

    private bool HitObstacle()
    {
        return Physics2D.OverlapCircle(movePoint.position, 0.2f, obstacle);
    }

}
