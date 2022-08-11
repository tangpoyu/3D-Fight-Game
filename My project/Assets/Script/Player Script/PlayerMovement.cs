using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody myBody;
    [SerializeField]
    private float walkSpeed, zSpeed, rotationSpeed;
    private float rotation = 90f;

    private PlayerAnimation playerAnimation;
    private enum ComboState
    {
        NONE,
        PUNCH_1,
        PUNCH_2,
        PUNCH_3,
        KICK_1,
        KICK_2,
    }
    private bool activateTimerToReset;
    private float currentComboTimer, defaultComboTimer = 0.4f, coldTimer = 2f;
    private ComboState currentComboState;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        playerAnimation = GetComponentInChildren<PlayerAnimation>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
        DetectMovement();
      
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentComboState == ComboState.PUNCH_3 || currentComboState == ComboState.KICK_2) return;
            if (currentComboState == ComboState.KICK_1) currentComboState = ComboState.NONE;
            currentComboState++;
            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;
            if (currentComboState == ComboState.PUNCH_1) playerAnimation.Punch1();
            else if (currentComboState == ComboState.PUNCH_2) playerAnimation.Punch2();
            else if (currentComboState == ComboState.PUNCH_3)
            {
                currentComboTimer = coldTimer;
                playerAnimation.Punch3();
            }
           
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (currentComboState == ComboState.PUNCH_3 || currentComboState == ComboState.KICK_2) return;

            activateTimerToReset = true;
            currentComboTimer = defaultComboTimer;
            if(currentComboState == ComboState.KICK_1)
            {
                currentComboTimer = coldTimer;
                currentComboState++;
                playerAnimation.Kick2();
            } else
            {
                currentComboState = ComboState.KICK_1;
                playerAnimation.Kick1();
            }
           
        }
    }

    public void ResetComboState()
    {
        if(activateTimerToReset)
        {
            currentComboTimer -= Time.deltaTime;
            if(currentComboTimer <= 0)
            {
                currentComboState = ComboState.NONE;
                activateTimerToReset = false;
            }
        }
    }



    public void DetectMovement()
    {
        myBody.velocity = new Vector3(
            Input.GetAxisRaw(Axis.HORIZONTAL) * -walkSpeed,
            myBody.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL) * -zSpeed
        );

        if (myBody.velocity != Vector3.zero) {
            transform.rotation = Quaternion.LookRotation(myBody.velocity);
            playerAnimation.Walk(true);
        } else
        {
            playerAnimation.Walk(false);
        }
       
        // LEARN : transform.LookAt(myBody.velocity);
        /* LEARN : if(Input.GetAxisRaw(Axis.HORIZONTAL) > 0) 
        transform.rotation = Quaternion.Euler(0,-rotation,0); */
    }
}
 