using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //sets radius and (unused as of yet) toggle value
    public float radius = 3f;
    public bool hold = false;
    int distance = 7;

    //function to draw the radius when selected in the editor, makes it easy to see player interaction distances
    void OnMouseDown()
    {
    if (Vector3.Distance(playerPos.position, transform.position) <= distance)
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().detectCollisions = true;
            tog = true;
    }
}
