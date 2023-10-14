using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forwardsSpeed = 7f;

    [SerializeField] private float backwardsSpeed = 3.5f;

    [SerializeField] private float jumpSpeed = 100f;

    [SerializeField] private Transform groundCheck;

    [SerializeField] private LayerMask groundLayerMask;

    [SerializeField] private Animator animator;

    private Rigidbody2D rb;

    public ScrollingScreen scrollingScreen;

    private bool isGrounded;

    [HideInInspector] public Vector2 facing;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        if (scrollingScreen.isFlipped)
        {
            facing = Vector2.left;
        } else
        {
            facing = Vector2.right;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("horizontalInput", horizontalMovement);

        if (horizontalMovement > 0) 
        {
            rb.velocity = new Vector2(forwardsSpeed, rb.velocity.y);
            facing = Vector2.right;
            animator.SetBool("running", true);
        } else if (horizontalMovement < 0) {
            rb.velocity = new Vector2(-backwardsSpeed, rb.velocity.y);
            // uncomment below to face backwards, disabled it cause doesnt fit well in sidescroller
            facing = Vector2.left; 
            animator.SetBool("running", true);
        } else {
            rb.velocity = new Vector2(0, rb.velocity.y);
            facing = Vector2.right;
            animator.SetBool("running", false);
        }


        bool jumpInput = Input.GetButtonDown("Jump");

        if (jumpInput && isGrounded) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        // after calculations, set to false, will be set by collisions if true
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.2f, groundLayerMask);
        isGrounded = hit.collider != null;
        animator.SetBool("isGrounded", isGrounded);
    }
}
