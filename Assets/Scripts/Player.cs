using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	float vida = 30;

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

	void OnCollisionEnter2D(Collision2D col){
        print("oi");
		if (col.gameObject.name.Equals("projetil 1(Clone)")||(col.gameObject.name.Equals("projetil 1")) || 
            (col.gameObject.name.Equals("novelo(Clone)")) || (col.gameObject.name.Equals("novelo")) || 
            (col.gameObject.name.Equals("meteoro_estrela")) || (col.gameObject.name.Equals("meteoro_estrela(Clone)")) || 
            (col.gameObject.name.Equals("meteoro_giratorio(Clone)")) || (col.gameObject.name.Equals("meteoro_giratorio"))){
            vida -= 10;

			Destroy (col.gameObject);
		}	
	}
}
