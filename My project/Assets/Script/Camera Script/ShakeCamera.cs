using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    [SerializeField]
    private float power = 0.2f, duration = 0.2f, slowDownAmount = 1f;
    private float initialDuration;
    private bool shouldShake;
    private Vector3 startPostition;

    public bool ShouldShake { get => shouldShake; set => shouldShake = value; }

    // Start is called before the first frame update
    void Start()
    {
        startPostition = transform.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        Shake();   
    }

    private void Shake()
    {
        if (!ShouldShake) return;
 
        if(duration > 0)
        {
            transform.localPosition = startPostition + UnityEngine.Random.insideUnitSphere * power;
            duration -= Time.deltaTime * slowDownAmount;
        }
        else
        {
            ShouldShake = false;
            duration = initialDuration;
            transform.localPosition = startPostition;
        }
    }
}
