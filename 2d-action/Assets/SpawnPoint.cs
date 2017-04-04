using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	public GameObject spawnObject;
	public float interval;

	void Update () {
		transform.position = new Vector3(transform.position.x, Random.Range(-5f,20f), transform.position.z);
	}

	public void StartSpawn(){
		StartCoroutine("SpawnWalls");
	}

	public void StopSpawn(){
		StopCoroutine("SpawnWalls");
	}

	private IEnumerator SpawnWalls(){
		while(true){
			yield return new WaitForSeconds(interval);
			Instantiate(spawnObject, transform.position, transform.rotation);
		}
	}
}