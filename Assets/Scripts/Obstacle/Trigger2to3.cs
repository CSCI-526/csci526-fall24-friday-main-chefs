using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger2to3 : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject fireEnemy;
    public GameObject s2IceEnemy;
    public GameObject s2SodaEnemy;
    public GameObject s2MentoEnemy;

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
        if (collision.gameObject.CompareTag("Player"))
        {
            // disable the scripts of enemies in section 2
            if (s2IceEnemy != null)
            {
                s2IceEnemy.GetComponent<EnemyMovement>().enabled = false;
                s2IceEnemy.GetComponent<ShootController>().enabled = false;
            }
            if (s2SodaEnemy != null)
            {
                s2SodaEnemy.GetComponent<ShootController>().enabled = false;
                s2SodaEnemy.GetComponent<EnemyMovement>().enabled = false;
            }
            if (s2MentoEnemy != null)
            {
                s2MentoEnemy.GetComponent<ShootController>().enabled = false;
                s2MentoEnemy.GetComponent<EnemyMovement>().enabled = false;
            }

            // enable the scripts of enemies in section 3
            if (enemy1 != null)
            {
                enemy1.GetComponent<ShootController>().enabled = true;
            }
            if (enemy2 != null)
            {
                enemy2.GetComponent<ShootController>().enabled = true;
            }
            if (enemy3 != null)
            {
                enemy3.GetComponent<ShootController>().enabled = true;
            }
            if (fireEnemy != null)
            {
                fireEnemy.GetComponent<ShootController>().enabled = true;
            }

            // disble the trigger
            this.gameObject.SetActive(false);
        }
    }
}
