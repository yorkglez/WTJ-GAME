using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDonal : MonoBehaviour {

	/** Collisions **/
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			GameObject Donal = GameObject.FindGameObjectWithTag("Donal");
		//	DonaldMovements donal = Donal.GetComponent<DonaldMovements> ();
		//	Donal.SetActive (true);
		//	donal.isActive = true;
		}
	}
}
