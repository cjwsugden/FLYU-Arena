using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    Vector3 fallingVelocity;

    [SerializeField]
    public float playerSpeed = 12f;
    [SerializeField]
    public float gravityAcceleration = -9.81f;

    [SerializeField]
    int jumpHeight;

    public Transform GroundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    private bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if(isGrounded && fallingVelocity.y < 0)
        {
            fallingVelocity.y = -3f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * playerSpeed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            fallingVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityAcceleration); 
        }
        
        fallingVelocity.y += gravityAcceleration * Time.deltaTime;

        controller.Move(fallingVelocity * Time.deltaTime);
    }
}
