using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;

    public Transform groundCheck;
    public LayerMask groundMask;
    private Vector3 velocity;
    private float groundDistance = 0.5f;

    [SerializeField]
    public float movementSpeed = 12f;
    [SerializeField]
    public float sprintSpeed = 0f;
    [SerializeField]
    public float gravity = -18f;
    [SerializeField]
    public float jumpHeight =3;



    void Update()
    {
        checkIfGrounded();
        movementSystem();
    }






    private bool checkIfGrounded()
    {
        if(Physics.CheckSphere(groundCheck.position, groundDistance, groundMask))
        {
            //Debug.Log("Grounded");
            return true;
        }
        return false;
    }


    private void movementSystem()
    {
        horizontalMovement();
        verticalMovement();
    }

    private void horizontalMovement()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * movementSpeed * Time.deltaTime);
    /*
        if(Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(move * sprintSpeed * Time.deltaTime);
        }
    */
    }

    public void verticalMovement()
    {
        if(checkIfGrounded() && velocity.y <= -3f)
        {
            velocity.y = -3f;
        }

        if(Input.GetButtonDown("Jump") && checkIfGrounded())
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }


    private void wallMovement()
    {
        
    }
}
