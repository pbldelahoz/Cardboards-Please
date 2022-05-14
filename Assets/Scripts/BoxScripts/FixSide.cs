using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FixSide : MonoBehaviour
{
    public GameObject boxSide;  

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.Equals(boxSide) && boxSide.GetComponent<Grabbed>().IsGrabbed)
        {
            boxSide.GetComponent<Rigidbody>().isKinematic = true;
            HingeJoint joint = boxSide.GetComponent<HingeJoint>();
            joint.axis = Vector3.zero;
            JointLimits limits = new JointLimits();
            limits.max = -90;
            limits.min = -90;
            joint.limits = limits;            
            boxSide.GetComponent<XRGrabInteractable>().throwOnDetach = true;
        }
    }
}
