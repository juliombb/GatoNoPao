using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour {

	public float speedX;
	public float speedY;
	// Use this for initialization
	void Start () {
        if(speedY==0)
		    speedY = Random.Range (-5f, 5f);

        if(speedX==0)
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
