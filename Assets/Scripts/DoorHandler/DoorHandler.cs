using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public bool isOpen = false; // To track door's state

    // Method to open the door
    public void OpenDoor()
    {
        if (!isOpen)
        {
            gameObject.SetActive(false); // Make the door disappear (open)
            isOpen = true;
            Debug.Log("Door opened!");
        }
    }

    // Method to close the door
    public void CloseDoor()
    {
        if (isOpen)
        {
            gameObject.SetActive(true); // Make the door visible (closed)
            isOpen = false;
            Debug.Log("Door closed!");
        }
    }
}