using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baralhoJogo : MonoBehaviour {

	public baralho baralhoOrdenado;
	public List<carta> cartas; // Cartas embaralhadas.
	public int vezesEmbaralhar; // Definir quantas vezes devemos embaralhar as cartas.
	private List<carta> embaralhar; // Movimentar ordem das cartas.


	// Use this for initialization
	void Start () {
		embaralhar = new List<carta> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void embaralharCartas() {
		// Limpa a lista de cartas e a lista embaralhar.
		embaralhar.Clear ();
		cartas.Clear ();
		// Transfere as cartas do baralho ordenado para a lista embaralhar, ainda 
		//   na ordem, mas a lista cartas receberá as cartas misturadas.
		foreach (carta carta in baralhoOrdenado.cartas) {
			embaralhar.Add(carta);
		}

		// Definido o número de vezes que devemos embaralhar.
		int vezes = vezesEmbaralhar;

		// Embaralhar até que o número de vezes seja alcançado.
		do {
			// Transfere as cartas da lista embaralhar para a lista cartas de forma randômica (misturada).
			while (embaralhar.Count > 0) {
				int i = Random.Range (0, embaralhar.Count);
				//print(embaralhar [i].name);
				cartas.Add (embaralhar [i]);
				embaralhar.RemoveAt (i);
			}
//			print("Embaralhamos");
//			print(" ");
//			print(" ");

			// Contagem reversa de número de vezes que já embaralhamos as cartas.
			vezes -= 1;
			// Se ainda devemos embaralhar novamente as cartas, transferimos as cartas novamente para a lista
			//   embaralhar para misturar novamente.
			if (vezes > 0) {
				embaralhar.Clear ();
				foreach (carta carta in cartas) {
					embaralhar.Add(carta);
				}
				cartas.Clear();
			}

		} while (vezes > 0);


	}



}
