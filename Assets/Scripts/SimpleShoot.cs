using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShoot : MonoBehaviour
{
    //public GameObject spotLight;
    private Light light;
    private BoxCollider box;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        box = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PullTheTriger()
    {
        light.enabled = !light.enabled;
        //Activamos la luz y el collider
        Debug.Log("ey");
    }

    public void ReleaseTheTriger()
    {
        light.enabled = !light.enabled;
        //Desactivamos la luz y el collider
        Debug.Log("uyy");
    }
}
