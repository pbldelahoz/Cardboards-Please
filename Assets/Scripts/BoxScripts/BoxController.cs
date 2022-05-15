using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private int sidesClosed;
    private bool objectInside;
    [SerializeField] private GameObject[] children;
    [SerializeField] private GameObject closedBox;

    public int SidesClosed
    {
        get { return sidesClosed; }
        set { sidesClosed = value; }
    }

    public bool ObjectInside
    {
        get { return objectInside; }
        set { objectInside = value; }
    }

    void Awake()
    {
        sidesClosed = 0;
        objectInside = false;
    }

    void Update()
    {
        if (objectInside && sidesClosed == 4)
        {
            // CAMBIAR MODELO CAJA
            foreach (var obj in children)
            {
                Destroy(obj);
            }

            Instantiate(closedBox);
        }
    }
}