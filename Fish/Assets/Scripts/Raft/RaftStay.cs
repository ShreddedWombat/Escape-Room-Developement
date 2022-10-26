using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftStay : MonoBehaviour
{

    public Transform Raft;

    public float rotLock;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(Raft.rotation.x >= rotLock)
        {
            Raft.Rotate(-(Raft.rotation.x - rotLock), 0, 0);
        }
        if (Raft.rotation.y >= rotLock)
        {
            Raft.Rotate(0, -(Raft.rotation.y - rotLock), 0);
        }
        if (Raft.rotation.z >= rotLock)
        {
            Raft.Rotate(0, 0, -(Raft.rotation.z - rotLock));
        }
        if (Raft.rotation.x <= -rotLock)
        {
            Raft.Rotate(-(Raft.rotation.x + rotLock), 0, 0);
        }
        if (Raft.rotation.y <= -rotLock)
        {
            Raft.Rotate(0, -(Raft.rotation.y + rotLock), 0);
        }
        if (Raft.rotation.z <= -rotLock)
        {
            Raft.Rotate(0, 0, -(Raft.rotation.z + rotLock));
        }
    }
}
