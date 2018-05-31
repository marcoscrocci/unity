﻿using UnityEngine;
using System.Collections;

public class tetroMov : MonoBehaviour
{
	public bool podeRodar;
	public bool roda360;

	public float queda;

	public float velocidade;
	public float timer;

	gameManager gManager;
	spawnTetro gSpawner;

	void Start()
	{
		timer = velocidade;

		gManager = GameObject.FindObjectOfType<gameManager>();
		gSpawner = GameObject.FindObjectOfType<spawnTetro>();
	}

	// Update is called once per frame
	void Update()
	{
		if (!gManager.pause) {
			if (gManager.pontoDificuldade > 1000) {
				gManager.pontoDificuldade = 0;
				gManager.dificuldade += .5f;
			}

			if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.DownArrow))
				timer = velocidade;

			if (Input.GetKey (KeyCode.RightArrow)) {
				timer += Time.deltaTime;

				if (timer > velocidade) {
					transform.position += new Vector3 (1, 0, 0);
					timer = 0;
				}

				if (posicaoValida ()) {
					gManager.atualizaGrade (this);
				} else {
					transform.position += new Vector3 (-1, 0, 0);
				}
			}

			if (Input.GetKey (KeyCode.LeftArrow)) {
				timer += Time.deltaTime;

				if (timer > velocidade) {
					transform.position += new Vector3 (-1, 0, 0);
					timer = 0;
				}

				if (posicaoValida ()) {
					gManager.atualizaGrade (this);
				} else {
					transform.position += new Vector3 (1, 0, 0);
				}
			}

			if (Input.GetKey (KeyCode.DownArrow)) { //|| Time.time - queda >= 1)
				timer += Time.deltaTime;

				if (timer > velocidade) {
					transform.position += new Vector3 (0, -1, 0);
					timer = 0;
				}

				if (posicaoValida ()) {
					gManager.atualizaGrade (this);
				} else {
					transform.position += new Vector3 (0, 1, 0);
					gManager.apagaLinha ();
					if (gManager.acimaGrade (this)) {
						gManager.gameOver ();
					}
					gManager.score += 10;
					gManager.pontoDificuldade += 10;
					enabled = false;
					gSpawner.proximaPeca ();
				}
				//queda = Time.time;
			}

			if (Time.time - queda >= (1 / gManager.dificuldade) && !Input.GetKey (KeyCode.DownArrow)) {
				transform.position += new Vector3 (0, -1, 0);

				if (posicaoValida ()) {
					gManager.atualizaGrade (this);
				} else {
					transform.position += new Vector3 (0, 1, 0);
					gManager.apagaLinha ();
					if (gManager.acimaGrade (this)) {
						gManager.gameOver ();
					}
					gManager.score += 10;
					gManager.pontoDificuldade += 10;
					enabled = false;
					gSpawner.proximaPeca ();
				}

				queda = Time.time;
			}

			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				if (podeRodar) {
					if (!roda360) {
						if (transform.rotation.z < 0) {
							transform.Rotate (0, 0, 90);

							if (posicaoValida ()) {
								gManager.atualizaGrade (this);
							} else {
								transform.Rotate (0, 0, -90);
							}

						} else {
							transform.Rotate (0, 0, -90);

							if (posicaoValida ()) {
								gManager.atualizaGrade (this);
							} else {
								transform.Rotate (0, 0, 90);
							}

						}
					} else {
						transform.Rotate (0, 0, -90);

						if (posicaoValida ()) {
							gManager.atualizaGrade (this);
						} else {
							transform.Rotate (0, 0, 90);
						}
					}
				}
			}
		}
	}

	bool posicaoValida()
	{
		foreach (Transform child in transform)
		{
			Vector2 posBloco = gManager.arredonda(child.position);

			if (gManager.dentroGrade(posBloco) == false)
			{
				return false;
			}

			if (gManager.posicaoTransformGrade(posBloco) != null && gManager.posicaoTransformGrade(posBloco).parent != transform)
			{
				return false;
			}
		}
		return true;
	}



}