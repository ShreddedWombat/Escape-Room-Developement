using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement3 : MonoBehaviour
{
    //declares the Player Position and the Character Controller, which takes movement inputs
    public CharacterController controller;
    public Transform playerBody;

    //defines the variables and layers and positions used in collision detection
    public Transform fieldCheck;
    public Transform groundCheck;

    public bool fieldKeep = true;
    public bool isGrounded;
    public bool isFielded = false;
    public bool groundField = false;

    public float groundDistance = 0.4f;

    public LayerMask groundMask;

    //defines the variables that are used in player movement
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float minSpd = 0f;
    public float maxTme = 0.9f;

    //Vectors used for collision detection, and the velocity vector
    public Vector3 velocity;
    public Vector3 move;
    public Vector3 playPoint;


    //Time & Ground Float for (unfinished) forcefields
    float fieldTime = 0;
    float groundTime = 0;

    //Locking Variable

    public bool lockX = true;

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
        //statements that check for ground collisions and adjust the adjust player velocity accordingly
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //detects when player is touching the ground, and sets y velocity to a constant to prevent excess accelleration
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2.6f;
        }

        //stops player from sliding after force field bounce(UNFINISHED)
        if(groundField && isGrounded)
        {
        groundTime += Time.deltaTime;

            if(groundTime > 0.3){
                velocity.x = 0;
                velocity.y = 0;
                velocity.z = 0;
                groundField = false;
                groundTime = 0;
            
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
    
    //UNFINISHED function to calculate velocity reflections
    void flipper(){
        if(isFielded && fieldKeep && !lockX){
            //reflects velocity across a normal, which is drawn between player and closest point on field at the moment of impact
            Vector3 fieldNormal = (playPoint - playerBody.position);
            velocity = Vector3.Reflect(velocity , fieldNormal) * 8;
            velocity.y += 2f;
            //sets all related variables to allow for reseting process
            fieldKeep = false;
            groundField = true;
            isFielded = false;
            lockX = true;
        }
        else{
            //used to set a delay inbetween bounces, to avoid rapid reflection bug
            fieldTime += Time.deltaTime;
        }
        //allows new bounces after a short time OR contact with the ground.
        if(fieldTime > 0.3 || groundField == false){
            fieldKeep = true;
            fieldTime = 0;
            }
        /*if(!isFielded && !fieldKeep){
            fieldKeep = true;
        }*/
    }
    //function to call all the functions
    void funcCall(){
        
        isGround();
        
        velocityLim();

        flipper();
    }

    // Start is called before the first frame update
    void Start()
    {
        //start off the force field(UNFINISHED) as active
        fieldKeep = true;
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
        if(!isFielded)
        {
            controller.Move(move * speed * Time.deltaTime);
        }
        velocity.y += gravity * Time.deltaTime * 2;

        controller.Move(velocity * Time.deltaTime);

        //UNFINISHED additional interact options, such as special buttons or keys.
        if (Input.GetButtonDown("Interact"))
        {
           //placeholder
        }

        //Debug.Log(playPoint);
    }
}
