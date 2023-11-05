using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreLevelCompleted : MonoBehaviour
{
    public TMP_Text Text;


    // Update is called once per frame
    void Update()
    {
        if (Score.Instance.isGreater == true)
        {
            Text.text = "NEW HIGH SCORE: " + Score.Instance.HighScorePoint.ToString();
        }
        else
        {
            Text.text = "SCORE: " + Score.Instance.ScorePoint.ToString();
        }
    }
}
