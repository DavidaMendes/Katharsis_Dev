using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class voltar1 : MonoBehaviour
{
   public void VoltarMenu()
   { 
    SceneManager.LoadSceneAsync(0);
   }
}
