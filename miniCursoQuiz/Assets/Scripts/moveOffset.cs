using UnityEngine;
using System.Collections;

public class moveOffset : MonoBehaviour {

	private Material materialAtual;
	public float velocidade;
	private float offset;

	// Use this for initialization
	void Start () {
		materialAtual = GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	// Alterado para FixedUpdate para os frames por segundo não mudar as vezes que passa aqui por segundo.
	void FixedUpdate () {

		offset += 0.001f;
		//print (offset);
		materialAtual.SetTextureOffset("_MainTex", new Vector2(offset * velocidade, 0));

	}
}
