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

		/*rb2d.AddForce (Vector2.right * speed);
		float limitedspeed = Mathf.Clamp (rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2 (limitedspeed, rb2d.velocity.y);
		if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f) {
			speed = -speed;
			rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
		}*/

	
	}

	/** Collisions **/
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag=="EnemyLimit" ) {
			dir = -dir;
			CheckOrientation ();
		}
		if (col.gameObject.tag == "Bullet") {
			Life = Life - 1;
			Destroy (col.gameObject);
		}
	}
	void CheckOrientation(){
		if (dir == -1) {
			transform.localScale = new Vector3(-1f,1f,1f);
		}
		else if(dir == 1){
			transform.localScale = new Vector3(1f,1f,1f);
		}
	}

}
