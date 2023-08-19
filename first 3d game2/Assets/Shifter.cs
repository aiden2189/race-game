using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shifter : MonoBehaviour
{
    public int count;
    public RectTransform Button;

    public void Shift()
    {
        count = count + 1;
    }

    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            Button.localPosition = new Vector2(-60, 40);
        }

        if (Input.GetKeyDown("2"))
        {
            Button.localPosition = new Vector2(-60, -40);
        }

        if (Input.GetKeyDown("3"))
        {
            Button.localPosition = new Vector2(0, 40);
        }

        if (Input.GetKeyDown("4"))
        {
            Button.localPosition = new Vector2(0, -40);
        }

        if (Input.GetKeyDown("5"))
        {
            Button.localPosition = new Vector2(60, 40);
        }

        if (Input.GetKeyDown("r"))
        {
            Button.localPosition = new Vector2(60, -40);
        }

        if (Input.GetKeyDown("s"))
        {
            Button.localPosition = new Vector2(0, 0);
        }
    }
}
