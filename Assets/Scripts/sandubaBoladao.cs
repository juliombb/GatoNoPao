using UnityEngine;
using System.Collections;

public class sandubaBoladao: MonoBehaviour {

	private Transform target;
	private float raio = 7.0f;
	float i = 0;


	void Start() {
		target = GameObject.Find ("Alvo").transform;    
	}

	void Update() {		
		this.transform.position = new Vector3((target.transform.position.x + Mathf.Cos(i)*raio), (target.transform.position.y + Mathf.Sin(i)*raio),0.0f);
		i += 0.017f;
		if(i>2*Mathf.PI)
			i = 0;
	}
}