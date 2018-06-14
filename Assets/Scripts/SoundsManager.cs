using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour {
	public static AudioClip firePSound, jumpPSound, coin, playerDying, donalFire, donalJump;
	static AudioSource audioSrc;
	// Use this for initialization
	void Start () {
		jumpPSound = Resources.Load<AudioClip> ("Sounds/jump");
		firePSound = Resources.Load<AudioClip> ("Sounds/firePlayer");
		coin = Resources.Load<AudioClip> ("Sounds/coins");
		playerDying = Resources.Load<AudioClip> ("Sounds/playerDying");
		donalFire = Resources.Load<AudioClip> ("Sounds/DonalFire");
		donalJump = Resources.Load<AudioClip> ("Sounds/donalJump");
		audioSrc = GetComponent<AudioSource> ();
	}
	public static void PlaySound(string clip){
		switch (clip) {
		case "jumpPlayer":
			audioSrc.PlayOneShot (jumpPSound);
			break;
		case "firePlayer":
			audioSrc.PlayOneShot (firePSound);
			break;
		case "jumpEnemy":
			audioSrc.PlayOneShot (firePSound);
			break;
		case "coin":
			audioSrc.PlayOneShot (coin);
			break;
		case "playerDying":
			audioSrc.PlayOneShot (playerDying);
			break;
		case "donalFire":
			audioSrc.PlayOneShot (donalFire);
			break;
		case "donalJump":
			audioSrc.PlayOneShot (donalJump);
			break;
		}

	}
		
	}

