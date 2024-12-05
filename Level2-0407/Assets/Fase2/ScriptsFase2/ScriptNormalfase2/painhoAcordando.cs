using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class painhoAcordando : MonoBehaviour
{
    [SerializeField] private GameObject zzZ;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private CinemachineImpulseSource shack;

    private Vector2 originalColliderSize;
    private Vector2 originalColliderOffset;
    [SerializeField] private Vector2 newColliderSize = new Vector2(30f, 23f);
    [SerializeField] private Vector2 newColliderOffset = new Vector2(0f, 0f);

    [SerializeField] private int tempoInicial = 15;
    [SerializeField] private int tempoFinal = 20;

    private Animator anim;
    private bool isAcordando;
    private bool isOlhosAbertos;

    public bool IsAcordando => isAcordando;
    public bool IsOlhosAbertos => isOlhosAbertos;

    public AudioSource soundRonco;
    public AudioSource soundAcordando;
    public AudioSource soundDeathJulieta;

    public playerOne scriptJulieta;

    void Start()
    {
        scriptJulieta = FindAnyObjectByType<playerOne>();
        StartSound(soundRonco);
        anim = GetComponent<Animator>();
        originalColliderSize = boxCollider.size;
        originalColliderOffset = boxCollider.offset;
        StartCoroutine(AcordarDormirLoop());
    }

    void Update()
    {
        anim.SetBool("isAcordando", isAcordando);
        anim.SetBool("isOlhosAbertos", isOlhosAbertos);
    }

    public IEnumerator AcordarDormirLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetRandomInterval());
            Acordando();

            yield return new WaitForSeconds(4f);
            AbrindoOlho();

            yield return new WaitForSeconds(0.5f);
            PainhoAcordado();

            yield return new WaitForSeconds(2f);
            Dormindo();
        }
    }

    public void Acordando()
    {
        isAcordando = true;
        shack.GenerateImpulseWithForce(2f);
    }

    private void AbrindoOlho()
    {
        isOlhosAbertos = true;
        StopSound(soundRonco);
    }

    public void PainhoAcordado()
    {
        soundAcordando.Play();
        isAcordando = false;
        isOlhosAbertos = true;
        boxCollider.size = newColliderSize;
        boxCollider.offset = newColliderOffset;
    }

    public void Dormindo()
    {
        isOlhosAbertos = false;
        isAcordando = false;
        boxCollider.size = originalColliderSize;
        boxCollider.offset = originalColliderOffset;
        StartSound(soundRonco);
    }

    float GetRandomInterval()
    {
        int randomTime = Random.Range(tempoInicial, tempoFinal);
        Debug.Log(randomTime);
        return (float)randomTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(HandlePlayerDeath(col.gameObject));
        }
    }

    private IEnumerator HandlePlayerDeath(GameObject player)
    {
        if (!soundDeathJulieta.isPlaying)
        {
            soundDeathJulieta.Play();
        }
        scriptJulieta.isJulietaScare = true;
        yield return new WaitForSeconds(1f);

        scriptJulieta.isJulietaScare = false;
        scriptJulieta.isJulietaDead = true;
        yield return new WaitForSeconds(2f);

        Destroy(player);
        yield return new WaitForSeconds(0.5f);
        
        SceneManager.LoadScene("GameOver");
    }

    public void StartSound(AudioSource para)
    {
        if (para != null && !para.isPlaying)
        {
            para.Play();
            para.loop = true;
        }
    }

    public void StopSound(AudioSource para)
    {
        if (para != null && para.isPlaying)
        {
            para.loop = false;
            para.Stop();
        }
    }
}
