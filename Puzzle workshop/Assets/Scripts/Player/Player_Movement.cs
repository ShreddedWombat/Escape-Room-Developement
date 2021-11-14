using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    //declares the Player Position and the Character Controller, which takes movement inputs
    public CharacterController controller;
    public Transform playerBody;

    //defines the variables that are used in player movement
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float minSpd = 0f;
    public float maxTme = 0.2f;

    //defines the variables and layers used in collision detection
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask fieldMask;
    public float fieldDistance = 1f;
    public Transform fieldCheck;
    public Transform field;

    //Vectors used for collision detection
    Vector3 startPt;
    Vector3 endPt;
    Vector3 fieldNormal;

    //Velocity Vector
    Vector3 velocity;

    //Booleans used for collision detection
    bool isGrounded;
    bool isFielded = false;
    bool fieldKeep = true;
    bool groundField = false;

    //Time Float for (unfinished) forcefields
    float fieldTime = 0;

    // Update is called once per frame
    void Update()
    {
        //detects when player is touching the ground, and sets y velocity to a constant to prevent excess accelleration

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2.6f;

        }

        //checks for any force field objects within a capsule around the player
        startPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y + (fieldDistance +1.5f), fieldCheck.position.z);
        endPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y - (fieldDistance +1.5f), playerBody.position.z);

        if(fieldKeep == true)
        {
            isFielded = Physics.CheckCapsule(startPt, endPt, fieldDistance + 0.3f, fieldMask);
            /*if(isFielded){
                groundField = true;
            }*/
        }
        else{
            isFielded = false;
            fieldTime += Time.deltaTime;
            
        }

        //(UNFINISHED) reflects player's velocity depending on the angle of collision
        
        //isFielded = Physics.CheckSphere(groundCheck.position, groundDistance, fieldMask);
          if(isFielded && fieldKeep)
          {
              float xBounce;
              float yBounce;
              float zBounce;

              if(velocity.x < 0){
                    xBounce = 1;
              }
              else{
                    xBounce = -1;}

              if(velocity.y < 0){
                    yBounce = 1;
              }
              else{
                    yBounce = -1;}

              if(velocity.z < 0){
                    zBounce = 1;
              }
              else{
                    zBounce = -1;}
              //float xBounce = ((velocity.x) / (Mathf.Abs(velocity.x))) * 2;
              //float yBounce = ((velocity.x) / (Mathf.Abs(velocity.y))) * 2;
              //float zBounce = ((velocity.x) / (Mathf.Abs(velocity.z))) * 2;
              Debug.Log(xBounce + " " + yBounce + " " + zBounce);
              /*velocity.y = (velocity.y + yBounce) * -1;
              velocity.x = (velocity.x + xBounce) * -1;
              velocity.z = (velocity.z + zBounce) * -1;*/

              Vector3 fieldNormal = (fieldCheck.position - field.position);
              velocity = Vector3.Reflect(velocity , fieldNormal) / 40;
              if(velocity.y > 30)
              {
                    velocity.y = 30;
              }

              fieldKeep = false;
              groundField = true;
          }

        //If statements to manage and reset velocities when required

        if(fieldTime > 0.3 || groundField == false){
                fieldKeep = true;
                fieldTime = 0;
            }

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

        //gets spacebar input and jumps the player
        if(Input.GetButtonDown("Jump") && isGrounded)
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

        Debug.Log(velocity);
    }
}