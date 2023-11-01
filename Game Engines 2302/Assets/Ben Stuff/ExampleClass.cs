using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private AudioSource Shooting;
    [SerializeField] private AudioSource Reloading;
    [SerializeField] private int maxBullets;



    CharacterController charCtrl;
    public Vector3 m_maxPos;
    public GameObject player;
    public float timer;

    private Transform weaponTransform;
    private Transform weaponTransform2;
    private int currentBullets;

    void Awake()
    {
        //pool = ObjectPooler.Instance;
        //camera = transform.Find("Camera");
        weaponTransform = transform.Find("Rifle");
        weaponTransform2 = transform.Find("Rifle_2");
        currentBullets = maxBullets;
    }

    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
        timer = 0;
    }

    void FixedUpdate()
    {
        
            timer += Time.deltaTime;
            RaycastHit hit;
            Vector3 p1 = transform.position + charCtrl.center;
            float distanceToObstacle = 0;

            // Cast a sphere wrapping character controller 10 meters forward
            // to see if it is about to hit anything.
            if (Physics.SphereCast(p1, charCtrl.height / 2, transform.forward, out hit, 10))
            {
                distanceToObstacle = hit.distance;
                m_maxPos = this.transform.position;
                transform.LookAt(player.transform);
                if (timer >= 1 && this.CompareTag("Enemy"))
                {

                    if (currentBullets == 0)
                    {
                        currentBullets = maxBullets;

                    }
                    if (currentBullets > 0)
                    {
                        currentBullets--;
                        Shoot();

                    }
         
                    timer = 0;
                }
                if (timer >= 0.1 && this.CompareTag("Boss"))
                {
                    BossShoot();
                    timer = 0;
                }

            
        }
    }

    private void Shoot()
    {
        Quaternion spawnRotation = transform.rotation;
        GameObject go = Instantiate(bulletPrefab, weaponTransform.position, spawnRotation);
        Bullet bullet = go.GetComponent<Bullet>();
        bullet.dir = transform.forward;
        Shooting.Play();
        Destroy(go, 2f);

    }
    private void BossShoot()
    {
        Quaternion spawnRotation = transform.rotation;
        GameObject go = Instantiate(bulletPrefab, weaponTransform.position, spawnRotation);
        GameObject go2 = Instantiate(bulletPrefab, weaponTransform2.position, spawnRotation);
        Bullet bullet = go.GetComponent<Bullet>();
        Bullet bullet2 = go2.GetComponent<Bullet>();
        bullet.dir = transform.forward;
        bullet2.dir = transform.forward;
        Shooting.Play();
        Destroy(go, 2f);

    }
}
