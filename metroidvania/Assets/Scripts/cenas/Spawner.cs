using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Poder[] poderes;

    private GameObject prota;

    void Spawnar() {
        foreach (Poder p in poderes) {
            if (p.status) {
                GameObject poder = Instantiate(p.prefab);
                poder.transform.parent = transform;
                poder.transform.localPosition = p.coords;
                poder.GetComponent<Poderzin>().tipo = p.tipo;
            }
        }
    }

    void Start()
    {
        prota = GameObject.Find("Protagonista");

        Spawnar();
    }

}
