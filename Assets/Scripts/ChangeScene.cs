using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour {
	public string Scene;
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			SceneManager.LoadScene (Scene);
		}
	}
}
