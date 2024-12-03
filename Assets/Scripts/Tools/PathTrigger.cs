using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTrigger : MonoBehaviour
{
    public static List<string> pathList = new List<string>();
    public string trigger_name;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Try to get the MovementController component from the colliding object
        if (other.gameObject.CompareTag("Player"))
        {
            pathList.Add(trigger_name);
        }
    }
}
