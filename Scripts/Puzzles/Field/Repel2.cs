using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repel2 : MonoBehaviour
{
    //===NOTE=== This is an UNFINISHED, UNUSED (currently) script. NOT YET FUNCTIONAL

    // gets all the objects, colliders, scripts, and layers required for the script.
    public GameObject playerBody;
    public GameObject fieldBody;
    public LayerMask fieldMask;
    public Transform fieldCheck;
    public Collider collPoint;
    private Player_Movement3 playMove;

    //lock 1 of two for the Single Field Only, Seriously I Only Want One Field And No More At A Time (SFOSIOWOFANMAAT) locking system.
    private bool lockY = false;

    //bools to allow field to work in certain conditions
    public bool fieldKeep;
    bool isFielded;
    //lock 2 of 2 for SFOSIOWOFANMAAT, which will be taken from the player script.
    bool lockX;

    //float to define collision-detection radius
    public float fieldDistance = 0.5f;

    //vectors used to determine the reflection angle of the player's velocities.
    Vector3 startPt;
    Vector3 endPt;
    Vector3 fieldNormal;
    Vector3 velocity;
    Vector3 playPoint;

    //bool used to reset the field effects upon contact with a ground object.
    public bool groundField = false;

    //Lock for preventing rapid reflections of player velocity
    bool fieldLock = false;


    //function for the various locks and the setting of player variables
    void lockSet(){
        
        //updates all local var's with player ones.
        groundField = playMove.groundField;
        fieldKeep = playMove.fieldKeep;
        fieldCheck = playMove.fieldCheck;

        
        if(isFielded && fieldLock){
            
            //if all conditions are satisfied, update player variables with local ones.
            if(playMove.lockX == false){
                playMove.playPoint = playPoint;
                playMove.isFielded = isFielded;
                fieldLock = false;
            }
            //activate (SFOSIOWOFANMAAT) locking system.
            lockY = true;
            playMove.lockX = false;
        
        }

        //make sure the player's force field values reset, and reset the (SFOSIOWOFANMAAT).
        if (!isFielded){
            playMove.isFielded = false;
            
            lockY = false;
            fieldLock = true;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        //get the script component of the player
        playMove = playerBody.GetComponent<Player_Movement3>();
        //collPoint = fieldBody.GetComponent<Collider>();
        lockSet();
    }

    // Update is called once per frame
    void Update()
    {
        //update the 2nd lock of the (SFOSIOWOFANMAAT) system.
        lockX = playMove.lockX;



        //if, or statement for the (SFOSIOWOFANMAAT) system.
        if (lockX == true || lockY == true){


            //finds the closest point to the player on the collider of the forcefield.
            playPoint = Physics.ClosestPoint(playerBody.transform.position, collPoint, fieldBody.transform.position, fieldBody.transform.rotation);

            //call locking function
            lockSet();

            Debug.Log(playPoint);
            //define points used for capsule check
            startPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y + (fieldDistance), fieldCheck.position.z);
            endPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y - (fieldDistance), fieldCheck.position.z);

            //if available, check around the player for a collision with this force field.
            if(fieldKeep == true){
       
                isFielded = Physics.CheckCapsule(startPt, endPt, fieldDistance, fieldMask);
            }

            

        }

        
    }
}
