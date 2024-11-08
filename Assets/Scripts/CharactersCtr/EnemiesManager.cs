using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public GameManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // If there are no enemies children, the player wins
        if (transform.childCount == 0)
        {
            gameManager.gameOver("Please don't eat Mentos\n While drinking Coke\n (For Human)");
        }
    }
}
