using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public Rigidbody enemyRigidBody;
    public float knockback;
    
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            Debug.Log("Enemy is being hit by projectile/Physical attack.");
            enemyRigidBody.AddForce( new Vector3(knockback, 0f, 0f));
        }
    }
}
