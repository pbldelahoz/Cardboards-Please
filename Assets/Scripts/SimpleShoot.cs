using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShoot : MonoBehaviour
{
    //public GameObject spotLight;
    private Light light;
    private BoxCollider box;
    private bool pulsed = false;

    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField] private GameController _gameController;

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
        _audioSource.Play();
        //Activamos la luz y el collider
        Debug.Log("ey");
    }

    public void ReleaseTheTriger()
    {
        light.enabled = !light.enabled;
        box.enabled = !box.enabled;
        pulsed = false;
        //Desactivamos la luz y el collider
        Debug.Log("uyy");
    }

    private void OnTriggerEnter(Collider other)
    {
        //Comprobar si es un objeto con c�digo
        if (other.gameObject.tag == "Barras" && pulsed)
        {
            Debug.Log("CORRECTO");
            ObjectData objectData = other.GetComponent<ObjectData>();

            if (!objectData.getScanned())
            {
                objectData.setScanned();
                _gameController.addPoint();
            }
        }
        else if (other.gameObject.tag == "noBarras" && pulsed)
        {
            Debug.Log("INCORRECTO");

            ObjectData objectData = other.GetComponent<ObjectData>();
            if (!objectData.getScanned())
            {
                objectData.setScanned();
                _gameController.takePoint();
            }
        }
    }
}