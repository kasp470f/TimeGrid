using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBasedMovementMobile : MonoBehaviour
{
    public float moveSpeed;
    public LayerMask solidObjectLayer;
    public ParticleSystem dustSystem;
    private bool isMoving;
    public GameObject gameController;


    private void Update()
    {
        if (!gameController.GetComponent<CountdownController>().gameover && gameController.GetComponent<GameControllerScript>().start)
        {
            if(Input.touchCount > 0)
            {
                if (!isMoving)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Began)
                    {
                        var targetPos = transform.position;

                        if (touch.position.y < Screen.height - Screen.height / 6) // So not hit top screen
                        {
                            if (touch.position.y > Screen.height - Screen.height / 2.5) // Top
                            {
                                targetPos += new Vector3(0f, 1f);
                            }
                            else if (touch.position.y < Screen.height / 5) // Bottom
                            {
                                targetPos += new Vector3(0f, -1f);
                            }
                            else if (touch.position.x < Screen.width / 2) // Left
                            {
                                targetPos += new Vector3(-1f, 0f);
                            }
                            else if (touch.position.x > Screen.width / 2) // Right
                            {
                                targetPos += new Vector3(1f, 0f);
                            }
                        }

                        if (IsWalkable(targetPos)) StartCoroutine(Move(targetPos));
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
