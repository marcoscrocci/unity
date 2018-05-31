using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class player : MonoBehaviour {

	private Rigidbody2D playerRb;
	public float velocidade;
	private SpriteRenderer playerSprite;
	public bool flipX;

	// Use this for initialization
	void Start () {
		
		playerRb = GetComponent<Rigidbody2D> ();
		playerSprite = GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {

			velocidade *= -1;
			flipX = !flipX;
			playerSprite.flipX = flipX;

		}

		playerRb.velocity = new Vector2 (velocidade, playerRb.velocity.y);

	}


	void OnCollisionEnter2D(Collision2D colisao) {

		if (colisao.gameObject.tag == "espinho") {
			SceneManager.LoadScene ("gameover");
		} else {
			print (colisao.gameObject.tag);
		}

	}

	void OnTriggerEnter2D(Collider2D colisao) {

		if (colisao.gameObject.tag == "espinho") {
			SceneManager.LoadScene ("gameover");
		} else {
			print (colisao.gameObject.tag);
		}

	}



}
