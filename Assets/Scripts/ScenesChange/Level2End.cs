using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2End : MonoBehaviour
{
    public GameObject enemy;
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
        if(enemy == null)
        {
            timeManager.StopTimer();
            gameManager.gameOver("You Win!");
        }
    }
}
