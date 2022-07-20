using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour // attached to player
{
    [SerializeField] Animator anim;
    [SerializeField] private Transform movePoint; // empty game object that works like a movement tracker
    [SerializeField] private LayerMask obstacle;
    private float moveSpeed = 5;
    private bool atMovePoint = true; // whether the player has reached the move point

    private SortingGroup playerSortingGroup; // TODO: add sorting order to stationary objects via code instead of manually 


    // ***** DEFAULT METHODS *****
    void Start()
    {
        movePoint.parent = null;
        playerSortingGroup = GetComponent<SortingGroup>();
    }

    void Update()
    {
        MoveMovePoint();
        MovePlayer();
        MoveBehindObjects();
    }


    // ***** CUSTOM METHODS *****
    private bool HitObstacle()
    {
        return Physics2D.OverlapCircle(movePoint.position, 0.2f, obstacle);
    }


    private void MoveMovePoint()
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
    }


    private void MovePlayer()
    {
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


    private void MoveBehindObjects()
    {
        playerSortingGroup.sortingOrder = (int)(transform.position.y * -8); // think pivot point of sprite also plays a role in how well formula works
    }

}
