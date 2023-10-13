using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    [SerializeField] private float jumpSpeed = 5f;

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
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D col) {
        HandleCollision(col);
    }

    private void OnCollisionStay2D(Collision2D col) {
        // will be set to true if in contact with any ground colliders
        HandleCollision(col);
    }

    void HandleCollision(Collision2D col) {
        // Will be true if collision's layer is contained in the ground layer mask on this obj
		if((groundLayerMask & (1 << col.gameObject.layer)) != 0)
		{
			isGrounded = true;
        }
    }
}
