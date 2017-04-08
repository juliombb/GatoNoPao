using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atacar : MonoBehaviour {
    public GameObject balaPrefab;
    public int contadorAtaqueFuracao = 10;
	// Use this for initialization
	void Start () {

        InvokeRepeating("ataqueFuracao", 2.0f, 0.3f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void ataqueFuracao()
    {
        if (--contadorAtaqueFuracao > 0)
        {
            GameObject bala = (GameObject)Instantiate(balaPrefab);
            bala.transform.parent = transform;
            bala.transform.position = new Vector3(0, 0, 0);
        }
    }
}
