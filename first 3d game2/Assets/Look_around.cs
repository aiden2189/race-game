using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_around : MonoBehaviour
{
  	Vector2 rotation = Vector2.zero;
	public float speed = 3;
    [SerializeField] activatepause script;
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(script.pause1 == false)
        {
            Cursor.lockState = CursorLockMode.Locked;

        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y"); 
		transform.eulerAngles = (Vector2)rotation * speed;            
        }
    }
}