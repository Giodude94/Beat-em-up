using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public float dirX;
    //float moveSpeed;
    bool playerFacingRight;
    private float playerHeight;
    private float groundHeight;
    private bool pGrounded;
    //private float waveHeight;

    void Awake()
    {
        //Will having all these in the awake for each wave affect the game efficiency in the future? Potentially when spawning multiple projectiles.
        pGrounded = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isGrounded;
        playerHeight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().transform.position.y;
        playerFacingRight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().facingRight;
    }
    // Use this for initialization
    void Start () {
       // moveSpeed = 5;
    }
	
	// Update is called once per frame
	void Update () {
        playerHeight = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>().size.y;
        groundHeight = GameObject.FindGameObjectWithTag("Ground").GetComponent<BoxCollider2D>().size.y;
        //waveHeight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().wave.GetComponent<BoxCollider2D>().size.y;
        //dirX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        if (playerFacingRight && pGrounded)
        {
            //Debug.Log("The value for groundHeight is " + groundHeight + "    The value for waveHeight is " + waveHeight);
            transform.position = new Vector2(transform.position.x + dirX,  playerHeight - groundHeight); //.5 of ground height + wave height should give us the top of ground.   
        }
        else if(pGrounded && !playerFacingRight)
        {
            transform.position = new Vector2(transform.position.x - dirX, playerHeight - groundHeight);
        }
        else if (!pGrounded && playerFacingRight)
        {
            transform.position = new Vector2(transform.position.x + dirX, transform.position.y);
        }
        else if (!pGrounded && !playerFacingRight)
        {
            transform.position = new Vector2(transform.position.x - dirX, transform.position.y);
        }
        else
        {
            Debug.Log("Something went wrong with the wave. Script WaveController");
        }

    }
}
