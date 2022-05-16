using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //sets radius and (unused as of yet) toggle value
    public float radius = 3f;
    public bool toggle = false;

    //function to draw the radius when selected in the editor, makes it easy to see player interaction distances
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Update()
    {
        
    }
}
