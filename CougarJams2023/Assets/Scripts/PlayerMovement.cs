using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private float jumpSpeed = 5f;

    [SerializeField] private Transform groundCheck;

    [SerializeField] private LayerMask groundLayerMask;

    private Rigidbody2D rb;


    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (horizontalMovement > 0) 
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        } else if (horizontalMovement < 0) {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        } else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }


        bool jumpInput = Input.GetButtonDown("Jump");

        if (jumpInput && isGrounded) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        // after calculations, set to false, will be set by collisions if true
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.2f, groundLayerMask);
        isGrounded = hit.collider != null;
    }
}
