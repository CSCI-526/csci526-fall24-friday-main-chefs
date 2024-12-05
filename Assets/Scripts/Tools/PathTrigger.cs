using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTrigger : MonoBehaviour
{
    public static Dictionary<string, int> pathDict = new Dictionary<string, int>();
    public string trigger_name;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Try to get the MovementController component from the colliding object
        if (other.gameObject.CompareTag("Player"))
        {
            if (!pathDict.ContainsKey(trigger_name))
            {
                pathDict[trigger_name] = 1;
            }
            else
            {
                pathDict[trigger_name] += 1;
            }
        }
    }

    public static List<string> GetAllTriggerNames()
    {
        List<string> triggerNames = new List<string>();
        
        GameObject pathTriggersObject = GameObject.Find("PathTriggers");
        
        if (pathTriggersObject != null)
        {
            // Method 1: Using transform to get child objects directly
            for (int i = 0; i < pathTriggersObject.transform.childCount; i++)
            {
                Transform child = pathTriggersObject.transform.GetChild(i);
                // Get PathTrigger script from each child object
                PathTrigger trigger = child.GetComponent<PathTrigger>();
                if (trigger != null)
                {
                    triggerNames.Add(trigger.trigger_name);
                }
            }
        }
        else
        {
            Debug.LogWarning("PathTriggers object not found");
        }
        
        return triggerNames;
    }
}
