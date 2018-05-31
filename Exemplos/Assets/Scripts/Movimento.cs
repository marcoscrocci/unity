using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {

	public float velocidade;
	private Vector3 posicao;

	// Use this for initialization
	void Start () {
		posicao = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x + velocidade * Time.deltaTime, 0, 0);
	}
}
