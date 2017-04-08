using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mecherCamera : MonoBehaviour {
    bool isMecherCamera = false;
    public float velocidade = 10;

    Vector3 posicInicial;
	// Use this for initialization
	void Start () {
        posicInicial = transform.position;
        destino = posicInicial;

    }

    Vector3 destino;
    int quantasMechidas=0;
	// Update is called once per frame
	void Update () {
        if (isMecherCamera)
        {
            print("oi");
            quantasMechidas = Random.Range(2, 7);
            isMecherCamera = false;
        }
        if (quantasMechidas > 0 && transform.position.x == destino.x && transform.position.y== destino.y)
        {
            if (quantasMechidas > 1)
            {
                print("chegou");
                destino = new Vector3(posicInicial.x+Random.Range(-2.00f, 2.0f), posicInicial.y+Random.Range(-1.0f, 1.0f), posicInicial.z);
            }
            else
            {
                destino = posicInicial;
            }
            quantasMechidas--;
        }
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidade * Time.deltaTime);
	}

    public void mecherACamera()
    {
        isMecherCamera = true;
    }
}
