using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {
    public int currentHp;
    public int maxHP;
    public string objectName; //To sore the names of the enemies i.e the different types. (Cat, Goblin, Dog, ....)
    //private EnemyController enemy;


    private void Awake()
    {
        //enemy = GetComponent<EnemyController>();
        if (tag == "Player")
        {
            maxHP = 10;
        }
        else if(tag == "Weak Cat")
        {
            maxHP = 6;
        }
        else if(tag == "Strong Cat")
        {
            maxHP = 12;
        }
        else if (tag == "Enemy")
        {
            maxHP = 6;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
