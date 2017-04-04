using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float flap = 600f;
	public float scroll = 10f;

	Rigidbody2D rigidbody2D;
	GameControllerbk gameController;
	GameObject scoreGUI;

	void Awake(){
		rigidbody2D = GetComponent<Rigidbody2D>();
		gameController = GameObject.Find("GameController").GetComponent<GameControllerbk>();
		scoreGUI = GameObject.Find("ScoreGUI");
	}

	void Start(){
		rigidbody2D.isKinematic = true;
	}

	void FixedUpdate(){
		// if (gameController[0].isPlaying == true) {
		if (gameController.isPlaying == true) {
			rigidbody2D.velocity = new Vector2(scroll, rigidbody2D.velocity.y);
		}
	}

	void Update () {
		if (Input.GetKeyDown ("space")) {
			if(gameController.isPlaying == false){
				gameController.SendMessage("GameStart");
				rigidbody2D.isKinematic = false;
			}
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce(Vector2.up * flap, ForceMode2D.Impulse);
		}
	} 

	void Move() {
		if (gameController.isPlaying == true) {
			rigidbody2D.velocity = new Vector2(scroll, rigidbody2D.velocity.y);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "CountZone"){
			scoreGUI.SendMessage("AddScore", 1);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Death"){
			gameController.SendMessage("GameOver");
		}
	}
}