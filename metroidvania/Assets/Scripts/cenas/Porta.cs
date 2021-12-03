using UnityEngine;
using UnityEngine.SceneManagement;

public class Porta : MonoBehaviour
{
    [SerializeField] private string proximaCena;

    [SerializeField] private Vector3 spawnPoint;

    void OnTriggerEnter2D(Collider2D outro) {
        if (outro.tag == "Player") {
            outro.transform.position = spawnPoint;

            SceneManager.LoadScene(proximaCena);
        }
        
    }

}
