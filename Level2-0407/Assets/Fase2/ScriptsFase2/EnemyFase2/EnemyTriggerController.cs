using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyTriggerController : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 3.5f;
    private Vector2 enemyDirection;
    private Rigidbody2D enemyRb;
    public AreaController detectionArea;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite spriteNormal;
    private Animator anim;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>(); 
    }

    void Update()
    {
        if (detectionArea.detectedObjs.Count > 0)
        {
            UpdateAnimations();
        }
        else
        {
            ResetLayer();
            anim.SetBool("walking", false);
            spriteRenderer.sprite = spriteNormal;
        }
    }

    private void FixedUpdate()
    {
        if (detectionArea.detectedObjs.Count > 0)
        {
            enemyDirection = (detectionArea.detectedObjs[0].transform.position - transform.position).normalized;
            enemyRb.MovePosition(enemyRb.position + enemyDirection * moveSpeed * Time.deltaTime);

            if (enemyDirection.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (enemyDirection.x < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
    }

    private void UpdateAnimations()
    {
        ResetLayer();

        if (Mathf.Abs(enemyDirection.x) > Mathf.Abs(enemyDirection.y))
        {
            if (enemyDirection.x > 0)
            {
                anim.SetLayerWeight(2, 1);
                spriteRenderer.flipX = false;
            }
            else if (enemyDirection.x < 0)
            {
                anim.SetLayerWeight(2, 1);
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            if (enemyDirection.y > 0)
            {
                anim.SetLayerWeight(0, 1);
            }
            else if (enemyDirection.y < 0)
            {
                anim.SetLayerWeight(1, 1);
            }
        }

        anim.SetBool("walking", true);
    }

    private void ResetLayer()
    {
        anim.SetLayerWeight(0, 0);
        anim.SetLayerWeight(1, 0);
        anim.SetLayerWeight(2, 0);
    }
}
