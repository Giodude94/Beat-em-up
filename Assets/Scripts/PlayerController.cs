﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject projectile;
    public Transform projectileSpawnPoint;
    public Rigidbody2D playerRigidBody2d;
    public bool facingRight;
    private bool jump;
    public float jumpForce;
    public bool isGrounded;
    private Transform groundCheck;
    public LayerMask groundLayers;

    float dirX, moveSpeed;


    Animator anim; //Animation that is to be used.
    //public GameObject wave;


    private void Awake()
    {
        jump = false;
        jumpForce = jumpForce + 0f;
        playerRigidBody2d = GetComponent<Rigidbody2D>(); //The rigid body that is attached to the player.

    }


    // Use this for initialization
    void Start()
    {
        facingRight = true; //The player will be facing right at the start of the game. Always.
        anim = GetComponent<Animator>();
        moveSpeed = 5f;
        

    }

    // Update is called once per frame
    void Update()
    {
        // This grounded meachanic is a point in the bottom left of the char collider that extends to the bottom right(a bit more below) that then draws a line between the two points
        // if there is a layer of ground that is touching the line the player will be grounded.
        isGrounded = Physics2D.OverlapArea(new Vector2((transform.position.x - .85f) , transform.position.y - 1.32f), 
                       new Vector2(transform.position.x + 0.85f, transform.position.y - 1.7f), groundLayers);

        
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

        //Moves the player in the x axis.
        transform.position = new Vector2(transform.position.x + dirX, transform.position.y);

        //If the player is moving and the player is not currently kicking.
        if (dirX != 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("Kick"))
        {
            anim.SetBool("isWalking", true);
            Flip(dirX);
        }
        else
        {
            anim.SetBool("isWalking", false);
            //Flip(dirX); //Will flip while in the middle of the kick animation.
        }
        //If the player is clicking the left mouse button and it is not in the middle of a kick animation.
        if (Input.GetButtonDown("Fire1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Kick"))
        {
            anim.SetBool("isWalking", false);
            anim.SetTrigger("hit");
            //Code for picking up the game object that the player is passing over.
            if (projectile != null)
            {
                GameObject clone;
                clone = (GameObject)Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);
                clone.GetComponent<WaveController>().enabled = true;
                clone.GetComponent<DestroyGameObj>().enabled = true;
                clone.tag = "Projectile";
                clone.transform.position = new Vector2(projectileSpawnPoint.position.x, projectileSpawnPoint.position.y);
                //GameObject clone = Instantiate(wave, transform.position, Quaternion.identity);
            }
        }

        //Jumping
        if ((Input.GetButtonDown("Jump")))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        //The player will only jump if they are grounded. Fixes jumping in the air multiple times.
        if (jump && isGrounded)
        {
            playerRigidBody2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    void Flip(float dirX)//Flipping the player in the direction that they are walking
    {

        if (dirX > 0 && !facingRight || dirX < 0 && facingRight)//When player is moving to the right.
        {
            facingRight = !facingRight;//Flip the values of facing right.
            Vector3 theScale = transform.localScale; //Creating a ref to the players local scale;
            theScale.x *= -1;
            transform.localScale = theScale;

        }
    }
    void OnTriggerEnter2D(Collider2D collision) //Handles collisions for the player. Handles if the game object is of type projectile then should set the projectile that was picked up.
    {
        //Debug.Log(collision.tag);
        if(collision.tag == "Wave"){ //Currently our projectile is set to Wave(The type of projectile).
            projectile = collision.gameObject;
        }
    }
}