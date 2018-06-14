using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeScene : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			GameObject thePlayer = GameObject.Find("Player");
			MovementsPlayer Player = thePlayer.GetComponent<MovementsPlayer> ();
			if (Player.key == true)
				SceneController.LoadScene ("Level2");
		}
	}
}
