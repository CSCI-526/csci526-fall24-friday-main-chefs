using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryController : MonoBehaviour
{
    public GameObject enemy;

    private GameObject enemyInScene = null;
    private bool generateEnemy = false;
    private float enemyRespawnTime = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(generateEnemy)
        {
            if (enemyInScene == null)
            {
                if (enemyRespawnTime > 3f)
                {
                    enemyInScene = Instantiate(enemy, new Vector2(75, 1), Quaternion.identity);
                    enemyInScene.SetActive(true);
                    enemyRespawnTime = 0f;
                }
                else
                {
                    enemyRespawnTime += Time.deltaTime;
                }
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            generateEnemy = true;
            enemyInScene = Instantiate(enemy, new Vector2(75, 1), Quaternion.identity);
            enemyInScene.SetActive(true);
        }
        // stop detecting player
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
