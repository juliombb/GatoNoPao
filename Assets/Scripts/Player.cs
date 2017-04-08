using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	int vida = 3;
	float speed = 10.0f;
	const float cadencia = 0.5f;
	float intervalo = 0.0f;
	public GameObject tiro;
	GameObject tiroAtual;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		intervalo += Time.deltaTime;
		if (Input.GetButton("Fire1") && intervalo >= cadencia) {
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
		if (col.gameObject.tag.Equals("Obstacle")) {
			vida -= 1;
			col.gameObject.transform.position = new Vector3(12.0f, Random.Range(-5.0f,5.0f),0.0f);
		}	
	}
}
