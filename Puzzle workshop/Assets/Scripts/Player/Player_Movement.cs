using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public CharacterController controller;
    public Transform playerBody;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask fieldMask;
    public float fieldDistance = 0.7f;
    public Transform fieldCheck;

    Vector3 startPt;
    Vector3 endPt;

    Vector3 velocity;
    bool isGrounded;
    bool isFielded;
    bool fieldKeep = true;

    float fieldTime = 0;
    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }

        startPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y + (fieldDistance +1.5f), fieldCheck.position.z);
        endPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y - (fieldDistance +1.5f), playerBody.position.z);

        if(fieldKeep)
        {
            isFielded = Physics.CheckCapsule(startPt, endPt, fieldDistance + 0.05f, fieldMask);
        }
        else{
            isFielded = false;

            if(fieldTime > 4){
                fieldKeep = true;
            }
        }
        //isFielded = Physics.CheckSphere(groundCheck.position, groundDistance, fieldMask);
          if(isFielded && fieldKeep)
          {
              velocity.y = velocity.y * -2;
              velocity.x = velocity.x * -2;
              fieldKeep = false;
          }

         

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if(!isFielded)
        {
        controller.Move(move * speed * Time.deltaTime);
        }
        velocity.y += gravity * Time.deltaTime * 2;

        controller.Move(velocity * Time.deltaTime);
    }
}