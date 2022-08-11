using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
   
    public void Walk(bool isWalk)
    {
        animator.SetBool(AnimationTags.WALK, isWalk);
    }

    public void Punch1()
    {
        animator.SetTrigger(AnimationTags.PUNCH1);
    }

    public void Punch2()
    {
        animator.SetTrigger(AnimationTags.PUNCH2);
    }

    public void Punch3()
    {
        animator.SetTrigger(AnimationTags.PUNCH3);
    }

    public void Kick1()
    {
        animator.SetTrigger(AnimationTags.KICK1);
    }

    public void Kick2()
    {
        animator.SetTrigger(AnimationTags.KICK2);
    }

    public void Death()
    {
        animator.SetTrigger(AnimationTags.DEATH);
    }
}
