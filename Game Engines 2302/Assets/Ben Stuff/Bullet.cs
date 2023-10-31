using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    private float attackDamage = 10f;
    //private Vector3 spawnLoc;
    public Vector3 dir;
    
    private VFXManager vfxm;

    public void OnEnable()
    {
        speed = 25f;
       // dir = new Vector3 (1f,1f,1f);
    }

    void Start()
    {
        vfxm = VFXManager.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.LookAt(dir);

        Vector3 moveAmount = speed * Time.deltaTime * dir;
        //Vector3 moveAmount = new Vector3 (speed * dir.x, speed * dir.y, speed * dir.z);
        transform.position = transform.position + moveAmount;

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            CharacterStats targetChar = other.gameObject.GetComponent<CharacterStats>();
            if (targetChar == null) { return; }
            if (targetChar.IFrames == false)
            {

                targetChar.TakeDamage(attackDamage);
                Quaternion spawnRotation = transform.rotation * Quaternion.AngleAxis(180f, Vector3.up);
                GameObject vfx = Instantiate(vfxm.FindFX("Blood"), transform.position, spawnRotation);
                Destroy(vfx, 2f);
            }
        }
        if (other.CompareTag("Enemy") )
        {
            CharacterStats targetChar = other.gameObject.GetComponent<CharacterStats>();
            if (targetChar == null) { return; }
            targetChar.TakeDamage(attackDamage);
            Quaternion spawnRotation = transform.rotation * Quaternion.AngleAxis(180f, Vector3.up);
            GameObject vfx = Instantiate(vfxm.FindFX("Blood"), transform.position, spawnRotation);
            Destroy(vfx, 2f);
        }

        //put vfx here
        // Destroy the bullet on collision
        Destroy(gameObject);
    }
}
