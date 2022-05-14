using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixSide : MonoBehaviour
{
    public GameObject boxSide;  

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.Equals(boxSide) && boxSide.GetComponent<Grabbed>().IsGrabbed)
        {
            boxSide.GetComponent<Rigidbody>().useGravity = false;
            HingeJoint joint = boxSide.GetComponent<HingeJoint>();
            JointLimits jl = new JointLimits();
            jl.min = -90;
            jl.max = -90;
            joint.limits = jl;            
        }
    }
}
