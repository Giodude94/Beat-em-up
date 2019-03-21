using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour {

    public GameObject wave;
    public bool facingRight;

    float dirX, moveSpeed;


    Animator anim;
    //public GameObject wave;

	// Use this for initialization
	void Start () {
        facingRight = true; //The player will be facing right at the start of the game. Always.
        anim = GetComponent<Animator>();
        moveSpeed = 5f;
		
	}
	
	// Update is called once per frame
	void Update () {

        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + dirX, transform.position.y);
        
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

        if(Input.GetButtonDown("Fire1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Kick"))
        {
            //Flip(dirX);
            anim.SetBool("isWalking", false);
            anim.SetTrigger("hit");
            GameObject clone;
            clone = Instantiate(wave, transform.position, Quaternion.identity);
        }


    }

    void Flip(float dirX)
    {
        if(dirX > 0 && !facingRight || dirX < 0 && facingRight)//We are moving to the right.
        {
            facingRight = !facingRight;//Flip the values of facing right.
            Vector3 theScale = transform.localScale; //Creating a ref to the players local scale;
            theScale.x *= -1; 
            transform.localScale = theScale;
        }
    }
}
