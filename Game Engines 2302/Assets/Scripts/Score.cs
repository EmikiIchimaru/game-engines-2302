using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }
    public float ScorePoint = 0f;
    public float HighScorePoint = 0f;
    public bool isGreater = false;
    public float timeRemaining = 0f;
    public float Bullet = 0f;
 
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
