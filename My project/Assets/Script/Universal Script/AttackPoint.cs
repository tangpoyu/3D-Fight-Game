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
            if(isPlayer)
            {
                Vector3 hitFXPos = transform.position;
                Instantiate(hitFx, hitFXPos, Quaternion.identity);
                String animationName = animator.GetNextAnimatorClipInfo(0)[0].clip.name;
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
                        throw new System.NotImplementedException();
                }
                if (animationName == AnimationTags.PUNCH3_MOTITION_NAME 
                    || animationName == AnimationTags.KICK2_MOTITION_NAME)
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                    // TODO : Apply damage on Player and update health UI stats by creating health script.
                }
                else
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                    // TODO : Apply damage on Player and update health UI stats by creating health script.
                }
            }
            // print(hit[0].gameObject.name);
            gameObject.SetActive(false);
        }
    }
}
