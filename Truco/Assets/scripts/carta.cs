using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carta : MonoBehaviour
{
	public int valor; // Valor da força da carta.
	private bool manilha; // Quando o valor 1 é uma manilha.
	public int valorManilha; // De 1 a 4, onde o valor da carta passa a ser o valor 13 + o valor da manilha.

	// Use this for initialization
	void Start ()
	{
		//print ("carta.cs");
	}

	// Update is called once per frame
	void Update ()
	{
		//print ("carta.cs");
	}

	public int GetValor() {
		int resultado = 0;

		if (manilha) {
			resultado = 13 + valorManilha;
		} else {
			resultado = valor;
		}

		return resultado;
	}

	public void SetManilha(bool valor) {
		manilha = valor;
	}

	public bool GetManilha() {
		return manilha;
	}

}
