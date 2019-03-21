using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {

    public float dirX;
    float moveSpeed;
    bool catPlayerFacingRight;

    void Awake()
    {
        catPlayerFacingRight = GameObject.FindGameObjectWithTag("Player").GetComponent<CatController>().facingRight;
    }
    // Use this for initialization
    void Start () {
        moveSpeed = 5;
    }
	
	// Update is called once per frame
	void Update () {


        //dirX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        if (catPlayerFacingRight)
        {
            transform.position = new Vector2(transform.position.x + dirX, transform.position.y);    
        }
        else
        {
            transform.position = new Vector2(transform.position.x - dirX, transform.position.y);
        }

    }
}
