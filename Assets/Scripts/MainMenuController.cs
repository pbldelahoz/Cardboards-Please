using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    #region Data

    [SerializeField] private Canvas _canvas;
    [SerializeField] private Image creditsImage;
    [SerializeField] private GameObject creditsButton;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject spawnBoxButton;
    [SerializeField] private GameController _gameController;


    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI countText;


    private bool inGame = false;


    [SerializeField] private List<GameObject> disableObjects = new List<GameObject>();
    [SerializeField] private GameObject destroyableObjects;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        hideText(countText);
        hideText(timeText);
        creditsImage.enabled = false;
        disableDisableObjects();
        hideButton(spawnBoxButton);
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void buttonShowCreditsAction()
    {
        creditsImage.enabled = true;
        hideText(titleText);
        hideText(timeText);
        hideText(countText);
    }

    public void buttonQuitAction()
    {
        if (inGame)
        {
            _gameController.goToMenu();

            unHideButton(playButton);
            unHideButton(creditsButton);

            creditsImage.enabled = false;
            hideText(countText);
            hideText(timeText);
            showText(titleText);

            disableDisableObjects();
            destroyObjects();

            inGame = false;
        }
        else
        {
            Application.Quit();
        }
    }

    public void playButtonAction()
    {
        creditsImage.enabled = false;

        hideButton(playButton);
        hideButton(creditsButton);

        enableDisableObjects();

        inGame = true;
        showText(timeText);
        showText(countText);
        hideText(titleText);
        _gameController.blackFade();
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

    private void destroyObjects()
    {
        for (int i = 0; i < destroyableObjects.transform.childCount; i++)
        {
            Destroy(destroyableObjects.transform.GetChild(i).gameObject);
        }
    }

    private void enableDisableObjects()
    {
        foreach (GameObject obj in disableObjects)
        {
            obj.gameObject.SetActive(true);
            MeshRenderer[] disable = obj.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer rend in disable)
            {
                rend.enabled = true;
            }
        }
    }

    private void disableDisableObjects()
    {
        foreach (GameObject obj in disableObjects)
        {
            MeshRenderer[] disable = obj.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer rend in disable)
            {
                rend.enabled = false;
            }

            obj.gameObject.SetActive(false);
        }
    }

    private void showText(TextMeshProUGUI text)
    {
        text.enabled = true;
    }

    private void hideText(TextMeshProUGUI text)
    {
        text.enabled = false;
    }
}