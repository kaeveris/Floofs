using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 2f;
	public float bulletSpeed = 5f;
	public float movingSpeed = 10f;
	public float score;
	public GameObject bulletPrefab;
	public Basket basket;
	public Floof floof;
	public Enemy enemy;
	public bool dead;

	// Use this for initialization
	void Start () {
		dead = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		score = transform.position.z;
		if (score < 0) {
			score = 0;
		}

		// look left
		if (Input.GetKey ("left") || Input.GetKey ("a")) {
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(new Vector3(0, -90, 0)), 0.03f);
		}
		// look right
		if (Input.GetKey ("right") || Input.GetKey ("d")) {
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(new Vector3(0, 90, 0)), 0.03f);
		}
		// look down
		if (Input.GetKey ("down") || Input.GetKey ("s")) {
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(new Vector3(90, 0, 0)), 0.03f);
		}
		// look up
		if (Input.GetKey ("up") || Input.GetKey ("w")) {
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(new Vector3(-90, 0, 0)), 0.03f);
		}

		// move forward 
		transform.position += Vector3.forward * 2f * Time.deltaTime;
		if (score > 50) {
			transform.position += Vector3.forward * 2.1f * Time.deltaTime;
		} else if (score > 100) {
			transform.position += Vector3.forward * 2.2f * Time.deltaTime;
		} else if (score > 150) {
			transform.position += Vector3.forward * 2.3f * Time.deltaTime;
		} else if (score > 200) {
			transform.position += Vector3.forward * 2.4f * Time.deltaTime;
		} else if (score > 250) {
			transform.position += Vector3.forward * 2.5f * Time.deltaTime;
		} else if (score > 300) {
			transform.position += Vector3.forward * 2.6f * Time.deltaTime;
		} else if (score > 350) {
			transform.position += Vector3.forward * 2.7f * Time.deltaTime;
		} else if (score > 400) {
			transform.position += Vector3.forward * 2.8f * Time.deltaTime;
		} else if (score > 500) {
			transform.position += Vector3.forward * 2.9f * Time.deltaTime;
		}



		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag ("EnemyBlue")) {
			if (transform.position.z > enemy.transform.position.z) {
				dead = true;
			}	
		}
		foreach (GameObject enemy in GameObject.FindGameObjectsWithTag ("EnemyRed")) {
			if (transform.position.z > enemy.transform.position.z) {
				dead = true;
			}	
		}

		//shoot
		if (Input.GetKeyDown("space")){
			GameObject bulletObject = Instantiate (bulletPrefab);
			bulletObject.transform.position = transform.position;
			bulletObject.GetComponent<Rigidbody> ().AddForce (transform.forward * bulletSpeed);
		}

	}




}
