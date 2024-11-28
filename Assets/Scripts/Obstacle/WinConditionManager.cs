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

    // 檢查是否滿足所有條件
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

    // 在同一個腳本中處理終點的碰撞檢測
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && hasTouchedFork && hasTouchedPoison)
        {
            gameManager.gameOver("You've completed the challenge!", true);
        }
    }
}