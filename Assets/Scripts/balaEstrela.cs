using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaEstrela : MonoBehaviour {
    public float velocidade = 10.0f;

    Vector3 posicaoInicial;
	// Use this for initialization
	void Start () {
        Destroy(transform.gameObject, 40);
        posicaoInicial = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = transform.localPosition + posicaoInicial * velocidade * Time.deltaTime;
	}

    private void OnBecameInvisible()
    {
        Destroy(transform.gameObject);
    }

}
