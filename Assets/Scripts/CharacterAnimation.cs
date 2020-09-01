using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Walk(bool Walking)
    {
        anim.SetBool("isWalking", Walking);
    }

    public void Hit_1()
    {
        anim.SetTrigger("attack");
    }

    public void Hit_2()
    {
        anim.SetTrigger("attack2");
    }

    public void Hit_3()
    {
        anim.SetTrigger("attack3");
    }
}
