using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{
    public int level;
    public Text levelDisplay;
    public GameObject TileMapGrid;

    private void Update()
    {
        if (gameObject.GetComponent<GameControllerScript>().start == true)
        {
            levelDisplay.gameObject.SetActive(true);
            levelDisplay.text = $"Level: {level}";
        }

        TileMapGrid.GetComponent<SwapTileMap>().SwapMap(level);
    }
}
