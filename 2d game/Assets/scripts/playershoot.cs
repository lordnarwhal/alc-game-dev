﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershoot : MonoBehaviour {
	public Transform FirePoint;
	public GameObject Projectile;

	// Use this for initialization
	void Start () {
		Projectile = GameObject.Find("projectile");
		Projectile = Resources.Load("Prefabs/projectile") as GameObject; 
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Mouse1))
			Instantiate(Projectile,FirePoint.position, FirePoint.rotation);
		
	}
}
