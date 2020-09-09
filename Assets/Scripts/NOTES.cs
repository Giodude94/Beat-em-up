using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOTES : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Fix camera angle and position for 3d space movement.
    //Seperate sprite from cat gameObject that way we can angle it 45 degrees to make it look good for the camera.


   //Added tornado spell. Issue of each spells' positioning needs to be addressed ASAP.
   //After adding the spell into the inventory create a function that adjusts the spellSpawn location according to the spell that is in the active slot (inventory[0])
   // that way the spawn location is adjusted(X,Y,Z coordinates) before we spawn that particular spell.

   // Find a way to implement a way to pick up a certain pickup and associate that with an object in an inventory that will be on the character.
   // Or see if you can change the scripts of pick ups stored in the inventory so that it can double down as the projectile that will be spawned.


    //The character should not move once it has attacks. In beat 'em ups the player does not move once they start attacking.
    //The chain should not continue if there is no target in front of the player. Should just repeat the first attack in the chain if there is no target.


   //Could set int the animation to not take any input from the Horizonatal axis as a means of stopping the char when attacking.
   
   //Character movement needs to be fixed for whenever the player is moving and attacking. The player only stops for a little bit. looks jittery.
  


    // Update is called once per frame
    void Update()
    {
        
    }
}
