using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public const int numSpellSlots = 2;
    public GameObject[] inventory = new GameObject[2]; // Creating an array that holds our items, currently set to two items total.
    public GameObject droppedSpell;
    public GameObject[] spellList = new GameObject[2]; //List that holds prefabs of all available spells the character can use

    //for UI
    public Image[] itemImages = new Image[numSpellSlots];

    public void AddItem(GameObject spell)
    {

        bool itemAdded = false;
        bool duplicate = false;

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] != null && inventory[i].name == spell.name) //Player cannot pick up another of an item they already have.
            {
                duplicate = true;
                //Debug.Log ("Duplicate item.");
                break;
            }

            if (inventory[i] == null)
            { // looking in each spot of the inventry until an empty spot is found

                //Gets the sprite and sets it into the inventory of images to be displayed in the UI.
                //itemImages[i].sprite = spell.GetComponent<SpriteRenderer>().sprite;
                //itemImages[i].enabled = true;


                inventory[i] = AssignSpellFromList(spell);
                //Debug.Log (item.name + " was added");
                // playerText.weaponPickedUp(spell);
                itemAdded = true; 
                //Make the object de activate to similate object being picked up.
                spell.SendMessage("DoInteraction");

                break; //Can change to return if needed. 
            }
        }
        //If the inventory is full
        if (itemAdded == false && duplicate == false)
        {
            Vector3 itemPos = spell.transform.position;// Storing the current position of the item that is to be picked up.
                                                       //inventory [1].SetActive (true); un comment this to get the object to re appear at original position when dropped.

            //droppedSpell = Instantiate(inventory[0], itemPos, Quaternion.Euler(0, 180, 0));// Istantiating the dropped object where the player is standing.
            //droppedSpell.name = inventory[0].name; //Changing the name of the Instantiated object(clone) to be the same name as the object in the inventory. (clone)(clone) -> (clone)
            //droppedSpell.SetActive(true);//Setting the active to true in order to show the Instantiated object.

            inventory[0] = AssignSpellFromList(spell); //Active slot is the first slot, so we will replace the current spell with the new spell.
            
            //Updatindg the UI to represent the new spell that was swapped.
            itemImages[0].sprite = inventory[0].GetComponent<SpriteRenderer>().sprite;
            itemImages[0].enabled = true;
            
            
            //playerText.weaponPickedUp(item);
            //inventory[0] = spell; // First item in the array of objects

            spell.SendMessage("DoInteraction");
            
            //Debug.Log ("Inventory is full - Item was switched out with secondary weapon.");
        }



    }

    public void SwitchSpells() // Function for switching the primary and secondary spells.
    {
        //Initializing the first item in our inventory as our first item for the swap.
        GameObject item1 = inventory[0];
        //Initializing the second item in our inventory as the second item for the swap.
        GameObject item2 = inventory[1];
        // Temporary game object to hold an item in the inventory array.
        GameObject item3 = null; 

        item3 = item1; // putting the weapon from the first slot into the temporary game object.
        inventory[0] = item2; // Setting the weapon in the second slot into the first slot.
        inventory[1] = item3; // setting the weapon in the temporary slot into the second slot.


        //We have to update the images that are shown on the UI to respresent the switch in spells.
        //Updating the first spell in the inventory.
        itemImages[0].sprite = inventory[0].GetComponent<SpriteRenderer>().sprite;
        itemImages[0].enabled = true;
        //Updating the second spell in the inventory.
        itemImages[1].sprite = inventory[1].GetComponent<SpriteRenderer>().sprite;
        itemImages[1].enabled = true;

    }

    private GameObject AssignSpellFromList(GameObject spell)
    {
        //The assignment is based on if the name of the spell is the same as the name in the spell list.
        for(int i = 0; i < spellList.Length; i++)
        {
            if (spell.name == spellList[i].name)
            {
                return spellList[i];
            }
        }



        return spell;

    }

}

