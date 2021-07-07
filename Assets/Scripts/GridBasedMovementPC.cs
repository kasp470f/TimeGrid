using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBasedMovementPC : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectLayer;
    public ParticleSystem dustSystem;
    private bool isMoving;
    private Vector2 input;
    public GameObject gameController;


    private void Update()
    {
        if (!gameController.GetComponent<CountdownController>().gameover)
        {
            if (!isMoving)
            {
                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");

                if (input.x != 0) input.y = 0;

                if (input != Vector2.zero)
                {
                    var targetPos = transform.position;
                    targetPos.x += input.x;
                    targetPos.y += input.y;

                    if (IsWalkable(targetPos))
                    {
                        StartCoroutine(Move(targetPos));
                        SoundControllerScript.PlaySound("movement");
                    }
                }
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        CreateDust();
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.3f, solidObjectLayer) != null)
        {
            return false;
        }
        return true;
    }

    private void CreateDust()
    {
        dustSystem.Play();
    }
}

