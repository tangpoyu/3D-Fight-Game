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
    [SerializeField]
    private HealthUI healthUI;

    private void Awake()
    {
        characterAnimation = GetComponentInChildren<CharacterAnimation>();
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (isDied) return;

        health -= damage;

        if (isPlayer)
        {
            healthUI.updateBloodVolumeOnPlayer(health);
        }

        if (health <= 0)
        {
            isDied = true;
            characterAnimation.Death();
            gameObject.GetComponent<CharacterMovement>().enabled = false;
            if(isPlayer)
            {
                GameObject.FindWithTag(Tags.ENEMY_TAG).GetComponent<EnemyMovement>().enabled = false;
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
