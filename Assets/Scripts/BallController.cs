﻿using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour 
{
	public float moveSpeed;
	public float jumpspeed;
	Vector3 respawnPosition;

	int score = 0;
	bool isGrounded = true;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float x = Input.GetAxis ("Horizontal") * moveSpeed * Time.deltaTime;
		float z = Input.GetAxis ("Vertical") * moveSpeed * Time.deltaTime;
		//Create a force that you apply to the rigid body of the object
		Vector3 force = new Vector3 ( x , 0f, z );
		if (isGrounded && Input.GetButton ("Jump")) 
		{
			force.y = jumpspeed;
			isGrounded = false;
		}
		rigidbody.AddForce (force);
	}

	void OnCollisionEnter(Collision collision) 
	{
		if(collision.collider.CompareTag("Ground"))
		{
			isGrounded = true;
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if(other.CompareTag ("Coin"))
		{
		other.gameObject.SetActive (false);
			ScoreTracker.Instance.AddScore(10);
		}
	}
	
}