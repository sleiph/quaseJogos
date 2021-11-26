using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checker : MonoBehaviour
{
    Animator animator;

    // qual a tecla desse checker
    public string key;

    // mae dos textos de interface
    public GameObject uinterfaceGO;
    uinterface uInterface;

    // pra saber se tem algo dentro do checker
    List<seta> setas;

    // recompensa as setas acertadas
    void Recompensa() {
        foreach (seta s in setas) {
            // manda a interface mudar o score
            uInterface.MudaScore(s.GetPontos());

            // e o combo
            uInterface.MudaCombo(true);

            // confirma que a nota foi acertada
            s.deuTudoCerto = true;
        }
    }

    // se a nota entrar no check
    void OnTriggerEnter2D(Collider2D col) {
        setas.Add( col.gameObject.GetComponent<seta>() );
    }

    // se a nota sair de dentro do check
    void OnTriggerExit2D(Collider2D col) {
        seta s = col.gameObject.GetComponent<seta>();

        // se nao tiver apertado a tecla, perdeu o combo
        if (!s.deuTudoCerto)
            uInterface.MudaCombo(false);

        int i = setas.IndexOf( s );
        setas.RemoveAt(i);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();

        uInterface = uinterfaceGO.GetComponent<uinterface>();

        setas = new List<seta>();
    }

    // Update is called once per frame
    void Update()
    {       
        animator.SetBool("keyDown", Input.GetKey(key));
        
        // quebra o combo se apertar sem notas por perto
        if (Input.GetKeyDown(key)) {
            if (setas.Count > 0) {
                Recompensa();
            }
            else {
                uInterface.MudaCombo(false);
            }
        }
    }
}
