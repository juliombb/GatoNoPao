using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour {

	public float speedX;
	public float speedY;
	// Use this for initialization
	void Start () {
		speedY = Random.Range (-1f, 1f);
		speedX = Random.Range (15.0f, 16.0f);
	}

	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3(speedX, speedY, 0.0f) * Time.deltaTime;
	}

	void OnBecameInvisible () {
		Destroy(gameObject);
	}
}
