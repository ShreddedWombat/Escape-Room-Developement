using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement2 : MonoBehaviour
{

    public CharacterController controller;
    public Transform playerBody;
    public Transform fieldCheck;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float minSpd = 0f;
    public float maxTme = 0.9f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    public bool fieldKeep;

    public Vector3 velocity;
    public Vector3 move;

    public bool isGrounded;
    public bool isFielded = false;
    public bool groundField = false;

    public Vector3 playPoint;

    void isGround(){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2.6f;

        }
    }
    
    // Update is called once per frame
    void Update()
    {

        isGround();
        

        
        //isFielded = Physics.CheckSphere(groundCheck.position, groundDistance, fieldMask);
          

        if(isFielded && fieldKeep)
          {
              Vector3 fieldNormal = (fieldCheck.position - playPoint);
              velocity = Vector3.Reflect(velocity , fieldNormal) / 4;
              if(velocity.y > 20)
              {
                    velocity.y = 20;
              }
              if(velocity.x > 10)
              {
                    velocity.x = 10;
              }
              if(velocity.z > 10)
              {
                    velocity.z = 10;
              }

              fieldKeep = false;
              groundField = true;
          }

        
        if(groundField && isGrounded)
        {
            velocity.x = 0;
            velocity.y = 0;
            velocity.z = 0;
            groundField = false;
            groundField = false;
        }

        if(velocity.x != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, minSpd, maxTme * Time.deltaTime);
        }
        if(velocity.y != 0)
        {
            velocity.y = Mathf.MoveTowards(velocity.y, minSpd, maxTme * Time.deltaTime);
        }
        if(velocity.z != 0)
        {
            velocity.z = Mathf.MoveTowards(velocity.z, minSpd, maxTme * Time.deltaTime);
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