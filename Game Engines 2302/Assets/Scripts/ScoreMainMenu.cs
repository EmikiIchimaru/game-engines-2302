using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreMainMenu : MonoBehaviour
{
    public TMP_Text Text;

    void Update()
    {    
        Text.text = "HIGH SCORE:" + Score.Instance.HighScorePoint.ToString();
    }
}
