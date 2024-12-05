using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource sound; // Arraste o áudio aqui no Inspector

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlaySound); // Adiciona o som ao evento de clique
        }
        else
        {
            Debug.LogWarning("Nenhum componente de botão encontrado neste objeto.");
        }
    }

    private void PlaySound()
    {
        if (sound != null)
        {
            sound.Play(); // Toca o som ao clicar
        }
        else
        {
            Debug.LogWarning("Nenhum áudio atribuído ao componente AudioSource.");
        }
    }
}
