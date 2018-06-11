using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {
	public Transform Target;
	public float Speed;
	private Vector3 posStart, posEnd;
	// Use this for initialization
	void Start () {
		if (Target != null) {
			Target.parent = null;
			posStart = transform.position;
			posEnd = Target.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate(){
		if (Target != null) {
			float fxSpeed = Speed *Time.deltaTime;
			transform.position = Vector3.MoveTowards (transform.position, Target.position, fxSpeed);
		}
		if (transform.position == Target.position) {
			Target.position = (Target.position == posStart) ? posEnd : posStart;
		}
	}
}
