using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<Collider2D> EnemyPushBack;
    public float playerSpeed = 10;
    public float barkDistance = 2;

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

    private void bark()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Ray2D ray = new Ray2D(transform.position + transform.up * transform.localScale.y, transform.up);
            Debug.DrawRay(ray.origin, ray.direction * barkDistance, Color.red, 0.1f);

            RaycastHit2D hit = Physics2D.Raycast(transform.position + transform.up * transform.localScale.y, transform.up, barkDistance);
            if (hit)
            {
                if (hit.collider.gameObject.tag == "enemy")
                {
                    print("There is an enemy ahead");

                    if (EnemyPushBack != null)
                    {
                        EnemyPushBack(hit.collider);
                    }
                } 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        bark();
    }
}
