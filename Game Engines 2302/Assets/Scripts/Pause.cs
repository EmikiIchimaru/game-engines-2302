using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject Pausemenu;
    public bool ispaused;
    // Start is called before the first frame update
    void Start()
    {
        Pausemenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ispaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }

    public void PauseGame()
    {
        Pausemenu.SetActive(true);
        Time.timeScale = 0f;
        ispaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void ResumeGame()
    {
        Pausemenu.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMain()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
}

