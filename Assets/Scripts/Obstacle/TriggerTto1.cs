using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTto1 : MonoBehaviour
{
    public GameObject gate;
    public GameObject enemy1;
    public GameObject enemy2;

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
        if (collision.gameObject.tag == "Player")
        {
            // enable the scripts of enemies in section 1
            if (enemy1 != null)
            {
                enemy1.GetComponent<ShootController>().enabled = true;
            }
            if (enemy2 != null)
            {
                enemy2.GetComponent<ShootController>().enabled = true;
            }

            // close the gate and disble the trigger
            gate.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
