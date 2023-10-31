using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    [SerializeField] private AudioSource Dead;
    [SerializeField] public bool IFrames = false;


    public float maxHealth;
    private int Score;
    private float currentHealth;
    public int EnemyKilled;
    public float cooldowntimer;
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Score = 0;
        EnemyKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {       
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && cooldowntimer == 0 && IFrames == true)
        {
            IFrames = true;
            cooldowntimer = 3;
        }
        if (IFrames == true)
        {
            cooldowntimer -= Time.deltaTime;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = currentHealth - damage;
        //put fx here
       
        if (this.CompareTag("Player"))
        {

            if (currentHealth <= 0f)
            {
                Die();
            }
        }
        if (this.CompareTag("Enemy"))
        {
            if (currentHealth <= 0f)
            {
                Die();
                Score = 10 + Score;
                EnemyKilled = EnemyKilled + 1;
            }
        }
        if (this.CompareTag("Boss"))
        {
            if (currentHealth <= 0f)
            {
                Die();
                Score = 10 + Score;
                EnemyKilled = EnemyKilled + 1;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Health"))
        {
            currentHealth = currentHealth + 20;
            Destroy(other.gameObject);

        }
    }
    private void Die()
    {
 
        Destroy(gameObject, 0.1f);
        //put fx here
        Dead.Play();
    }
    private void CheckShift()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            IFrames = true;
        }
    }
}
