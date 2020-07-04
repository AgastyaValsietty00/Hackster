using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController Controller;
    private Vector3 velocity;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask whatIsGround;

    private bool isGrounded;
    void Start()
    {
        
    }
    
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, whatIsGround);

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        Controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        Controller.Move(velocity * Time.deltaTime);
    }
}
