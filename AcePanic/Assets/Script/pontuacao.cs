﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pontuacao : MonoBehaviour {

	public static int pontos;
	public Text pontosTxt;

	// Use this for initialization
	void Start () {
	
		pontos = 0;

	}
	
	// Update is called once per frame
	void Update () {

		pontosTxt.text = pontos.ToString ();

	}
}
