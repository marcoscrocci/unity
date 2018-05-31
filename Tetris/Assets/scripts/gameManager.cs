using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

	public static int altura = 20;
	public static int largura = 10;

	public int score = 0;
	public int pontoDificuldade = 0;
	public float dificuldade = 1;
	public Text textoScore;
	public Text textoGameOver;
	public static Transform[,] grade = new Transform[largura, altura];
	public bool pause = false;
	public Button botaoPause;
	//public Button botaoReset;

	void Start ()
	{
		textoGameOver.gameObject.SetActive (false);
		//botaoReset.gameObject.SetActive (false);
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (botaoPause.gameObject.activeSelf) {
				pausarJogo ();
			} else {
				ReiniciarJogo ();
			}
		}

		textoScore.text = score.ToString ();
	}

	public bool dentroGrade (Vector2 posicao)
	{
		return ((int)posicao.x >= 0 && (int)posicao.x < largura && (int)posicao.y >= 0);
	}

	public Vector2 arredonda (Vector2 nA)
	{
		return new Vector2 (Mathf.Round (nA.x), Mathf.Round (nA.y));
	}

	public void atualizaGrade (tetroMov pecaTetris)
	{
		for (int y = 0; y < altura; y++) {
			for (int x = 0; x < largura; x++) {
				if (grade [x, y] != null) {
					if (grade [x, y].parent == pecaTetris.transform) {
						grade [x, y] = null;
					}
				}
			}
		}

		foreach (Transform peca in pecaTetris.transform) {
			Vector2 posicao = arredonda (peca.position);

			if (posicao.y < altura) {
				grade [(int)posicao.x, (int)posicao.y] = peca;
			}
		}
	}

	public Transform posicaoTransformGrade (Vector2 posicao)
	{
		if (posicao.y > altura - 1) {
			return null;
		} else {
			return grade [(int)posicao.x, (int)posicao.y];
		}
	}

	public bool linhaCheia (int y)
	{
		for (int x = 0; x < largura; x++) {
			if (grade [x, y] == null) {
				return false;
			}
		}
		return true;
	}

	public void deletaQuadrado (int y)
	{
		for (int x = 0; x < largura; x++) {
			Destroy (grade [x, y].gameObject);

			grade [x, y] = null;
		}
	}

	public void moveLinhaBaixo (int y)
	{
		for (int x = 0; x < largura; x++) {
			if (grade [x, y] != null) {
				grade [x, y - 1] = grade [x, y];
				grade [x, y] = null;

				grade [x, y - 1].position += new Vector3 (0, -1, 0);
			}
		}
	}

	public void moveTodasLinhasBaixo (int y)
	{
		for (int i = y; i < altura; i++) {
			moveLinhaBaixo (i);
		}
	}

	public void apagaLinha ()
	{
		for (int y = 0; y < altura; y++) {
			if (linhaCheia (y)) {
				deletaQuadrado (y);
				moveTodasLinhasBaixo (y + 1);
				y--;
				score += 100;
				pontoDificuldade += 100;
			}
		}
	}

	public bool acimaGrade (tetroMov pecaTetro)
	{
		for (int x = 0; x < largura; x++) {
			foreach (Transform quadrado in pecaTetro.transform) {
				Vector2 posicao = arredonda (quadrado.position);

				if (posicao.y > altura - 1) {
					return true;
				}
			}
		}
		return false;
	}

	public void gameOver ()
	{
		//SceneManager.LoadScene ("gameOver");
		textoGameOver.gameObject.SetActive (true);
		pausarJogo ();
		botaoPause.gameObject.SetActive (false);
		//botaoReset.gameObject.SetActive (true);
	}

	public void pausarJogo ()
	{		
		pause = !pause;

//		if (Time.timeScale == 0) {
//			Time.timeScale = 1;
//		} else {
//			Time.timeScale = 0;
//		}
		
	}

	public void ReiniciarJogo ()
	{		
		SceneManager.LoadScene ("cena1");
	}



}