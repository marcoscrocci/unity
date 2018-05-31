using UnityEngine;
using System.Collections;

// Barreira inferior - y = -0.264
// Barreira superior - y = 0.341
// Destruir barreira - x = -6
// Spawn - x = 6



public class moveObjeto : MonoBehaviour {

	public float speed;
	private float x;
	public GameObject player;
	private bool pontuado;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
		x = transform.position.x;
		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);

		if (x <= -7) {
			Destroy (transform.gameObject);
		}

		if (x < player.transform.position.x && !pontuado) {
			pontuado = true;
			PlayerController.pontuacao += 1;
		}

	}
}
