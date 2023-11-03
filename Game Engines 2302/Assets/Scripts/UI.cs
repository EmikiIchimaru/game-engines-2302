using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public float timeRemaining = 60.0f; // Set initial countdown time here
    public TMP_Text Text;
    public GameObject player;
    public int typeofStats;
    private CharacterStats stats;
    private PlayerStats Pstats;


    void Start()
    {
        stats = player.GetComponent<CharacterStats>();
        Pstats = player.GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (typeofStats == 1)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime; 
                int seconds = Mathf.CeilToInt(timeRemaining);
                Text.text = seconds.ToString();
            }
            else
            {
                GameOver(); // Trigger game over when the timer reaches zero
            }
        }

        if (typeofStats == 2)
        {
            Text.text = "Health: " + stats.currentHealth;
            if (stats.currentHealth <= 0f)
            {
                GameOver();
            }
        }

        if (typeofStats == 3)
        {
            Text.text = "   " + Pstats.score.ToString();
        }

        if (typeofStats == 4)
        {
            Text.text = "" + Score.Instance.Bullet.ToString() + "/10";
        }
    }


    void GameOver()
    {
        // Implement game over logic, for example:
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
        // Load a game over scene or display a game over menu.
    }
}
