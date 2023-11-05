using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinAndLose : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemies;
    private PlayerStats pStats;
    private CharacterStats stats;
    public float timeRemaining = 60f;

    

    void Start()
    {
        pStats = player.GetComponent<PlayerStats>();
        stats = player.GetComponent<CharacterStats>();
    }
    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            EndGame(false); // Trigger game over when the timer reaches zero
        }

        if(stats.currentHealth <= 0)
        {
            EndGame(false);
        }

        foreach (var enemy in enemies)
        {
            if (enemy != null)
                return;   
        }
        EndGame(true);
    }



    private void EndGame(bool win)
    {
        if (win == true)
        {
            int seconds = Mathf.CeilToInt(timeRemaining);
            pStats.score += timeRemaining;
            if (pStats.score > Score.Instance.HighScorePoint)
            {
                Score.Instance.HighScorePoint = Mathf.Round(pStats.score);
                Score.Instance.isGreater = true;
            }
            else
            {
                Score.Instance.ScorePoint = Mathf.Round(pStats.score);
                Score.Instance.isGreater = false;
            }
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Win");
        }

        if (win == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Lose");
        }


            // Implement logic for restarting the game or going back to the main menu.
        }
}
