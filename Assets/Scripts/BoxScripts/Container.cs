using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    private BoxController boxController;

    void Awake()
    {
        boxController = this.transform.parent.GetComponentInParent<BoxController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("UN OBJETO HA salido");

        if (other.gameObject.layer == 6)
        {
            Debug.Log("UN OBJETO HA ENTRADO");
            boxController.ObjectInside = true;
            boxController.setObjectData(other.gameObject.GetComponent<ObjectData>());
            other.gameObject.transform.position.Set(0, 0, 0);
            other.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            boxController.ObjectInside = false;
        }
    }
}