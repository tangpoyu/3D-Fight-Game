using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;
    private CharacterAnimation characterAnimation;
    private EnemyMovement enemyMovement;
    private bool isDied;
    [SerializeField]
    private bool isPlayer;

    private void Awake()
    {
        characterAnimation = GetComponentInChildren<CharacterAnimation>();
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (isDied) return;

        health -= damage;
        if(health <= 0)
        {
            isDied = true;
            characterAnimation.Death();
            if(isPlayer)
            {
                // TODO : Enemy's Damage dealing
            }
            return;
        }

        if(!isPlayer)
        {
            if(knockDown)
            {
                if (Random.Range(0, 2) > 0)
                {
                    characterAnimation.KnockDown();
                    Invoke("StandUp", 10f);
                } else
                {
    
                    if (Random.Range(0, 3) > 1)
                    {
                        characterAnimation.Hit();
                    }
                }
            }
        }
    }

    public void StandUp()
    {
        characterAnimation.StandUp();
    }
}
