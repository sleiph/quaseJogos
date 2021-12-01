using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arqueiro : MonoBehaviour
{
    [Range(0, 8f)] [SerializeField] private float velocidadeTiro = 4f;
    [SerializeField] private GameObject projetil;

    private bool isAtirando = false;

    void Atirar() {
        float direcao = this.transform.position.x - this.transform.GetChild(1).position.x;
        Vector3 spawn = new Vector3(-direcao, 0, transform.position.z);
        GameObject flecha = Instantiate(projetil);
        flecha.transform.parent = transform;
        flecha.transform.localPosition = spawn;
        flecha.GetComponent<Flecha>().EscolherDirecao(
            direcao
        );
        Debug.Log(spawn);
    }

    void OnTriggerEnter2D(Collider2D outro) {
        if (outro.tag == "Player") {
            if (!isAtirando) {
                InvokeRepeating("Atirar", .1f, velocidadeTiro);
                isAtirando = true;
            }
        }
    }

}
