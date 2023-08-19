using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public Transform mass;
    public Rigidbody car;

    public TMP_Text speedomeder;

    public float enginePower = 0;
    public float BrakeForce = 100;
    public float maxSteer = 25;
    public float maxSpeed;

    public float Stall = 1;
    public GameObject StallText;

    public float power = 0;
    public float brake = 0;
    public float steer = 0;

    void Start()
    {
        car.centerOfMass = mass.localPosition;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //movement code
        power = Input.GetAxis("Vertical") * enginePower * Stall;
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
        
        GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, maxSpeed);

    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            enginePower = 100;
            maxSpeed = 3;
            IsStall();
        }

        if (Input.GetKeyDown("2"))
        {
            enginePower = 500;
            maxSpeed = 10;
            IsStall();
        }
        
        if (Input.GetKeyDown("3"))
        {
            enginePower = 1500;
            maxSpeed = 50;
            IsStall();
        }

        if (Input.GetKeyDown("4"))
        {
            enginePower = 5000;
            maxSpeed = 100;
            IsStall();
        }

        if (Input.GetKeyDown("5"))
        {
            enginePower = 1000000;
            maxSpeed = 500;
            IsStall();
        }

        if (Input.GetKeyDown("r"))
        {
            enginePower = -100;
            IsStall();
        }

        if (Input.GetKeyDown("s"))
        {
            enginePower = 0;
            UnStall();
        }

    }

    IEnumerator SomeCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(1f);         
        for (int i = 0; i < 10; i++)
        {
            StallText.SetActive(false);
            yield return wait;
            StallText.SetActive(true); 
            yield return wait; 
        }
    }

    public void IsStall()
    {
        if(power > 0)
        {
            Stall = 0;
            StartCoroutine(SomeCoroutine());  
        }    
    }
    
    public void UnStall()
    {
        Stall = 1;
        StallText.SetActive(false);
        StopAllCoroutines();
    }
}


