using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public Animator transition;
    public float transitionTime = 1f;

    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0); //StartCoroutine();
    }
/* 
    IEnumerator LoadLevel(int levelIndex)
    {
        //transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    } */
}
