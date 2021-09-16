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
            velocity.y = -2.6f;

        }

        startPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y + (fieldDistance +1.5f), fieldCheck.position.z);
        endPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y - (fieldDistance +1.5f), playerBody.position.z);

        if(fieldKeep)
        {
            isFielded = Physics.CheckCapsule(startPt, endPt, fieldDistance + 0.05f, fieldMask);
        }
        else{
            isFielded = false;
            fieldTime += Time.deltaTime;
            if(fieldTime > 1){
                fieldKeep = true;
                fieldTime = 0;
            }
        }
        //isFielded = Physics.CheckSphere(groundCheck.position, groundDistance, fieldMask);
          if(isFielded && fieldKeep)
          {
              float xBounce = Mathf.Pow((velocity.x),0) * 2;
              float yBounce = Mathf.Pow((velocity.y),0) * 2;
              float zBounce = Mathf.Pow((velocity.z),0) * 2;

              velocity.y = (velocity.y + yBounce) * -2;
              velocity.x = (velocity.x + xBounce) * -2;
              velocity.z = (velocity.z + zBounce) * -2;
              fieldKeep = false;
          }

         

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if((x == 0) && (velocity.x != 0))
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
        }

        Vector3 move = transform.right * x + transform.forward * z;
        if(!isFielded)
        {
        controller.Move(move * speed * Time.deltaTime);
        }
        velocity.y += gravity * Time.deltaTime * 2;

        controller.Move(velocity * Time.deltaTime);
    }
}