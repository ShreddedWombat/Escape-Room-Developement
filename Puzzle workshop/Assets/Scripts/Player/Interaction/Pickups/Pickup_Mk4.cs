using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Mk4 : MonoBehaviour
{
    //defines the positions and layers referenced in the script
    public GameObject theCamera;
    public Transform playerPos;
    public Transform dest;
    public Transform drop;
    public LayerMask ground;
    //public GameObject holder;
    //public bool hold;

    //defines the variables and booleans used in the script
    public float rad = 1.5f;
    bool tog = false;
    bool again = false;
    bool groundColl = false;
    public bool holding;
    public int distance;
    public float speed;

    Rigidbody selfBody;

    //The force that a player outputs when throwing an object (note: boxes are too heavy to throw)
    public float throwForce = 600;

    void OnMouseDown()
    {
        if (Vector3.Distance(playerPos.position, transform.position) <= distance && !tog && !holding)
        {
            tog = true;
            theCamera.GetComponent<Mouse_Look>().holding = true;
            //GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Rigidbody>().useGravity = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        //function to draw the radius when selected in the editor, makes it easy to see player interaction distances
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rad);
    }




    //checks for any ground-layer objects within a sphere around the object.
    /*void isGrounded()
    {
        if (Physics.CheckSphere(transform.position, rad, ground))
        {
            groundColl = true;
        }
        else
        {
            groundColl = false;
        }
    }*/

    void Update()
    {
        selfBody = GetComponent<Rigidbody>();

        //isGrounded();
        holding = theCamera.GetComponent<Mouse_Look>().holding;

        if (tog)
        {
            //Constantly updates the object's position to the player's "hand". Sets the "hand" as a parent object,
            //and disables velocity, both standard and angular.
            /*GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.position = dest.position;
            transform.parent = dest;*/
            //transform.position = Vector3.MoveTowards(transform.position, dest.position, speed * Time.deltaTime);
            selfBody.MovePosition(dest.position);


            //if the left mouse button is pressed while holding an object, and the object isn't colliding with any "ground" objects,
            //then the held object will be dropped.
            if (Input.GetButtonDown("Fire1") && !groundColl)
            {
                if (again)
                {
                    transform.position = drop.position;
                    /*transform.parent = null;
                    GetComponent<Collider>().enabled = true;*/
                    GetComponent<Rigidbody>().useGravity = true;
                    theCamera.GetComponent<Mouse_Look>().holding = false;
                    //GetComponent<Rigidbody>().isKinematic = false;
                    tog = false;
                    again = false;

                }
                //this "agian" variable simply means that an in-game frame must pass before the drop code can be run.
                //Implemented to prevent objects from being grabbed and immediately dropped.
                else if (!again)
                {
                    again = true;
                }
            }

            //Works the same as the above statement, except it adds a forwards force to the object to achieve a "throw".
            else if (Input.GetButtonDown("Fire2") && !groundColl)
            {
                if (again)
                {
                    transform.position = dest.position;
                    /*transform.parent = null;
                    GetComponent<Collider>().enabled = true;*/
                    GetComponent<Rigidbody>().useGravity = true;
                    theCamera.GetComponent<Mouse_Look>().holding = false;
                    //GetComponent<Rigidbody>().isKinematic = false;
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
