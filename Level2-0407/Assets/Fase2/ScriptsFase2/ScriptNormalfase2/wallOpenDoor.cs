using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallOpenDoor : MonoBehaviour
{
    private bool playerInTrigger = false;
    [SerializeField] private GameObject[] portas;
    [SerializeField] private Sprite spriteAberto; 
    [SerializeField] private Sprite spriteFechado; 
    public AudioSource sound;

    private PlayerSwap camPlayer;

    void Start()
    {
        camPlayer = FindAnyObjectByType<PlayerSwap>();
        camPlayer.virtualCamera.Follow = camPlayer.playerRomeu.transform;
    }

    void Update()
    {
        if (camPlayer.virtualCamera.Follow == camPlayer.playerJulieta.transform)
        {
            if (playerInTrigger && (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Fire2")))
            {
                sound.Play();
                ToggleColliders();
            }
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

    private void ToggleColliders()
    {
        foreach (GameObject porta in portas)
        {
            if (porta != null)
            {
                Collider2D collider = porta.GetComponent<Collider2D>();
                SpriteRenderer spriteRenderer = porta.GetComponent<SpriteRenderer>();

                if (collider != null && spriteRenderer != null)
                {
                    bool isColliderActive = collider.enabled;
                    collider.enabled = !isColliderActive;
                    spriteRenderer.sprite = collider.enabled ? spriteFechado : spriteAberto;
                }
            }
        }
    }
}
