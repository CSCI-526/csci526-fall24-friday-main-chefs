using System.Collections;
using UnityEngine;

public class FireEnemyController : HealthController
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BulletBase bullet = collision.gameObject.GetComponent<BulletBase>();
        if (bullet != null)
        {
            if (bullet.foodType == BulletBase.FoodType.Ice)
            {
                EatBullets(bullet.calories);
                Destroy(collision.gameObject);
            }
            else
            {
                Debug.Log("FireEnemy ignores " + bullet.foodType + " bullets!");
            }
        }
    }
}
