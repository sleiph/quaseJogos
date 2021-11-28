using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poderzin : MonoBehaviour
{
    [SerializeField] private bool isParedabilidade;

    void OnTriggerEnter2D(Collider2D outro) {
        if (outro.tag == "Player") {
            if (isParedabilidade) {
                Paredabilizar(outro);
            }
        }

        Destroy(gameObject);
        
    }

    void Paredabilizar(Collider2D coll) {
        PhysicsMaterial2D Paredavel = new PhysicsMaterial2D();
        Paredavel.friction = 1f;
        Paredavel.name = "Paredavel";
        
        coll.gameObject.GetComponent<BoxCollider2D>().sharedMaterial = Paredavel;
        coll.gameObject.GetComponent<CircleCollider2D>().sharedMaterial = Paredavel;

        GameObject jogador = coll.gameObject;
        jogador.GetComponent<CharController>().isParedavel = true;
    }

}
