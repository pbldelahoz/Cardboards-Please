using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    // Start is called before the first frame update
    float currentTime = 0f;
    [SerializeField] float startingTime = 240f;
    bool activate = false;
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
            currentTime -= 1 * Time.deltaTime;
        }
    }
}
