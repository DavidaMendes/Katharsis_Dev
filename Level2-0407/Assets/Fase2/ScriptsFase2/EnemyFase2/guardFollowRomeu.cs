using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardFollowRomeu : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject romeu;
    private Transform target;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    void Start()
    {
        if (romeu != null)
        {
            target = romeu.GetComponent<Transform>();
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            UpdateAnimations();
        }
    }

    private void UpdateAnimations()
    {
        Vector2 direction = target.position - transform.position;

        ResetLayer();

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                anim.SetLayerWeight(2, 1);
                spriteRenderer.flipX = false;
            }
            else if (direction.x < 0)
            {
                anim.SetLayerWeight(2, 1);
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            if (direction.y > 0)
            {
                anim.SetLayerWeight(0, 1);
            }
            else if (direction.y < 0)
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
