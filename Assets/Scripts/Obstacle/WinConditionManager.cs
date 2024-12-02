using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionManager : MonoBehaviour
{
    public bool hasTouchedFork = false;
    public bool hasTouchedPoison = false;
    public GameObject endPoint;
    public GameManagerScript gameManager;
    
    private SpriteRenderer endPointRenderer;

    void Start()
    {
        endPointRenderer = endPoint.GetComponent<SpriteRenderer>();
        endPointRenderer.color = Color.red;
    }

    public void CheckWinCondition()
    {
        if(hasTouchedFork && hasTouchedPoison)
        {
            endPointRenderer.color = Color.green;
        }
    }

    public void TouchedFork()
    {
        hasTouchedFork = true;
        CheckWinCondition();
    }

    public void TouchedPoison()
    {
        hasTouchedPoison = true;
        CheckWinCondition();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && hasTouchedFork && hasTouchedPoison)
        {
            gameManager.gameOver("You've completed the challenge!", true);
        }
    }
}