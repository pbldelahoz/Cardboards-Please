using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private int sidesClosed;
    private bool objectInside;
    private ObjectData _objectData;
    public bool spawned = false;
    [SerializeField] private GameObject[] children;
    [SerializeField] private GameObject closedBox;
    private GameObject newBox;

    public int SidesClosed
    {
        get { return sidesClosed; }
        set { sidesClosed = value; }
    }

    public void setObjectData(ObjectData oD)
    {
        _objectData = oD;
    }

    public ObjectData getObjectData()
    {
        return _objectData;
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
            Debug.Log("AAAAAAAAAAAAAAAAAAA");
            // CAMBIAR MODELO CAJA
            foreach (var obj in children)
            {
                Destroy(obj);
            }

            if (!spawned)
            {
                newBox = Instantiate(closedBox, gameObject.transform.position, gameObject.transform.rotation);
                newBox.transform.SetParent(gameObject.transform);
                spawned = true;
            }
        }
    }
}