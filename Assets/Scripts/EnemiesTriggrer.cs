using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesTriggrer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			GameObject thePlayer = GameObject.Find("Player");
			MovementsPlayer Player = thePlayer.GetComponent<MovementsPlayer> ();
			SoundsManager.PlaySound ("playerDying");
			Player.Lifes = Player.Lifes - 1;
		}
	}
}
