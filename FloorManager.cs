using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour {

	public Player player;
	public GameObject floor1;
	public GameObject floor2;
	public GameObject floor3;
	public float offsetLenght = 50f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.z >= floor2.transform.position.z) {
			floor1.transform.position = new Vector3 (0, 0, floor2.transform.position.z + offsetLenght);
		}	
		if (player.transform.position.z >= floor1.transform.position.z) {
			floor3.transform.position = new Vector3 (0, 0, floor1.transform.position.z + offsetLenght);
		}	
		if (player.transform.position.z >= floor3.transform.position.z) {
			floor2.transform.position = new Vector3 (0, 0, floor3.transform.position.z + offsetLenght);
		}	
	}
}
