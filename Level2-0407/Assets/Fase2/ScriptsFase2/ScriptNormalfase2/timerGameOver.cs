using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timerGameOver : MonoBehaviour
{
    public Text timerText;
    [SerializeField] public float timeRemaining = 300f; 
    [SerializeField] GameObject background;

    void Start()
    {
        background.SetActive(false);
    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            background.SetActive(false);
            UpdateTimerText();
        }
        else if(timeRemaining <= 0)
        {
            background.SetActive(true);
            timerText.text = "00:00";
        }
        else
        {
            timerText.text = "00:00";
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
