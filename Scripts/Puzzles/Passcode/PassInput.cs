using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using both the UI library, and the TextMeshPro library
using UnityEngine.UI;
using TMPro;

public class PassInput : MonoBehaviour
{
    //declares the door position to be referenced through the script
    public Transform Door;
    //pos of the player
    public Transform playerPos;
    //popup UI object
    public GameObject Pop;
    //distance the player must be to interact with the input
    public int distance = 3;
    //declare the textmesh input
    public TMP_InputField Input;
    //the goal (password) required
    public string Goal = "PassWord";
    //the string that stores the player input
    public string goalCheck;
    //the textmesh of the number display
    public TextMeshPro numDisplay;

    //int for door movement
    int i = 0;
    //the button to submit what the player enters
    public Button Submit;

    //function that, when the player is close enough and they interact with the input object, will activate the pop-up window
    void OnMouseDown()
    {
        if (Vector3.Distance(playerPos.position, transform.position) <= distance)
        {
            Pop.SetActive(true);
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //get the button event information, and check to see if it gets pressed
        Button Subbtn = Submit.GetComponent<Button>();
        Subbtn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        //if password correct, open door
        if (goalCheck.ToLower() == Goal.ToLower())
        {
            if (i <= 50)
            {
                Door.transform.Translate(Vector3.up / 10);
                i++;
            }
        }
        //if not correct, close door
        if(goalCheck.ToLower() != Goal.ToLower())
        {
            if (i >= 0)
            {
                Door.transform.Translate(Vector3.down / 10);
                i--;
            }

        }
    }

    //function to be run when the pop-up button is pressed.
    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        //sets the goal-checking string to the player's input
        goalCheck = Input.text;
        //deactivates the pop-up
        Pop.SetActive(false);
        //sets the displayed text to the player's input
        numDisplay.text = goalCheck;
    }
}
