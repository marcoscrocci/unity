using UnityEngine;
using System.Collections;

public class comandosBasicos : MonoBehaviour {

	public GameObject player;

	public void btnPularClick() {
		player.GetComponent<PlayerController> ().pular = true;
	}

	public void btnEscorregarClick() {
		player.GetComponent<PlayerController> ().escorregar = true;
	}

}
