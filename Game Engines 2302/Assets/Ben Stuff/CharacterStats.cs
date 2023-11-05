using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour
{
    //public static CharacterStats Instance { get; private set; }

    [SerializeField] private AudioSource Dead;
    [SerializeField] public bool IFrames = false;


    public float maxHealth;
   // public float Score;
    public float currentHealth;
    public float cooldowntimer;
    public float timer;
    public GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
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

        if (Input.GetKeyDown(KeyCode.M))
        {
            BackToMain();
            
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
             
            }
        }
        if (this.CompareTag("Boss"))
        {
            if (currentHealth <= 0f)
            {

                Die();

            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Health"))
        {
            currentHealth = currentHealth + 50;
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

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
    }
}
