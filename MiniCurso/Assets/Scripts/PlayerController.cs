using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Animator anime;
	public Rigidbody2D playerRigidbody;
	public int forceJump;
	//public bool jump;
	public bool slide;
	public bool escorregar;
	public bool pular;
	public GameObject btnPular;
	public GameObject btnEscorregar;

	// Verifica o chão
	public Transform GroundCheck;
	public bool grounded;
	public LayerMask whatIsGround;

	// Slide
	public float slideTime;
	public float timeTemp;

	// Colisor
	public Transform colisor;

	// Audio
	public AudioSource audio;
	public AudioClip soundJump;
	public AudioClip soundDash;

	// Pontuação
	public static int pontuacao;
	public UnityEngine.UI.Text txtPontos;

	// Use this for initialization
	void Start () {
		pontuacao = 0;
		PlayerPrefs.SetInt("pontuacao", pontuacao);
		escorregar = false;
		pular = false;

		if (Application.platform != RuntimePlatform.Android) {
			btnPular.SetActive (false);
			btnEscorregar.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Application.platform != RuntimePlatform.Android) {
			if (Input.GetButtonDown ("Jump")) {
				pular = true;
			}
			if (Input.GetButtonDown ("Slide")) {
				escorregar = true;
			}
		}


		txtPontos.text = pontuacao.ToString ();

		//if (Input.GetButtonDown("Jump") && grounded && !evitarPulo) {
		if (pular && grounded) {
			//Debug.Log ("Jump");
			playerRigidbody.AddForce(new Vector2(0, forceJump));
			audio.PlayOneShot (soundJump);

			if (slide) {
				colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
				slide = false;
			}

			pular = false;
			//jump = true;
		}

		//if ((Input.GetButtonDown("Slide")) && grounded && !slide) {
		if (escorregar && grounded && !slide) {
			//Debug.Log ("Slide");
			audio.PlayOneShot (soundDash);
			colisor.position = new Vector3(colisor.position.x, colisor.position.y - 0.3f, colisor.position.z);
			slide = true;
			timeTemp = 0;
			escorregar = false;
		}
	


		grounded = Physics2D.OverlapCircle (GroundCheck.position, 0.2f, whatIsGround);

		if (slide) {
			timeTemp += Time.deltaTime;
			if (timeTemp >= slideTime) {
				colisor.position = new Vector3(colisor.position.x, colisor.position.y + 0.3f, colisor.position.z);
				slide = false;
			}
		}

		//anime.SetBool ("jump", jump);
		anime.SetBool ("jump", !grounded);
		anime.SetBool ("slide", slide);

	}


	void OnTriggerEnter2D() {
		//Debug.Log ("Bateu");
		PlayerPrefs.SetInt("pontuacao", pontuacao);
		if (pontuacao > PlayerPrefs.GetInt ("recorde")) {
			PlayerPrefs.SetInt("recorde", pontuacao);
		}
		Application.LoadLevel("gameover");
	}



}
