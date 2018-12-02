using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {

	public float speed = 2f;
	public Player player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		// move forward 
		transform.position += Vector3.forward * 2f * Time.deltaTime;
		if (player.score > 50) {
			transform.position += Vector3.forward * 2.1f * Time.deltaTime;
		} else if (player.score > 100) {
			transform.position += Vector3.forward * 2.2f * Time.deltaTime;
		} else if (player.score > 150) {
			transform.position += Vector3.forward * 2.3f * Time.deltaTime;
		} else if (player.score > 200) {
			transform.position += Vector3.forward * 2.4f * Time.deltaTime;
		} else if (player.score > 250) {
			transform.position += Vector3.forward * 2.5f * Time.deltaTime;
		} else if (player.score > 300) {
			transform.position += Vector3.forward * 2.6f * Time.deltaTime;
		} else if (player.score > 350) {
			transform.position += Vector3.forward * 2.7f * Time.deltaTime;
		} else if (player.score > 400) {
			transform.position += Vector3.forward * 2.8f * Time.deltaTime;
		} else if (player.score > 500) {
			transform.position += Vector3.forward * 2.9f * Time.deltaTime;
		}
	}


}
