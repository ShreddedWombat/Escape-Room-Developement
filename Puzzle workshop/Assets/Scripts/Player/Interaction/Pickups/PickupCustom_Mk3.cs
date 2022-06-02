using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCustom_Mk3 : MonoBehaviour
{

    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Transform PickupTarget;
    [SerializeField] private Rigidbody Dest;
    [SerializeField] private Rigidbody selectBody;
    [Space]
    [SerializeField] private float PickupRange;
    private Rigidbody CurrentObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void CheckPress()
    {
        /*if (CurrentObject)
        {
            CurrentObject.transform.rotation = PickupTarget.rotation;
        }*/

        if (Input.GetKeyDown(KeyCode.E))
        {

            if (CurrentObject)
            {
                CurrentObject.useGravity = true;
                CurrentObject = null;
            }

            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckPress();

        
    }

    void FixedUpdate()
    {
        if (CurrentObject)
        {
            Dest.SpringJoint.connectedBody = selectBody;

        }
    }
}
