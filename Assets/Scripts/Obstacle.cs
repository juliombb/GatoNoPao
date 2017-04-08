using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	public float speed = 14.0f;
	public float acceleration = 4.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float posX = transform.position.x;
		float posY = transform.position.y;
		this.transform.position += new Vector3 (-1, 0 + 1.5f*Mathf.Sin(transform.position.x), 0) * speed * Time.deltaTime;
		if (posX <= -12.0f) {
			posX = 12.0f;
			posY = Random.Range (-5.0f, 5.0f);
			this.transform.position = new Vector3 (posX, posY, -2.0f);
			speed += acceleration * Time.deltaTime;
		}
	}

	void OnTriggerEnter2D (Collider2D col){
		this.transform.position = new Vector3 (12.0f, Random.Range (-5.0f, 5.0f), -2.0f);
	}
}
