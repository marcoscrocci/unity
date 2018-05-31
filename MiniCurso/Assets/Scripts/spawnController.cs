using UnityEngine;
using System.Collections;

public class spawnController : MonoBehaviour {

	public GameObject barreiraPrefab;
	public float rateSpawn;
	private float currentTime;
	private int posicao;
	private float y;
	public float posA;
	public float posB;

	// Use this for initialization
	void Start () {
		currentTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		if (currentTime >= rateSpawn) {
			currentTime = 0;
			posicao = Random.Range (1, 100);
			if (posicao > 50) {
				y = posA; //0.35f;
			} else {
				y = posB; //-0.265f;
			}
			GameObject tempPrefab = Instantiate (barreiraPrefab) as GameObject;
			tempPrefab.transform.position = new Vector3 (transform.position.x, y, tempPrefab.transform.position.z);

		}

	}
}
