using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arqueiro : MonoBehaviour
{
    [Range(0, 10f)] [SerializeField] private float velocidadeTiro = 5f;

    void Atirar() {
        Debug.Log(this.transform.GetChild(1).position);
        Debug.Log(this.transform.position - this.transform.GetChild(1).position);
    }

    void OnTriggerEnter2D(Collider2D outro) {
        if (outro.tag == "Player") {
            InvokeRepeating("Atirar", 0f, velocidadeTiro);
        }
    }

}
