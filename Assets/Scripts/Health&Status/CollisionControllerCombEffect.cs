using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControllerCombEffect : MonoBehaviour
{
    private HealthController healthController ;
    private StatusControllerCombEffect statusController;

    void Awake()
    {
        healthController = GetComponent<HealthController>();
        statusController = GetComponent<StatusControllerCombEffect>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the object collides with an enemy or player, apply damage accordingly
        if (collision.gameObject.tag == "Enemy" && healthController.isPlayer)
        {
            healthController.EatBullets(collision.gameObject.GetComponent<BulletBase>().calories);
            statusController.SetStatusCounter(collision.gameObject.GetComponent<BulletBase>().foodType, 5);
        }
        else if (collision.gameObject.tag == "Player" && !healthController.isPlayer)
        { 
            healthController.EatBullets(collision.gameObject.GetComponent<BulletBase>().calories);
            statusController.SetStatusCounter(collision.gameObject.GetComponent<BulletBase>().foodType, 5);
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
