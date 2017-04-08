using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	int vida = 3;
	float speed = 10.0f;
	const float cadencia = 0.5f;
	float intervalo = 0.0f;
	public Image vida1, vida2, vida3;
	public GameObject tiro;
	GameObject tiroAtual;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		intervalo += Time.deltaTime;
		if ((Input.GetButton("Fire1")||Input.GetButton("Jump"))  && intervalo >= cadencia) {
			tiroAtual = Instantiate(tiro);
			tiroAtual.transform.position = this.transform.position + new Vector3(1.0f, 0.0f, 0.0f);
			intervalo = 0;
		}
		if (vida == 0) {
			Destroy (this.gameObject);
			//gameover
		}
		this.transform.position += new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0) * speed * Time.deltaTime;
	}
	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag.Equals ("Obstacle")) {
			vida--;
			vidaManager ();
			col.gameObject.transform.position = new Vector3 (12.0f, Random.Range (-5.0f, 5.0f), 0.0f);
		}
	}
	void OnTriggerEnter (Collider col){ // levou um tiro
		if (col.gameObject.tag.Equals("EnemyProjectile")) {
			vida--;
			vidaManager ();
			Destroy (col.gameObject);
		}	
	}

	void vidaManager(){
		Color cor = new Color32 (255, 255, 255, 0);
		switch(vida){
		case 2:
			vida3.color = cor;
			break;
		case 1:
			vida2.color = cor;
			vida3.color = cor;
			break;
		case 0:
			vida1.color = cor;
			vida2.color = cor;
			vida3.color = cor;
			break;
		}
	
	}
}
