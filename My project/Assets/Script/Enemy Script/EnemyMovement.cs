using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : CharacterMovement
{
    private Transform playerTarget;
    [SerializeField]
    private float attackDistance = 1f, chasePlayerAfterAttack = 1f;
    private bool followPlayer, attackPlayer;

    private void Start()
    {
        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
        followPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        // LEARN : What is differense of function between Update and FixedUpdate ?
        Movement();
    }

    public override void Movement()
    {
        if (!followPlayer)  return;
        
        if(Vector3.Distance(transform.position, playerTarget.position) < attackDistance)
        {
            characterAnimation.Walk(false);
            myBody.velocity = Vector3.zero;
            followPlayer = false;
            attackPlayer = true;
           
        }
        else
        {
            transform.LookAt(playerTarget.position);
            myBody.velocity = transform.forward * walkSpeed;
            characterAnimation.Walk(true);
            followPlayer = true;
            attackPlayer = false;
        }
       
    }

    public override void Attack()
    {
        if(!attackPlayer) return;

        currentAttackTimer += Time.deltaTime;
        if(currentAttackTimer > defaultAttackTime)
        {
            switch(UnityEngine.Random.Range(0, AnimationTags.ATTACK_AIM_COUNT))
            {
                case 0:
                    characterAnimation.Punch1();
                    break;

                case 1:
                    characterAnimation.Punch2();
                    break;

                case 2:
                    characterAnimation.Kick1();
                    break;
            }
          
            currentAttackTimer = 0;
        }

        if(Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chasePlayerAfterAttack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }

    public override void ResetComboState()
    {
        throw new NotImplementedException();
    }
}
