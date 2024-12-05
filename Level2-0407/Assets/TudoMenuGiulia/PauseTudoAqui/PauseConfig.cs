using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseConfig : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [Header("First Selected Options")]
    [SerializeField] private GameObject _mainMenuFirst;

    private bool isPaused = false;

    private void Start()
    {
        if (pauseCanvas != null)
        {
            pauseCanvas.SetActive(false);
        }

        Time.timeScale = 1;
    }

    private void Update()
    {
        if (InputManager.instance.MenuOpenCloseInput && (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Pause")))
        {
            TogglePauseCanvas();
        }
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void TogglePauseCanvas()
    {
        isPaused = !isPaused;

        if (pauseCanvas != null)
        {
            pauseCanvas.SetActive(isPaused);
            Time.timeScale = isPaused ? 0 : 1;

            if (isPaused) // Se o canvas foi ativado
            {
                EventSystmMainMenu();
            }
            else // Se o canvas foi desativado
            {
                EventSystmCloseAllMenus();
            }
        }
    }

    public void EventSystmMainMenu()
    {
        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }
    
    public void EventSystmCloseAllMenus()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
