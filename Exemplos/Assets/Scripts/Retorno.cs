using UnityEngine;
using System.Collections;

public class Retorno : MonoBehaviour {

	public float cronometro;
	public int condicao;
	public int resultado;
	public string tecla;

	//public GUIText gt;
	//public int idioma;
	//Vector3 vector;

	// Use this for initialization
	void Start () {
		//resultado = somatoria (5, 6);
		//resultado = AreaCubo (5, 5, 5);
		//gt = GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if( Input.anyKey )
		{
			if (Input.inputString.Length != 0) {
				tecla = Input.inputString;
			}
		}

		/*
		if (condicao != 0) {
			return;
		}

		cronometro += Time.deltaTime; */
	}

	int somatoria(int x, int y) {
		return x + y;

	}

	int AreaCubo(int a, int b, int c) {
		return a * b * c;
	}

}
