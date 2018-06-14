using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameoverController : MonoBehaviour {
	public void GameOver(){
		SceneManager.LoadScene ("GameOver");
	}
}
