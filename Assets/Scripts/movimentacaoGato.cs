using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentacaoGato : MonoBehaviour {
	public GameObject tiro;
	GameObject tiroAtual;
	private float vida = 100;
    public float variacaoMovimentacaoX, variacaoMovimentacaoY;
    public float velocidade;
	private int intervalo = 0;

    float posicaoInicialX, posicaoInicialY;
    // Use this for initialization
    void Start () {
        posicaoInicialX = transform.position.x;
        posicaoInicialY = transform.position.y;
	}

    bool realizouMovimentacao = true;
    float posicaoDestinoX, posicaoDestinoY;
	// Update is called once per frame
	void Update () {
		intervalo++;
        if (realizouMovimentacao)
        {
            posicaoDestinoX = posicaoInicialX + Random.Range(-variacaoMovimentacaoX, variacaoMovimentacaoX);
            posicaoDestinoY = posicaoInicialY + Random.Range(-variacaoMovimentacaoY, variacaoMovimentacaoY);

            realizouMovimentacao = false;

            print("proxima posicao X:" + posicaoDestinoX + " proxima posicao Y:" + posicaoDestinoY);
        }

        float quantidadeMovimentacao = velocidade * Time.deltaTime;


        transform.position = Vector3.MoveTowards(transform.position, new Vector3(posicaoDestinoX, posicaoDestinoY, transform.position.z), quantidadeMovimentacao);

        if (posicaoDestinoX == transform.position.x && posicaoDestinoY == transform.position.y)
            realizouMovimentacao = true;
		if (vida < 0)
			Destroy (this.gameObject);
		if (intervalo > 60) {
			tiroAtual = Instantiate(tiro);
			tiroAtual.transform.position = this.transform.position - new Vector3(1.0f, 0.0f, 0.0f);
			intervalo = 0;
		}
			}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.name.Equals("projetil(Clone)")||(col.gameObject.name.Equals("projetil"))) {
			vida -= 10;
			Destroy (col.gameObject);
		}	
	}
}
