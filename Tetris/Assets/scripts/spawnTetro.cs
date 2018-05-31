using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnTetro : MonoBehaviour {

	public int mostraProximaPeca;

	public Transform[] criaPecas;
	public List<GameObject> mostraPecas;

	// Use this for initialization
	void Start () {

		mostraProximaPeca = Random.Range(0, 7);
		proximaPeca();
	}

	public void proximaPeca()
	{
		Instantiate(criaPecas[mostraProximaPeca], transform.position, Quaternion.identity);

		mostraProximaPeca = Random.Range(0, 7);

		for (int i = 0; i < mostraPecas.Count; i++)
		{
			mostraPecas[i].SetActive(false);
		}

		mostraPecas[mostraProximaPeca].SetActive(true);
	}




}