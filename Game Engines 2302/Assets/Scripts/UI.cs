using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{ // Set initial countdown time here
    public TMP_Text Text;
    public GameObject player;
    public GameObject Manager;
    public int typeofStats;
    private CharacterStats stats;
    public PlayerStats pStats;
    public WinAndLose time;


    void Start()
    {
        stats = player.GetComponent<CharacterStats>();
        pStats = player.GetComponent<PlayerStats>();
        time = Manager.GetComponent<WinAndLose>();
    }

    private void Update()
    {
        if (typeofStats == 1)
        {
            int seconds = Mathf.CeilToInt(time.timeRemaining);
            Text.text = seconds.ToString();
        }

        if (typeofStats == 2)
        {
            Text.text = "Health: " + stats.currentHealth;
        }

        if (typeofStats == 3)
        {
            Text.text = "   " + pStats.score.ToString();
        }

        if (typeofStats == 4)
        {
            Text.text = "" + Score.Instance.Bullet.ToString() + "/10";
        }
        if (typeofStats == 5)
        {
            Text.text = "" + pStats.enemyKilled.ToString() + "/10 Killed";
        }
    }


}
