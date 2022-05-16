//This particular script was developed by Brody Smith, and is used with his full permission.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    //As stated earlier, this script was provided to me by Brody Smith, and as such I would request that any mention or
    //consideration of this script and it's use in-game be omitted from the marking process, as that would be an unfair
    //evaluation of my programming, and it would reflect poorly on me as an individual to take credit for someone elses
    //work.

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
