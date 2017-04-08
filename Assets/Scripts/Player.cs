﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
<<<<<<< HEAD
	int vida = 3;
=======
	float vida = 30;
>>>>>>> 47dfcfcaf57f269628b2c6d3d7043d20840e2716
	float speed = 10.0f;
	const float cadencia = 0.5f;
	float intervalo = 0.0f;
	public GameObject tiro;
	public Text lblScore;
	GameObject tiroAtual;

	// Use this for initialization
	void Start () {
		lblScore.text = ""+ vida;
	}
	
	// Update is called once per frame
	void Update () {
		intervalo += Time.deltaTime;
		if ((Input.GetButton("Fire1")||Input.GetButton("Jump"))  && intervalo >= cadencia) {
			tiroAtual = Instantiate(tiro);
			tiroAtual.transform.position = this.transform.position + new Vector3(1.0f, 0.5f, 0.0f);
			intervalo = 0;
		}
		if (vida <= 0) {
			Destroy (this.gameObject);
			//gameover
		}
		this.transform.position += new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0) * speed * Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag.Equals ("Obstacle")) {
			vida -= 1;
			col.gameObject.transform.position = new Vector3 (12.0f, Random.Range (-5.0f, 5.0f), 0.0f);
		}
		if (col.gameObject.tag.Equals("projetilBoss")) {
			vida -= 2;
			Destroy (col.gameObject);
		}	
	}
}
