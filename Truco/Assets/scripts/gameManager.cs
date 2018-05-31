using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

	// Pontuação das duplas/times, quando for 4 jogadores, ou pontuação para o jogador 1 e 2. 
	public int pontosTime1; // ou jogador 1
	public int pontosTime2; // ou jogador 2
	private bool novaRodada;

	public baralho baralhoOrdenado; // Memoriza um baralho em ordem do 4 de ouros ao 3 de paus.
	public baralhoJogo baralhoRodada; // Baralho da rodada com a ordem das cartas misturadas.
	public carta cartaVerso;

	public jogador jogador1;
	public jogador jogador2;
	//public jogador jogador3;
	//public jogador jogador4;


	// Use this for initialization
	void Start () {
		definirPosicoesJogadores ();
		novaRodada = true;
	}
	
	// Update is called once per frame
	void Update () {
		//print ("gameManager.cs update");
		if (novaRodada) {
			novaRodada = false;
			baralhoRodada.embaralharCartas ();
			distribuirCartas ();		
		} else {
			// Rodada em andamento...
		}
	}

	void definirPosicoesJogadores() {
		//eu = jogador1;
	}

	void distribuirCartas() {
		// Método obterCarta(carta do baralho da rodada, posição da carta na mão do jogador).
		jogador1.obterCarta (proximaCarta (), 0);
		jogador2.obterCarta (proximaCarta (), 0);
		jogador1.obterCarta (proximaCarta (), 1);
		jogador2.obterCarta (proximaCarta (), 1);
		jogador1.obterCarta (proximaCarta (), 2);
		jogador2.obterCarta (proximaCarta (), 2);

//		print("Valor da carta do meio: " + jogador2.cartas [1].GetCarta ().GetValor ().ToString());
//		jogador2.cartas [1].GetCarta ().SetManilha (true);
//		print("Valor da carta do meio: " + jogador2.cartas [1].GetCarta ().GetValor ().ToString());

		//jogador2.removerCarta (1);

//		print("Valor da carta do meio: " + jogador1.cartas [1].GetCarta ().GetValor ().ToString());
//		jogador1.cartas [1].GetCarta ().SetManilha (true);
//		print("Valor da carta do meio: " + jogador1.cartas [1].GetCarta ().GetValor ().ToString());
		//jogador1.removerCarta (jogador1.cartas[1]);
	}

	private carta proximaCarta() {
		// Retorna a primeira carta do baralho da rodada e remove ela da lista.
		carta proxima = baralhoRodada.cartas [0];
		baralhoRodada.cartas.RemoveAt (0);
		return proxima;
	}

}
