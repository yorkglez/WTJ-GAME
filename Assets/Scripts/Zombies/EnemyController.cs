using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	/** Variables **/
	private Animator animator;
	public float speed = 1f;
	public float dir = 1f;
	public float maxSpeed = 5f;
	public bool grounded = true;
	public int Life = 2;
	private Rigidbody2D rb2d;
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		CheckOrientation ();
	}
	
	// Update is called once per frame
	void Update(){
		//animator.SetFloat ("Speed",Mathf.Abs(rb2d.velocity.x));
		animator.SetBool ("Grounded",grounded);
		if (Life == 0) {
			Destroy (gameObject);
		}
	}

	void FixedUpdate () {
		Vector2 rigiSpeed = rb2d.velocity;
		rigiSpeed.x = speed * dir;
		rb2d.velocity = rigiSpeed;
	}

	/** Collisions **/
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag=="EnemyLimit" ) {
			dir = -dir;
			CheckOrientation ();
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Bullet") {
			Life = Life - 1;
			Destroy (col.gameObject);
		}
	}
	/** Check orientation of object and change this **/
	void CheckOrientation(){
		if (dir == -1) {
			transform.localScale = new Vector3(-1f,1f,1f);
		}
		else if(dir == 1){
			transform.localScale = new Vector3(1f,1f,1f);
		}
	}

}
