using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _3x3Pattern : MonoBehaviour
{
    int distance = 5;

    public Color32 opt1;
    public Color32 opt2;
    public Color32 opt3;
    public Color32 opt4;
    public Color32 opt5;
    public Color32 opt6;
    public Color32 opt7;
    public Color32 opt8;
    public Color32 goal;

    public bool Corrected = false;
    public GameObject But_3x3;
    int _3xSwitch = 1;

    private Dictionary<string, Color32> optDict = new Dictionary<string, Color32>();
    

    private void OnMouseDown()
     {
        var playerPos = GameObject.Find("playerBody").transform.position;

        if(Vector3.Distance(playerPos, transform.position) <= distance){

            var _3xRend = But_3x3.GetComponent<Renderer>();

            string curOpt = ("opt"+_3xSwitch);
            optDict.TryGetValue(curOpt, out Color32 currOption);
            _3xRend.material.SetColor("_BaseColor", currOption);
            _3xSwitch += 1;
            }
        
        if(_3xSwitch == 9){
            _3xSwitch = 1;
        }
     }



    // Start is called before the first frame update
    void Start()
    {

        optDict.Add("opt1", opt1);
        optDict.Add("opt2", opt2);
        optDict.Add("opt3", opt3);
        optDict.Add("opt4", opt4);
        optDict.Add("opt5", opt5);
        optDict.Add("opt6", opt6);
        optDict.Add("opt7", opt7);
        optDict.Add("opt8", opt8);

        var _3xRend = But_3x3.GetComponent<Renderer>();
        _3xRend.material.SetColor("_BaseColor", opt1);
    }

    // Update is called once per frame
    void Update()
    {
        var _3xRend = But_3x3.GetComponent<Renderer>();
        var _3xHue = _3xRend.material.GetColor("_BaseColor");
        if(_3xHue == goal){
            Corrected = true;
        }
        else{
            Corrected = false;
        }
    }
}
