using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class away : MonoBehaviour
{
    [SerializeField] activatepause script;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (script.pause1 == false)
        {
            Destroy(gameObject);
        }
    }
}
