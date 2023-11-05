using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float score;
    public float enemyKilled;
    public float noofenemyKilled = 10;
    public GameObject[] enemies;
    public bool[] flag = new bool[] { false, false, false, false, false, false, false, false, false, false};
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < noofenemyKilled; i++)
        {
            if (enemies[i] == null && flag[i] == false)
            {
                enemyKilled += 1;
                score += 10;
                flag[i] = true;
            }
        }
    }
}
