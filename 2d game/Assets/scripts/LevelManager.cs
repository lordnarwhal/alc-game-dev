using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public GameObject CurrentCheckPoint;

	private Rigidbody2D pc;

	//Particles
	public GameObject DeathParticle;
	public GameObject RespawnPartcle;

	//respawn delay
	public float RespawnDelay;

	//point penalty on death
	public int PointPenaltyOnDeath;

	//store gravity value
	private float GravityStore;

	// Use this for initialization
	void Start () {
		pc = FindObjectOfType<Rigidbody2D> ();
	}

	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo(){
		//generate deathparticle
		Instantiate (DeathParticle, pc.transform.position, pc.transform.rotation);
		//hide pc
		//pc.enabled = false;
		pc.GetComponent<Renderer> ().enabled = false;
		//gravity reset
		GravityStore = pc.GetComponent<Rigidbody2D>().gravityScale;
		pc.GetComponent<Rigidbody2D>().gravityScale = 0f;
		pc.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		//point penalty
		ScoreManager.AddPoints(-PointPenaltyOnDeath);
		//debug message
		Debug.Log ("pc Respawn");
		//respawn delay
		yield return new WaitForSeconds (RespawnDelay);
		//graniy restore
		pc.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
		//match pcs transform position
		pc.transform.position = CurrentCheckPoint.transform.position;
		//Show pc
		//pc.enabled = true;
		pc.GetComponent<Renderer> ().enabled = true;
		//spawn pc
		Instantiate (RespawnPartcle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
