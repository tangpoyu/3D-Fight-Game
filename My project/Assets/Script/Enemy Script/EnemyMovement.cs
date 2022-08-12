using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyAnimation enemyAnimation;
    private Rigidbody myBody;
    [SerializeField]
    private float speed = 5f;
    private Transform playerTarget;
    [SerializeField]
    private float attackDistance = 1f, chasePlayerAfterAttack = 1f;
    private float currentAttackTime;
    private float defaultAttackTime = 2f;
    private bool followPlayer, attackPlayer;

    private void Awake()
    {
        enemyAnimation = GetComponentInChildren<EnemyAnimation>();
        myBody = GetComponent<Rigidbody>();
        playerTarget = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }
    // Start is called before the first frame update
    void Start()
    {
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
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (!followPlayer)  return;
        
        if(Vector3.Distance(transform.position, playerTarget.position) < attackDistance)
        { 
            enemyAnimation.Walk(false);
            myBody.velocity = Vector3.zero;
            followPlayer = false;
            attackPlayer = true;
           
        }
        else
        {
            transform.LookAt(playerTarget.position);
            myBody.velocity = transform.forward * speed;
            enemyAnimation.Walk(true);
            followPlayer = true;
            attackPlayer = false;
        }
       
    }

    private void Attack()
    {
        if(!attackPlayer) return;

        currentAttackTime += Time.deltaTime;
        if(currentAttackTime > defaultAttackTime)
        {
            switch(UnityEngine.Random.Range(0, AnimationTags.ATTACK_AIM_COUNT))
            {
                case 0:
                    enemyAnimation.Punch1();
                    break;

                case 1:
                    enemyAnimation.Punch2();
                    break;

                case 2:
                    enemyAnimation.Kick1();
                    break;
            }
          
            currentAttackTime = 0;
        }

        if(Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chasePlayerAfterAttack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }
}
