using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region Data

    [SerializeField] private Canvas _canvas;
    [SerializeField] private Image creditsImage;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        creditsImage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void buttonShowCredits()
    {
        creditsImage.enabled = true;
        print("aaaaaaaaaaaaaaaasd");
    }

    public void buttonQuitToMenu()
    {
    }

    public void buttonQuit()
    {
        Application.Quit();
    }

    public void playButton()
    {
        creditsImage.enabled = false;
        //screen shows loading
        //buttons dissapear except for quit
        //game starts
    }
}