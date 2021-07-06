using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;

    public void DisplayScore()
    {
        scoreDisplay.gameObject.SetActive(true);
        scoreDisplay.text = $"Score: {score}";
    }
}
