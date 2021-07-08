using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repel : MonoBehaviour
{
    public GameObject Field;
    public Transform playerBody;
    public float repDistance = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision){

    }
}
