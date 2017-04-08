using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaFuracao : MonoBehaviour {

    float i = 0;
    private float raio = 1.0f;
    public float taxaCrescimento = 1;
    public float velocidade = 3;


    // Use this for initialization
    void Start () {
        Destroy(transform.gameObject,20);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3((transform.parent.gameObject.transform.position.x + Mathf.Cos(i) * raio), (transform.parent.gameObject.transform.position.y + Mathf.Sin(i) * raio), 0.0f);
        i += velocidade * Time.deltaTime;
        raio = raio + taxaCrescimento * Time.deltaTime;
        if (i > 2 * Mathf.PI)
            i = 0;
    }
}
