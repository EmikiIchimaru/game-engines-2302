using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    //private Vector3 spawnLoc;
    public Vector3 dir;

    public void OnEnable()
    {
        speed = 10f;
        dir = new Vector3 (1f,1f,1f);
    }

    void Start()
    {
        transform.Rotate(90f,0f,0f);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(dir);

        Vector3 moveAmount = speed * Time.deltaTime * dir;
        //Vector3 moveAmount = new Vector3 (speed * dir.x, speed * dir.y, speed * dir.z);
        transform.position = transform.position + moveAmount;
    }
}
