﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	
	public GameObject[] models;
	public Bullet bullet;

	// Use this for initialization
	void Start () {
		int randomIndex = Random.Range (0, models.Length);
		for (int i = 0; i < models.Length; i++) {
			models [i].SetActive (i == randomIndex);
		}
	}

	// Update is called once per frame
	void Update () {	
	}


}