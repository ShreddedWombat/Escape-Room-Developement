using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PassInput : MonoBehaviour
{
    public Transform Door;

    public Transform playerPos;
    public GameObject Pop;
    public int distance = 3;
    public TMP_InputField Input;
    public string Goal = "PassWord";
    public string goalCheck;
    public TextMeshPro numDisplay;
    int i = 0;

    public Button Submit;


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
        Button Subbtn = Submit.GetComponent<Button>();
        Subbtn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (goalCheck.ToLower() == Goal.ToLower())
        {
            if (i <= 50)
            {
                Door.transform.Translate(Vector3.up / 10);
                i++;
            }
        }
        
        if(goalCheck.ToLower() != Goal.ToLower())
        {
            if (i >= 0)
            {
                Door.transform.Translate(Vector3.down / 10);
                i--;
            }

        }
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        goalCheck = Input.text;
        Pop.SetActive(false);
        numDisplay.text = goalCheck;
    }
}
