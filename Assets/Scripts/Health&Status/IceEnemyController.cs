using System.Collections;
using UnityEngine;

public class IceEnemyController : HealthController
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BulletBase bullet = collision.gameObject.GetComponent<BulletBase>();
        if (bullet != null)
        {
            if (bullet.foodType == BulletBase.FoodType.Fire)
            {
                EatBullets(bullet.calories);
                Destroy(collision.gameObject);
            }
            else
            {
                Debug.Log("IceEnemy ignores " + bullet.foodType + " bullets!");
            }
        }
    }
}
