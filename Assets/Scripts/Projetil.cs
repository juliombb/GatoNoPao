using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour {

	float speedX = 14.0f;
	float speedY;
	// Use this for initialization
	void Start () {
		speedY = Random.Range(-0.6f, 0.6f);
	}

	// Update is called once per frame
	void Update () {
		this.transform.position += new Vector3(speedX, speedY, 0.0f) * Time.deltaTime;
		Debug.Log(Screen.width);
	}

	void OnBecameInvisible () {
		Destroy(gameObject);
	}
}
