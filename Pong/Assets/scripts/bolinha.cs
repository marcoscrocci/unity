using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolinha : MonoBehaviour {

	private Rigidbody2D rb2D;
	public float x;
	public float y;
	public bool jogando;
	private gameManager gManagerScript;
	public AudioClip som1;
	public AudioClip som2;

	// Use this for initialization
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
		gManagerScript = GameObject.Find ("GameManager").GetComponent<gameManager>();

		x = Random.Range (-6f, 6f);
		y = Random.Range (-6f, 6f);

		rb2D.velocity = new Vector2 (x, y);

		jogando = true;

	}
	
	// Update is called once per frame
	void Update () {
		if (jogando) {
			if (rb2D.velocity.x < 2f && rb2D.velocity.x > -2f) {
				//rb2D.velocity = new Vector2 (2f, rb2D.velocity.y);
				if (rb2D.velocity.x >= 0) {
					rb2D.velocity = new Vector2 (2f, rb2D.velocity.y);
				} else {
					rb2D.velocity = new Vector2 (-2f, rb2D.velocity.y);
				}
			}

			if (rb2D.velocity.y < 2f && rb2D.velocity.y > -2f) {
				//rb2D.velocity = new Vector2 (rb2D.velocity.y, 2f);
				if (rb2D.velocity.y >= 0) {
					rb2D.velocity = new Vector2 (rb2D.velocity.x, 2f);
				} else {
					rb2D.velocity = new Vector2 (rb2D.velocity.x, -2f);
				}

			}
		}

		if ( (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && (!jogando)) {
			Start ();
		}
	}

	void OnTriggerEnter2D(Collider2D outro) {
		if (outro.gameObject.tag == "parede_direita") {
			rb2D.velocity = Vector2.zero;
			transform.position = new Vector3 (0, 0, 0);
			jogando = false;
			gManagerScript.pontuacao2 += 1;
		}
		if (outro.gameObject.tag == "parede_esquerda") {
			rb2D.velocity = Vector2.zero;
			transform.position = new Vector3 (0, 0, 0);
			jogando = false;
			gManagerScript.pontuacao1 += 1;
		}

	}

	void OnCollisionEnter2D(Collision2D colisao) {
		if (colisao.gameObject.tag == "parede") {
			AudioSource.PlayClipAtPoint (som2, transform.position);

		} else {
			AudioSource.PlayClipAtPoint (som1, transform.position);
		}

	}
}
