using UnityEngine;

public class ButtonAnimationReset : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        
        if (animator != null)
        {
            animator.Play("Seleted", -1, 0f); 
        }
    }
}
