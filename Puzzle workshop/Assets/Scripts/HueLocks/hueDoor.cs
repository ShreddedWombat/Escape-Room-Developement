using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hueDoor : MonoBehaviour
{
    int i = 0; 

    public Transform Door;

    public GameObject hueBut;
    private hueLock_1 hueLock;
    public GameObject hueBut1;
    private hueLock_2 hueLock1;
    public GameObject hueBut2;
    private hueLock_3 hueLock2;
    
    // Start is called before the first frame update
    void Start()
    {
        
        hueLock = hueBut.GetComponent<hueLock_1>(); 
        hueLock1 = hueBut1.GetComponent<hueLock_2>(); 
        hueLock2 = hueBut2.GetComponent<hueLock_3>(); 

        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if(hueLock.Corrected == true && hueLock1.Corrected == true && hueLock2.Corrected == true) {
            if (i <= 50) {
                Door.transform.Translate(Vector3.up / 10);
                i++;
            }
            }
        if(hueLock.Corrected == false || hueLock1.Corrected == false || hueLock2.Corrected == false) {
            if (i >= 0) {
                Door.transform.Translate(Vector3.down / 10);
                i--;
            }
            
          }  
        
    }
}
