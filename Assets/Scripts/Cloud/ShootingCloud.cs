using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingCloud : MonoBehaviour {

	/** Variables **/
	public float bulletSpeed;
	private float rigiSpeed;
	private Rigidbody2D bulletRb;
	public Transform bulletSpawner;
	private Transform playerT;
	public GameObject bulletPref;
	public GameObject player;


	// Use this for initialization
	void Awake(){
		//bulletRb = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Cloud");
		playerT = player.transform;

	}
	void Start () {
		InvokeRepeating("Shooting",0f,1.2f);
	}
		
	/** Enemy Shooting**/
	public void Shooting(){
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
		SoundsManager.PlaySound ("donalFire");
		Destroy (bullet, 1.5f);
	}
}
