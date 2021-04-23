using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody torqueRidigbody = null;
    private float torqueFactor;
    private float angularMax = 4f;


    void FixedUpdate()
    {
        torqueRidigbody.AddTorque(new Vector3(0.6f, 0, 0));
        if(torqueRidigbody.angularVelocity.x>angularMax)
        {
            torqueRidigbody.angularVelocity = new Vector3(angularMax, torqueRidigbody.angularVelocity.y, torqueRidigbody.angularVelocity.z);
        }
    }
}
