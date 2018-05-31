using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMobile : MonoBehaviour {

	private Rigidbody2D rbPlayer;
	public bool apertando;
	public float velocidade;

	// Use this for initialization
	void Start () {
		rbPlayer = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			apertando = true;
		} else {
			apertando = false;
		}
	}

	void FixedUpdate() {
		if (apertando) {
			Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 mousePos2D = new Vector2 (mousePos3D.x, mousePos3D.y);
			Vector2 dir = mousePos2D - new Vector2 (0, transform.position.y);
			rbPlayer.velocity = new Vector2 (0, dir.y * velocidade);
		} else {
			rbPlayer.velocity = Vector2.zero;
		}
	}
}
