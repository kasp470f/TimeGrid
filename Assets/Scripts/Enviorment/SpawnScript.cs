using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject block;
    private void Start()
    {
        SpawnBlock();
    }

    public void SpawnBlock()
    {
        bool blockSpawned = false;
        while (!blockSpawned)
        {
            Vector3 blockPosition = new Vector3(Mathf.Round(Random.Range(-4f, 4f)) + 0.5f, Mathf.Round(Random.Range(-7f, 5f)) + 0.5f, 0f);
            if ((blockPosition - transform.position).magnitude < 3) continue;
            else
            {
                Instantiate(block, blockPosition, Quaternion.identity);
                blockSpawned = true;
            }
        }
    }
}
