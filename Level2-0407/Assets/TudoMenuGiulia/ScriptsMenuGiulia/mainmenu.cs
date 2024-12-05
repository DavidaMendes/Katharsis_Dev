using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Importar para usar Image

public class mainmenu : MonoBehaviour
{
    public void PlayGame(int numn)
    { 
        SceneManager.LoadSceneAsync(numn);
    }

    public void VerControles()
    { 
        SceneManager.LoadSceneAsync(2);
    }

    public void VerCreditos()
    { 
        SceneManager.LoadSceneAsync(1);
    }

    public void SairJogo()
    { 
        Application.Quit();
    }

    public void tela()
    {
        // Toggle fullscreen
        Screen.fullScreen = !Screen.fullScreen;
    }

    public void SeletorNivel(int num)
    { 
        SceneManager.LoadSceneAsync(num);
    }

    public AudioListener audioListener;
    public AudioSource audioSource;
    public Image imageAudioSource; // Altere o tipo para Image
    public Image imageAudioListener; // Altere o tipo para Image
    public Sprite audioOn;
    public Sprite audioOff;

    public void TirarSource()
    {
        if (audioSource != null)
        {
            audioSource.enabled = !audioSource.enabled;
            if (audioSource.enabled)
            {
                imageAudioSource.sprite = audioOn;
            }
            else
            {
                imageAudioSource.sprite = audioOff;
            }
        }
    }

    public void TirarListener()
    {
        if (audioListener != null)
        {
            audioListener.enabled = !audioListener.enabled;
            if (audioListener.enabled)
            {
                imageAudioListener.sprite = audioOn;
            }
            else
            {
                imageAudioListener.sprite = audioOff;
            }
        }
    }
}
