using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement3 : MonoBehaviour
{
    //declares the Player Position and the Character Controller, which takes movement inputs
    public CharacterController controller;
    public Transform playerBody;

    //defines the variables and layers and positions used in collision detection
    public Transform groundCheck;

    public bool isGrounded;
    public bool yLock;

    public float groundDistance = 0.4f;

    public LayerMask groundMask;

    //defines the variables that are used in player movement
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 6f;
    public float minSpd = 0f;
    public float maxTme = 0.9f;

    //Vectors used for collision detection, and the velocity vector
    public Vector3 velocity;
    public Vector3 move;
    public Vector3 playPoint;

    //Functions

    void velocityGroup(){
        //caps all velocities, will change to mathf.clamp
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
        if(velocity.y < -20)
              {
                    velocity.y = -20;
              }
        if(velocity.x < -10)
              {
                    velocity.x = -10;
              }
        if(velocity.z < -10)
              {
                    velocity.z = -10;
              }
    }

    void isGround(){
        //statements that check for ground collisions and adjust player velocity accordingly
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //detects when player is touching the ground, and sets y velocity to a constant to prevent excess accelleration
        if (isGrounded && velocity.y < -0.01f)
        {
            if (velocity.y <= -3.1f)
            {
                yLock = true;
                velocity.y = -1.8f;
                velocity.y = Mathf.MoveTowards(velocity.y, minSpd, maxTme * maxTme * Time.deltaTime);
            }
            else if(velocity.y >= -0.1f && yLock)
            {
                velocity.y = 0;
                yLock = false;
            }
        }
        
    }

    //limits and slowly resets velocity values
    void velocityLim(){
        
        velocityGroup();

        //constant deceleration on all velocity axis.
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
    }
    
    
    void funcCall(){
        
        isGround();
        
        velocityLim();

    }


    // Update is called once per frame
    void Update()
    {
        //call the function to call all functions
        funcCall();
        //gets spacebar input and jumps the player
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        //gets WASD input for the character controller
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //passes correct movement values to the character controller
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime * 2;
        }

        controller.Move(velocity * Time.deltaTime);


        //Debug.Log(playPoint);
    }
}
