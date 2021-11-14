using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hueLock_2 : MonoBehaviour
{
    //functionally identical to hueLock_1

    public Color32 opt1;
    public Color32 opt2;
    public Color32 opt3;
    public Color32 opt4;
    public Color32 goal;
    public bool Corrected = false;
    public GameObject hueBut;
    int hueSwitch = 1;


    private void OnMouseDown()
     {
        var hueRend = hueBut.GetComponent<Renderer>();

        if(hueSwitch == 1){
            hueRend.material.SetColor("_BaseColor", opt1);
            hueSwitch = 2;
        }
        else if(hueSwitch == 2){
            hueRend.material.SetColor("_BaseColor", opt2);
            hueSwitch = 3;
        }
        else if(hueSwitch == 3){
            hueRend.material.SetColor("_BaseColor", opt3);
            hueSwitch = 4;
        }
        else{
            hueRend.material.SetColor("_BaseColor", opt4);
            hueSwitch = 1;
        }
        
        
     }
    
    // Start is called before the first frame update
    void Start()
    {
        var hueRend = hueBut.GetComponent<Renderer>();
        hueRend.material.SetColor("_BaseColor", opt3);
        
    }

    // Update is called once per frame
    void Update()
    {
        var hueRend = hueBut.GetComponent<Renderer>();
        var hueHue = hueRend.material.GetColor("_BaseColor");
        if(hueHue == goal){
            Corrected = true;
        }
        else{
            Corrected = false;
        }
        
    }
}
