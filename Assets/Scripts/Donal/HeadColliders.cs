using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadColliders : MonoBehaviour {
	public float Power;
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			GameObject thePlayer = GameObject.Find("Player");
			MovementsPlayer Player = thePlayer.GetComponent<MovementsPlayer> ();
			Player.OutCollision (Power);
			GameObject Donal = GameObject.Find("Donal");
			DonaldMovements donal = Donal.GetComponent<DonaldMovements> ();
			donal.Life = donal.Life - 1;
		}
	}
}
