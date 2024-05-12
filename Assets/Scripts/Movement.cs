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
    public float spinningStrength = 0.6f;

    private float currentTurnAngle = 0;

    void FixedUpdate()
    {
        

        // Apply forward/reverse acceleration to each wheel 
        // 👈 left wheel: W 👆 & S 👇
        // 👉 right wheel: E 👆 & D 👇

        // Spinning with the pivot point at the CENTER
        // rotate clockwise
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            leftWheel.motorTorque = linearAcceleration; 
            rightWheel.motorTorque = -linearAcceleration;
        } 
        // rotate counter clockwise
        else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.E))
        {
            leftWheel.motorTorque = -linearAcceleration; 
            rightWheel.motorTorque = linearAcceleration;
        } 
        // Linear movement
        // forward
        else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.E)) {
             leftWheel.motorTorque = linearAcceleration;
             rightWheel.motorTorque = linearAcceleration;
        }
        // backward
        else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            leftWheel.motorTorque = -linearAcceleration;
            rightWheel.motorTorque = -linearAcceleration;
        } 
        // Spinning with the wheel as the pivot point
        // rotate clockwise with right wheel as pivot
        else if(Input.GetKey(KeyCode.W))
        {
            leftWheel.motorTorque = linearAcceleration;
            rightWheel.motorTorque = -linearAcceleration * spinningStrength;
            
        } 
         // rotate counter clockwise with right wheel as pivot
        else if (Input.GetKey(KeyCode.S))
        {
            leftWheel.motorTorque = -linearAcceleration;
            rightWheel.motorTorque = linearAcceleration * spinningStrength;
        } 
         // rotate counter clockwise with left wheel as pivot
        else if(Input.GetKey(KeyCode.E))
        {
             rightWheel.motorTorque = linearAcceleration;
             leftWheel.motorTorque = -linearAcceleration * spinningStrength;
        } 
        // rotate clockwise with left wheel as pivot
        else if(Input.GetKey(KeyCode.D))
        {
            rightWheel.motorTorque = -linearAcceleration;
            leftWheel.motorTorque = linearAcceleration * spinningStrength;
        } 

        // Decelerate
        if(!Input.GetKey(KeyCode.E) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) 
        {
             rightWheel.motorTorque = 0;
             leftWheel.motorTorque = 0;
        }

        // Break 
        if (Input.GetKey(KeyCode.Space))
        {
            rightWheel.brakeTorque = breakForce;
            leftWheel.brakeTorque = breakForce;
        }  


        // Apply steering

        // if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        // {
        //     currentTurnAngle = maxTurnAngle * 1;
        //     rightWheel.motorTorque = -rotationalAcceleration;
        //     leftWheel.motorTorque = rotationalAcceleration;
        // } else if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.S))
        // {
        //     currentTurnAngle = maxTurnAngle * -1;
        //     rightWheel.motorTorque = rotationalAcceleration;
        //     leftWheel.motorTorque = -rotationalAcceleration;
        // }
        //  else {
        //     currentTurnAngle = 0f;
        // }

        // leftWheel.steerAngle = currentTurnAngle;
        // rightWheel.steerAngle = currentTurnAngle;

        // rightWheel.motorTorque = currentAcceleration;
        // leftWheel.motorTorque = currentAcceleration;
         
    }

}
