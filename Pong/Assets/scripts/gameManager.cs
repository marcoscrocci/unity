using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

	public int pontuacao1;
	public int pontuacao2;
	public Text pontos_player1;
	public Text pontos_pleyer2;

	// Use this for initialization
	void Start () {
		pontuacao1 = 0;
		pontuacao2 = 0;
	}
	
	// Update is called once per frame
	void Update () {
		pontos_player1.text = pontuacao1.ToString();
		pontos_pleyer2.text = pontuacao2.ToString();
	}
}
