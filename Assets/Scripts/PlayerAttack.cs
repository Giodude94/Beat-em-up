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

    void Awake()
    {
        playerAnim = GetComponent<CharacterAnimation>();
        playerAnimator = playerAnim.anim;
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

        /*
        if (Input.GetButtonDown("Fire1") && (playerAnim.anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || playerAnim.anim.GetCurrentAnimatorStateInfo(0).IsName("Walk")))
        {
            Invoke("ShootProjectile", 0);
            ShootProjectile();
            //playerAnim.Hit_1();
            playerAnim.Walk(false);
            dirX = 0;


        }

        else if (Input.GetButtonDown("Fire1") && playerAnim.anim.GetCurrentAnimatorStateInfo(0).IsName("Combo1_Hit1"))
        {
            Invoke("ShootProjectile", 0);
            //anim.SetTrigger("attack");
            //anim.SetBool("isWalking", false);
            dirX = 0;

        }

        else if (Input.GetButtonDown("Fire1") && playerAnim.anim.GetCurrentAnimatorStateInfo(0).IsName("Combo1_Hit2"))
        {
            Invoke("ShootProjectile", 0);
            //anim.SetTrigger("attack");
            dirX = 0;
        }
        else if (Input.GetButtonDown("Fire1") && playerAnim.anim.GetCurrentAnimatorStateInfo(0).IsName("Combo1_Hit2"))
        {
            Invoke("ShootProjectile", 0);
            //playerAnim.anim.ResetTrigger("attack");
            dirX = 0;
        }
        */


    }

    void ComboAttacks()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            currentComboState++;
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;

            if(currentComboState == ComboState.HIT_1)
            {
                playerAnim.Hit_1();
            }
            if (currentComboState == ComboState.HIT_2)
            {
                playerAnim.Hit_2();
            }
            if (currentComboState == ComboState.HIT_3)
            {
                playerAnim.Hit_3();
            }
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
                currentComboTimer = defaultComboTimer; //Redundant line 85
            }
        }
    }

}
