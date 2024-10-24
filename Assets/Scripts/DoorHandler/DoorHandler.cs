using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    public bool locked ; 
    // Start is called before the first frame update
    void Start()
    {
        locked = true ; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Key"))
        {
            locked = false ; 
            gameObject.SetActive(false);
        }
    }
    /*
    this is function if we want to lock the door again after player has passed
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Key"))
        {
            locked = true ; 
        }
    }*/
}
