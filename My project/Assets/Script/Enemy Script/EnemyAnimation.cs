using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour, CharacterAnimation
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
        animator.SetTrigger(AnimationTags.ATTACK1);
    }

    public void Punch2()
    {
        animator.SetTrigger(AnimationTags.ATTACK2);
    }

    public void Punch3()
    {
        throw new System.NotImplementedException();
    }

    public void Kick1()
    {
        animator.SetTrigger(AnimationTags.ATTACK3);
    }

    public void Kick2()
    {
        throw new System.NotImplementedException();
    }

    public void Idle()
    {
        animator.Play(AnimationTags.IDLE_ANIMATION);
    }

    public void KnockDown()
    {
        animator.SetTrigger(AnimationTags.KNOCK_DOWN);
    }

    public void StandUp()
    {
        animator.SetTrigger(AnimationTags.STAND_UP);
    }

    public void Hit()
    {
        animator.SetTrigger(AnimationTags.HIT);
    }

    public void Death()
    {
        animator.SetTrigger(AnimationTags.DEATH);
    }

    public Animator GetAnimator()
    {
        return animator;
    }
}
