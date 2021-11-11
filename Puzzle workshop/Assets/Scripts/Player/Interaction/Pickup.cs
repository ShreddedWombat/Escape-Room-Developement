using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform playerPos;
    public Transform dest;
    bool tog = false;
    bool again = false;
    int distance = 7;

    public float throwForce = 600;
    Vector3 objectPos;

    void OnMouseDown()
    { 
        if (tog == false)
        {
            if (Vector3.Distance(playerPos.position, transform.position) <= distance)
            {
                GetComponent<Collider>().enabled = false;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().detectCollisions = true;
                tog = true;
            }
        }
        
    }

    void Update()
    {
        

        if (tog == true)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.position = dest.position;
            transform.parent = dest;



            if (Input.GetButtonDown("Fire1"))
            {
                if (again == true)
                {
                    
                    transform.parent = null;
                    GetComponent<Rigidbody>().useGravity = true;
                    GetComponent<Collider>().enabled = true;
                    tog = false;
                    again = false;
                }
                else if (again == false)
                {
                    again = true;
                }
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                if (again == true)
                {
                    
                    transform.parent = null;
                    GetComponent<Rigidbody>().useGravity = true;
                    GetComponent<Collider>().enabled = true;
                    tog = false;
                    again = false;
                    GetComponent<Rigidbody>().AddForce(dest.forward * throwForce);
                }
                else if (again == false)
                {
                    again = true;
                }
                

            }

        }
        
    }

    
        
    

}
