using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntranceManager : MonoBehaviour
{
    private BoxCollider2D bc;
    private GameObject player;
    private GameObject[] enemies;
    private EnemyMovement[] enemiesMovement;
    private ShootController playerShootCtrl;
    private ShootController[] enemiesShootCtrl;

    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        bc.isTrigger = true;
        player = GameObject.Find("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        playerShootCtrl = player.GetComponent<ShootController>();
        enemiesMovement = enemies.Select(enemy => enemy.GetComponent<EnemyMovement>()).ToArray();
        enemiesShootCtrl = enemies.Select(enemy => enemy.GetComponent<ShootController>()).ToArray();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ResetShootAndMovement(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ResetShootAndMovement(true);
        }
    }

    private void ResetShootAndMovement(bool enable)
    {
        playerShootCtrl.enabled = enable;
        foreach (ShootController enemyShootCtrl in enemiesShootCtrl)
        {
            if (enemyShootCtrl == null)
            {
                continue;
            }
            else
            {
                enemyShootCtrl.enabled = enable;
            }
        }
        foreach (EnemyMovement enemyMovement in enemiesMovement)
        {
            if (enemyMovement == null)
            {
                continue;
            }
            else
            {
                enemyMovement.enabled = enable;
            }
        }
    }
}
