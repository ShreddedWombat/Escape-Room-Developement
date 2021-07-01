 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.Events;
 
 public class cubeClick : MonoBehaviour {
 
     [SerializeField] UnityEvent anEvent;
 
 
     private void OnMouseDown()
     {
         print("You clicked the cube!");
         anEvent.Invoke();
     }
 
    
     public void EventClick()
     {
         print("Which also triggered this method as a UnityEvent!");
     }
 }