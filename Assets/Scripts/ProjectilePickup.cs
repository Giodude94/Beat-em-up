using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePickup : MonoBehaviour
{
    public bool inventory; // A boolean that indicates if this projectile can be picked up and stored in the inv.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoInteraction()//Interaction that happens when the spell is picked up.
    {
        gameObject.SetActive(false);
    }
    
}
