using UnityEngine;
using System.Collections;

public class espinho : MonoBehaviour {

	private Rigidbody2D espinhoRb;
	public int atritoMinimo, atritoMaximo;
	public Vector3 posicao;
	public GameObject espinhoPrefab;
	private int atrito;

	// Use this for initialization
	void Start () {

		espinhoRb = GetComponent<Rigidbody2D> ();
		atrito = Random.Range (atritoMinimo, atritoMaximo);
		espinhoRb.drag = atrito;
		posicao = transform.position;
		//print ("Novo espinho");
			
	}
	
	void OnBecameInvisible() {
	
		Instantiate (espinhoPrefab, posicao, transform.localRotation);
		pontuacao.pontos += 1;
		Destroy (this.gameObject);


	}

}
