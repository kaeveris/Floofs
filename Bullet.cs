using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour {

	public float lifetime = 3f;
	public GameController gameController;
	public Player player;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
		lifetime -= Time.deltaTime;


		if (lifetime < 0) {
			Destroy (gameObject);
		}		

	}

	void OnTriggerEnter (Collider collider){
		if (collider.tag == "FloofRed") {			
			foreach (GameObject enemyRed in GameObject.FindGameObjectsWithTag ("EnemyRed")) {
				Destroy(enemyRed);
			}
			Destroy (gameObject);
			Destroy (collider.gameObject);	
			FindObjectOfType<AudioManager>().Play("kill");

		}
		if (collider.tag == "FloofBlue") {
			foreach (GameObject enemyBlue in GameObject.FindGameObjectsWithTag ("EnemyBlue")) {
				Destroy(enemyBlue);
			}
			Destroy (gameObject);
			Destroy (collider.gameObject);
			FindObjectOfType<AudioManager>().Play("kill");

		}
	}
}
