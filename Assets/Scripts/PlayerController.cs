using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject wave;
    public Rigidbody2D rb2d;
    public bool facingRight;
    private bool jump;
    public float jumpForce;
    public bool isGrounded;
    private Transform groundCheck;
    public LayerMask groundLayers;

    float dirX, moveSpeed;


    Animator anim;
    //public GameObject wave;


    private void Awake()
    {
        jump = false;
        //isGrounded = true;
        jumpForce = jumpForce + 0f;
        rb2d = GetComponent<Rigidbody2D>();
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
        //In order for the one that is similar to IronHaven to work you must include a transfrom in Unity scene editor.
        //This grounded meachanic is a point in the bottom left of the char collider that extends to the bottom right(a bit more below) that then draws a line between the two points
        // if there is a layer of ground that is touching the line the player will be grounded.
        isGrounded = Physics2D.OverlapArea(new Vector2((transform.position.x - .85f) , transform.position.y - 1.32f), 
                       new Vector2(transform.position.x + 0.85f, transform.position.y - 1.7f), groundLayers);

        //Debug.Log(isGrounded);
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x+ dirX, transform.position.y);

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

        if (Input.GetButtonDown("Fire1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Kick"))
        {
            //Flip(dirX);
            anim.SetBool("isWalking", false);
            anim.SetTrigger("hit");
            GameObject clone;
            clone = Instantiate(wave, transform.position, Quaternion.identity);
        }

        if ((Input.GetButtonDown("Jump")))
        {
            jump = true;
        }



    }

    private void FixedUpdate()
    {
        if (jump && isGrounded)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
            //anim.SetTrigger("PlayerJump")//setJump();
        }
    }

    void Flip(float dirX)
    {
        if (dirX > 0 && !facingRight || dirX < 0 && facingRight)//We are moving to the right.
        {
            facingRight = !facingRight;//Flip the values of facing right.
            Vector3 theScale = transform.localScale; //Creating a ref to the players local scale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}