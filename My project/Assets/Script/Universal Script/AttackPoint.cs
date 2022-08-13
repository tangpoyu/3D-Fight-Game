using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    [SerializeField]
    private LayerMask collisionLayer;
    [SerializeField]
    private float radius = 1;
    [SerializeField]
    private bool isPlayer, isEnemy;
    [SerializeField]
    private GameObject hitFx;
    
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        DetectCollision();
    }

    private void DetectCollision()
    {
        Collider[] hit =  Physics.OverlapSphere(transform.position, radius, collisionLayer);
        if (hit.Length > 0)
        {
            float damage;
            //print("current:" + animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
            //print("next: " + animator.GetNextAnimatorClipInfo(0)[0].clip.name);
            String animationName = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
            if (isPlayer)
            {
                Vector3 hitFXPos = transform.position;
                Instantiate(hitFx, hitFXPos, Quaternion.identity);
                
                switch (animationName)
                {
                    case AnimationTags.PUNCH1_MOTITION_NAME:
                    case AnimationTags.PUNCH2_MOTITION_NAME:
                        damage = 10;
                        break;

                    case AnimationTags.PUNCH3_MOTITION_NAME:
                    case AnimationTags.KICK1_MOTITION_NAME:
                        damage = 20;
                        break;

                    case AnimationTags.KICK2_MOTITION_NAME:
                        damage = 50;
                        break;

                    default:
                        damage = 0;
                        break;
                }
                if (animationName == AnimationTags.PUNCH3_MOTITION_NAME 
                    || animationName == AnimationTags.KICK2_MOTITION_NAME)
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                }
                else
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                }
                print(animationName + ":" + damage);
            }

            if(isEnemy)
            {
                switch (animationName)
                {
                    case AnimationTags.ENEMY1_ATTACK1:
                        damage = 10;
                        break;

                    case AnimationTags.ENEMY1_ATTACK2:
                        damage = 20;
                        break;

                    case AnimationTags.ENEMY1_ATTACK3:
                        damage = 50;
                        break;

                    default:
                        damage = 0;
                        break;
                }
                hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
            }
            // print(hit[0].gameObject.name);
            gameObject.SetActive(false);
        }
    }
}
