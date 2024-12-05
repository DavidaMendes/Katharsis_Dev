using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class fase : MonoBehaviour
{

    public Button [] buttons;

    private void Awake()
    {
       int unlockedLevel = PlayerPrefs.GetInt("NivelDesbloqueado", 1); 
       for (int i = 0; i < buttons.Length; i++)
       { 
           buttons [i].interactable = false;
       }

       for (int i = 0; i < unlockedLevel; i++)
       { 
          buttons [i].interactable = true;
          if(i >= 1)
          {
            break;
          }
       }
    }
   
  public void IrFase1()
    { 
      SceneManager.LoadSceneAsync(3);
    }

}