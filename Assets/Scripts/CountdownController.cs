using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public float countdownTimer;
    private float seconds;
    private float miliseconds;
    public Text countdownDisplay;
    public bool gameover;

    private void Start()
    {
        string[] temp = TimeSpan.FromMilliseconds(countdownTimer).TotalSeconds.ToString().Split('.');
        if(temp.Length > 2)
        {
            seconds = float.Parse(temp[0]);
            miliseconds = (float)TimeSpan.FromSeconds(float.Parse($"0.{temp[1]}")).TotalMilliseconds;
        }
        else seconds = float.Parse(temp[0]);
    }


    private void Update()
    {
        if (gameObject.GetComponent<GameControllerScript>().start)
        {
            countdownDisplay.gameObject.SetActive(true);
            if (gameover == false)
            {
                if (miliseconds <= 0)
                {
                    seconds--;
                    miliseconds = 100;
                }

                miliseconds -= Time.deltaTime * 100;
            }

            if (seconds <= 0 && miliseconds <= 0) gameover = true;
            if (gameover)
            {
                countdownDisplay.text = string.Format("GAME OVER");
                gameObject.GetComponent<ScoreScript>().DisplayScore();
            }
            else countdownDisplay.text = string.Format("{0}s {1}ms", seconds.ToString().PadLeft(2, '0'), Mathf.Round(miliseconds).ToString().PadLeft(2, '0'));


            if (gameover == true && Input.touchCount == 1) gameObject.GetComponent<Restart>().ResetGame();
        }
    }

    public void AddTime(float addedTime)
    {
        seconds += addedTime;
    }
}
