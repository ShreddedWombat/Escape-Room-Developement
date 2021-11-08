using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repel2 : MonoBehaviour
{

    public GameObject playerBody;
    public GameObject fieldBody;
    public LayerMask fieldMask;
    public float fieldDistance = 0.5f;
    public Transform fieldCheck;
    public Collider collPoint;
    
    private Player_Movement3 playMove;
    private bool lockY = false;

    public bool fieldKeep;
    bool isFielded;
    bool lockX;
    
    Vector3 startPt;
    Vector3 endPt;
    Vector3 fieldNormal;
    Vector3 velocity;
    Vector3 playPoint;

    
    public bool groundField = false;

    bool fieldLock = false;









    void lockSet(){
        
        groundField = playMove.groundField;
        fieldKeep = playMove.fieldKeep;
        playPoint = playMove.playPoint;
        fieldCheck = playMove.fieldCheck;
        lockX = playMove.lockX;

        if(isFielded && fieldLock){
            

            if(playMove.lockX == false){
                playMove.playPoint = playPoint;
                playMove.isFielded = isFielded;
                fieldLock = false;
            }

            lockY = true;
            playMove.lockX = false;
        
        }

        if(!isFielded){
            playMove.isFielded = false;
            playMove.lockX = true;
            lockY = false;
            fieldLock = true;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        playMove = playerBody.GetComponent<Player_Movement3>();
        //collPoint = fieldBody.GetComponent<Collider>();
        lockSet();
    }

    // Update is called once per frame
    void Update()
    {
        lockX = playMove.lockX;
        

        
        
        if(lockX == true || lockY == true){

            

            playPoint = Physics.ClosestPoint(playerBody.transform.position, collPoint, fieldBody.transform.position, fieldBody.transform.rotation);

            lockSet();

            Debug.Log(playPoint);
            startPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y + (fieldDistance), fieldCheck.position.z);
            endPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y - (fieldDistance), fieldCheck.position.z);

            if(fieldKeep == true){
       
                isFielded = Physics.CheckCapsule(startPt, endPt, fieldDistance + 0.3f, fieldMask);
            }

            

        }

        
    }
}
