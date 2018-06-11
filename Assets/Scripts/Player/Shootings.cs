using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootings : MonoBehaviour {

	/** Variables **/
	public float bulletSpeed;
	private Rigidbody2D bulletRb;
	public Transform bulletSpawner;
	public GameObject bulletPref;
	public GameObject player;
	private Transform playerT;
	private bool Fire;
	private Animator animator;

	// Use this for initialization

	void Awake(){
		animator = GetComponent<Animator> ();

	//	bulletRb = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerT = player.transform;

	}
	void Start () {
		
		//bulletRb.velocity = new Vector3(bulletSpeed,bulletRb


	}
	// Update is called once per frame
	void Update () {
		animator.SetBool ("Fire", Fire);
		PlayerShooting();
	}

	public void PlayerShooting(){
		
		/** Key Actions**/
		if (Input.GetKeyDown (KeyCode.F)) {
			Fire = true;
			//Instantiate (bulletPref, bulletSpawner.position, bulletSpawner.rotation);
			GameObject bullet = Instantiate (bulletPref, bulletSpawner.position, bulletSpawner.rotation);
			bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (bulletSpeed, 2);
			if (playerT.localScale.x > 0) {
				//Debug.Log (playerT.localScale.x);
				//bullet.velocity = new Vector2 (bulletSpeed, bulletRb.velocity.y);
				bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (bulletSpeed, 2);
				transform.localScale = new Vector3 (1f, 1f, 1f);
			} else{
				//Debug.Log (transform.localScale.x);
				bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-bulletSpeed, 2);
				//bulletRb.velocity = new Vector2 (-bulletSpeed, bulletRb.velocity.y);
				transform.localScale = new Vector3 (-1f, 1f, 1f);
			}
			Destroy (bullet, 2.0f);
		}
	//	Fire = false;
		if(Input.GetKeyUp(KeyCode.F)){
			Fire = false;
		}
	}

}
