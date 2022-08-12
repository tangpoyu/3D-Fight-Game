using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : MonoBehaviour
{
    [SerializeField]
    private LayerMask collisionLayer;
    [SerializeField]
    private float radius = 1, damage;
    [SerializeField]
    private bool isPlayer, isEnemy;
    [SerializeField]
    private GameObject hitFx;

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
            if(isPlayer)
            {
                Vector3 hitFXPos = transform.position;
                Instantiate(hitFx, hitFXPos, Quaternion.identity);
                if(gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.LEFT_LEG_TAG))
                {
                    // TODO : Apply damage on Player and update health UI stats by creating health script.
                } else
                {
                    // TODO : Apply damage on Player and update health UI stats by creating health script.
                }
            }
            // print(hit[0].gameObject.name);
            gameObject.SetActive(false);
        }
    }
}
