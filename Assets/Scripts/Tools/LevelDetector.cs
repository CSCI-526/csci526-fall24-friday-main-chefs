using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDetector : MonoBehaviour
{
    public int level;
    private int temp;
    private bool isLog;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!isLog)
            {
                isLog = true;
                ObstacleLogManager.levelDict[Fork.level] = Fork.touchTimes;
                ObstacleLogManager.levelDict[PoisonNeedle.level] = PoisonNeedle.touchTimes;
                Fork.touchTimes = 0;
                PoisonNeedle.touchTimes = 0;

                temp = level - 1;
                Fork.level = Fork.level.Replace(temp.ToString(), level.ToString());
                PoisonNeedle.level = PoisonNeedle.level.Replace(temp.ToString(), level.ToString());
            }
        }
    }
}
