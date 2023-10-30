using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //private ObjectPooler pool;
    //private new Transform camera;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int maxBullets;
    [SerializeField] private int Anime;
    public ExampleClass script;

    private int currentBullets;

    private Transform weaponTransform;

    void Awake()
    {
        //pool = ObjectPooler.Instance;
        //camera = transform.Find("Camera");
        weaponTransform = transform.Find("Rifle");
        currentBullets = maxBullets;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Anime == 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (weaponTransform == null) { return; }
                if (currentBullets > 0)
                {
                    currentBullets--;
                    Shoot();
                }
                else
                {
                    //play no bullet fx;
                }

                //Debug.Log("Shooting!");

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("reload");
                currentBullets = maxBullets;
                //Debug.Log("Shooting!");

            }
        }
        if (Anime == 1)
            {
            if (script.Flag == true) {

                BotShoot();
        }
    }
    }

    private void Shoot()
    {
        Quaternion spawnRotation = transform.rotation;
        GameObject go = Instantiate(bulletPrefab, weaponTransform.position, spawnRotation);
        Bullet bullet = go.GetComponent<Bullet>();
        bullet.dir = transform.forward;
        Destroy(go, 2f);
    }
    private void BotShoot()
    {
        this.transform.position = script.m_maxPos;
        Quaternion spawnRotation = transform.rotation;
        GameObject go = Instantiate(bulletPrefab, weaponTransform.position, spawnRotation);
        Bullet bullet = go.GetComponent<Bullet>();
        bullet.dir = transform.forward;
        Destroy(go, 2f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 3f);
    }

}
