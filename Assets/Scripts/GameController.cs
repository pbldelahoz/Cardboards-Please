using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;

public class GameController : MonoBehaviour
{
    [SerializeField] List<GameObject> itemsList = new List<GameObject>();
    [SerializeField] XROrigin playerXR;
    private Vector3 firstPosition;
    Vector3 position;

    int currentLevel = 0;

    //Countdown
    float currentTime = 0f;
    [SerializeField] float startingTime = 10f;
    [SerializeField] float instanceTime = 20f;
    [SerializeField] float timeBetweenInstance = 0f;

    bool activate = false;

    public float transitionTime = 1f;

    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        firstPosition = playerXR.transform.position;
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
        playerXR.transform.position = firstPosition;
        StartCoroutine(LoadLevel());

    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        
    }
}
