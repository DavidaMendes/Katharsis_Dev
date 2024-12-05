using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    [Header("First Selected Options")]
    [SerializeField] private GameObject _mainMenuFirst;

    void Start()
    {
        if(InputManager.instance.MenuOpenCloseInput){
            EventSystmMainMenu();
        }
        // Configura o primeiro item selecionado assim que a cena inicia
        
    }

    public void EventSystmMainMenu()
    {
        // Define o primeiro item do menu principal para navegação
        EventSystem.current.SetSelectedGameObject(_mainMenuFirst);
    }

    public void EventSystmCloseAllMenus()
    {
        // Desativa a seleção quando necessário
        EventSystem.current.SetSelectedGameObject(null);
    }
}
