using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement2 : MonoBehaviour
{

    public CharacterController controller;
    public Transform playerBody;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float minSpd = 0f;
    public float maxTme = 0.2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    

    

    Vector3 velocity;
    bool isGrounded;
    public bool isFielded = false;
    public bool groundField = false;

    float fieldTime = 0;
    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2.6f;

        }
        

        
        //isFielded = Physics.CheckSphere(groundCheck.position, groundDistance, fieldMask);
          

        

        

        if(groundField && isGrounded)
        {
            velocity.x = 0;
            velocity.y = 0;
            velocity.z = 0;
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

        /*if((x == 0) && (velocity.x != 0))
        {
            if(velocity.x < 0 )
            {
                if(velocity.x > -1.01)
                {
                    velocity.x = 0;
                }
                else
                {
                    velocity.x += 1;
                }    
            }
            else
            {
                if(velocity.x < 1.01)
                {
                    velocity.x = 0;
                }
                else
                {
                    velocity.x -= 1;
                }
            }
        }

        if((z == 0) && (velocity.z != 0))
        {
            if(velocity.z < 0 )
            {
                if(velocity.z > -1.01)
                {
                    velocity.z = 0;
                }
                else
                {
                    velocity.z += 1;
                }    
            }
            else
            {
                if(velocity.z < 1.01)
                {
                    velocity.z = 0;
                }
                else
                {
                    velocity.z -= 1;
                }
            }
        }*/

        Vector3 move = transform.right * x + transform.forward * z;
        if(!isFielded)
        {
        controller.Move(move * speed * Time.deltaTime);
        }
        velocity.y += gravity * Time.deltaTime * 2;

        controller.Move(velocity * Time.deltaTime);
    }
}