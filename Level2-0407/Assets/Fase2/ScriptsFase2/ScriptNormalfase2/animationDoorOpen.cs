using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationDoorOpen : MonoBehaviour
{
    public Sprite doorClosedSprite;
    public Sprite doorOpenSprite;
    private SpriteRenderer spriteRenderer;
    private Collider2D doorCollider;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        doorCollider = GetComponent<Collider2D>();
        spriteRenderer.sprite = doorClosedSprite; 
    }

    void Update()
    {
        if (!doorCollider.enabled)
        {
            spriteRenderer.sprite = doorOpenSprite;
        }
        else
        {
            spriteRenderer.sprite = doorClosedSprite; 
        }
    }

    public void ToggleDoor()
    {
        doorCollider.enabled = !doorCollider.enabled;
    }
}
