using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour {
	public ChararterMove Player;
	public bool isFallowing;

	//camera position offset
	public float xOffset;
	public float yOffset;

	// Use this for initialization
	void Start () {
		Player = FindObjectOfType<ChararterMove>();
		isFallowing = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isFallowing){
			transform.position = new Vector3(Player.transform.position.x + xOffset, Player.transform.position.y + yOffset, transform.position.z);

		}
		
	}
}
