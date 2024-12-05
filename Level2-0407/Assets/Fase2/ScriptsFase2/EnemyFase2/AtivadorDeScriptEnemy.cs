using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivadorDeScriptEnemy : MonoBehaviour
{
    [SerializeField] private Collider2D detectionArea; 

    private animationGuard normalMovement;
    private EnemyTriggerController chasePlayer;

    private void Start()
    {
        normalMovement = FindObjectOfType<animationGuard>();
        chasePlayer = FindObjectOfType<EnemyTriggerController>();

        normalMovement.enabled = true; 
        chasePlayer.enabled = false; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            normalMovement.enabled = false;
            chasePlayer.enabled = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            normalMovement.enabled = true; 
            chasePlayer.enabled = false; 
        }
    }
}
