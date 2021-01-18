using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 10;

    private Vector3 moveVelocityDir;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void MovePlayer()
    {
        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        moveVelocityDir = Vector3.up * verticalMovement + Vector3.right * horizontalMovement;
    }

    void FixedUpdate()
    {
        rb.velocity = moveVelocityDir * playerSpeed;
        
        if (moveVelocityDir.sqrMagnitude > Mathf.Epsilon)
        {
            Quaternion desiredQuaternion = Quaternion.LookRotation(transform.forward, moveVelocityDir);
            rb.SetRotation(Quaternion.RotateTowards(rb.transform.rotation, desiredQuaternion, 1000 * Time.fixedDeltaTime));
        } 
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
}
