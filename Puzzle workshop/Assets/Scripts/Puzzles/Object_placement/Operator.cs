using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Operator : MonoBehaviour
{

    public int ASMD;
    public GameObject detect;
    public GameObject deText;
    public float operValue;

    public bool collVal;
    public float valDistance;
    public LayerMask valMask;

    public GameObject valueGiver;
    public ObjectVal valueScript;
    private TextMeshPro opText;
    private RectTransform deTrans;

    void OnCollisionStay(Collision collision)
    {
        collVal = Physics.CheckSphere(detect.transform.position, valDistance, valMask);
        if (collVal)
        {
            valueGiver = collision.gameObject;
            valueScript = valueGiver.GetComponent<ObjectVal>();
            operValue = valueScript.operValue;

        }
        else
        {
            operValue = 0;
        }
        
    }
    void collCheck()
    {
        collVal = Physics.CheckSphere(detect.transform.position, valDistance, valMask);
        if (!collVal)
        {
            operValue = 0;
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        collCheck();

        TextMeshPro opText = deText.GetComponent<TextMeshPro>();
        deTrans = deText.GetComponent<RectTransform>();

        if (ASMD == 1)
        {
            deTrans.localPosition = new Vector3(1.15f, 0.04f, 1.3f);
            opText.SetText("+");
        }
        if (ASMD == 2)
        {
            deTrans.localPosition = new Vector3(1.5f, 0.04f, 1.5f);
            opText.SetText("-");
        }
        if (ASMD == 3)
        {
            deTrans.localPosition = new Vector3(1.15f, 0.04f, 1.3f);
            opText.SetText("X");
        }
        if (ASMD == 4)
        {
            deTrans.localPosition = new Vector3(1.5f, 0.04f, 1.4f);
            opText.SetText ("/");
        }

        Debug.Log(operValue);
    }
}
