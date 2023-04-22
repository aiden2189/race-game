using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatepause : MonoBehaviour
{
    public bool pause1;

    void Start()
    {
        pause1 = true;
    }
    public void Onclick()
    {
        pause1 = false;

    }
    void Update()
    {
        
    }
}
