using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemyCollisionHandler : MonoBehaviour
{
    private FireEnemyController fireEnemyController;

    void Awake()
    {
        fireEnemyController = GetComponent<FireEnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletBase bullet = collision.gameObject.GetComponent<BulletBase>();
        if (bullet != null)
        {
            if (bullet.foodType == BulletBase.FoodType.Ice)
            {
                fireEnemyController.EatBullets(bullet.calories);
                Destroy(collision.gameObject); 
            }
            else
            {
                Debug.Log("FireEnemy ignores " + bullet.foodType + " bullets!");
            }
        }
    }
}
