using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hueLock_1 : MonoBehaviour
{
    //sets the max distance the player can be to interact with the buttons
    int distance = 5;

    //declares the different colour variables
    public Color32 opt1;
    public Color32 opt2;
    public Color32 opt3;
    public Color32 opt4;
    public Color32 goal;
    //public boolean to be accessed by the door
    public bool Corrected = false;
    //get the button object to be used
    public GameObject hueBut;
    //int to keep track of current colour
    int hueSwitch = 2;



    //function to be called when the player clicks on a button
    private void OnMouseDown()
     {
        //finds and gets the position of the player
        var playerPos = GameObject.Find("playerBody").transform.position;

        //only works if the player is close enough
        if (Vector3.Distance(playerPos, transform.position) <= distance){

            //gets the rendering component of the attached button
            var hueRend = hueBut.GetComponent<Renderer>();

            //the following lines get the current colour var, set the button's colour to that colour, then add 1 to the current colour var.
            if (hueSwitch == 1){
                hueRend.material.SetColor("_BaseColor", opt1);
                hueSwitch = 2;
            }
            else if(hueSwitch == 2){
                hueRend.material.SetColor("_BaseColor", opt2);
                hueSwitch = 3;
            }
            else if(hueSwitch == 3){
                hueRend.material.SetColor("_BaseColor", opt3);
                hueSwitch = 4;
            }
            else{
                hueRend.material.SetColor("_BaseColor", opt4);
                hueSwitch = 1;
        }
        }
        
     }
    
    // Start is called before the first frame update
    void Start()
    {
        //sets the starting colour
        var hueRend = hueBut.GetComponent<Renderer>();
        hueRend.material.SetColor("_BaseColor", opt4);
        
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the colour is the correct one, and if so updates the bool to true for the door.
        var hueRend = hueBut.GetComponent<Renderer>();
        var hueHue = hueRend.material.GetColor("_BaseColor");
        if(hueHue == goal){
            Corrected = true;
        }
        else{
            Corrected = false;
        }
        
    }
}
