using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atacar : MonoBehaviour {
    public GameObject balaFuracaoPrefabLaranja;
    public GameObject balaFuracaoPrefabAzul;
    public int contadorAtaqueFuracao = 10;
	// Use this for initialization
	void Start () {

        InvokeRepeating("ataqueFuracao", 10.0f, 1);
        InvokeRepeating("resetFuracao", 25, 15);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    bool laranja = true;
    private void ataqueFuracao()
    {
        if (--contadorAtaqueFuracao > 0)
        {
            GameObject bala;
            if (laranja)
            {
                bala = (GameObject)Instantiate(balaFuracaoPrefabLaranja);
                laranja = false;
            }
            else
            {   
                bala = (GameObject)Instantiate(balaFuracaoPrefabAzul);
                laranja = true;
            }
            bala.transform.SetParent(transform);
            bala.transform.localPosition = new Vector3(0,0, -1);
        }
    }

    private void resetFuracao()
    {
        contadorAtaqueFuracao = 10;
    }

}
