using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] List<GameObject> itemsList = new List<GameObject>();
    Vector3 position;

    int currentLevel = 0;

    //Countdown
    float currentTime = 0f;
    [SerializeField] float startingTime = 180f;
    [SerializeField] float instanceTime = 20f;
    [SerializeField] float timeBetweenInstance = 0f;

    bool activate = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        timeBetweenInstance = instanceTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
            currentTime -= 1 * Time.deltaTime;
            Debug.Log("Current Time: " + currentTime);
            if(currentTime < 0)
            {
                Debug.Log("Level Ended");
                activate = false;
                currentLevel++;
                blackFade();
            }
            else
            {
                timeBetweenInstance -= 1 * Time.deltaTime;
                if (timeBetweenInstance < 0)
                    spawnItem();
            }
        }
    }

    public void spawnItem()
    {
        if(currentTime > 0)
        {
            Debug.Log("Spawned Item");
            timeBetweenInstance = instanceTime;
            int randomId = Random.Range(0, itemsList.Count);
            Instantiate(itemsList[randomId], gameObject.transform.position, gameObject.transform.rotation);
        }

    }

    public void startTimer()
    {
        activate = true;
    }
    public void blackFade()
    {

    }
}
