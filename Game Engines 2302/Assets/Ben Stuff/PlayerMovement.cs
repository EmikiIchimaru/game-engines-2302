using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private CameraController camController;
    [SerializeField] private float baseSpeed;
    [SerializeField] private float sprintSpeed;


    private Vector3 cameraFacing;

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
        cameraFacing = camController.facingDirection;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        CheckSprint();

        
            
        Vector3 move = (transform.right) * x + (transform.forward) * z;

        controller.Move(move * (baseSpeed * speedBoost) * Time.deltaTime);

        Quaternion targetRotation = Quaternion.LookRotation(cameraFacing);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 30f * Time.deltaTime);

        //velocity.y += gravity * Time.deltaTime;

        //controller.Move(velocity * Time.deltaTime);
    }

    void CheckGrounded()
    {

    }

    private void CheckSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedBoost = sprintSpeed;
        } 

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speedBoost = 1f;
        } 
       
    }
}
