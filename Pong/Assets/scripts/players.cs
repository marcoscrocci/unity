using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Jogar com o Mouse e contra o computador:
//	GameObject "player1": Desativar o script "players" e ativar o script "computador".
//	GameObject "player2": Ativar o script "playerMobile".
// Jogar com o teclado com dois jogadores humanos:
//	GameObject "player1": Ativar o script "players" e desativar o script "computador".
//	GameObject "player2": Desativar o script "playerMobile".

public class players : MonoBehaviour {

	public float velocidade;
	public GameObject player1;
	public GameObject player2;
	public Rigidbody2D rbp1;
	public Rigidbody2D rbp2;

	// Use this for initialization
	void Start () {
		//rbp1 = GameObject.Find("player1").GetComponent<Rigidbody2D> ();
		//rbp2 = GameObject.Find("player2").GetComponent<Rigidbody2D> ();
		rbp1 = player1.GetComponent<Rigidbody2D> ();
		rbp2 = player2.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position += new Vector3 (0, Input.GetAxis ("Vertical") * velocidade * Time.deltaTime, 0);
		//player1.transform.position += new Vector3 (0, Input.GetAxis ("vPlayer1") * velocidade * Time.deltaTime, 0);
		//player2.transform.position += new Vector3 (0, Input.GetAxis ("vPlayer2") * velocidade * Time.deltaTime, 0);
	}

	void FixedUpdate () {
		rbp1.velocity = new Vector2 (0, Input.GetAxis ("vPlayer1") * velocidade);
		rbp2.velocity = new Vector2 (0, Input.GetAxis ("vPlayer2") * velocidade);
	}


}
