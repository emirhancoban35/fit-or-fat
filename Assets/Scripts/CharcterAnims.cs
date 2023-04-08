using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterAnims : MonoBehaviour , ICharacterAnimControl
{
    [Header("Anims")]
    public Animator animator;
    //public CharacterMovement characterMovement;

    public void DeadAnimation()
    {
        Debug.Log("Game Ower");
        //characterMovement.isWalking = false;
        animator.SetBool("ölüm", true);
        animator.SetBool("yürümek", false);
        //animator.SetBool("bölümTamam", false);
        animator.SetBool("bekleme", false);
    }

    public void LevelFinishAnimation()
    {
        /*animator.SetBool("yürüme", false);
                    animator.SetBool("bekleme", false);*/
        animator.SetBool("bölümTamam", true);
    }

    public void WalkingAnimation(bool isWalking)
    {
        animator.SetBool("yürüme", true);
        animator.SetBool("bekleme", false);
    }

    //private void Update()
    //{
    //    if (characterMovement.isWalking == true)
    //    {
    //        DeadAnimation();
    //    }
    //    if (characterMovement.isWalking == true)
    //    {
    //        WalkingAnimation(true);
    //    }
    //    if (characterMovement.isWalking == false)
    //    {
    //        /*animator.SetBool("yürüme", false);
    //        animator.SetBool("bekleme", false);*/
    //        animator.SetBool("bölümTamam", true);
    //    }
    //}
}

