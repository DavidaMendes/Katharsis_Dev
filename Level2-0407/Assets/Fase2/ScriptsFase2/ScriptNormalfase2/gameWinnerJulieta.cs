using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameWinnerJulieta : MonoBehaviour
{
    public bool gameWinnerJulietau = false;
    [SerializeField] private GameObject julieta;
    [SerializeField] private string sceneName;

    private openWindowJulieta gameWinnerRomeu;
    void Start()
    {
        //gameWinnerRomeu = FindObjectOfType<openWindowJulieta>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(gameWinnerJulietau == true && gameWinnerRomeu.gameWinnerRomeu == true)
        // {
        //     LoadScene(sceneName);
        // }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // if (col.CompareTag("Player"))
        // {
        //     gameWinnerJulietau = true;
        // }
        // Destroy(julieta);
        if (col.CompareTag("Player"))
        {
            LoadScene(sceneName);
        }
        Destroy(julieta);
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
