using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _3x3Pattern : MonoBehaviour
{

    //sets the max distance the player can be to interact with the buttons
    int distance = 5;

    //declares the different colour variables
    public Color32 opt1;
    public Color32 opt2;
    public Color32 opt3;
    public Color32 opt4;
    public Color32 opt5;
    public Color32 opt6;
    public Color32 opt7;
    public Color32 opt8;
    public Color32 goal;

    //public boolean to be accessed by the door
    public bool Corrected = false;
    //get the button object to be used
    public GameObject But_3x3;

    //int to keep track of current colour
    int _3xSwitch = 2;

    //define the dictionary that contains the colour options
    private Dictionary<string, Color32> optDict = new Dictionary<string, Color32>();
    
    //function to be called when the player clicks on a button
    private void OnMouseDown()
     {
        //finds and gets the position of the player
        var playerPos = GameObject.Find("playerBody").transform.position;

        //only works if the player is close enough
        if(Vector3.Distance(playerPos, transform.position) <= distance){

            //gets the rendering component of the attached button
            var _3xRend = But_3x3.GetComponent<Renderer>();

            //the following lines get the desired colour from the dictionary and set the button's colour to that colour.
            string curOpt = ("opt"+_3xSwitch);
            optDict.TryGetValue(curOpt, out Color32 currOption);
            _3xRend.material.SetColor("_BaseColor", currOption);
            _3xSwitch += 1;
            }
        //intentional integer overflow
        if(_3xSwitch == 9){
            _3xSwitch = 1;
        }
     }



    // Start is called before the first frame update
    void Start()
    {
        //adds all the colour options to the dictionary, with string 'keys'
        optDict.Add("opt1", opt1);
        optDict.Add("opt2", opt2);
        optDict.Add("opt3", opt3);
        optDict.Add("opt4", opt4);
        optDict.Add("opt5", opt5);
        optDict.Add("opt6", opt6);
        optDict.Add("opt7", opt7);
        optDict.Add("opt8", opt8);

        //starts the button on the correct colour
        var _3xRend = But_3x3.GetComponent<Renderer>();
        _3xRend.material.SetColor("_BaseColor", opt1);
    }

    // Update is called once per frame
    void Update()
    {       
        //checks if the colour is the correct.
        var _3xRend = But_3x3.GetComponent<Renderer>();
        var _3xHue = _3xRend.material.GetColor("_BaseColor");
        if(_3xHue == goal){
            Corrected = true;
        }
        else{
            Corrected = false;
        }
    }
}
