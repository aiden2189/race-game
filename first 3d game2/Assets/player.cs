using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public GameObject play;
    public Rigidbody player1;
    public GameObject enem;
    public float x;
    [SerializeField] activatepause script;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        
        if (script.pause1 == false)
        {
            player1.angularVelocity = new Vector3(0, 0, 0);
            //speed boost
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = 100f;
                x = 100f;
            }

            //actual movement code
            if (Input.GetKey(KeyCode.W))
            {
                player1.AddRelativeForce(Vector3.forward * speed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                player1.AddRelativeForce(Vector3.back * speed);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                player1.AddRelativeForce(Vector3.left * speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                player1.AddRelativeForce(Vector3.right * speed);
            }
            
        }
    }
    void OnTriggerEnter(Collider other) 
    {  
        if(other.tag == "enemy")
        {
            Destroy(play.gameObject);  
        }
    }
}
