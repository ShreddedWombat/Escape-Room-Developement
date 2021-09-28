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
    public float fieldDistance = 1f;
    public Transform fieldCheck;
    public Transform field;

    Vector3 startPt;
    Vector3 endPt;
    Vector3 fieldNormal;

    Vector3 velocity;
    bool isGrounded;
    bool isFielded = false;
    bool fieldKeep = true;
    bool groundField = false;

    float fieldTime = 0;
    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2.6f;

        }

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

              fieldKeep = false;
              groundField = true;
          }

        

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