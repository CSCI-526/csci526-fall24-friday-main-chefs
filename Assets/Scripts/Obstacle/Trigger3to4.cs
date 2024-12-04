using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger3to4 : MonoBehaviour
{
    public GameObject gate;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject iceEnemy;
    public GameObject s3Enemy1;
    public GameObject s3Enemy2;
    public GameObject s3Enemy3;
    public GameObject s3FireEnemy;

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
            // disable the scripts of enemies in section 3
            if (s3Enemy1 != null)
            {
                s3Enemy1.GetComponent<ShootController>().enabled = false;
            }
            if (s3Enemy2 != null)
            {
                s3Enemy2.GetComponent<ShootController>().enabled = false;
            }
            if (s3Enemy3 != null)
            {
                s3Enemy3.GetComponent<ShootController>().enabled = false;
            }
            if (s3FireEnemy != null)
            {
                s3FireEnemy.GetComponent<ShootController>().enabled = false;
            }

            // enable the scripts of enemies in section 4
            if (enemy1 != null)
            {
                enemy1.GetComponent<ShootController>().enabled = true;
            }
            if (enemy2 != null)
            {
                enemy2.GetComponent<ShootController>().enabled = true;
            }
            if (iceEnemy != null)
            {
                iceEnemy.GetComponent<ShootController>().enabled = true;
            }

            // close the gate and disable the trigger
            gate.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
