using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Transform obstacle;
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

		this.transform.position += new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0) * speed * Time.deltaTime;
	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.name.Equals("Obstacle")||(col.gameObject.name.Equals("Obstacle(Clone)"))) {
			Destroy (col.gameObject);
			float posX = 12.0f;
			float posY = Random.Range(-5.0f,5.0f);
			Vector3 pos = new Vector3 (posX, posY, 0);
			Instantiate(obstacle, pos, Quaternion.identity);
			this.transform.position = new Vector3 (-11.0f, 0f, 0f);
		}	
	}
}
