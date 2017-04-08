using UnityEngine;
using System.Collections;

public class GameLost : MonoBehaviour
{
	void onCollisionEnter (Collision col){
		if (col.gameObject.name == "projetil(Clone)") {
			Destroy (col.gameObject);
		}
	}

}