using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovimento : MonoBehaviour
{
    public CharController controller;

    public float runSpeed = 40f;
    float horizontalMove = 0f;

    bool isPulando = false;

    void Start()
    {
        
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) {
            isPulando = true;
        }
    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, isPulando);
        isPulando = false;
    }
}
