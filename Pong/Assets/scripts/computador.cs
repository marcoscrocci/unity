//Script criado pelo canal Cria Jogos
//https://goo.gl/0AEeuC
//criajogos.equilibrecursos.net

using UnityEngine;
using System.Collections;

public class computador : MonoBehaviour {

	public Transform bolinha;
	public float velocidade;

	private Rigidbody2D rbComp;

	// Use this for initialization
	void Start () {
		rbComp = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		rbComp.velocity = new Vector2(0, (bolinha.transform.position.y - transform.position.y) * velocidade);
	}
}