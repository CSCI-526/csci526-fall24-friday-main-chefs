using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial1End : MonoBehaviour
{
    public GameManagerScript gameManager;
    public TimeLogManager timeLogManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            timeLogManager.StopTimer();
            gameManager.gameOver("Energy management keeps you alive.", true);
        }
    }
}
