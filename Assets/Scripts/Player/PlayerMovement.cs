using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool onGround;
    private bool hasDoubleJumped;

    private Rigidbody playerCurrent;

    [SerializeField] private float playerSpeed = 1f;
    [SerializeField] private float jumpForce = 1f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] Camera playerCamera;

    public bool canMove = true;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerCurrent = GetComponent<Rigidbody>();
        hasDoubleJumped = true;
    }
    

    void Update()
    {
        if (canMove)
        {
            Move();

            //if (IsGrounded())
            //{
                //hasDoubleJumped = false;
            //}

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                Jump();
            }

            if (Input.GetButtonDown("Jump") && hasDoubleJumped == false && !IsGrounded())
            {
                Jump();
                hasDoubleJumped = true;
            }
        }
    }


    private void Jump()
    {
        playerCurrent.linearVelocity = new Vector3(playerCurrent.linearVelocity.x, jumpForce, playerCurrent.linearVelocity.z);
    }

 private void Move()
{
    // Get the input from the player
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    // Calculate the camera's forward and right vectors
    Vector3 cameraForward = playerCamera.transform.forward;
    Vector3 cameraRight = playerCamera.transform.right;

    // Set the y component to 0 to prevent vertical movement
    cameraForward.y = 0;
    cameraRight.y = 0;

    // Calculate the movement direction relative to the camera
    Vector3 moveDirection = (cameraForward * verticalInput + cameraRight * horizontalInput);

    // Check if the magnitude of moveDirection is greater than 1
    if (moveDirection.magnitude > 1)
    {
        // Normalize only if the magnitude is greater than 1
        moveDirection.Normalize();
    }

    // Apply the movement direction to the player's velocity
    playerCurrent.linearVelocity = new Vector3(moveDirection.x * playerSpeed, playerCurrent.linearVelocity.y, moveDirection.z * playerSpeed);
}

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }
    
}
