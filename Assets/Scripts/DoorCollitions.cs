﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollitions : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			GameObject thePlayer = GameObject.Find("Player");
			MovementsPlayer Player = thePlayer.GetComponent<MovementsPlayer> ();
			if (Player.key) {
			
			}
		}
	}
}
