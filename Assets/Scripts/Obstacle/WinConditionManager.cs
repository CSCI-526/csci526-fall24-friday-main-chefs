using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionManager : MonoBehaviour
{
    public GameManagerScript gameManager;
    public TimeLogManager timeLogManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected");
        gameManager.gameOver("\"You've completed the challenge!\"");

        if (this.gameObject.scene.name.Equals("Level4"))
        {
            timeLogManager.StopTimer();
            timeLogManager.ExternalUpload(TimeLogManager.timeDict);
        }
    }
}
