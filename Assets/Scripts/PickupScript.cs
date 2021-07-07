using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupScript : MonoBehaviour
{
    public GameObject gameController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        SoundControllerScript.PlaySound("pickup");
        gameController.GetComponent<ScoreScript>().score++;
        gameController.GetComponent<CountdownController>().AddTime(2f);
        gameController.GetComponent<SpawnScript>().SpawnBlock();
    }
}
