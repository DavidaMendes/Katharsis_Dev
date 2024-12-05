using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class defeatPlayer : MonoBehaviour
{
    public AudioSource soundDeathRomeu;
    [SerializeField] private GameObject romeu;

    void Start()
    {
        // soundDeathRomeu = FindAnyObjectByType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // Salvar o índice da cena atual
            PlayerPrefs.SetInt("LastScene", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.Save();
            
            // Iniciar a coroutine para tocar o som e depois carregar a nova cena
            soundDeathRomeu.Play();
            StartCoroutine(HandlePlayerDefeat());
        }
    }

    private IEnumerator HandlePlayerDefeat()
    {
        
        // Esperar o tempo de duração do som antes de mudar de cena
        yield return new WaitForSeconds(soundDeathRomeu.clip.length);

        SceneManager.LoadScene("GameOver");
        Destroy(romeu);
    }
}
