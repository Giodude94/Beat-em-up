using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    NONE,
    HIT_1,
    HIT_2,
    HIT_3
}

public class PlayerAttack : MonoBehaviour
{
    private CharacterAnimation playerAnim;
    private Animator playerAnimator;

    private bool activateTimerToReset;
    private float defaultComboTimer = 0.4f;
    private float currentComboTimer;

    private ComboState currentComboState;
    private PlayerController playerController;

    void Awake()
    {
        playerAnim = GetComponent<CharacterAnimation>();
        playerAnimator = playerAnim.anim;

        playerController = GetComponent<PlayerController>(); 
    }

    private void Start()
    {
        currentComboTimer = defaultComboTimer;
        currentComboState = ComboState.NONE; //Starting at no combo.
    }

    // Update is called once per frame
    void Update()
    {
        ComboAttacks();
        ResetComboState();

    }

    void ComboAttacks()
    {
        //Will execute when the player is attacking.
        if (Input.GetButtonDown("Fire1"))
        {
            //playerController.SendMessage("ShootProjectile");
            currentComboState++;
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;

            if(currentComboState == ComboState.HIT_1)
            {
                playerAnim.Hit_1();
                //playerController.SendMessage("ShootProjectile");
            }
            if (currentComboState == ComboState.HIT_2)
            {
                playerAnim.Hit_2();
                //playerController.SendMessage("ShootProjectile");
            }
            if (currentComboState == ComboState.HIT_3)
            {
                playerAnim.Hit_3();
                playerController.SendMessage("ShootProjectile");
            }
        }
        else //When we are not attacking.
        {

        }
    }

    void ResetComboState()
    {
        if (activateTimerToReset)
        {
            currentComboTimer -= Time.deltaTime;

            if(currentComboTimer <= 0f)
            {
                currentComboState = ComboState.NONE;

                activateTimerToReset = false;
                currentComboTimer = defaultComboTimer; //Redundant line 
            }
        }
    }

}
