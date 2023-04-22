using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour
{
    public float timetilldeath;
    
    void Start()
    {
        Destroy(gameObject, timetilldeath);
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}