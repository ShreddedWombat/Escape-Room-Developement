using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hueDoor : MonoBehaviour
{
    //int for door movement
    int i = 0;

    //declares the door position to be referenced through the script
    public Transform Door;

    //finds and gets all the buttons in the line.
    public GameObject hueBut;
    private hueLock_1 hueLock;
    public GameObject hueBut1;
    private hueLock_2 hueLock1;
    public GameObject hueBut2;
    private hueLock_3 hueLock2;
    
    // Start is called before the first frame update
    void Start()
    {
        //gets and accesses all of the script components of the buttons.
        hueLock = hueBut.GetComponent<hueLock_1>(); 
        hueLock1 = hueBut1.GetComponent<hueLock_2>(); 
        hueLock2 = hueBut2.GetComponent<hueLock_3>(); 

        
    }

    // Update is called once per frame
    void Update()
    {

        //checks if ALL buttons are correct
        if (hueLock.Corrected == true && hueLock1.Corrected == true && hueLock2.Corrected == true) {
            //moves the door up (relatively) slowly and smoothly, stopping at a specific point.
            if (i <= 50) {
                Door.transform.Translate(Vector3.up / 10);
                i++;
            }
        }
        //checks if ONLY ONE button is incorrect
        if (hueLock.Corrected == false || hueLock1.Corrected == false || hueLock2.Corrected == false) {
            //moves the door down (relatively) slowly and smoothly, stopping at a specific point.
            if (i >= 0) {
                Door.transform.Translate(Vector3.down / 10);
                i--;
            }
            
          }  
        
    }
}
