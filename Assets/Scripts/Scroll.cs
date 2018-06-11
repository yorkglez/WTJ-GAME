using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
	private GameObject background;
	public float speed = 0.5f;
	Vector3 startPos;
	// Use this for initialization
	void Start () {
		background = GameObject.FindGameObjectWithTag ("Background");
		startPos = background.transform.position;
	}
	
	// Update is called once per frame
	public void MoveBackground (int dir) {
		background.transform.Translate ((new Vector3(dir,0,0))*Time.deltaTime);

	}
}
