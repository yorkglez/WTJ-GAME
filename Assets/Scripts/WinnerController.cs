using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerController : MonoBehaviour {

	public static void ActiveWin (bool state){
		GameObject Canvas =  GameObject.FindGameObjectWithTag("CanvasWiner");
		Canvas.gameObject.SetActive(state);
	}
}
