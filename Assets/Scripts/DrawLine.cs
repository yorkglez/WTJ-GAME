using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
	public Transform From;
	public Transform To;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnDrawGizmosSelected(){
		if(From != null && To != null){
			Gizmos.color = Color.blue;
			Gizmos.DrawLine (From.position, To.position);
			Gizmos.DrawSphere (From.position,0.10f);
			Gizmos.DrawSphere (To.position,0.10f);
		}
	}
}
