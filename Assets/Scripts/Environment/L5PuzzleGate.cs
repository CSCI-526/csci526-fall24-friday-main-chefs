using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L5PuzzleGate : MonoBehaviour
{
    public GameObject upperGate;
    public GameObject lowerGate;
    public float upperPos;
    public float lowerPos;
    public bool gateOpen = false;
    public bool objectInside = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openGate()
    {
        Debug.Log("Opening gate");
        Debug.Log("Gate open: " + gateOpen);
        Debug.Log("Object inside: " + objectInside);
        if (!gateOpen && objectInside)
        {
            upperGate.transform.position = new Vector3(upperGate.transform.position.x, upperPos, upperGate.transform.position.z);
            lowerGate.transform.position = new Vector3(lowerGate.transform.position.x, lowerPos, lowerGate.transform.position.z);
            gateOpen = true;
        }        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Collision detected");
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("Player entered the gate");
            objectInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Collision detected");
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player exited the gate");
            objectInside = false;
        }
    }
    }
