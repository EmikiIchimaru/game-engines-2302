using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 60.0f; // Set initial countdown time here
    public TMP_Text countdownText;

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime; // Countdown by time passed
            UpdateTimerDisplay();
        }
        else
        {
            GameOver(); // Trigger game over when the timer reaches zero
        }
    }

    void UpdateTimerDisplay()
    {
        int seconds = Mathf.CeilToInt(timeRemaining);
        countdownText.text = seconds.ToString();
    }

    void GameOver()
    {
        // Implement game over logic, for example:
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
        // Load a game over scene or display a game over menu.
    }
}
