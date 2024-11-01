using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureTile : MonoBehaviour
{
    // Start is called before the first frame update
    public DoorHandler door; 
    public bool isSteppedOn ; 
    private SpriteRenderer spriteRenderer; 

    void Start()
    {
        //Setting initial color of the tile to red , we can change that anytime.
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Check if the player steps on the tile
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerSprite")) 
        {
            isSteppedOn = true;
            door.OpenDoor(); // Call the door's open method
            spriteRenderer.color = Color.green; // Change color to green when activated
            Debug.Log("Pressure tile activated, door opening.");
        }
    }

    // Check if the player leaves the tile
   /* private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayerSprite")) 
        {
            isSteppedOn = false;
            door.CloseDoor(); // Call the door's close method
            spriteRenderer.color = Color.red; // Change color back to red when deactivated
            Debug.Log("Pressure tile deactivated, door closing.");
        }
    }*/

}
