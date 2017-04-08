using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentacaoGato : MonoBehaviour {

    public float variacaoMovimentacaoX, variacaoMovimentacaoY;
    public float velocidade;

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
	}
}
