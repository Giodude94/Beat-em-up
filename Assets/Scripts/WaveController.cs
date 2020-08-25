﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public float moveSpeed;
    private bool playerFacingRight;
    

    void Awake()
    {
        //Boolean to see if the player is currently facing to the right.
        //gameObject.SetActive(true);
        playerFacingRight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().facingRight;
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () { 
        //Controlling which direction the wave will travel based on what direction the player is facing.
        if (playerFacingRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);    
        }
        else if(!playerFacingRight)
        {
            transform.position = new Vector2(transform.position.x - moveSpeed, transform.position.y);
        }
        else
        {
            Debug.Log("Something went wrong with the wave. Script WaveController");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)// Collision for the wave that is spawned by the player.
    {
        //Debug.Log(collision.tag); //Will display both the Player and the Enemy tags.
        if(collision.tag == "Enemy")
        {
            Debug.Log("Wave projectile has hit the enemy!");
            collision.GetComponent<HealthController>().takeDamage(2);
            Destroy(gameObject, .05f);
        }
    }
    
}
