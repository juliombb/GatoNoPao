using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {
	public GameObject Player;
	GameObject PlayerAtual;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PlayerAtual.transform.position = Player.transform.position;
		this.transform.parent = PlayerAtual.transform;
	}
}
