using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalboss : MonoBehaviour
{
    public Rigidbody boss;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Rigidbody clone;
            clone = Instantiate(boss, new Vector3(44,1,-44), Quaternion.identity); 
            clone = Instantiate(boss, new Vector3(44, 1, -44), Quaternion.identity);
        }
    }
}