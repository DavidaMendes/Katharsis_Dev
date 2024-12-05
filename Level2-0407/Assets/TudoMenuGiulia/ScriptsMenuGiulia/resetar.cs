using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetar : MonoBehaviour
{
   public void ResetGame()
{
     PlayerPrefs.DeleteAll();
}
}
