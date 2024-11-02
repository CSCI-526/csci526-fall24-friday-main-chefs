using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public GameManagerScript gameManager;
    public LogManagerScript logManager;
    public TimeManagerScript timeManager;
    public string sceneName;
    private bool isLog;

    // Start is called before the first frame update
    void Start()
    {
        sceneName = gameObject.scene.name;
        isLog = false;
        logManager = FindObjectOfType<LogManagerScript>();
        timeManager = FindObjectOfType<TimeManagerScript>();
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
                timeManager.StopTimer();
                if (sceneName == "Level5")
                {
                    timeManager.ExternalUpload(TimeManagerScript.timeDict);
                }
                isLog = true;
            }
            gameManager.gameOver("You Win!");
        }
    }
}
