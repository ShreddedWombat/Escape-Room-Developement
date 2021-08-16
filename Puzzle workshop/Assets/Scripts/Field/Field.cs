using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    int i = 0;

    public GameObject Activator;
    public Transform F_Field;
    public Active scriptToUse;




    
    
    // Start is called before the first frame update
    void Start()
    {
         scriptToUse = Activator.GetComponent<active>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(scriptToUse.active == 1){
            if (i <= 50) {
                F_Field.transform.Translate(Vector3.up / 10);
                i++;
            }
                active = 1;
        }
        if(scriptToUse.active == 0){
            if (i >= 0) {
                F_Field.transform.Translate(Vector3.down / 10);
                i--;
            }
                active = 0;
        }
    }
}
