using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float cameraDistance = 5.0f;
    public float cameraHeight = 2.0f;
    public float rotationSpeed = 2.0f;

    private float mouseX;
    private float mouseY;

    public Vector3 facingDirection { get { return GetFacingDirection(); } }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (player == null)
            return;

        // Capture mouse input for camera rotation
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, 15f, 90f);  // Clamp vertical rotation to avoid flipping

        // Calculate camera position based on player position and camera distance/height
        Vector3 offset = Quaternion.Euler(mouseY, mouseX, 0f) * new Vector3(0, 0, - cameraDistance);
        Vector3 cameraPosition = player.position + offset;
        transform.position = cameraPosition;

        // Rotate the camera to look at the player
        transform.LookAt(player.position + Vector3.up * cameraHeight);
    }

    private Vector3 GetFacingDirection()
    {
        Vector3 facing = (player.transform.position - transform.position);
        facing.y = 0f;
        return facing;
    }
}
