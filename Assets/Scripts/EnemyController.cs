using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Rigidbody2D enemyRigidBody2d;
    public float knockback;
    
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //NEEDS TO BE UPDATED FOR 3D USE.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.tag); //Will display both the Player and the Enemy tags.
        if (collision.tag == "Projectile")
        {
            //collision.GetComponent<HealthController>().currentHp -= 2;
            //enemyRigidBody2d.AddForce(new Vector2(200f, 0f));
            enemyRigidBody2d.velocity = new Vector2(knockback, 0f);
            

        }
    }
}
