using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameController _gameController;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("UN OBJETO HA sido contabilizado");

        if (other.gameObject.layer == 7)
        {
            _gameController.addPoint();
        }
    }
}