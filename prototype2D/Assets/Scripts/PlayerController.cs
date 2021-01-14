using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10;

    private Vector2 moveVelocity;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveVelocity.x = 0;
        moveVelocity.y = 0;
    }

    private void MovePlayer()
    {
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        moveVelocity.x = 0;
        moveVelocity.y = 0;

        if (Mathf.Abs(horizontalMovement) > Mathf.Epsilon || Mathf.Abs(verticalMovement) > Mathf.Epsilon)
        {
            moveVelocity.x = horizontalMovement * playerSpeed;
            moveVelocity.y = verticalMovement * playerSpeed;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
}
