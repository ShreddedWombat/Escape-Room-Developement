using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCalc : MonoBehaviour
{
    //int for door movement
    int i = 0;

    //declares the door position to be referenced through the script
    public Transform Door;

    //value that the door requires to open
    public float goal;
    //text display of the door
    private TextMeshPro doorText;
    //text object of the door
    public GameObject doText;

    //finds and gets all the operator detectors
    public GameObject Obj_1;
    private Operator oper_1;
    public GameObject Obj_2;
    private Operator oper_2;

    //public GameObject Obj_3;
    //private Operator oper_3;

    //to store the values of all the operators
    float val_1;
    float val_2;
    //float val_3;

    //stores the total value of all the operators
    float totVal = 0;

    //function to calculate total value
    void getVal()
    {       
        //resets total value before calculations
        totVal = 0;

        //super messy if statements to calculate based on operators(+,-,*,/) only if the operator has a value other than 0.
        if (oper_1.collVal == true)
        {
            if (oper_1.ASMD == 1)
            {
                totVal += val_1;
            }
            if (oper_1.ASMD == 2)
            {
                totVal -= val_1;
            }
            if (oper_1.ASMD == 3)
            {
                totVal *= val_1;
            }
            if (oper_1.ASMD == 4)
            {
                totVal /= val_1;
            }
        }
        //same as above, but for second operator object
        if (oper_2.collVal == true)
        {
            if (oper_2.ASMD == 1)
            {
                totVal += val_2;
            }
            if (oper_2.ASMD == 2)
            {
                totVal -= val_2;
            }
            if (oper_2.ASMD == 3)
            {
                totVal *= val_2;
            }
            if (oper_2.ASMD == 4)
            {
                totVal /= val_2;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
       //gets the scripts of the operators
       oper_1 = Obj_1.GetComponent<Operator>(); 
       oper_2 = Obj_2.GetComponent<Operator>(); 
       //oper_3 = Obj_3.GetComponent<Operator>(); 

        
    }

    // Update is called once per frame
    void Update()
    {
        //sets the text on the door to the goal value
        TextMeshPro doorText = doText.GetComponent<TextMeshPro>();
        doorText.SetText(goal.ToString());

        //gets the correct values from the operators
        val_1 = oper_1.operValue;
        val_2 = oper_2.operValue;

        //call the calc function
        getVal();

        //if calc is correct, open door
        if(totVal == goal){
            if (i <= 50) {
                Door.transform.Translate(Vector3.up / 10);
                i++;
            }
        }
        //if not, close door
        if(totVal != goal){
            if (i >= 0) {
                Door.transform.Translate(Vector3.down / 10);
                i--;
            }
        }

        Debug.Log(totVal);
    }
}