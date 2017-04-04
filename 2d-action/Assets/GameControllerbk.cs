using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerbk : MonoBehaviour {

	private GameObject player;
	private GameObject[] start;
	private GameObject[] gameOver;
	private GameObject spawnPoint;
	// public static bool isPlaying;
	public bool isPlaying;

	void Awake(){
		player = GameObject.Find ("Player");
		// start = GameObject.Find ("Start");
		// gameOver = GameObject.Find ("GameOver");

		// player = GameObject.FindGameObjectsWithTag("Player");
		start = GameObject.FindGameObjectsWithTag("Start");
		gameOver = GameObject.FindGameObjectsWithTag("GameOver");
		spawnPoint = GameObject.Find("SpawnPoint");
	}

	void Start (){
		// gameOver.SetActive (false);
		foreach (GameObject goObject in gameOver) {
			goObject.SetActive (false);
		}
		isPlaying = false;
	}

	void Update (){
		if (Input.GetKeyDown("a")) {
			Application.LoadLevel("StageSample");
		}
	}

	public void GameStart (){
		// start.SetActive (false);
		foreach (GameObject sObject in start)
		{
			sObject.SetActive (false);
		}
		spawnPoint.SendMessage("StartSpawn");
		isPlaying = true;
	}

	public void GameOver (){
		if (isPlaying == true) {
			// gameOver.SetActive (true);
			foreach (GameObject goObject in gameOver) {
				goObject.SetActive (true);
			}
			// spawnPoint.SendMessage("SpawnWalls");
			isPlaying = false;
			player.GetComponent<Player>().enabled = false;
		}
	}
}
