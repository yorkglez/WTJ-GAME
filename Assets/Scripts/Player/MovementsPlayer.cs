using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MovementsPlayer : MonoBehaviour {

	/** Variables **/
	public float speed = 2f;
	public float maxSpeed = 5f;
	public float jumpPower = 6.5f;
	private Rigidbody2D rb2d;
	private Animator animator;
	public bool grounded = true;
	private bool Jump = false;
	private bool Down;
	private bool doubleJump;
	public bool key = false;
	public int Lifes = 3;
	public int diamantCount = 0;
	private int Nlevel;
	private int dir;
	//private bool junaMode = false;
	public Text txtLifes;
	public Text txtDiamants;
	public Text txtLevel;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		txtLifes.text = Lifes.ToString();
		txtDiamants.text = diamantCount.ToString();
		Nlevel = SceneManager.sceneCount;
		txtLevel.text = txtLevel.text +" "+ Nlevel.ToString ();
	
	}
		
	void Update(){
		/**Animations Values **/
		animator.SetFloat ("Speed",Mathf.Abs(rb2d.velocity.x));
		animator.SetBool ("Grounded", grounded); 
		animator.SetBool ("Down", Down);
	
		/** Input Keys accions **/
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (grounded) {
				Jump = true;
				doubleJump = true;
			} else if (doubleJump) {
				Jump = true;
				doubleJump = false;
			}
		}

		if(Input.GetKeyDown(KeyCode.S)){
			Down = true;
		}
		if (Input.GetKeyUp (KeyCode.S)) {
			Down = false;
		}
		GameOver ();
		txtDiamants.text = diamantCount.ToString();
		txtLifes.text = Lifes.ToString();
	}
	// Update is called once per frame

	void FixedUpdate () {
		Vector3 fixedVelocity = rb2d.velocity;
		fixedVelocity.x *= 0.85f;
	//	if (grounded) {
			rb2d.velocity = fixedVelocity;
	//	}

		/*--Move to righ and left*/
		float h = Input.GetAxis ("Horizontal");
		rb2d.AddForce (Vector2.right * speed * h);
		float limitedSpeed = Mathf.Clamp (rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2 (limitedSpeed, rb2d.velocity.y);
		if (h > 0.1f) {
			transform.localScale = new Vector3 (1f,1f,1f);
			dir = 1;

		}
		if (h < -0.1f) {
			transform.localScale = new Vector3 (-1f,1f,1f);
			dir = -1;
		}

		/*--Jump*/
		if (Jump) {
			SoundsManager.PlaySound ("jumpPlayer");
			rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
			rb2d.AddForce (Vector2.up * jumpPower,ForceMode2D.Impulse);
			Jump = false;
		}
	}

	/**Player Collisions with Other Objects**/
	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag == "Platform" || col.gameObject.tag == "PlatformMobile") {
			grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "Platform" || col.gameObject.tag == "PlatformMobile") {
			grounded = false;
			if (col.gameObject.tag == "PlatformMobile") {
				transform.parent = null;
			}
		}
	}
	void OnBecameInvisible(){
		SceneController.LoadScene ("GameOver");
	//	transform.position = new Vector3 (0, 0, 0);
	}

	void OnCollisionEnter2D(Collision2D  col){
		if (col.gameObject.tag == "Enemy1") {
			Destroy(gameObject);
		}

		if (col.gameObject.tag == "PlatformMobile") {
			transform.parent = col.transform;
		}

		if (col.gameObject.tag == "Diamant") {
			Destroy (col.gameObject);
		}
	}

	/** Move play with collision enter with enemies **/
	public void OutCollision(float Power){
		Debug.Log ("dir" + dir);
		rb2d.velocity = new Vector2 (rb2d.velocity.x, 0);
		if (dir == -1) {
			rb2d.AddForce (Vector2.right * Power,ForceMode2D.Impulse);
		}
		if (dir == 1) {
			rb2d.AddForce (Vector2.left * Power,ForceMode2D.Impulse);
		}
	}

	/** Check numbers of lives for stop game **/
	void GameOver(){
		if (Lifes == 0) 
			SceneController.LoadScene ("GameOver");
	}
}
