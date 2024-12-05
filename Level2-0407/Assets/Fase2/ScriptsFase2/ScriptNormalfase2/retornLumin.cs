using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retornLumin : MonoBehaviour
{
    private bool playerInTrigger = false;
    private timerGameOver timerLumin;
    public AudioSource sound;

    void Start()
    {
        timerLumin = FindObjectOfType<timerGameOver>();
    }

    void Update()
    { 
        if (playerInTrigger && (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Fire2")))
        {
            sound.Play();
            timerLumin.timeRemaining = 120f;
        }   
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }
}
