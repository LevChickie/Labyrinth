using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	
	public float speed;
	public Slider healthBar;
	public Slider expBar;
	public Text scoreText;
	private int score;
	private float change;
	private Rigidbody player;
	// Use this for initialization
	void Start () {
		player = GetComponent<Rigidbody>();
		score = 0;
		SetScore ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vector = new Vector3(0,0,0);
		if (Input.GetKey (KeyCode.W)) {
			change = 0.4f;
		} else if (Input.GetKey (KeyCode.S)) {
			change = -0.4f;
		} else {
			return;
		}
		if (Camera.main.transform.localEulerAngles.y > 50 && Camera.main.transform.localEulerAngles.y <= 120) {
			vector = new Vector3 (player.position.x+change, player.position.y, player.position.z);
		} else if (Camera.main.transform.localEulerAngles.y > 150 && Camera.main.transform.localEulerAngles.y <= 210) {
			vector = new Vector3 (player.position.x, player.position.y, player.position.z-change);
		}else if (Camera.main.transform.localEulerAngles.y > 250 && Camera.main.transform.localEulerAngles.y <=310) {
			vector = new Vector3 (player.position.x - change, player.position.y, player.position.z);
		}else if (Camera.main.transform.localEulerAngles.y >= 0 && Camera.main.transform.localEulerAngles.y <= 30 || Camera.main.transform.localEulerAngles.y >330 ) {
			vector = new Vector3 (player.position.x, player.position.y, player.position.z+change);
		} else {
			return;
		}
			player.MovePosition(vector);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pickable")) {
			score++;
			other.gameObject.SetActive (false);
			SetScore ();
		} else if (other.gameObject.CompareTag ("Enemy")) {
			other.gameObject.SetActive (false);
			healthBar.value -= 0.1f;
		}
		/*
		 * Deactivated due this logic would cause the player to be able to walk through walls
		 * else if (other.gameObject.CompareTag ("Wall") && Input.GetKey (KeyCode.LeftShift)) {
			other.gameObject.SetActive (false);
		}*/
	}

	void SetScore(){
		expBar.value+=0.01f;
		scoreText.text = "Score: " + score;
	}

}
