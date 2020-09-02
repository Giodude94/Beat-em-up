﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //public GameObject projectile;
    public Transform projectileSpawnPoint;
    public Rigidbody2D playerRigidBody2d;
    public bool facingRight;
    public bool isGrounded;
    public float jumpForce;
    public LayerMask groundLayers;
    public Inventory playerInventory;


    private bool jump;
    private Transform groundCheck;

    float dirX, moveSpeed;


    private CharacterAnimation playerAnim;
    //Animator anim; //Animation that is to be used.
    //public GameObject wave;


    private void Awake()
    {
        playerAnim = GetComponent<CharacterAnimation>();
        jump = false;
        jumpForce = jumpForce + 0f;
        playerRigidBody2d = GetComponent<Rigidbody2D>(); //The rigid body that is attached to the player.
        playerInventory = GetComponent<Inventory>();

    }


    // Use this for initialization
    void Start()
    {
        facingRight = true; //The player will be facing right at the start of the game. Always.
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        // This grounded meachanic is a point in the bottom left of the char collider that extends to the bottom right(a bit more below) that then draws a line between the two points
        // if there is a layer of ground that is touching the line the player will be grounded.
        isGrounded = Physics2D.OverlapArea(new Vector2((transform.position.x - .85f), transform.position.y - 1.32f),
                       new Vector2(transform.position.x + 0.85f, transform.position.y - 1.7f), groundLayers);

        //Moves the player in the x axis.
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

        //Stops the player from moving whenever they are attacking.
        if (!Input.GetButton("Fire1")) {
            transform.position = new Vector2(transform.position.x + dirX, transform.position.y);
        }
        /*
         Bug in player movement and animation: When holding down horizontal directional movement then pressing mouse 1 then immedietly letting go of movement, the animation gets notacibly stuck for a few frames.
         Either a bug in the way I have the animation timings set or the code that is used to control the animations.
         */



        //Switching spells from one slot to the other
        if (Input.GetKeyDown(KeyCode.Q) && (playerInventory.inventory[0] != null && playerInventory.inventory[1] != null)) //If the player presses the key and there are two spells in the inventory.
        {
            playerInventory.SwitchSpells();
        }

        //If the player is moving and the player is not currently in the middle of the first combo, second combo, or third combo in the chain.
        //When dirX == 0, player is standing still.
        if ( !standingStill() )//&& !playerAnim.anim.GetCurrentAnimatorStateInfo(0).IsName("Hit1_Combo1")) //This piece of code makes it to where you can hit and move at the same time. without it cutting to the walking animation.
        { 
            playerAnim.Walk(true);
            Flip(dirX);

            //anim.ResetTrigger("attack");

            //Debug.Log("This code is running.");
        }
        else
        {
            playerAnim.Walk(false);

            Flip(dirX); //Will flip while in the middle of the kick animation.
        }



        //If the player is clicking the left mouse button and it is not in the middle of a kick animation.
        if (Input.GetButtonDown("Fire1") && (playerAnim.anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || playerAnim.anim.GetCurrentAnimatorStateInfo(0).IsName("Walk")))
        {
            Invoke("ShootProjectile", 0);
            ShootProjectile();
            playerAnim.Hit_1();
            playerAnim.Walk(false);
            dirX = 0;


        }
        
        else if(Input.GetButtonDown("Fire1") && playerAnim.anim.GetCurrentAnimatorStateInfo(0).IsName("Combo1_Hit1"))
        {
            Invoke("ShootProjectile", 0);
            //anim.SetTrigger("attack");
            //anim.SetBool("isWalking", false);
            dirX = 0;

        }
        
        else if(Input.GetButtonDown("Fire1") &&  playerAnim.anim.GetCurrentAnimatorStateInfo(0).IsName("Combo1_Hit2"))
        {
            Invoke("ShootProjectile", 0);
            //anim.SetTrigger("attack");
            dirX = 0;
        }
        else if(Input.GetButtonDown("Fire1") && playerAnim.anim.GetCurrentAnimatorStateInfo(0).IsName("Combo1_Hit2"))
        {
            Invoke("ShootProjectile", 0);
            //playerAnim.anim.ResetTrigger("attack");
            dirX = 0;
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
        if (collision.tag == "Pick_Up")
        { //Currently our projectile is set to Wave_Pick_Up(The type of projectile
            Debug.Log("This should happen");
            playerInventory.AddItem(collision.gameObject);

        }
        else
        {
            Debug.Log(collision.tag);
        }
    }


    private void ShootProjectile()
    {
        //If the players inventory for spell pick ups is empty we should not be able to spawn projectiles.
        if(playerInventory.inventory[0] == null)
        {
            //The player has not picked up a projectile to shoot yet. So there is nothing to instantiate.
        }
        else if(playerInventory.inventory.Length > 0)
        {   //Slot 0 in the array will be used to tell which spell is currently equiped.
            Instantiate(playerInventory.inventory[0], projectileSpawnPoint.position, playerInventory.inventory[0].transform.rotation);
        }
        else
        {
            Debug.Log(playerInventory.inventory.Length);
        }
    }

    bool standingStill()
    {
        if( dirX == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}