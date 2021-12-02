using UnityEngine;

public class controleMCC : MonoBehaviour
{
    [SerializeField] private GameObject poderzin;
    [SerializeField] private Vector3 spawnPoderzin;

    private GameObject prota;

    void Spawnar() {
        if (!prota.GetComponent<CharController>().ChecarPoderes("paredabilidade")) {
            GameObject poder = Instantiate(poderzin);
            poder.transform.parent = transform;
            poder.transform.localPosition = spawnPoderzin;
            poder.GetComponent<Poderzin>().tipo = "paredabilidade";
        }
    }

    void Start()
    {
        prota = GameObject.Find("Protagonista");

        Spawnar();
    }
}
