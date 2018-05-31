using UnityEngine;
using System.Collections;

public class comandosBasicos : MonoBehaviour {

	public void carregarCena(string nomeCena) {
		// Mover de uma cena para outra.
		Application.LoadLevel (nomeCena);  // Obsoleto.
		//SceneManager.LoadScene (nomeCena);
	}

	public void resetarPontuacoes() {
		PlayerPrefs.DeleteAll ();
	}

}
