using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
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
            GameObject go = Instantiate(bullet, camera.transform.position, Quaternion.identity);
            Vector3 dir = new Vector3 (camera.transform.rotation.x, transform.rotation.y, transform.rotation.z);
            go.GetComponent<Bullet>().SetRotation(dir);
            /*
            GameObject go = pool.GetPooledObject(0);
            go.SetActive(true);
            */
        }
    }
}
