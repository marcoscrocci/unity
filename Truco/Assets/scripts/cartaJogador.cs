using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartaJogador : MonoBehaviour {

	private carta cartaRecebida;

	// Use this for initialization
	void Start () {
		//b = FindObjectOfType<baralho> ();
		//Instantiate(b.cartas [0], transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void gerarCarta(carta c) {
		cartaRecebida = Instantiate(c, transform.position, Quaternion.identity);
	}

	public void destruirCarta() {
		Destroy (cartaRecebida.gameObject);
	}

	public carta GetCarta() {
		return cartaRecebida;
	}
		

}
