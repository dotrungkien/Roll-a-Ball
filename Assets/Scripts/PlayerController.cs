﻿using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public Text scoreText;
	
	private Rigidbody rb;
	private int score; 
	
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		score = 0;
		SetScoreText ();
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce (movement * speed);
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("coin"))
		{
			other.gameObject.SetActive (false);
			score = score + 1;
			SetScoreText ();
		}
	}
	
	void SetScoreText () 
	{
		scoreText.text = "Score: " + score;
	}
}