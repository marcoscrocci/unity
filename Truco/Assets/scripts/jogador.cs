using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jogador : MonoBehaviour {

	public List<cartaJogador> cartas;
	public List<cartaJogador> cartasVerso;
	public carta cartaVerso;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void obterCarta(carta c, int posicao) {
		cartas [posicao].gerarCarta (c);
		cartasVerso [posicao].gerarCarta (cartaVerso);
	}

	public void removerCarta(int posicao) {
		cartas [posicao].destruirCarta ();
		cartasVerso [posicao].destruirCarta ();
	}

	public void removerCarta(cartaJogador carta) {
		int posicao = cartas.IndexOf (carta);
		removerCarta (posicao);
	}
		

}
