using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform playerPos;
    public Transform dest;
    public Transform drop;
    public LayerMask ground;
    public float rad = 1.5f;
    bool tog = false;
    bool again = false;
    bool groundColl = false;
    int distance = 7;

    public float throwForce = 600;
    Vector3 objectPos;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rad);
    }

    void OnMouseDown()
    { 
        
        if (Vector3.Distance(playerPos.position, transform.position) <= distance && !tog)
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().detectCollisions = true;
            tog = true;
        }
        
        
    }

    

    void isGrounded(){
        if(Physics.CheckSphere(transform.position, rad, ground))
        {
            groundColl = true;
        }
        else
        {
            groundColl = false;
        }
    }

    void Update()
    {
        isGrounded();

        if (tog)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.position = dest.position;
            transform.parent = dest;



            if (Input.GetButtonDown("Fire1") && !groundColl)
            {
                if (again)
                {
                    transform.position = drop.position;
                    transform.parent = null;
                    GetComponent<Rigidbody>().useGravity = true;
                    GetComponent<Collider>().enabled = true;
                    tog = false;
                    again = false;
                }
                else if (!again)
                {
                    again = true;
                }
            }
            else if (Input.GetButtonDown("Fire2") && !groundColl)
            {
                if (again)
                {
                    transform.position = dest.position;
                    transform.parent = null;
                    GetComponent<Rigidbody>().useGravity = true;
                    GetComponent<Collider>().enabled = true;
                    tog = false;
                    again = false;
                    GetComponent<Rigidbody>().AddForce(dest.forward * throwForce);
                }
                else if (!again)
                {
                    again = true;
                }
                

            }

        }
        
    }

    
        
    

}
