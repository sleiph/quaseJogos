using UnityEngine;

public class Poderzin : MonoBehaviour
{
    [SerializeField] public string tipo;

    void OnTriggerEnter2D(Collider2D outro) {
        if (outro.tag == "Player") {
            Tipar(outro);

            Destroy(gameObject);
        }
    }

    void Tipar(Collider2D prota) {
        if (tipo == "paredabilidade") {
            Paredabilizar(prota);
        }
        else if (tipo == "escudo") {
            Escudar(prota);
        }
    }

    void Paredabilizar(Collider2D prota) {
        PhysicsMaterial2D Paredavel = new PhysicsMaterial2D();
        Paredavel.friction = 1f;
        Paredavel.name = "Paredavel";
        
        prota.sharedMaterial = Paredavel;

        GameObject jogador = prota.gameObject;
        jogador.GetComponent<CharController>().poderzinhos.Add("paredabilidade");
    }

    void Escudar(Collider2D prota) {
        Debug.Log("yay, escudo");
    }

}
