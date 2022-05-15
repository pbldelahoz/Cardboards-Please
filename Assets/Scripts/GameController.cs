using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] List<GameObject> itemsList = new List<GameObject>();
    [SerializeField] XROrigin playerXR;
    [SerializeField] private GameObject box;
    private Vector3 firstPosition;
    Vector3 position;
    private Stopwatch _stopwatch;
    private Stopwatch _instanceStopWatch;

    private int points;
    //Countdown
    //float currentTime = 0f;
    // private int currentLevel = 0;

    //[SerializeField] float startingTime = 10f;
    [SerializeField] float timeBetweenInstance = 5f;
    [SerializeField] float levelDuration = 120f;
    [SerializeField] GameObject spawnerFolder;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject spawnButton;
    [SerializeField] private GameObject spawnBoxButton;
    [SerializeField] private GameObject boxPosition;


    bool activate = false;


    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        _stopwatch = new Stopwatch();
        _instanceStopWatch = new Stopwatch();
        firstPosition = playerXR.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
            //currentTime -= 1 * Time.deltaTime;
            Debug.Log("Current Time: " + _stopwatch.Elapsed);
            Debug.Log("Current instance Time: " + _instanceStopWatch.Elapsed);

            if (_stopwatch.Elapsed.Seconds > levelDuration)
            {
                Debug.Log("Level Ended");
                activate = false;
                // currentLevel++;
                gameFinish();
                // blackFade();
            }
            else
            {
                if (_instanceStopWatch.Elapsed.Seconds > timeBetweenInstance)
                {
                    _instanceStopWatch.Restart();
                    spawnItem();
                }
            }
        }
    }

    public void spawnItem()
    {
        Debug.Log("Spawned Item");
        int randomId = Random.Range(0, itemsList.Count);
        GameObject obj = Instantiate(itemsList[randomId], gameObject.transform.position,
            gameObject.transform.rotation);
        obj.transform.SetParent(spawnerFolder.transform);
    }

    public void spawnBox()
    {
        Debug.Log("Spawned box");
        Instantiate(box, boxPosition.transform.position,
            gameObject.transform.rotation);
    }

    #region game flow

    public void startPlaying()
    {
        points = 0;
        _stopwatch.Restart();
        _instanceStopWatch.Restart();
        activate = true;
        hideButton(playButton);
        unHideButton(spawnButton);
        unHideButton(spawnBoxButton);
    }

    private void gameFinish()
    {
        _stopwatch.Stop();
        _instanceStopWatch.Stop();

        activate = false;
        unHideButton(playButton);
        hideButton(spawnButton);
        hideButton(spawnBoxButton);
    }

    public void goToMenu()
    {
        if (_stopwatch.IsRunning)
            _stopwatch.Stop();
        if (_instanceStopWatch.IsRunning)
            _instanceStopWatch.Stop();

        activate = false;
        hideButton(playButton);
        hideButton(spawnButton);
        hideButton(spawnBoxButton);
    }

    #endregion


    public void blackFade()
    {
        playerXR.transform.position = firstPosition;
    }


    public string getTime()
    {
        TimeSpan ts = _stopwatch.Elapsed;
        return String.Format(String.Format("{0:00}:{1:00}.{2:00}",
            ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10));
    }

    public int getPoints()
    {
        return points;
    }

    private void hideButton(GameObject button)
    {
        MeshRenderer[] bu = button.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer rend in bu)
        {
            rend.enabled = false;
        }

        button.SetActive(false);
    }

    private void unHideButton(GameObject button)
    {
        button.SetActive(true);
        MeshRenderer[] mrC = button.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer rend in mrC)
        {
            rend.enabled = true;
        }
    }

    public void addPoint()
    {
        points++;
    }
}