using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonaldMovements : MonoBehaviour {
	/** Variables **/
	private Animator animator;
	public float speed = 3f, dir = 1f, maxSpeed = 8f, bulletSpeed, rigiSpeed, jumpPower;
	public bool grounded = true, jump;
	public int Life = 4;
	private Rigidbody2D rb2d, bulletRb;
	public Transform bulletSpawner;
	private Transform playerT;
	public GameObject bulletPref;
	public GameObject player;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Donal");
		playerT = player.transform;
	}
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		CheckOrientation ();
		InvokeRepeating("Shooting",0f,1.2f);
		InvokeRepeating ("Jump", 1f, 3f);
	}

	// Update is called once per frame
	void Update(){
		animator.SetFloat ("Speed",Mathf.Abs(rb2d.velocity.x));
		animator.SetBool ("Grounded",grounded);
		if (Life == 0) {
		//	Destroy (gameObject);
		}
	}

	//
	void FixedUpdate () {
		Move ();

	}

	/** Collisions **/
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag=="EnemyLimit" ) {
			dir = -dir;
			CheckOrientation ();
		}
	}

	/**Move Object**/
	void Move(){
		Vector2 rigiSpeed = rb2d.velocity;
		rigiSpeed.x = speed * dir;
		rb2d.velocity = rigiSpeed;
	}

	/** Jump One time**/
	void Jump(){
		jump = true;
		if (jump) {
			rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
			rb2d.AddForce (Vector2.up * jumpPower,ForceMode2D.Impulse);
			jump = false;
		}
	}

	/** Check Direction and Change orientation**/
	void CheckOrientation(){
		if (dir == -1) {
			transform.localScale = new Vector3(-1f,1f,1f);
		}
		else if(dir == 1){
			transform.localScale = new Vector3(1f,1f,1f);
		}
	}

	void Shooting(){
		GameObject bullet = Instantiate (bulletPref, bulletSpawner.position, bulletSpawner.rotation);
		bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (bulletSpeed, 3);
		if (playerT.localScale.x > 0) {
			bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (bulletSpeed, 3);
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} 
		else{
			bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-bulletSpeed, 3);
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		}
		Destroy (bullet, 1.5f);
	}
}
