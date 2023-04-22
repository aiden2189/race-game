using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody bullet;
	private float speed = 50;
    public GameObject rarm;
    public GameObject cam;
    public GameObject gun;
    public float timer;
    public float time_between_reloads;
    public bool fire;
    private float count;
    [SerializeField] activatepause script;
    // Start is called before the first frame update
    void Start()
    {
        fire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (script.pause1 == false)
        {
            transform.position = rarm.transform.position;
            transform.rotation = cam.transform.rotation;

            if(Input.GetMouseButtonDown(0) && fire == true)
            {
                count = count + 1;
                Rigidbody clone; 

                clone = Instantiate(bullet, gun.transform.position, cam.transform.rotation); 
                clone.velocity = transform.TransformDirection(Vector3.forward * speed);
            }  
            if (count == 10)
            {
                fire = false;
            }
            if (fire == false)
            {
                timer = timer + 1 * Time.deltaTime;
            }
            if  (timer > time_between_reloads)
            {
                fire = true;
                timer = 0;
                count = 0;
            }
        }
    }
}