using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	static int vida = 3;
	bool estaVirado = false;
	float speed = 10.0f;
	const float cadencia = 0.5f;
	float intervalo = 0.0f;
	public Image vida1, vida2, vida3;
	public GameObject tiro;
	public GameObject novelo;
	GameObject tiroAtual;

	private SpriteRenderer mySpriteRenderer;

	void Awake(){
		mySpriteRenderer = GetComponent<SpriteRenderer>();
	}

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
		if (vida <= 0) {
			Destroy (this.gameObject);
			//gameover
		}
		this.transform.position += new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0) * speed * Time.deltaTime;
		if (mySpriteRenderer != null) {
			// if the A key was pressed this frame
			if ((Input.GetAxis ("Horizontal") < 0f) && (estaVirado == false)) {
				mySpriteRenderer.flipX = true;
				estaVirado = true;
			} else if ((Input.GetAxis ("Horizontal") > 0f) && (estaVirado)){
				mySpriteRenderer.flipX = false;
				estaVirado = false;
		}
		}
		float posX = transform.position.x;
		float posY = transform.position.y;

		if (posX <= -11.0f) {
			transform.position = new Vector3 (-11.0f, posY, -2.0f);
		}else if (posX >= 11.0f) {
			transform.position = new Vector3 (11.0f, posY, -2.0f);
		}

		if (posY <= -4.25f) {
			transform.position = new Vector3 (posX, -4.25f, -2.0f);
		}else if (posY >= 4.0f) {
			transform.position = new Vector3 (posX, 4.0f, -2.0f);
		}
	}
	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag.Equals ("Obstacle")) {
			Debug.Log ("passou");
			vida--;
			vidaManager ();
			print (vida);
		}
		// levou um tiro
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
