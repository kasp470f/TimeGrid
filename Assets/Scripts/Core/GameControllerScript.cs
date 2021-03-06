using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public Text startDisplay;
    public bool start = false;

    public void Start()
    {
        startDisplay.gameObject.SetActive(true);
    }

    public void Update()
    {
        if(!start)
        {
            if(Input.touchCount == 1 || Input.GetMouseButtonDown(0))
            {
                startDisplay.gameObject.SetActive(false);
                start = true;
            }
        }
    }
}
