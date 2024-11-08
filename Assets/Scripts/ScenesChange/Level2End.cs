using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2End : MonoBehaviour
{
    public GameObject enemy;
    public GameManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy == null)
        {
            gameManager.gameOver("Thank you\nMy Powerful Stomach");
        }
    }
}
