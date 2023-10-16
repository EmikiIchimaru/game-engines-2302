using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
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
            //Debug.Log("Shooting!");
            Quaternion spawnRotation = transform.rotation;
            GameObject go = Instantiate(bulletPrefab, weaponTransform.position, spawnRotation);
            Bullet bullet = go.GetComponent<Bullet>();
            bullet.dir = transform.forward;
            Destroy(go, 2f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 3f);
    }

}
