using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5End : MonoBehaviour
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
        //Debug.Log("Collision detected");
        if (collision.gameObject.tag == "Player")
        {
            gameManager.gameOver("Just as planned¡­ \nThis is my escape route!");
        }        
    }
}
