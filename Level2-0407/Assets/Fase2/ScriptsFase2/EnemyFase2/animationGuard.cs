using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationGuard : MonoBehaviour
{
    public float speed = 2.0f;
    public Vector2[] points; // Array de pontos para a patrulha
    private int currentPointIndex = 0; // Índice do ponto atual

    private Animator anim;
    private SpriteRenderer sprite;

    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        // Se não houver pontos definidos, adicionar pontos para formar um quadrado
        if (points.Length == 0)
        {
            Vector2 startPosition = transform.position;
            points = new Vector2[4];
            points[0] = startPosition;
            points[1] = startPosition + new Vector2(2, 0); // Ajuste conforme necessário
            points[2] = startPosition + new Vector2(2, -2);
            points[3] = startPosition + new Vector2(0, -2);
        }


    }

    void Update()
    {
        Vector2 currentPosition = transform.position;
        Vector2 targetPosition = points[currentPointIndex];

        // Mover o inimigo em direção ao ponto atual
        transform.position = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);

        // Verificar se o inimigo chegou ao ponto atual
        if (Vector2.Distance(currentPosition, targetPosition) < 0.1f)
        {
            // Avançar para o próximo ponto
            currentPointIndex = (currentPointIndex + 1) % points.Length;
        }

        // Atualizar animações
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        ResetLayer();

        switch (currentPointIndex)
        {
            case 0:
                
                anim.SetLayerWeight(0, 1);
                sprite.flipX = false;
                break;
            case 1:
                
                anim.SetLayerWeight(2, 1);
                break;
            case 2:
                
                anim.SetLayerWeight(1, 1);
                sprite.flipX = true;
                break;
            case 3:
                
                anim.SetLayerWeight(2, 1);
                break;
            default:
                break;
        }

        // Define o parâmetro "walking" para true
        anim.SetBool("walking", true);
    }

    private void ResetLayer()
    {
        anim.SetLayerWeight(0, 0);
        anim.SetLayerWeight(1, 0);
        anim.SetLayerWeight(2, 0);
    }
}
