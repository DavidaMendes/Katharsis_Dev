using UnityEngine;
using Cinemachine;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;

public class PlayerSwap : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public Transform playerRomeu;
    public Transform playerJulieta;

    // Scripts dos personagens
    public MonoBehaviour romeuScript;
    public MonoBehaviour julietaScript;

    // PostProcessing Volume
    public PostProcessVolume postProcessingVolume;

    private bool isRomeuActive = true;

    // Valores para Romeu
    private float orthoSizeRomeu = 3.5f;
    private Vector3 trackedOffsetRomeu = new Vector3(0, 0f, 0);

    // Valores para Julieta
    private float orthoSizeJulieta = 12.4f;
    private Vector3 trackedOffsetJulieta = new Vector3(0, 6.5f, 0);

    void Start()
    {
        // Configuração inicial para Romeu
        if (playerRomeu != null)
        {
            virtualCamera.Follow = playerRomeu;
            virtualCamera.LookAt = playerRomeu;
            virtualCamera.m_Lens.OrthographicSize = orthoSizeRomeu;
            romeuScript.enabled = true;
        }
        
        if (playerJulieta != null)
        {
            julietaScript.enabled = false;
        }

        postProcessingVolume.enabled = true;
        SetInstantCameraTransition();

        var composer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        if (composer != null)
        {
            composer.m_TrackedObjectOffset = trackedOffsetRomeu;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("RB") || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(SwapPlayerWithDelay());
        }
    }

    IEnumerator SwapPlayerWithDelay()
    {
        yield return new WaitForSeconds(0.25f);
        SwapPlayer();
    }

    public void SwapPlayer()
    {
        var composer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();

        // Verifica se os players ainda existem antes de trocar
        if (isRomeuActive && playerJulieta != null)
        {
            // Mudar para Julieta se ela existir
            virtualCamera.Follow = playerJulieta;
            virtualCamera.LookAt = playerJulieta;
            virtualCamera.m_Lens.OrthographicSize = orthoSizeJulieta;

            if (composer != null)
            {
                composer.m_TrackedObjectOffset = trackedOffsetJulieta;
            }

            if (romeuScript != null)
                romeuScript.enabled = false;
            julietaScript.enabled = true;
            postProcessingVolume.enabled = false;
        }
        else if (!isRomeuActive && playerRomeu != null)
        {
            // Mudar para Romeu se ele existir
            virtualCamera.Follow = playerRomeu;
            virtualCamera.LookAt = playerRomeu;
            virtualCamera.m_Lens.OrthographicSize = orthoSizeRomeu;

            if (composer != null)
            {
                composer.m_TrackedObjectOffset = trackedOffsetRomeu;
            }

            romeuScript.enabled = true;
            if (julietaScript != null)
                julietaScript.enabled = false;
            postProcessingVolume.enabled = true;
        }

        // Garantir que a transição ocorra de maneira suave
        SetInstantCameraTransition();

        // Alterna o estado apenas se o player para o qual está trocando existir
        if ((isRomeuActive && playerJulieta != null) || (!isRomeuActive && playerRomeu != null))
        {
            isRomeuActive = !isRomeuActive;
        }
    }

    void SetInstantCameraTransition()
    {
        var composer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        if (composer != null)
        {
            composer.m_XDamping = 0f;
            composer.m_YDamping = 0f;
            composer.m_ZDamping = 0f;
        }

        var transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        if (transposer != null)
        {
            transposer.m_XDamping = 0f;
            transposer.m_YDamping = 0f;
            transposer.m_ZDamping = 0f;
        }
    }
}
