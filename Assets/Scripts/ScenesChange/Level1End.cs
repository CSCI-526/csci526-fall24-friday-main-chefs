using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1End : MonoBehaviour
{
    public GameManagerScript gameManager;
    public TimeManagerScript timeManager;
    // Start is called before the first frame update
    void Start()
    {
        timeManager = FindObjectOfType<TimeManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected");
        timeManager.StopTimer();
        gameManager.gameOver("You Win!");
    }
}
