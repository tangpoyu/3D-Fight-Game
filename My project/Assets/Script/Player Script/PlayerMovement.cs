using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody myBody;
    [SerializeField]
    private float walkSpeed, zSpeed, rotationSpeed;
    private float rotation = 90f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  print("RAW: " + Input.GetAxisRaw(Axis.HORIZONTAL) + ", noRaw: " + Input.GetAxis(Axis.HORIZONTAL));
    }

    private void FixedUpdate()
    {
        DetectMovement();
    }

    public void DetectMovement()
    {
        myBody.velocity = new Vector3(
            Input.GetAxisRaw(Axis.HORIZONTAL) * -walkSpeed,
            myBody.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL) * -zSpeed
        );

        if(myBody.velocity != Vector3.zero) transform.rotation = Quaternion.LookRotation(myBody.velocity);
       
        // LEARN : transform.LookAt(myBody.velocity);
        /* LEARN : if(Input.GetAxisRaw(Axis.HORIZONTAL) > 0) 
        transform.rotation = Quaternion.Euler(0,-rotation,0); */
    }
}
