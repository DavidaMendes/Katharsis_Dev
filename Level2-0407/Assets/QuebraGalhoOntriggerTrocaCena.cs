using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuebraGalhoOntriggerTrocaCena : MonoBehaviour
{
    [SerializeField] int numeroCena;
    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Player1"))
        {
            trocaScene(numeroCena);
        }
    }

    public void trocaScene(int num)
    {
        SceneManager.LoadScene(num);
    }
}
