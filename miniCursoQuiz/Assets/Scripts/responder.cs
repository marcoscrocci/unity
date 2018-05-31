using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class responder : MonoBehaviour {

	private int idTema;

	public Text pergunta;
	public Text respostaA;
	public Text respostaB;
	public Text respostaC;
	public Text respostaD;
	public Text infoResposta;

	public string[] perguntas;
	public string[] alternativaA;
	public string[] alternativaB;
	public string[] alternativaC;
	public string[] alternativaD;
	public string[] corretas;

	private int idPergunta;
	private float acertos;
	private float questoes;
	private float media;
	private int notaFinal;

	// Use this for initialization
	void Start () {
		idTema = PlayerPrefs.GetInt ("idTema");
		idPergunta = 0;
		questoes = perguntas.Length;

		atualizarTextos ();
	}
	
	public void resposta(string alternativa) {
		if (alternativa == "A") {
			if (alternativaA [idPergunta] == corretas [idPergunta]) {
				acertos += 1;
			}
		} 
		else if (alternativa == "B") {
			if (alternativaB [idPergunta] == corretas [idPergunta]) {
				acertos += 1;
			}
		} 
		else if (alternativa == "C") {
			if (alternativaC [idPergunta] == corretas [idPergunta]) {
				acertos += 1;
			}
		} 
		else if (alternativa == "D") {
			if (alternativaD [idPergunta] == corretas [idPergunta]) {
				acertos += 1;
			}
		} 

		proximaPergunta ();

	}

	void proximaPergunta() {
		idPergunta += 1;
		if (idPergunta <= (questoes - 1)) {
			atualizarTextos ();
		} else {
			media = 10 * (acertos / questoes);
			notaFinal = Mathf.RoundToInt (media);

			if (notaFinal > PlayerPrefs.GetInt ("notaFinal" + idTema.ToString ())) {
				PlayerPrefs.SetInt ("notaFinal" + idTema.ToString (), notaFinal);
				PlayerPrefs.SetInt ("acertos" + idTema.ToString (), (int) acertos);
			}

			PlayerPrefs.SetInt ("notaFinalTemp" + idTema.ToString (), notaFinal);
			PlayerPrefs.SetInt ("acertosTemp" + idTema.ToString (), (int) acertos);
			PlayerPrefs.SetInt ("questoesTemp" + idTema.ToString (), (int) questoes);

			Application.LoadLevel ("notaFinal");
		}
	}


	void atualizarTextos ()
	{
		pergunta.text = perguntas [idPergunta];
		respostaA.text = alternativaA [idPergunta];
		respostaB.text = alternativaB [idPergunta];
		respostaC.text = alternativaC [idPergunta];
		respostaD.text = alternativaD [idPergunta];
		infoResposta.text = "Respondendo " + (idPergunta + 1).ToString () + " de " + questoes.ToString () + " perguntas.";
	}
}
