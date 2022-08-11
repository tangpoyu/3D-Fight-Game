using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
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

    public void Attack(int id)
    {
        switch (id)
        {
            case 1:
                animator.SetTrigger(AnimationTags.ATTACK1);
                break;

            case 2:
                animator.SetTrigger(AnimationTags.ATTACK2);
                break;

            case 3:
                animator.SetTrigger(AnimationTags.ATTACK3);
                break;
        }
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
}
