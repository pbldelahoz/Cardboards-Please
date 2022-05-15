using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameController _gameController;
    [SerializeField] private TextMeshProUGUI _text;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "" + _gameController.getPoints().ToString();
    }
}