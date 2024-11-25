using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceEnemyCollisionHandler : MonoBehaviour
{
    private IceEnemyController iceEnemyController;

    void Awake()
    {
        iceEnemyController = GetComponent<IceEnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletBase bullet = collision.gameObject.GetComponent<BulletBase>();
        if (bullet != null)
        {
            if (bullet.foodType == BulletBase.FoodType.Fire)
            {
                iceEnemyController.EatBullets(bullet.calories);
                Destroy(collision.gameObject); 
            }
            else
            {
                Debug.Log("IceEnemy ignores " + bullet.foodType + " bullets!");
            }
        }
    }
}
