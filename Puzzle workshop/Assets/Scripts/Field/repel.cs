using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repel : MonoBehaviour
{   
    
    public GameObject playerBody;
    public LayerMask fieldMask;
    public float fieldDistance = 1f;
    public Transform fieldCheck;
    public Transform field;
    
    private Player_Movement2 playMove;

    bool fieldKeep;
    bool isFielded;
    
    Vector3 startPt;
    Vector3 endPt;
    Vector3 fieldNormal;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        playMove = playerBody.GetComponent<Player_Movement2>();

    }

    // Update is called once per frame
    void Update()
    {
        isFielded = playMove.isFielded;
        velocity = playMove.velocity;

        startPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y + (fieldDistance +1.5f), fieldCheck.position.z);
        endPt = new Vector3(fieldCheck.position.x, fieldCheck.position.y - (fieldDistance +1.5f), playerBody.position.z);

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

        if(isFielded && fieldKeep)
          {
              float xBounce;
              float yBounce;
              float zBounce;

              if(velocity.x < 0){
                    xBounce = 1;
              }
              else{
                    xBounce = -1;}

              if(velocity.y < 0){
                    yBounce = 1;
              }
              else{
                    yBounce = -1;}

              if(velocity.z < 0){
                    zBounce = 1;
              }
              else{
                    zBounce = -1;}
              //float xBounce = ((velocity.x) / (Mathf.Abs(velocity.x))) * 2;
              //float yBounce = ((velocity.x) / (Mathf.Abs(velocity.y))) * 2;
              //float zBounce = ((velocity.x) / (Mathf.Abs(velocity.z))) * 2;
              Debug.Log(xBounce + " " + yBounce + " " + zBounce);
              /*velocity.y = (velocity.y + yBounce) * -1;
              velocity.x = (velocity.x + xBounce) * -1;
              velocity.z = (velocity.z + zBounce) * -1;*/

              Vector3 fieldNormal = (fieldCheck.position - field.position);
              velocity = Vector3.Reflect(velocity , fieldNormal) / 40;
              if(velocity.y > 30)
              {
                    velocity.y = 30;
              }

              fieldKeep = false;
              groundField = true;
          }

          if(fieldTime > 0.3 || groundField == false){
                fieldKeep = true;
                fieldTime = 0;
            }

        playMove.isFielded = isFielded;
        playMove.velocity = velocity;
    }
}
