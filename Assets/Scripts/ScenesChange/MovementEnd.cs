using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnd : MonoBehaviour
{
    public GameManagerScript gameManager;
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
        gameManager.gameOver("\"Take the first step.\"");
    }
}
