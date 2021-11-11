using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCalc : MonoBehaviour
{
    int i = 0; 
    

    public Transform Door;

    public float goal;
    private TextMeshPro doorText;
    public GameObject doText;

    public GameObject Obj_1;
    private Operator oper_1;
    public GameObject Obj_2;
    private Operator oper_2;
    //public GameObject Obj_3;
    //private Operator oper_3;

    float val_1;
    float val_2;
    //float val_3;

    float totVal = 0;


    void getVal()
    {
        totVal = 0;

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
        
       oper_1 = Obj_1.GetComponent<Operator>(); 
       oper_2 = Obj_2.GetComponent<Operator>(); 
       //oper_3 = Obj_3.GetComponent<Operator>(); 

        
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshPro doorText = doText.GetComponent<TextMeshPro>();
        doorText.SetText(goal.ToString());

        val_1 = oper_1.operValue;
        val_2 = oper_2.operValue;

        getVal();

        if(totVal == goal){
            if (i <= 50) {
                Door.transform.Translate(Vector3.up / 10);
                i++;
            }
        }
        if(totVal != goal){
            if (i >= 0) {
                Door.transform.Translate(Vector3.down / 10);
                i--;
            }
        }

        Debug.Log(totVal);
    }
}