using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openWindowJulieta : MonoBehaviour
{
    public bool gameWinnerRomeu = false;
    [SerializeField] private BoxCollider2D colliderWindowJulieta;
    [SerializeField] private SpriteRenderer windowSpriteRenderer; 
    [SerializeField] private Sprite openWindowSprite; 
    [SerializeField] private GameObject Romeu;
    [SerializeField] private PlayerSwap playerSwap; // Referência ao script de troca de jogador
    public AudioSource soundKey2;
    public GameObject[] setasRenderers;

    void Start()
    {
        colliderWindowJulieta.enabled = true;
        if(setasRenderers != null){
            for(int i = 0; i < setasRenderers.Length; i++){
                setasRenderers[i].SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            colliderWindowJulieta.enabled = false;
            gameWinnerRomeu = true;

            if (windowSpriteRenderer != null && openWindowSprite != null)
            {
                windowSpriteRenderer.sprite = openWindowSprite;
            }
            soundKey2.Play();
            Destroy(Romeu);
            if(setasRenderers != null){
                for(int i = 0; i < setasRenderers.Length; i++){
                    setasRenderers[i].SetActive(true);
                }
            }

            // Troca de câmera para Julieta
            if (playerSwap != null)
            {
                playerSwap.SwapPlayer();
            }
        }
    }
}
