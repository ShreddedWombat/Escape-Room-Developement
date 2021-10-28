using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repel2 : MonoBehaviour
{












    void lockSet(){
        
        

        if(isFielded){
            lockY = true;
            playMove.lockX = false;

            if(!playMove.lockX){
                playMove.playPoint = playPoint;
                playMove.isFielded = isFielded;
                playMove.fieldKeep = true;
        }
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
        
    }

    // Update is called once per frame
    void Update()
    {

        if(lockX = true || lockY = true){

            playPoint = Physics.ClosestPoint(playerBody.transform.position, collPoint, fieldBody.transform.position, fieldBody.transform.rotation);

            startPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y + (fieldDistance +1.5f), fieldCheck.position.z);
            endPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y - (fieldDistance +1.5f), playerBody.transform.position.z);

            isFielded = Physics.CheckCapsule(startPt, endPt, fieldDistance + 0.3f, fieldMask);
            

        }
    }
}
