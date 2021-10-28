using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repel : MonoBehaviour
{   
    
    public GameObject playerBody;
    public GameObject fieldBody;
    public LayerMask fieldMask;
    public float fieldDistance = 1f;
    public Transform fieldCheck;
    public Collider collPoint;
    
    private Player_Movement2 playMove;

    bool fieldKeep;
    bool isFielded;
    
    Vector3 startPt;
    Vector3 endPt;
    Vector3 fieldNormal;
    Vector3 velocity;
    Vector3 playPoint;

    float fieldTime = 0;
    public bool groundField = false;



    // Start is called before the first frame update
    void Start()
    {
        playMove = playerBody.GetComponent<Player_Movement2>();
        collPoint = fieldBody.GetComponent<Collider>();
        groundField = playMove.groundField;
        fieldKeep = playMove.fieldKeep;
        playPoint = playMove.playPoint;
        fieldCheck = playMove.fieldCheck;
    }

    // Update is called once per frame
    void Update()
    {
        fieldKeep = playMove.fieldKeep;
        groundField = playMove.groundField;
        isFielded = playMove.isFielded;
        velocity = playMove.velocity;
        playPoint = playMove.playPoint;
        fieldCheck = playMove.fieldCheck;

        playPoint = Physics.ClosestPoint(playerBody.transform.position, collPoint, fieldBody.transform.position, fieldBody.transform.rotation);

        startPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y + (fieldDistance +1.5f), fieldCheck.position.z);
        endPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y - (fieldDistance +1.5f), playerBody.transform.position.z);

        if(fieldKeep == true)
        {
            isFielded = Physics.CheckCapsule(startPt, endPt, fieldDistance + 0.3f, fieldMask);
            /*if(isFielded){
                groundField = true;
            }*/
        }
        else{
            isFielded = false;
            fieldTime += Time.deltaTime;
            
        }

        
              

          
        if 
          if(fieldTime > 0.13 || groundField == false){
                fieldKeep = true;
                fieldTime = 0;
            }

        playMove.isFielded = isFielded;
        playMove.velocity = velocity;
        playMove.groundField = groundField;
        playMove.fieldKeep = fieldKeep;
        playMove.playPoint = playPoint;
        playMove.fieldCheck = fieldCheck;

        Debug.Log(fieldNormal);
        Debug.Log(fieldCheck.position);
        Debug.Log(playPoint);
        Debug.Log(velocity);
        Debug.Log(playMove.velocity);
        //Debug.DrawLine(fieldCheck.position, playPoint, Color.white, 100000.0f, true);
    }
}
