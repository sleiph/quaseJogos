using System;
using UnityEngine;

public class spawner : MonoBehaviour
{
    // prefabs pra desenhar as notas
    public GameObject seta;
    public GameObject circulo;
    // valores de spawn dos prefabs
    Nota[] notas;

    // arquivo q mostra quando spawnar cada nota
    public TextAsset notasTXT;
    string[] linhas;
    // contador de linhas do arquivo txt
    int indice; 
    // valores da proxima linha do txt
    int[] proximaNota;

    // contador de tempo
    int segundos;

    // le a proxima linha do txt
    int[] LerProximaLinha(int i) {
        string linha = linhas[i];
        string[] temp = linha.Split(' ');
        int[] valores = new int[] {
            Int32.Parse(temp[0]),
            Int32.Parse(temp[1]),
            Int32.Parse(temp[2])
        };
        return valores;
    }

    // spawna uma Nota
    void Spawn (Nota nota, float velo) {
        GameObject myNota = Instantiate(nota.prefab);
        myNota.transform.parent = transform;
        myNota.transform.localPosition = nota.posicao;
        myNota.transform.localRotation = nota.rotacao;
        myNota.GetComponent<seta>().velocidade = velo;
    }

    // spawna todas as notas de cada segundo
    void SpawnaNotas() {
        segundos += 1;
        
        // se o arquivo nao tiver terminado
        if (proximaNota[0] != 0 && proximaNota[2] != 0) {
            // se for tempo de spawnar as notas
            if (segundos == proximaNota[0]) {
                int[] temp = proximaNota;

                // spawna todas as notas com o mesmo tempo de inicio
                while (proximaNota[0] == temp[0]) {
                    Spawn( notas[temp[1]], temp[2] );
                    temp = LerProximaLinha(indice++);
                }
                
                proximaNota = temp;
            }
        }
        else {
            // volta do inicio do arquivo
            Comeca();
        }
    }

    // (re)inicia os valores das variaveis
    void Comeca() {
        segundos = 0;
        indice = 0;
        proximaNota = LerProximaLinha(indice++);
    }

    // Start is called before the first frame update
    void Start()
    {
        // inicia os valores
        linhas = notasTXT.text.Split('\n');
        Comeca();

        // cria os prefabs possiveis
        notas = new Nota[5] {
            new Nota(-3.5f, 90, seta),  // esquerda
            new Nota(-1.5f, 0, seta),   // cima
            new Nota(1.5f, 180, seta),  // baixo
            new Nota(3.5f, -90, seta),  // direita
            new Nota(0, 0, circulo)     // tudo
        };

        // chama a funcao de spawn a cada segundo
        InvokeRepeating("SpawnaNotas", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
