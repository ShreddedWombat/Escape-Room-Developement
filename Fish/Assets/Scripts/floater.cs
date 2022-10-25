using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class floater : MonoBehaviour
{
    public Transform[] floaters;

    public float underDrag = 3f;

    public float underangleDrag = 1f;

    public float airDrag = 0f;

    public float airangleDrag = 0.05f;

    public float floatingPower = 15f;

    public float waterHeight = 0f;

    Rigidbody m_Rigidbody;

    int floatsUnder;

    bool underwater;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        floatsUnder = 0;
        for (int i = 0; i < floaters.Length; i++)
        {
            float diff = floaters[i].position.y - waterHeight;

            if (diff < 0)
            {
                m_Rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(diff), floaters[i].position, ForceMode.Force);
                floatsUnder += 1;
                if (!underwater)
                {
                    underwater = true;
                    SwitchDrag(true);
                }
            }
        }
        
        if(underwater && floatsUnder == 0)
        {
            underwater = false;
            SwitchDrag(false);
        }
    }

    void SwitchDrag(bool isUnderwater)
    {
        if (isUnderwater)
        {
            m_Rigidbody.drag = underDrag;
            m_Rigidbody.angularDrag = underangleDrag;
        }
        else
        {
            m_Rigidbody.drag = airDrag;
            m_Rigidbody.angularDrag = airangleDrag;
        }
    }
}
