using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{           
    [SerializeField] WheelCollider FLW;
    [SerializeField] WheelCollider FRW;
    [SerializeField] WheelCollider RLW;
    [SerializeField] WheelCollider RRW;

    [SerializeField] Transform FLT;
    [SerializeField] Transform FRT;
    [SerializeField] Transform RLT;
    [SerializeField] Transform RRT;

    public float enginePower = 150;
    public float BrakeForce = 100;
    public float maxSteer = 25; 

    public float power = 0;
    public float brake = 0;
    public float steer = 0;

    void Start()
    {

    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //movement code
        power = Input.GetAxis("Vertical") * enginePower;
        steer = Input.GetAxis("Horizontal") * maxSteer;
        brake = Input.GetKey("space") ? GetComponent<Rigidbody>().mass * 0.5f : 0;

        FLW.steerAngle = steer;
        FRW.steerAngle = steer;

        if (brake > 0)
        {
            //Brakes on 
            FLW.brakeTorque = brake;
            FRW.brakeTorque = brake;
            RLW.brakeTorque = brake;
            RRW.brakeTorque = brake;
            //Engine idol
            RLW.motorTorque = 0;
            RRW.motorTorque = 0;
        }
        else
        {
            //Brakes idol
            FLW.brakeTorque = 0;
            FRW.brakeTorque = 0;
            RLW.brakeTorque = 0;
            RRW.brakeTorque = 0;
            //Engine on
            RLW.motorTorque = power;
            RRW.motorTorque = power;
        }
        UpdateWheel(FLW, FLT);
        UpdateWheel(FRW, FRT);
        UpdateWheel(RLW, RLT);
        UpdateWheel(RRW, RRT);
    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }
}


