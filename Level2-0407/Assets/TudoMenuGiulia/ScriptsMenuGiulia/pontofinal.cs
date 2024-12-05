using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pontofinal : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
  {
     if(collision.CompareTag("Player") || collision.CompareTag("Player1"))
       {
         UnlockNewLevel();
         // SceneController.instance.NextLevel();
         SceneManager.LoadScene("selecaodeniveis");
         if(PlayerPrefs.GetInt("ReachedIndex") == 11)
         {
            SceneManager.LoadScene("final");
         }
       }

  }

  public void UnlockNewLevel()
    {
       if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
          {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("NivelDesbloqueado", PlayerPrefs.GetInt("NivelDesbloqueado", 1) + 1);
            PlayerPrefs.Save();
          }  
    }

}
