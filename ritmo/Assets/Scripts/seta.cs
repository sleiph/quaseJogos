using UnityEngine;

public class seta : MonoBehaviour
{
    // valida se a seta foi acertada
    public bool deuTudoCerto;

    // pontuação
    public float velocidade;

    public int GetPontos() {
        // calculo de pontuação
        /// quao dentro do checker vc apertou o botao
        int precisao = (int)(transform.position.y*10);
        if (precisao>-10)
            precisao += Mathf.Abs(precisao) * 2;
        else
            precisao += 20;

        // depende da precisao e da velocidade da nota
        return (precisao + (int)velocidade);

        // no script de uinterface
        // o combo atual tmbm se soma à nota
    }

    // Start is called before the first frame update
    void Start()
    {
        // atitude pessimista
        /// tipicamente associada a filhos de familias pequeno-burguesas
        deuTudoCerto = false;
    }

    // Update is called once per frame
    void Update()
    {
        // move pra baixo com velocidade constante
        transform.Translate(
            new Vector3(0, -velocidade, 0) * Time.deltaTime, Space.World
        );

        // destroi quando foi acertada
        if (deuTudoCerto)
            Destroy(gameObject);

        // destroi quando sai da tela
        if (transform.position.y < -5f) {
            Destroy(gameObject);
        }
    }
}
