using UnityEngine;
using System.Collections;

public class sandubaBoladao: MonoBehaviour {
	public GameObject tiro;
	GameObject tiroAtual;
	private float vida = 100;
	private Transform target;
	private float raio = 7.0f;
	float i = 0;
	float intervalo = 0.0f;


	void Start() {
		target = GameObject.Find ("Alvo").transform;    
	}

	void Update() {	
		intervalo++;	
		this.transform.position = new Vector3((target.transform.position.x + Mathf.Cos(i)*raio), (target.transform.position.y + Mathf.Sin(i)*raio),0.0f);
		i += 0.017f;
		if(i>2*Mathf.PI)
			i = 0;
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