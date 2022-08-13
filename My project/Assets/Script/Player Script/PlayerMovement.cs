using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    [SerializeField]
    private float zSpeed, rotationSpeed; 
    private bool activateTimerToReset;
    private ComboState currentComboState;

    private enum ComboState
    {
        NONE,
        PUNCH_1,
        PUNCH_2,
        PUNCH_3,
        KICK_1,
        KICK_2,
    }


    // Update is called once per frame
    void Update()
    {
        //  print("RAW: " + Input.GetAxisRaw(Axis.HORIZONTAL) + ", noRaw: " + Input.GetAxis(Axis.HORIZONTAL));
        Attack();
        ResetComboState();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    
    public override void Movement()
    {
        myBody.velocity = new Vector3(
            Input.GetAxisRaw(Axis.HORIZONTAL) * -walkSpeed,
            myBody.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL) * -zSpeed
        );

        if (myBody.velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(myBody.velocity);
            characterAnimation.Walk(true);
        }
        else
        {
            characterAnimation.Walk(false);
        }

        // LEARN : transform.LookAt(myBody.velocity);
        /* LEARN : if(Input.GetAxisRaw(Axis.HORIZONTAL) > 0) 
        transform.rotation = Quaternion.Euler(0,-rotation,0); */
    }

    public override void Attack()
    {
        string currentAnimation = characterAnimation.GetAnimator().GetCurrentAnimatorClipInfo(0)[0].clip.name;
        if (currentAnimation != AnimationTags.IDLE_ANIMATION) return;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentComboState == ComboState.PUNCH_3 || currentComboState == ComboState.KICK_2) return;

            if (currentComboState == ComboState.KICK_1) currentComboState = ComboState.NONE;
            currentComboState++;
            activateTimerToReset = true;
            currentAttackTimer = defaultAttackTime;
            if (currentComboState == ComboState.PUNCH_1) characterAnimation.Punch1();
            else if (currentComboState == ComboState.PUNCH_2) characterAnimation.Punch2();
            else if (currentComboState == ComboState.PUNCH_3)
            {
                currentAttackTimer = coldTimer;
                characterAnimation.Punch3();
            }

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (currentComboState == ComboState.PUNCH_3 || currentComboState == ComboState.KICK_2) return;

            activateTimerToReset = true;
            currentAttackTimer = defaultAttackTime;
            if (currentComboState == ComboState.KICK_1)
            {
                currentAttackTimer = coldTimer;
                currentComboState++;
                characterAnimation.Kick2();
            }
            else
            {
                currentComboState = ComboState.KICK_1;
                characterAnimation.Kick1();
            }

        }
    }

    public override void ResetComboState()
    {
        if (activateTimerToReset)
        {
            currentAttackTimer -= Time.deltaTime;
            if (currentAttackTimer <= 0)
            {
                currentComboState = ComboState.NONE;
                activateTimerToReset = false;
            }
        }
    }
}
 