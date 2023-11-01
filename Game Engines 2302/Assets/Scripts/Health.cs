using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public TMP_Text HealthText;
    public GameObject player;
    private CharacterStats stats;

    public void Start()
    {
        stats = player.GetComponent<CharacterStats>();
    }
    public void Update()
    {
        HealthText.text = "Health: " + stats.currentHealth;
    }
}
