using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onomatopeiaAnim : MonoBehaviour
{
    private painhoAcordando scriptPai;
    private Animator anim;
    private bool isAfirmacao;

    void Start()
    {
        anim = GetComponent<Animator>();
        scriptPai = FindObjectOfType<painhoAcordando>();
        isAfirmacao = false;
    }

    void Update()
    {
        isAfirmacao = scriptPai.IsOlhosAbertos;
        anim.SetBool("isAfirmacao", isAfirmacao);
    }
}
