using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Service

public abstract class CharacterMovement: MonoBehaviour
{
    [SerializeField] 
    protected float walkSpeed = 5f;
    protected Rigidbody myBody;
    protected CharacterAnimation characterAnimation;
    protected float currentAttackTimer;
    [SerializeField]
    protected float defaultAttackTime, coldTimer;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        characterAnimation = GetComponentInChildren<CharacterAnimation>();
    }

    public string GetCurrentCharacterAnimation()
    {
        return characterAnimation.GetAnimator().GetCurrentAnimatorClipInfo(0)[0].clip.name;
    }

    public abstract void Movement();
    public abstract void Attack();
    public abstract void ResetComboState();
}
