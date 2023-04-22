using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private float timer;
    private float jump;
    private float timejump;
    public float onfloor;
    public float y;      
    public Rigidbody player2;
    [SerializeField] activatepause script;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (script.pause1 == false)
        {
            player2.velocity = new Vector3(0, y, 0);

            //jump code
            if (Input.GetKeyDown(KeyCode.Space) && timejump < 2)
            {
                jump = 1;
                timejump = timejump + 1;
                onfloor = 0;

            }
            if (jump == 1 && timer < 0.5f)
            {
                y = 8;
                timer = timer + 1 * Time.deltaTime;
            }
            else
            {
                y = -8;
                timer = 0;
                jump = 0;
            }
            if (onfloor == 1 || transform.position.y < 0)
            {
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
                y = 0;
                timejump = 0;
            }
            if (onfloor == 3)
            {
                y = -3;
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //collison with ground
        if (other.tag == "Ground")
        {
            onfloor = 1; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground" && jump == 1)
        {
            onfloor = 0;
        }
        if (other.tag == "Ground" && jump == 0)
        {
            onfloor = 3;
        }
    }
}
