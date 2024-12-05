using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallBlink : MonoBehaviour
{
    private bool playerInTrigger = false;
    [SerializeField] private float tempo = 1f;
    public AudioSource sound;

    private PlayerSwap camPlayer;
    private GameObject playerJulieta;

    void Start()
    {
        camPlayer = FindAnyObjectByType<PlayerSwap>();
        playerJulieta = GameObject.Find("Julieta"); 
    }

    void Update()
    {
        // Apenas permite o blink se a Julieta for o personagem ativo
        if (camPlayer != null && camPlayer.virtualCamera.Follow == playerJulieta.transform)
        {
            if (playerInTrigger && (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Fire2")))
            {
                sound.Play();
                StartCoroutine(BlinkWalls());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Checa se a Julieta está no trigger
        if (col.CompareTag("Player") && col.transform == playerJulieta.transform)
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.transform == playerJulieta.transform)
        {
            playerInTrigger = false;
        }
    }

    private IEnumerator BlinkWalls()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("WallBlink");

        foreach (GameObject wall in walls)
        {
            wall.SetActive(false);
        }

        yield return new WaitForSeconds(tempo);

        float blinkDuration = 1f;
        float blinkInterval = 0.1f; 
        int blinkTimes = Mathf.FloorToInt(blinkDuration / (blinkInterval * 2));

        for (int i = 0; i < blinkTimes; i++)
        {
            foreach (GameObject wall in walls)
            {
                wall.SetActive(true);
            }
            yield return new WaitForSeconds(blinkInterval);

            foreach (GameObject wall in walls)
            {
                wall.SetActive(false);
            }
            yield return new WaitForSeconds(blinkInterval);
        }

        foreach (GameObject wall in walls)
        {
            wall.SetActive(true);
        }
    }
}
