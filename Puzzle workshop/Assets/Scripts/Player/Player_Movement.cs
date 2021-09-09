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
    public float fieldDistance = 0.4f;

    Vector3 velocity;
    bool isGrounded;
    bool isFielded;

   // All Collision-Based events
   void OnCollisionEnter(Collision collision)
   {
          
          // Force  Field Collisions
          isFielded = Physics.CheckSphere(groundCheck.position, fieldDistance, fieldMask);
          if(isFielded)
          {
              velocity.y = velocity.y * -1;
              velocity.x = velocity.x * -1;
          }
   }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime * 2;

        controller.Move(velocity * Time.deltaTime);
    }
}
