using System;
using UnityEngine.UI;
using UnityEngine;

public class uinterface : MonoBehaviour
{
    int score;
    Text scoreText;

    int combo;
    Text comboText;

    public void MudaScore(int s) {
        // adiciona o combo na pontuacao
        s += combo;

        score += s;
        scoreText.text = String.Format("Score: {0}", score);
    }

    public void MudaCombo(bool isCombando) {
        combo = (isCombando ? combo + 1 : 0 );
        comboText.text = String.Format("Combo: {0}", combo);
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = transform.GetChild(0).GetComponent<Text>();

        combo = 0;
        comboText = transform.GetChild(1).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
