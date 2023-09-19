using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private ObjectPooler pool;
    private new Transform camera;

    void Awake()
    {
        pool = ObjectPooler.Instance;
        camera = transform.Find("Camera");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Shooting!");
            GameObject go = pool.GetPooledObject(0);
            go.SetActive(true);
        }
    }
}
