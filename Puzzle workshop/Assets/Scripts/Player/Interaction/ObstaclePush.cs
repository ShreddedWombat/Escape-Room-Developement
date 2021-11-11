//This particular script was developed by Brody Smith, and is used with his full permission.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
 
    [SerializeField] private float forceMagnitude;

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if(rigidbody != null){
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
        }
    }
}
