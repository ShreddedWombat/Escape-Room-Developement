using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{

    int correct = 0;
    public GameObject Activator;
    private Door3x3 is_correct;
    
    // Start is called before the first frame update
    void Start()
    {
        is_correct = Activator.GetComponent<Door3x3>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Activator.active == 1){  
            correct = 1;
        }
        if(Activator.active == 0){
            correct = 0;
        }
    }
}
