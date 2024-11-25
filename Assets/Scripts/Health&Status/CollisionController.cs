using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private HealthController healthController ;
    private StatusController statusController;

    void Awake()
    {
        healthController = GetComponent<HealthController>();
        statusController = GetComponent<StatusController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object collides with an enemy or player, apply damage accordingly
        if (collision.gameObject.tag == "EnemyBullet" && healthController.isPlayer)
        {
            healthController.EatBullets(collision.gameObject.GetComponent<BulletBase>().calories);
            statusController.SetStatusCounter(collision.gameObject.GetComponent<BulletBase>().foodType, 5);
            Debug.Log("Get hit by enemy");

        }
        else if (collision.gameObject.tag == "PlayerBullet" && !healthController.isPlayer)
        { 
            healthController.EatBullets(collision.gameObject.GetComponent<BulletBase>().calories);
            statusController.SetStatusCounter(collision.gameObject.GetComponent<BulletBase>().foodType, 5);
            Debug.Log("Get hit by player");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
