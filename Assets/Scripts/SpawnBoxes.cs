using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class SpawnBoxes : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] cloneObject;
    private Stopwatch _stopwatch;
    private int spawnTime;

    void Start()
    {
        spawnTime = 1;
        _stopwatch = new Stopwatch();
        _stopwatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (_stopwatch.Elapsed.Seconds > spawnTime)
        {
            spawnBox();
        }
    }

    public void spawnBox()
    {
        spawnTime = Random.Range(1, 6);
        _stopwatch.Restart();
        Debug.Log("Spawned box");
        int aux = Random.Range(0, 1);
        Instantiate(cloneObject[aux], gameObject.transform.position,
            gameObject.transform.rotation);
    }
}