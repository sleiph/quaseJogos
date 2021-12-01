using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{
    [Range(0, .4f)] [SerializeField] private float velocidade = .1f;
    [SerializeField] private bool isPraDireita = true;

    void OnTriggerEnter2D(Collider2D outro) {
        if (outro.gameObject.layer == LayerMask.NameToLayer("Plataformas")) {
            Destroy(gameObject);
        }
        else if (outro.tag == "Player") {
            Destroy(gameObject);
        }
    }

    public void EscolherDirecao(float direcao) {
        if (direcao > 0) {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
            isPraDireita = false;
        }
    }

    void FixedUpdate() {
        if (isPraDireita)
            transform.position += new Vector3(velocidade, 0, 0);
        else
            transform.position += new Vector3(-velocidade, 0, 0);
    }
}
