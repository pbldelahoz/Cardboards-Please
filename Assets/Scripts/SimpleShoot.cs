using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShoot : MonoBehaviour
{
    //public GameObject spotLight;
    private Light light;
    private BoxCollider box;
    private bool pulsed = false;
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
        pulsed = true;
        light.enabled = !light.enabled;
        box.enabled = !box.enabled;
        //Activamos la luz y el collider
        Debug.Log("ey");
    }

    public void ReleaseTheTriger()
    {
        light.enabled = !light.enabled;
        box.enabled = !box.enabled;
        //Desactivamos la luz y el collider
        Debug.Log("uyy");
    }

    private void OnTriggerEnter(Collider other)
    {
        //Comprobar si es un objeto con código
        if(other.gameObject.tag == "Barras" && pulsed)
        {
            Debug.Log("CORRECTO");
            pulsed = false;
        }
    }
}
