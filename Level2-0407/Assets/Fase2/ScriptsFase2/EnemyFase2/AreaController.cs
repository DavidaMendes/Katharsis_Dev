using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    public string tagTargetDetection = "Player";
    public List<Collider2D> detectedObjs = new List<Collider2D>();

    private void OnTriggerEnter2D (Collider2D col)
    {
        if(col.gameObject.tag == tagTargetDetection)
        {
            detectedObjs.Add(col);
        }
    }
    private void OnTriggerExit2D (Collider2D col)
    {
        if(col.gameObject.tag == tagTargetDetection)
        {
            detectedObjs.Remove(col);
        }
    }

    
}
