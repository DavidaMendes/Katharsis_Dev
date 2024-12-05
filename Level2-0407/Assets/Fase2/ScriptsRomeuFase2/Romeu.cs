using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Romeu : MonoBehaviour
{
    public float Speed;
    public AudioSource soundMoveRomeu;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector2 direction; // Variável para armazenar o valor dos eixos

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        // Verifique se o AudioSource foi atribuído corretamente
        if (soundMoveRomeu == null)
        {
            Debug.LogError("AudioSource não atribuído no Inspector.");
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        direction.x = Input.GetAxis("Horizontal"); 
        direction.y = Input.GetAxis("Vertical");   

        if (direction != Vector2.zero)
        {
            StartSound(soundMoveRomeu);
        }
        else
        {
            StopSound(soundMoveRomeu);
        }

        // Movimenta o personagem
        rb.velocity = direction.normalized * Speed;

        // Controla a animação e o flip da sprite dependendo do eixo X
        if (direction.x != 0)
        {
            resetLayer();
            anim.SetLayerWeight(2, 1);

            if (direction.x > 0)
            {
                sprite.flipX = false; // Movendo para a direita
            }
            else if (direction.x < 0)
            {
                sprite.flipX = true; // Movendo para a esquerda
            }
        }

        // Controla a animação dependendo do eixo Y
        if (direction.y > 0 && direction.x == 0)
        {
            resetLayer();
            anim.SetLayerWeight(1, 1); // Indo para cima
        }
        if (direction.y < 0 && direction.x == 0)
        {
            resetLayer();
            anim.SetLayerWeight(0, 1); // Indo para baixo
        }

        // Define se o personagem está andando ou parado
        if (direction != Vector2.zero)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }

    }

    // Função para resetar as camadas de animação
    private void resetLayer()
    {
        anim.SetLayerWeight(0, 0);
        anim.SetLayerWeight(1, 0);
        anim.SetLayerWeight(2, 0);
    }
    // Inicia o som de movimento
    public void StartSound(AudioSource para)
    {
        if (para != null && !para.isPlaying)
        {
            para.Play();
            para.loop = true;
        }
    }

    // Para o som de movimento
    public void StopSound(AudioSource para)
    {
        if (para != null && para.isPlaying)
        {
            para.loop = false;
            para.Stop();
        }
    }
}
