using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]  WheelCollider rightWheel;
    [SerializeField]  WheelCollider leftWheel;

    public float linearAcceleration = 50f;
    public float rotationalAcceleration = 500f;
    public float breakForce = 300f;
    public float maxTurnAngle = 15f;
    public float strength = 0.5f;

    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0;

    void FixedUpdate()
    {
        

        // Apply forward/reverse acceleration to each wheel (left: W & S; right: E & D)       
        if(Input.GetKey(KeyCode.W))
        {
            leftWheel.motorTorque = linearAcceleration;
            rightWheel.motorTorque = -linearAcceleration * strength;
        } else if (Input.GetKey(KeyCode.S))
        {
            leftWheel.motorTorque = -linearAcceleration;
        } else 
        {
             leftWheel.motorTorque = 0;
              rightWheel.motorTorque = 0;
        }

        // if(Input.GetKey(KeyCode.E))
        // {
        //     rightWheel.motorTorque = linearAcceleration;
        // } else if (Input.GetKey(KeyCode.D))
        // {
        //     rightWheel.motorTorque = -linearAcceleration;
        // } else 
        // {
        //      rightWheel.motorTorque = 0;
        // }


        // Apply steering

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            currentTurnAngle = maxTurnAngle * 1;
            rightWheel.motorTorque = -rotationalAcceleration;
            leftWheel.motorTorque = rotationalAcceleration;
        } else if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.S))
        {
            currentTurnAngle = maxTurnAngle * -1;
            rightWheel.motorTorque = rotationalAcceleration;
            leftWheel.motorTorque = -rotationalAcceleration;
        }
         else {
            currentTurnAngle = 0f;
        }

        leftWheel.steerAngle = currentTurnAngle;
        rightWheel.steerAngle = currentTurnAngle;

        // rightWheel.motorTorque = currentAcceleration;
        // leftWheel.motorTorque = currentAcceleration;

        // If pressing space, give currentBreakForce a value
        if (Input.GetKey(KeyCode.Space))
        {
            currentBreakForce = breakForce;
        } else {
            currentBreakForce = 0f;
        }

        rightWheel.brakeTorque = currentBreakForce;
        leftWheel.brakeTorque = currentBreakForce;   
    }

}
