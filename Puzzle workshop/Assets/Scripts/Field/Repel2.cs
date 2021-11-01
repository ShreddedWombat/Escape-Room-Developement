using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repel2 : MonoBehaviour
{

    public GameObject playerBody;
    public GameObject fieldBody;
    public LayerMask fieldMask;
    public float fieldDistance = 1f;
    public Transform fieldCheck;
    public Collider collPoint;
    
    private Player_Movement3 playMove;
    private bool lockY = false;

    bool fieldKeep;
    bool isFielded;
    bool lockX;
    
    Vector3 startPt;
    Vector3 endPt;
    Vector3 fieldNormal;
    Vector3 velocity;
    Vector3 playPoint;

    float fieldTime = 0;
    public bool groundField = false;










    void lockSet(){
        
        groundField = playMove.groundField;
        fieldKeep = playMove.fieldKeep;
        playPoint = playMove.playPoint;
        fieldCheck = playMove.fieldCheck;
        lockX = playMove.lockX;

        if(isFielded){
            

            if(playMove.lockX == false){
                playMove.playPoint = playPoint;
                playMove.isFielded = isFielded;
                
            }

            lockY = true;
            playMove.lockX = false;
        
        }

        if(!isFielded){
            playMove.isFielded = isFielded;
            playMove.lockX = true;
            lockY = false;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        playMove = playerBody.GetComponent<Player_Movement3>();
        collPoint = fieldBody.GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void Update()
    {

        

        
        
        if(lockX == true || lockY == true){

            lockSet();

            playPoint = Physics.ClosestPoint(playerBody.transform.position, collPoint, fieldBody.transform.position, fieldBody.transform.rotation);

            startPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y + (fieldDistance +1.5f), fieldCheck.position.z);
            endPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y - (fieldDistance +1.5f), playerBody.transform.position.z);

            if(fieldKeep == true){
       
                isFielded = Physics.CheckCapsule(startPt, endPt, fieldDistance + 0.3f, fieldMask);
            
            }
            else{
                isFielded = false;
                fieldTime += Time.deltaTime;
            }

            if(fieldTime > 0.13 || groundField == false){
                fieldKeep = true;
                fieldTime = 0;
            }
        }

        
    }
}
