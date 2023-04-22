using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject cam;
    public float speed;
    Vector2 rotation = Vector2.zero;
    [SerializeField] activatepause script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(script.pause1 == false)
        {
        rotation.y += Input.GetAxis("Mouse X");
        //rotation.x += -Input.GetAxis("Mouse Y"); 
		transform.eulerAngles = (Vector2)rotation * speed;            
        }

    }
}
