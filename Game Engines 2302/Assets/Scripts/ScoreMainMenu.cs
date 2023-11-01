using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreMainMenu : MonoBehaviour
{
    private Score Scorepoint;
    public GameObject player;
    public TMP_Text Text;
    public float totalscore;
    // Start is called before the first frame update
    void Start()
    {
        Scorepoint = player.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        totalscore = Scorepoint.ScorePoint;
        Text.text = "SCORE:" + totalscore;
    }
}
