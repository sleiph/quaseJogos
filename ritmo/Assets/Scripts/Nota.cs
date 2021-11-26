using UnityEngine;

public class Nota {
  // classe q da forma aos prefabs

  public Vector3 posicao { get; set;}
  public Quaternion rotacao { get; set;}

  public GameObject prefab { get; set;}

  public Nota (float x, int rot, GameObject prefab) {
    posicao = new Vector3(x, 0, 0);
    rotacao = Quaternion.Euler(0, 0, rot);
    this.prefab = prefab;
  }
}
