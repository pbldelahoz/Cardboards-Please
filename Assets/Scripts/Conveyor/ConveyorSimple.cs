using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSimple : MonoBehaviour
{
    public float speed;
    Rigidbody rBody;
    public bool xDirection = false;
    public bool yDirection= false;
    public bool zDirection=false;
    // Start is called before the first frame update

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = rBody.position;
        float speedPos = speed * Time.fixedDeltaTime;
        Vector3 speedVec = Vector3.zero;
        if (xDirection)
        {
            speedVec.x = -speedPos;
        }
        if (yDirection)
        {
            speedVec.y = -speedPos;
        }  
        if (zDirection)
        {
            speedVec.z = -speedPos;
        }
        rBody.position += speedVec;
        rBody.MovePosition(pos);
    }
}
