using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalboss1 : MonoBehaviour
{
    public Rigidbody boss;

    public float speed;
    void Update()
    {
        Rigidbody clone;

        clone = Instantiate(boss, boss.transform.position, Quaternion.identity);
        clone.velocity = transform.TransformDirection(Vector3.forward* speed);
    }

}   