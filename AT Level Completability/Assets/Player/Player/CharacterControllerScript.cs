using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] float speed = 7.5f;
    private Vector3 velocity = new Vector3(0, 0, 0);

    private float playerHorizontal;
    private float playerVertical;

    private Vector3 moveVector;

    [SerializeField] float LookSpeed = 0.75f;

    [SerializeField] GameObject groundCheckObject;
    private bool isGrounded = true;
    [SerializeField] float JumpHeight        = 1;
    [SerializeField] float gravityMultiplier = 1.8f;

    public bool  hasDoubleJump = false;
    private bool canDoubleJump = false;

    void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    void Gravity()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        else
        {
            velocity.y += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }
    }

    void GroundCheck()
    {
        RaycastHit hit;
        float distance = 0.5f;
        Vector3 dir = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, dir, out hit, distance))
        {
            isGrounded = true;
            canDoubleJump = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void UserInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerHorizontal = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerHorizontal = 1;
        }
        else
        {
            playerHorizontal = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            playerVertical = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            playerVertical = -1;
        }
        else
        {
            playerVertical = 0;
        }

        moveVector = new Vector3(playerHorizontal, 0, playerVertical);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Move()
    {
        controller.Move(speed * Time.deltaTime * moveVector);
        controller.Move(velocity * Time.deltaTime);

        if (moveVector != Vector3.zero)
        {
            transform.forward = Vector3.Lerp(transform.forward, moveVector, LookSpeed);
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            velocity.y = 0;
            velocity.y += Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y);
        }
        if(hasDoubleJump && canDoubleJump)
        {
            canDoubleJump = false;
            velocity.y = 0;
            velocity.y += Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y);
        }
    }

    void Update()
    {
        UserInput();
    }

    void FixedUpdate()
    {
        GroundCheck();
        Gravity();
        Move();
    }
}
