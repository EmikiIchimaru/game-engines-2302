using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float baseSpeed;
    [SerializeField] private float sprintSpeed;

    //private float gravity = -9.81f;
    //public float jumpHeight = 3f;
    private float speedBoost = 1f;
    //private Vector3 velocity;


    void Update()
    {
        //if (!GameManager.isControl) { return; }
        
        /* if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        } */

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedBoost = sprintSpeed;
        } 
        else
        {
            speedBoost = 1f;
        }
            
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (baseSpeed * speedBoost) * Time.deltaTime);

        //velocity.y += gravity * Time.deltaTime;

        //controller.Move(velocity * Time.deltaTime);
    }

    void CheckGrounded()
    {

    }
}
