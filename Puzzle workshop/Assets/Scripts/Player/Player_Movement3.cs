using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement3 : MonoBehaviour
{

    public CharacterController controller;

    public Transform playerBody;
    public Transform fieldCheck;
    public Transform groundCheck;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float minSpd = 0f;
    public float maxTme = 0.9f;
    public float groundDistance = 0.4f;

    public LayerMask groundMask;

    public Vector3 velocity;
    public Vector3 move;
    public Vector3 playPoint;

    public bool fieldKeep = true;
    public bool isGrounded;
    public bool isFielded = false;
    public bool groundField = false;

    float fieldTime = 0;
    float groundTime = 0;

    //Locking Variable

    public bool lockX = true;

    //Functions

    void velocityGroup(){
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
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2.6f;
        }

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

    void velocityLim(){
        
        velocityGroup();

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
    
    void flipper(){
        if(isFielded && fieldKeep && !lockX){
            Vector3 fieldNormal = (playPoint - playerBody.position);
            velocity = Vector3.Reflect(velocity , fieldNormal) * 8;
            velocity.y += 2f;
            fieldKeep = false;
            groundField = true;
            isFielded = false;
            lockX = true;
        }
        else{
            fieldTime += Time.deltaTime;
        }

        if(fieldTime > 0.3 || groundField == false){
            fieldKeep = true;
            fieldTime = 0;
            }
        /*if(!isFielded && !fieldKeep){
            fieldKeep = true;
        }*/
    }

    void funcCall(){
        
        isGround();
        
        velocityLim();

        flipper();
    }

    // Start is called before the first frame update
    void Start()
    {
        fieldKeep = true;
    }

    // Update is called once per frame
    void Update()
    {
        funcCall();
        
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

        //Debug.Log(playPoint);
    }
}
