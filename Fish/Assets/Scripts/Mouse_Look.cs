using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Look : MonoBehaviour
{
    //These Define the variables and references used within the script.

    //The GameObject the holds the PopUp script
    public GameObject Pop;

    //Value of Mouse Sensitivity
    public float mouseSensitivity = 50f;

    //Position of the Player
    public Transform playerBody;

    //boolean to prevent multiple items held
    public bool holding = false;

    //variable for rotation management
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
     


    }

    // Update is called once per frame
    void Update()
    {
        //only allows if there are no popups
        if (Pop.activeSelf == false)
        {
            //hides the cursor
            Cursor.lockState = CursorLockMode.Locked;

            //grabs the values of the mouse axis
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            //calculations for the player rotation
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);

        }
        else
        {
            //reveals cursor for popups
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
