using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FixSide : MonoBehaviour
{
    public GameObject boxSide;

    private const float VERTICAL_ANGLE = -95;

    private BoxController boxController;

    void Awake()
    {
        boxController = this.gameObject.GetComponentInParent<BoxController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.Equals(boxSide) && boxSide.GetComponent<Grabbed>().IsGrabbed)
        {
            HingeJoint joint = boxSide.GetComponent<HingeJoint>();
            FixedJoint newJoint = boxSide.AddComponent<FixedJoint>() as FixedJoint;
            newJoint.connectedBody = joint.connectedBody;            
            newJoint.anchor = joint.anchor;
            
            JointLimits limits = new JointLimits();
            limits.max = VERTICAL_ANGLE;
            limits.min = VERTICAL_ANGLE;
            joint.limits = limits;
            
            Destroy(joint);

            boxSide.GetComponent<XRGrabInteractable>().throwOnDetach = true;

            boxSide = null;

            boxController.SidesClosed++;
            Debug.Log(boxController.SidesClosed);
        }
    }
}
