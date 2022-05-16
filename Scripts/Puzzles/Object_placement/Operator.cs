using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//uses the TextMeshPro library
using TMPro;

public class Operator : MonoBehaviour
{
    //int to store operation value(+,-,*,/)
    public int ASMD;
    //gets the objects of the object, and the text object on the object
    public GameObject detect;
    public GameObject deText;
    //the value output by the operator object
    public float operValue;

    //bool to store if there is an object colliding or not
    public bool collVal;
    //distance an object must be to collide
    public float valDistance;
    //layer an object must be to collide
    public LayerMask valMask;

    //gameobject of the valid colliding object
    public GameObject valueGiver;
    //var to store the script of the colliding object
    public ObjectVal valueScript;
    //to store the actual text mesh of the text object
    private TextMeshPro opText;
    //to store the local position(relative to the operator) of the text
    private RectTransform deTrans;

    //function called constantly while a collision is occuring
    void OnCollisionStay(Collision collision)
    {
        //check a sphere around the operator for a value-storing object
        collVal = Physics.CheckSphere(detect.transform.position, valDistance, valMask);
        if (collVal)
        {
            //get the gameobject that is colliding
            valueGiver = collision.gameObject;
            //get the script of the colliding gameobject
            valueScript = valueGiver.GetComponent<ObjectVal>();
            //set the output float to the one stored in the colliding gameobject
            operValue = valueScript.operValue;

        }
        else
        {
            //output is zero if nothing with a value is colliding
            operValue = 0;
        }
        
    }
    //simple function to set value to zero, to fix the quick-pass bug
    void collCheck()
    {
        collVal = Physics.CheckSphere(detect.transform.position, valDistance, valMask);
        if (!collVal)
        {
            operValue = 0;
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //run the quick-pass fix
        collCheck();

        //get the text mesh of the text object
        TextMeshPro opText = deText.GetComponent<TextMeshPro>();
        //get the local position(relative to the operator) of the text object
        deTrans = deText.GetComponent<RectTransform>();

        //for each possible operator, set desired display text and optimal position to center the text.
        if (ASMD == 1)
        {
            deTrans.localPosition = new Vector3(1.15f, 0.04f, 1.3f);
            opText.SetText("+");
        }
        if (ASMD == 2)
        {
            deTrans.localPosition = new Vector3(1.5f, 0.04f, 1.5f);
            opText.SetText("-");
        }
        if (ASMD == 3)
        {
            deTrans.localPosition = new Vector3(1.15f, 0.04f, 1.3f);
            opText.SetText("X");
        }
        if (ASMD == 4)
        {
            deTrans.localPosition = new Vector3(1.5f, 0.04f, 1.4f);
            opText.SetText ("/");
        }

        Debug.Log(operValue);
    }
}
