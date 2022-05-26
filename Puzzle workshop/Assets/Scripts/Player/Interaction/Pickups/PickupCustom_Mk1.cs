using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCustom_Mk1 : MonoBehaviour
{
    public float grabRange = 5;
    public float moveForce = 250;
    public Transform grabParent;
    private GameObject objectGrabbed = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (objectGrabbed == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, grabRange))
                {
                    HoldObject(hit.transform.gameObject);
                }
            }
            else
            {

            }
        }

        if(objectGrabbed != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if(Vector3.Distance(objectGrabbed.transform.position, grabParent.position) > 0.1f)
        {
            Vector3 moveDirection = (grabParent.position - objectGrabbed.transform.position);
            objectGrabbed.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void HoldObject (GameObject heldObject)
    {
        if (heldObject.GetComponent<Rigidbody>()){
            Rigidbody heldRigid = heldObject.GetComponent<Rigidbody>();
            heldRigid.useGravity = false;
            heldRigid.drag = 10;

            heldRigid.transform.parent = grabParent;
            objectGrabbed = heldObject;
        }
    }

    void DropGrabbed()
    {
        Rigidbody heldRigid = objectGrabbed.GetComponent<Rigidbody>();
        heldRigid.useGravity = true;
        heldRigid.drag = 1;

        objectGrabbed.transform.parent = null;
        objectGrabbed = null;
    }
}
