using System.Collections.Generic;
using UnityEngine;

public class SwapTileMap : MonoBehaviour
{
    public GameObject gameController;
    private List<GameObject > tilemaps = new List<GameObject>();

    private void Start()
    {
        foreach (Transform child in transform)
        {
           if(child.name.Contains("Tilemap_Floor")) tilemaps.Add(child.gameObject);
        }
    }

    public void SwapMap(int level) 
    {
        foreach (GameObject child in tilemaps) child.SetActive(false);

        if (level >= 0 && level <= 15) tilemaps[0].SetActive(true);
        else if (level >= 16) tilemaps[1].SetActive(true);
    }
}
