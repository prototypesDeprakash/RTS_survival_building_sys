using System;
using UnityEngine;

public class JumpAndMoveForward : MonoBehaviour
{
    public float jumpHeight = 2f; // Desired jump height
    public float jumpSpeed = 5f; // Speed of the jump
    public float gravityMultiplier = 2.5f; // Multiplier to enhance gravity effect

    private Rigidbody rb;
    private bool isGrounded = false;
    private float originalGravity;
    private bool isOnJumpPlatform;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalGravity = Physics.gravity.y;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("JumpPlatform"))
        {
            isOnJumpPlatform = true; // Player is on a JumpPlatform
        }

        isGrounded = true; // Player is grounded when colliding with any surface
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("JumpPlatform"))
        {
            isOnJumpPlatform = false; // Player leaves the JumpPlatform
        }

        isGrounded = false; // Player is no longer grounded when leaving the surface
    }
    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // Handle jumping
        if (isGrounded && isOnJumpPlatform && Input.GetButtonDown("Jump"))
        {
            StartJump();
        }

        // Adjust gravity for smooth falling
        AdjustGravity();
    }

    void StartJump()
    {
        // Calculate jump velocity
        float jumpVelocity = Mathf.Sqrt(-2 * originalGravity * jumpHeight);
        rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
    }

    void AdjustGravity()
    {
        // Increase gravity for a more natural falling
        Physics.gravity = new Vector3(0, originalGravity * gravityMultiplier, 0);
    }

   

}