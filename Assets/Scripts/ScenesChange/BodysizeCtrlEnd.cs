using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodysizeCtrlEnd : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerSprite")
        {
            gameManager.gameOver("Shed some fat and dive into the cave!", true);
        }
    }
}