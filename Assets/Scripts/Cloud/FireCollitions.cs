using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollitions : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			GameObject thePlayer = GameObject.Find("Player");
			MovementsPlayer Player = thePlayer.GetComponent<MovementsPlayer> ();
			Player.Lifes = Player.Lifes - 1;
			Destroy (gameObject);
		}
	}
}
