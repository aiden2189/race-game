using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class focus : MonoBehaviour
{

    public GameObject cam;
    public GameObject player;
    private float x;
    private float y;
    private float z;
    [SerializeField] activatepause script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;
        cam.transform.position = new Vector3(x, y+0.5f, z);
        if (script.pause1 == false)
        {
            foreach (Transform child in GetComponentsInChildren<Transform>(true))
            {
                child.gameObject.layer = LayerMask.NameToLayer("playerMask");
            }
        }

    }
}