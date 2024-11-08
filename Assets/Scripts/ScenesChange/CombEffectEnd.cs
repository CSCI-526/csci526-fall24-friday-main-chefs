using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombEffectEnd : MonoBehaviour
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
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Player")
        {
            gameManager.gameOver("Don't eat Mentos while drinking Coke!\n (As a human)", true);
        }
    }
}
