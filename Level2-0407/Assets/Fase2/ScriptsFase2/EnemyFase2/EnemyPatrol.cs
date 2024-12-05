using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2.0f;
    public Vector2[] points; // Array de pontos para a patrulha
    private int currentPointIndex = 0; // Índice do ponto atual

    void Start()
    {
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
        // Mover o inimigo em direção ao ponto atual
        transform.position = Vector2.MoveTowards(transform.position, points[currentPointIndex], speed * Time.deltaTime);

        // Verificar se o inimigo chegou ao ponto atual
        if (Vector2.Distance(transform.position, points[currentPointIndex]) < 0.1f)
        {
            // Avançar para o próximo ponto
            currentPointIndex = (currentPointIndex + 1) % points.Length;
        }
    }
}
