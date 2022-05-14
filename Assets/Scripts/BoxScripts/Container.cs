using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    private BoxController boxController;

    void Awake() {
        boxController = this.transform.parent.GetComponentInParent<BoxController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer != 3)
        {
            boxController.ObjectInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer != 3)
        {
            boxController.ObjectInside = false;
        }
    }
}
