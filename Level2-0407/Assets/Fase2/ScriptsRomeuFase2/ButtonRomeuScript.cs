using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRomeuScript : MonoBehaviour
{
    private string[] buttonsNames = { "Button1", "Button2", "Button3" };
    public bool[] buttons;                   
    private bool[] isNearButtons;            
    public Renderer[] buttonsRenderers;      
    public GameObject[] setasRenderers;   
    public bool boolSeta = true;   
    public GameObject chave;

    [SerializeField] private Color proximityColor = Color.green;
    [SerializeField] private Color touchButtonColor = Color.grey;
    private Color originalColor;
    public SpriteRenderer guardaRoupaJulietaRender;
    public Sprite guardaRoupaAberto;
    public AudioSource soundClick;
    public AudioSource soundKey;

    private bool hasPlayedSoundKey = false;

    void Start()
    {
        originalColor = buttonsRenderers.Length > 0 ? buttonsRenderers[0].material.color : Color.white;
        isNearButtons = new bool[buttonsNames.Length];
        if (chave != null)
        {
            chave.SetActive(false);
        }
        if(setasRenderers != null){
            for(int i = 0; i < setasRenderers.Length; i++){
            setasRenderers[i].SetActive(false);
        }
        }
    }

    void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (isNearButtons[i] && (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.E)) && !buttons[i])
            {
                buttons[i] = true;
                Debug.Log("Apertou " + buttonsNames[i]);

                if (buttonsRenderers[i] != null)
                {
                    buttonsRenderers[i].material.color = touchButtonColor;
                }

                if (soundClick != null)
                {
                    soundClick.Play();
                }
            }
        }

        if (chave != null && AllButtonsPressed())
        {
            chave.SetActive(true);
            if(setasRenderers != null){
                for(int i = 0; i < setasRenderers.Length; i++){
                setasRenderers[i].SetActive(boolSeta);
            }
            }
            
            if (guardaRoupaJulietaRender != null && guardaRoupaAberto != null && !hasPlayedSoundKey)
            {
                guardaRoupaJulietaRender.sprite = guardaRoupaAberto;
                
                if (soundKey != null)
                {
                    soundKey.Play();
                }

                hasPlayedSoundKey = true;
            }
        }
    }

    private bool AllButtonsPressed()
    {
        foreach (bool button in buttons)
        {
            if (!button) return false;
        }
        return true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        for (int i = 0; i < buttonsNames.Length; i++)
        {
            if (col.CompareTag(buttonsNames[i]) && !buttons[i])
            {
                Debug.Log("Entrou no botão " + buttonsNames[i]);
                isNearButtons[i] = true;

                if (buttonsRenderers[i] != null)
                {
                    buttonsRenderers[i].material.color = proximityColor; 
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        for (int i = 0; i < buttonsNames.Length; i++)
        {
            if (col.CompareTag(buttonsNames[i]))
            {
                isNearButtons[i] = false;
                
                if (!buttons[i] && buttonsRenderers[i] != null)
                {
                    buttonsRenderers[i].material.color = originalColor;
                }
            }
        }
    }

}
