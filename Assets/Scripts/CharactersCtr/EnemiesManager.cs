using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public GameManagerScript gameManager;
    public LogManagerScript logManager;
    private bool isLog;

    // Start is called before the first frame update
    void Start()
    {
        isLog = false;
        logManager = FindObjectOfType<LogManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // If there are no enemies children, the player wins
        if (transform.childCount == 0)
        {
            if (!isLog)
            {
                Debug.Log("Start to upload log data");
                logManager.ExternalUpload(BulletBase.counter, "Win");
                isLog = true;
            }
            gameManager.gameOver("You Win!");
        }
    }
}
