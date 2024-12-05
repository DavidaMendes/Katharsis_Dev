using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerOne : MonoBehaviour
{
    [SerializeField] float speed = 8f;
    [SerializeField] float crouchSpeed = 1.5f; 
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] float jumpForce = 300f;
    [SerializeField] LayerMask layerMask;
    private bool facingRight;
    private Animator anim;
    private bool isCrouching;
    private Vector2 originalColliderSize;
    private Vector2 originalColliderOffset;
    [SerializeField] Vector2 crouchColliderSize = new Vector2(1f, 0.5f);
    [SerializeField] Vector2 crouchColliderOffset = new Vector2(0f, -0.25f);
    [SerializeField] BoxCollider2D boxCollider;
    private GameObject currentDoor;

    private float currentSpeed; 

    // Animações relacionadas ao pai
    public bool isJulietaScare;
    public bool isJulietaDead;

    void Start()
    {
        isCrouching = false;
        anim = GetComponent<Animator>();

        originalColliderSize = boxCollider.size;
        originalColliderOffset = boxCollider.offset;

        currentSpeed = speed; 
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveInput * currentSpeed, rb.velocity.y);

        if ((Input.GetButtonDown("JumpJoyStick") || Input.GetKeyDown(KeyCode.W)) && GroundCheck())
        {
            rb.AddForce(Vector2.up * jumpForce);
        }

        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        anim.SetFloat("hSpeed", Mathf.Abs(moveInput));
        anim.SetFloat("Jumped", rb.velocity.y);
        anim.SetBool("isGround", GroundCheck());
        anim.SetBool("isScare", isJulietaScare);
        anim.SetBool("isDead", isJulietaDead);

        Crouch();

        // Verifica interação com Fire2 ou P
        if (currentDoor != null && (Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.E)))
        {
            OpenDoor();
        }
    }

    bool GroundCheck()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, layerMask);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }

    // Função de agachar
    void Crouch()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetButton("RB"))
        {
            isCrouching = true;
            boxCollider.size = crouchColliderSize;
            boxCollider.offset = crouchColliderOffset;
            currentSpeed = crouchSpeed; 
        }
        else
        {
            isCrouching = false;
            boxCollider.size = originalColliderSize;
            boxCollider.offset = originalColliderOffset;
            currentSpeed = speed; 
        }

        anim.SetBool("isCrouch", isCrouching);
    }

    // Função para abrir portas ao colidir com elas
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Door"))
        {
            currentDoor = collision.gameObject;
        }
    }

    // Quando o jogador sai da colisão com a porta, ele não pode mais abrir
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Door"))
        {
            currentDoor = null;
        }
    }

    // Função para abrir a porta
    void OpenDoor()
    {
        if (currentDoor != null)
        {
            Collider2D doorCollider = currentDoor.GetComponent<Collider2D>();
            if (doorCollider != null)
            {
                doorCollider.enabled = false;
            }
        }
    }
}
