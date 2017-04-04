using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	GameControllerbk gameController;

	public float scroll = 0.15f;
	public float dropPoint = -50f;

	void Awake(){
		gameController = GameObject.Find("GameController").GetComponent<GameControllerbk>();
	}

	void Update () {
		// if (GameController.isPlaying == true) {
		// 	transform.Translate (Vector2.left * scroll);
		// }
		if (gameController.isPlaying == true) {
			transform.Translate (Vector2.left * scroll);
		}

		if (transform.position.x <= dropPoint) {
			Destroy(gameObject);
		}
	}
}
