using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public float dirX;
    float moveSpeed;
    bool PlayerFacingRight;
    private float playerHeight;
    private float groundHeight;
    private float waveHeight;

    void Awake()
    {
        playerHeight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().transform.position.y;
        PlayerFacingRight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().facingRight;
    }
    // Use this for initialization
    void Start () {
        moveSpeed = 5;
    }
	
	// Update is called once per frame
	void Update () {
        playerHeight = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>().size.y;
        groundHeight = GameObject.FindGameObjectWithTag("Ground").GetComponent<BoxCollider2D>().size.y;
        waveHeight = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().wave.GetComponent<BoxCollider2D>().size.y;
        //dirX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        if (PlayerFacingRight)
        {
            Debug.Log("The value for groundHeight is " + groundHeight + "    The value for waveHeight is " + waveHeight);
            transform.position = new Vector2(transform.position.x + dirX,  playerHeight - groundHeight); //.5 of ground height + wave height should give us the top of ground.   
        }
        else
        {
            transform.position = new Vector2(transform.position.x - dirX, transform.position.y);
        }

    }
}
