using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walljump : MonoBehaviour {
public float JumpHeight;
public Transform wallCheck;
public float wallCheckRadius;
public LayerMask whatIsWall;
private bool walled;
public Animator animator;
private bool doubleJump;
	// Use this for initialization
	void Start () {
		animator.SetBool("isJumping",false);
	}
	void FixedUpdate () {
		walled = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Space)&& walled){
		animator.SetBool("isJumping",true);
		Jump();
		}
		if(walled)
			doubleJump = false;
			animator.SetBool("isJumping",false);

			if(Input.GetKeyDown (KeyCode.Space)&& !doubleJump && !walled){
				Jump();
				doubleJump = true;
				animator.SetBool("isJumping",true);
			}
	}
	public void Jump(){
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
		animator.SetBool("isJumping",true);
	}
}
