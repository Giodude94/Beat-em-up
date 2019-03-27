using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    //public Rigidbody2D projectile;
    //public Transform Spawnpoint;
    public float moveSpeed;
    private bool playerFacingRight;
    private float playerHeight;
    private float groundHeight;
    private bool pGrounded;
    private float WAVEHEIGHT = 2.17f;
    

    void Awake()
    {
        playerFacingRight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().facingRight;
    }

    // Use this for initialization
    void Start () {
       // moveSpeed = 5;
    }
	
	// Update is called once per frame
	void Update () { 
        //groundHeight = GameObject.FindGameObjectWithTag("Ground").GetComponent<BoxCollider2D>().size.y;
        
        //dirX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
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
}
