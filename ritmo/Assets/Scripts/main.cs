using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("cima", Input.GetKey("up"));
        animator.SetBool("baixo", Input.GetKey("down"));
        animator.SetBool("esquerda", Input.GetKey("left"));
        animator.SetBool("direita", Input.GetKey("right"));
        animator.SetBool("tudo", Input.GetKey("space"));
    }
}
