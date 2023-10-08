using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //private ObjectPooler pool;
    //private new Transform camera;

    [SerializeField] private GameObject bulletPrefab;

    private Transform weaponTransform;

    void Awake()
    {
        //pool = ObjectPooler.Instance;
        //camera = transform.Find("Camera");
        weaponTransform = transform.Find("Rifle");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (weaponTransform == null) { return; }
            Debug.Log("Shooting!");
            GameObject go = Instantiate(bulletPrefab, weaponTransform.position, Quaternion.identity);
            Bullet bullet = go.GetComponent<Bullet>();
            bullet.dir = transform.forward;
            Destroy(go, 2f);
        }
    }
}
