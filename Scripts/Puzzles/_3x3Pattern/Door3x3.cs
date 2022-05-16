using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3x3 : MonoBehaviour
{
    //int for door movement
    int i = 0; 

    //declares the door position to be referenced through the script
    public Transform Door;

    //finds and gets all the buttons in the grid.
    public GameObject _3x3But;
    private _3x3Pattern pattern;
    public GameObject _3x3But1;
    private _3x3Pattern pattern1;
    public GameObject _3x3But2;
    private _3x3Pattern pattern2;
    public GameObject _3x3But3;
    private _3x3Pattern pattern3;
    public GameObject _3x3But4;
    private _3x3Pattern pattern4;
    public GameObject _3x3But5;
    private _3x3Pattern pattern5;
    public GameObject _3x3But6;
    private _3x3Pattern pattern6;
    public GameObject _3x3But7;
    private _3x3Pattern pattern7;
    public GameObject _3x3But8;
    private _3x3Pattern pattern8;
    // Start is called before the first frame update
    void Start()
    {
        //gets and accesses all of the script components of the buttons.
        pattern = _3x3But.GetComponent<_3x3Pattern>(); 
        pattern1 = _3x3But1.GetComponent<_3x3Pattern>(); 
        pattern2 = _3x3But2.GetComponent<_3x3Pattern>(); 
        pattern3 = _3x3But3.GetComponent<_3x3Pattern>(); 
        pattern4 = _3x3But4.GetComponent<_3x3Pattern>(); 
        pattern5 = _3x3But5.GetComponent<_3x3Pattern>(); 
        pattern6 = _3x3But6.GetComponent<_3x3Pattern>(); 
        pattern7 = _3x3But7.GetComponent<_3x3Pattern>(); 
        pattern8 = _3x3But8.GetComponent<_3x3Pattern>(); 

        
    }

    // Update is called once per frame
    void Update()
    {
        
        //checks if ALL buttons are correct
        if(pattern.Corrected == true && pattern1.Corrected == true && pattern2.Corrected == true && pattern3.Corrected == true && pattern4.Corrected == true && pattern5.Corrected == true && pattern6.Corrected == true && pattern7.Corrected == true && pattern8.Corrected == true) {
            //moves the door up (relatively) slowly and smoothly, stopping at a specific point.
            if (i <= 50) {
                Door.transform.Translate(Vector3.up / 10);
                i++;
            }
            }
        //checks if ONLY ONE button is incorrect
        if (pattern.Corrected == false || pattern1.Corrected == false || pattern2.Corrected == false || pattern3.Corrected == false || pattern4.Corrected == false || pattern5.Corrected == false || pattern6.Corrected == false || pattern7.Corrected == false || pattern8.Corrected == false) {
            //moves the door down (relatively) slowly and smoothly, stopping at a specific point.
            if (i >= 0) {
                Door.transform.Translate(Vector3.down / 10);
                i--;
            }
            
          }  
        
    }
}
