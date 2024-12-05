using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaveOpenPortao : MonoBehaviour
{
    public PlayerSwap PlayerSwap;
    [SerializeField] private Color proximityColor = Color.green;
    private Color originalColor;
    private SpriteRenderer portaRenderer;
    [SerializeField] private Sprite portaoAberto;
    public GameObject porta;
    public AudioSource sound;
    public ButtonRomeuScript btRS;

    void Start()
    {
        PlayerSwap = FindAnyObjectByType<PlayerSwap>();
        btRS = FindAnyObjectByType<ButtonRomeuScript>();
        portaRenderer = porta.GetComponent<SpriteRenderer>();
        if (portaRenderer != null)
        {
            originalColor = portaRenderer.material.color;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player pegou a chave");
            btRS.boolSeta = false;
            porta.GetComponent<BoxCollider2D>().enabled = false;
            if (portaRenderer != null)
            {
                portaRenderer.sprite = portaoAberto;
                PlayerSwap.SwapPlayer();
                sound.Play();   
            }
            Invoke("DestroyKey", 1f);
        }
    }


    private void DestroyKey()
    {
        Destroy(gameObject); // Destroi a chave
    }
}
