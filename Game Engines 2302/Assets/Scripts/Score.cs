using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float ScorePoint = 0f;
    public float EnemyKilled = 0f;
    public float Bullet = 0f;
    public GameObject player;
    public PlayerShoot Ammo;

    void Start()
    {
        Ammo = player.GetComponent<PlayerShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        Bullet = Ammo.currentBullets;
    }
}
