using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;

    private void Update()
    {
        if (gameObject.GetComponent<GameControllerScript>().start == true)
        {
            scoreDisplay.gameObject.SetActive(true);
            scoreDisplay.text = $"Score: {score}";
        }
    }
}
