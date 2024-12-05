using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bordaAparecer : MonoBehaviour
{
    [SerializeField] private Color proximityColor = Color.green; // Cor quando o jogador está próximo
    private Color originalColor; // Cor original do objeto
    private Renderer objectRenderer; // Renderer do objeto para alterar a cor

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color; // Armazena a cor original
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && objectRenderer != null)
        {
            objectRenderer.material.color = proximityColor; // Muda para a cor de proximidade quando o jogador se aproxima
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") && objectRenderer != null)
        {
            objectRenderer.material.color = originalColor; // Restaura a cor original quando o jogador se afasta
        }
    }
}
