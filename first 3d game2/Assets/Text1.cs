using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Text1 : MonoBehaviour 
{
     
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;

    public string texta;
    public string textb;
    public string textc;

    TextMeshProUGUI text4;
    TextMeshProUGUI text5;
    TextMeshProUGUI text6;

    public float num1;
    private float num2;


    [SerializeField] activatepause script;
    [SerializeField] Gun script1;
    void Start() 
     {
        text4 = text1.GetComponent<TextMeshProUGUI>();
        text5 = text2.GetComponent<TextMeshProUGUI>();
        text6 = text3.GetComponent<TextMeshProUGUI>();
        text1.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
    }
     void Update()
     {
        if (script.pause1 == false)
        {
            text1.SetActive(true);
            text2.SetActive(true);
            text3.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0) && script.pause1 == false && script1.fire == true)
        {
            num1 = num1 + 1;
        }
        texta = num1.ToString();
        text4.text = ("Shots fired " + texta);
        

        if (num1 == 10)
        {
            num1 = 0;
            num2 = num2 + 1;
        }
        textb = num2.ToString();
        text5.text = ("Magazines spent " + textb);

        
        text6.text = ("Wait " + script1.timer);
    }
}