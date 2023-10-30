using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSFX : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Replace with your input logic
        {
            audioSource.Play();
        }
    }
}

